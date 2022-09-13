using CQRS.DataAccess.CQRS.Queries.Request;
using CQRS.DataAccess.CQRS.Queries.Response;
using CQRS.DataAccess.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.DataAccess.CQRS.Handlers.QueryHandlers
{
    public class GetByIdProductQueryHandler
    {
        public GetByIdProductQueryResponse GetByIdProduct(GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            var product = CQRSDbContext.ProductList.FirstOrDefault(p => p.Id == getByIdProductQueryRequest.Id);
            return new GetByIdProductQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            };
        }
    }
}
