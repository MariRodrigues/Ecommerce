using Ecommerce.Application.Commands.UserAdmin;
using Ecommerce.Application.Response;
using Ecommerce.Domain;
using Ecommerce.Domain.Entities.Users;
using Ecommerce.Infra.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.UserAdmin
{
    public class UserAdminHandler : IUserAdminHandler
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly AppDbContext _userContext;
        private readonly IUnitOfWork _uow;

        public UserAdminHandler(UserManager<CustomUser> userManager, AppDbContext userContext, IUnitOfWork uow)
        {
            _userManager = userManager;
            _userContext = userContext;
            _uow = uow;
        }

        public async Task<ResponseApi> Handle(CreateUserAdminCommand request, CancellationToken cancellationToken)
        {
            // Verifica se o e-mail já existe
            if (await _userManager.FindByEmailAsync(request.Email) is not null)
                return new ResponseApi(false, "E-mail existente.");

            // Verifica se o username já existe
            if (await _userManager.FindByNameAsync(request.UserName) is not null)
                return new ResponseApi(false, "Username existente.");

            CustomUser newUser = new(request.Name, request.Email, request.UserName, request.PhoneNumber);

            using (var transaction = _uow.BeginTransaction())
            {
                try
                {
                    var identityUser = await _userManager.CreateAsync(newUser, request.Password);

                    if (!identityUser.Succeeded)
                        return new ResponseApi(false, "Não foi possível cadastrar o usuário: " + identityUser?.Errors);

                    // Adiciona a role ao usuário
                    var resultRole = await _userManager.AddToRoleAsync(newUser, "Admin");

                    if (!resultRole.Succeeded)
                        return new ResponseApi(false, "Não foi possível adicionar a role ao usuário.");

                    _uow.Commit();
                }
                catch (Exception ex)
                {
                    _uow.RollbackTransaction();
                    return new ResponseApi(true, "Erro ao cadastrar usuário: " + ex.Message);
                }
            }
            return new ResponseApi(true, "Usuário cadastrado com sucesso!");
        }
    }
}
