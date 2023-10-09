using Ecommerce.Application.Commands.Category;
using Ecommerce.Application.Response;
using Ecommerce.Domain;
using Ecommerce.Domain.Entities.Categories;
using Ecommerce.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Application.Handlers.Categories
{
    public class CategoryHandler : ICategoryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryHandler(IUnitOfWork uow, ICategoryRepository categoryRepository)
        {
            _uow = uow;
            _categoryRepository = categoryRepository;
        }

        public async Task<ResponseApi> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = new(request.Name);

            using var scope = _uow.BeginTransaction();

            try
            {
                _categoryRepository.Include(category);
            }
            catch (Exception ex)
            {
                scope.RollbackTransaction();
                return new ResponseApi(false, "Não foi possível cadastrar a categoria: " + ex.Message);
            }
            try
            {
                scope.Commit();
            } catch(Exception ex)
            {
                scope.RollbackTransaction();
                return new ResponseApi(false, "Não foi possível cadastrar a categoria: " + ex.Message);
            }
            

            return new ResponseApi(true, "Categoria cadastrada com sucesso.");
        }
    }
}
