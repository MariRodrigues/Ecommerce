using Dapper;
using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Entities.Users;
using Ecommerce.Domain.Queries;
using Ecommerce.Infra.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Queries
{
    public class CustomerQueries : ICustomerQueries
    {
        public readonly SqlConnection _connection;

        public CustomerQueries(AppDbContext context)
        {
            _connection = new SqlConnection(context.Database.GetConnectionString());
        }

        public async Task<IEnumerable<CustomerViewModel>> GetUsers()
        {
            var query = @"SELECT 
                             u.[Id] as UserId
                              ,[Name]
                              ,[Status]
                              ,[UserName]      
                              ,[Email]
	                          ,ci.[CPF]
                              ,CASE 
                                    WHEN ci.[Gender] = 1 THEN 'Feminino'
                                    WHEN ci.[Gender] = 2 THEN 'Masculino'
                                    ELSE 'Desconhecido'
                                END as Gender
	                          ,a.Id as Address_AddressId
	                          ,a.[Street] as Address_Street
                              ,a.[Number] as Address_Number
                              ,a.[Complement] Address_Complement
                              ,a.[City] as Address_City
                              ,a.[State] as Address_State
                              ,a.[CEP] as Address_CEP
                              ,a.[Country] as Address_Country
                              ,a.[Observation] as Address_Observation
                              ,a.[ReceiverName] as Address_ReceiverName

                          FROM [Ecommerce].[dbo].[AspNetUsers] u

                          LEFT JOIN CustomerInfos ci ON ci.UserId = u.Id
                          LEFT JOIN Addresses a ON a.Id = ci.AddressId ";

            var result = await _connection.QueryAsync(query);

            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(CustomerViewModel), "UserId");
            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(AddressViewModel), "AddressId");

            return Slapper.AutoMapper.MapDynamic<CustomerViewModel>(result);
        }

        public async Task<CustomerViewModel> GetUserById(int userId)
        {
            var queryArgs = new DynamicParameters();
            queryArgs.Add("userId", userId);

            var query = @"SELECT 
                             u.[Id] as UserId
                              ,[Name]
                              ,[Status]
                              ,[UserName]      
                              ,[Email]
	                          ,ci.[CPF]
                              ,CASE 
                                    WHEN ci.[Gender] = 1 THEN 'Feminino'
                                    WHEN ci.[Gender] = 2 THEN 'Masculino'
                                    ELSE 'Desconhecido'
                                END as Gender
	                          ,a.Id as Address_AddressId
	                          ,a.[Street] as Address_Street
                              ,a.[Number] as Address_Number
                              ,a.[Complement] Address_Complement
                              ,a.[City] as Address_City
                              ,a.[State] as Address_State
                              ,a.[CEP] as Address_CEP
                              ,a.[Country] as Address_Country
                              ,a.[Observation] as Address_Observation
                              ,a.[ReceiverName] as Address_ReceiverName

                          FROM [Ecommerce].[dbo].[AspNetUsers] u

                          LEFT JOIN CustomerInfos ci ON ci.UserId = u.Id
                          LEFT JOIN Addresses a ON a.Id = ci.AddressId 

                          WHERE u.Id = @userId";

            var result = await _connection.QueryAsync(query, queryArgs);

            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(CustomerViewModel), "UserId");
            Slapper.AutoMapper.Configuration.AddIdentifier(typeof(AddressViewModel), "AddressId");

            return Slapper.AutoMapper.MapDynamic<CustomerViewModel>(result).FirstOrDefault();
        }
    }
}
