using Ecommerce.Application.Commands.Customers;
using Ecommerce.Application.Response;
using Ecommerce.Domain.Entities.Users;
using Ecommerce.Infra.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.Customers
{
    public class CustomerHandler : ICustomerHandler
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly AppDbContext _appContext;
        private readonly UserDbContext _userContext;

        public CustomerHandler(UserManager<CustomUser> userManager, AppDbContext context, UserDbContext userContext)
        {
            _userManager = userManager;
            _appContext = context;
            _userContext = userContext;
        }

        public async Task<ResponseApi> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            CustomUser newUser = new()
            {
                Name = request.Name,
                Email = request.Email,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber
            };

            // Verifica se o e-mail já existe
            var user = await _userManager.FindByEmailAsync(newUser.UserName);
            if (user is not null)
                return new ResponseApi(false, "E-mail existente.");

            var identityUser = await _userManager.CreateAsync(newUser, request.Password);

            if (!identityUser.Succeeded)
                return new ResponseApi(false, "Não foi possível cadastrar o usuário!");

            // Adiciona a role ao usuário
            var resultRole = await _userManager.AddToRoleAsync(newUser, "User");

            if (!resultRole.Succeeded)
                return new ResponseApi(false, "Não foi possível adicionar a role ao usuário!");

            // Acrescenta as informações adicionais do usuário
            try
            {
                Address address = new()
                {
                    Street = request.Street,
                    City = request.City,
                    Number = request.Number,
                    State = request.State,
                    Complement = request.Complement,
                    CEP = request.CEP
                };

                _userContext.Addresses.Add(address);
                _userContext.SaveChanges();

                CustomerInfo customerInfo = new()
                {
                    UserId = newUser.Id,
                    CPF = request.CPF,
                    Gender = request.Gender,
                    Address = address
                };

                _userContext.CustomerInfos.Add(customerInfo);
                _userContext.SaveChanges();
            
            } catch (Exception ex)
            {
                return new ResponseApi(true, "Não foi possível cadastrar as informações e endereço: " + ex.Message);
            }

            return new ResponseApi(true, "Usuário cadastrado com sucesso!");
        }
    }
}
