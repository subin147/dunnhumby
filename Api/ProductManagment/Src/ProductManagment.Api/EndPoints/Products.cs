using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ProductManagment.Api.Data.Context;
using ProductManagment.Api.Data.Entities;
using ProductManagment.Api.DTOs;
using System;

namespace ProductManagment.Api.EndPoints
{
    public static class Products
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            app.MapPost("/products/register", async (IProductRepository repository, ProductDto product,IValidator<ProductDto> validator) =>
            {   
                var validationResult = await validator.ValidateAsync(product);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(validationResult.Errors);
                }

                var isSuccess=await repository.Add(product);
                return Results.Ok(new {IsSuccess=isSuccess,Message=$"Product '{product.Name}' added successfully."});
            });

            app.MapGet("/products", async (IProductRepository repository) =>
            {
                var products=await repository.GetAll();
                if (products == null)
                    return Results.Problem("An error occured while fetching products");
                return Results.Ok(products);
            });

        }
    }
}
