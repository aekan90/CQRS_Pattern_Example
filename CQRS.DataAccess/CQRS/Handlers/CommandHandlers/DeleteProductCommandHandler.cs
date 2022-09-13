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
    public class DeleteProductCommandHandler
    {

        public DeleteProductCommandResponse DeleteProduct(DeleteProductCommandRequest deleteProductCommandRequest)
        {
            var deleteProduct = CQRSDbContext.ProductList.FirstOrDefault(p => p.Id == deleteProductCommandRequest.Id);
            CQRSDbContext.ProductList.Remove(deleteProduct);
            return new DeleteProductCommandResponse
            {
                IsSuccess = true
            };
        }

    }
}
