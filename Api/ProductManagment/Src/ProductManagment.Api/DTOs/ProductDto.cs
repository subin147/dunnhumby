using FluentValidation;
using System.ComponentModel;

namespace ProductManagment.Api.DTOs
{

    public record ProductDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Category { get; set; } = null!;
        public  string Name { get; set; } = null!;
        public  string Code { get; set; } = null!;
        public  decimal Price { get; set; } 
        public  string SKU { get; set; } = null!;
        public int StockQuantity { get; set; }
        public DateTime DateAdded { get; set; }
    }

    /// <summary>
    /// Validator for input data
    /// </summary>
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(request => request.CategoryId)
                .NotNull().WithMessage("Category is required.");

            RuleFor(request => request.Name)
                .NotNull().WithMessage("Name is required.");

            RuleFor(request => request.Code)
                .NotNull().WithMessage("Code is required.");

            RuleFor(request => request.Price)
               .NotNull().WithMessage("Price is required.")
               .GreaterThan(0).WithMessage("Price can't be a negative number.");

            RuleFor(request => request.SKU)
               .NotNull().WithMessage("SKU is required.");

            RuleFor(request => request.StockQuantity)
               .NotNull().WithMessage("Stock quantity is required.")
               .GreaterThan(0).WithMessage("Stock quantity can't be a negative number.");

        }
    }
}
