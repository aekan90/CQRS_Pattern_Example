using CQRS.DataAccess.CQRS.Commands.Request;
using CQRS.DataAccess.CQRS.Commands.Response;
using CQRS.DataAccess.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.DataAccess.CQRS.Handlers.CommandHandlers
{
    public class CreateProductCommandHandler
    {

        public CreateProductCommandResponse CreateProduct(CreateProductCommandRequest createProductCommandRequest)
        {
            var id = Guid.NewGuid();
            CQRSDbContext.ProductList.Add(new()
            {
                Id = id,
                Name = createProductCommandRequest.Name,
                Price = createProductCommandRequest.Price,
                Quantity = createProductCommandRequest.Quantity,
                CreateTime = DateTime.Now
            });
            return new CreateProductCommandResponse
            {
                IsSuccess = true,
                ProductId = id
            };
        }

    }
}
