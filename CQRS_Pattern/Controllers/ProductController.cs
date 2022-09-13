using CQRS.DataAccess.CQRS.Commands.Request;
using CQRS.DataAccess.CQRS.Commands.Response;
using CQRS.DataAccess.CQRS.Handlers.CommandHandlers;
using CQRS.DataAccess.CQRS.Handlers.QueryHandlers;
using CQRS.DataAccess.CQRS.Queries.Request;
using CQRS.DataAccess.CQRS.Queries.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        CreateProductCommandHandler _createProductCommandHandler;
        DeleteProductCommandHandler _deleteProductCommandHandler;
        GetAllProductQueryHandler _getAllProductQueryHandler;
        GetByIdProductQueryHandler _getByIdProductQueryHandler;
        public ProductController(
            CreateProductCommandHandler createProductCommandHandler,
            DeleteProductCommandHandler deleteProductCommandHandler,
            GetAllProductQueryHandler getAllProductQueryHandler,
            GetByIdProductQueryHandler getByIdProductQueryHandler)
        {
            _createProductCommandHandler = createProductCommandHandler;
            _deleteProductCommandHandler = deleteProductCommandHandler;
            _getAllProductQueryHandler = getAllProductQueryHandler;
            _getByIdProductQueryHandler = getByIdProductQueryHandler;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] GetAllProductQueryRequest requestModel)
        {
            List<GetAllProductQueryResponse> allProducts = _getAllProductQueryHandler.GetAllProduct(requestModel);
            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromQuery] GetByIdProductQueryRequest requestModel)
        {
            GetByIdProductQueryResponse product = _getByIdProductQueryHandler.GetByIdProduct(requestModel);
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateProductCommandRequest requestModel)
        {
            CreateProductCommandResponse response = _createProductCommandHandler.CreateProduct(requestModel);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery] DeleteProductCommandRequest requestModel)
        {
            DeleteProductCommandResponse response = _deleteProductCommandHandler.DeleteProduct(requestModel);
            return Ok(response);
        }
    }
}
