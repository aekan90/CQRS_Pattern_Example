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
    public class GetAllProductQueryHandler
    {
        public List<GetAllProductQueryResponse> GetAllProduct(GetAllProductQueryRequest getAllProductQueryRequest)
        {
            return CQRSDbContext.ProductList.Select(product => new GetAllProductQueryResponse
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = product.Quantity,
                CreateTime = product.CreateTime
            }).ToList();
        }
    }
}
