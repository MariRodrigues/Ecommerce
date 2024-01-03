using Ecommerce.Application.Commands.Subcategories;
using Ecommerce.Application.Response;
using Ecommerce.Domain.Repositories;
using Ecommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ecommerce.Domain.Entities.Subcategories;

namespace Ecommerce.Application.Handlers.Subcategories
{
    public class SubcategoryHandler : ISubcategoryHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly ISubcategoryRepository _subcategoryRepository;
        private readonly ICategoryRepository _categoryRepository;

        public SubcategoryHandler(IUnitOfWork uow, ISubcategoryRepository subcategoryRepository, ICategoryRepository categoryRepository)
        {
            _uow = uow;
            _subcategoryRepository = subcategoryRepository;
            _categoryRepository = categoryRepository;
        }
        public async Task<ResponseApi> Handle(CreateSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.GetById(request.CategoryId);

            if (category == null)
                return new ResponseApi(false, "A categoria informada não existe");

            Subcategory subcategory = new(request.Name, request.CategoryId);

            using var scope = _uow.BeginTransaction();

            try
            {
                _subcategoryRepository.Include(subcategory);
            }
            catch (Exception ex)
            {
                scope.RollbackTransaction();
                return new ResponseApi(false, "Não foi possível cadastrar a subcategoria: " + ex.Message);
            }

            scope.Commit();

            return new ResponseApi(true, "Subcategoria cadastrada com sucesso.");
        }
    }
}
