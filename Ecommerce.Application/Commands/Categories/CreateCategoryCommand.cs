using Ecommerce.Application.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;


namespace Ecommerce.Application.Commands.Category
{
    public class CreateCategoryCommand : IRequest<ResponseApi>
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(30, ErrorMessage = "Nome excede os 30 caracteres máximos.")]
        public string Name { get; set; }
    }
}
