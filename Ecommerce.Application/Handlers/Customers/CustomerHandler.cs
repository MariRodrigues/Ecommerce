using Ecommerce.Application.Commands.Customers;
using Ecommerce.Application.Response;
using Ecommerce.Domain;
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
        private readonly AppDbContext _userContext;
        private readonly IUnitOfWork _uow;

        public CustomerHandler(UserManager<CustomUser> userManager, AppDbContext userContext, IUnitOfWork uow)
        {
            _userManager = userManager;
            _userContext = userContext;
            _uow = uow;
        }

        public async Task<ResponseApi> Handle(CreateUserCommand request, CancellationToken cancellationToken)
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
                    var resultRole = await _userManager.AddToRoleAsync(newUser, "User");

                    if (!resultRole.Succeeded)
                        return new ResponseApi(false, "Não foi possível adicionar a role ao usuário.");

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.RollbackTransaction();
                    return new ResponseApi(true, "Erro ao cadastrar usuário: " + ex.Message);
                }
            }
            return new ResponseApi(true, "Usuário cadastrado com sucesso!");
        }

        public async Task<ResponseApi> Handle(CreateCustomerInfoCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            using (var transaction = _uow.BeginTransaction())
            {
                try
                {
                    Address address = new()
                    {
                        Street = request.Street,
                        City = request.City,
                        Number = request.Number,
                        State = request.State,
                        Complement = request.Complement,
                        CEP = request.CEP,
                        Country = request.Country,
                        Observation = request.Observation,
                        ReceiverName = request.ReceiverName
                    };
                    _userContext.Addresses.Add(address);

                    CustomerInfo customerInfo = new()
                    {
                        UserId = user.Id,
                        CPF = request.CPF,
                        Gender = request.Gender,
                        Address = address
                    };
                    _userContext.CustomerInfos.Add(customerInfo);

                    transaction.Commit();

                    // Atualiza ID na tabela
                    address.CustomerInfoId = customerInfo.Id;

                    _userContext.CustomerInfos.Update(customerInfo);
                    _userContext.SaveChanges();

                    user.CustomerInfoId = customerInfo.Id;
                    await _userManager.UpdateAsync(user);
                }
                catch (Exception ex)
                {
                    transaction.RollbackTransaction();
                    return new ResponseApi(true, "Erro ao cadastrar informações adicionais do usuário: " + ex.Message);
                }
            }
            return new ResponseApi(true, "Informações cadastradas com sucesso!");
        }
    }
}
