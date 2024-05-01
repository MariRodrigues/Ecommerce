using Bogus;
using Ecommerce.Application.Commands.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Test.Ecommerce.UnitTests.Commons.Fakers
{
    public static class CreateCategoryCommandFaker
    {
        private static Faker<CreateCategoryCommand> CreateFaker() =>
            new Faker<CreateCategoryCommand>().RuleFor(category => category.Name, faker => faker.Company.CompanyName());

        public static CreateCategoryCommand Generate() => CreateFaker().Generate();
    }
}
