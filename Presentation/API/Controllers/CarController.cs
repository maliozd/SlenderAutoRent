using Application.Features.Cars.Commands.UpdateCar;
using Application.Features.Cars.Queries.GetAllCars;
using Application.Features.Cars.Queries.GetAvailableCars;
using Application.Features.Cars.Queries.GetCarById;
using Application.Features.Cars.Queries.GetCarsByBrand;
using Application.Features.Cars.Queries.GetCarsPaged;
using Application.Features.Commands.Cars.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedFramework.Dtos.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = "User")]

        public async Task<IActionResult> Get([FromQuery] GetAllCarsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            var user = Request.HttpContext.User.Identity.Name;
            return Ok(response);
        }

        [HttpGet("GetPaged")]
        public async Task<IActionResult> GetPaged([FromQuery] GetCarsPagedQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetCarByIdQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }



        //toDo --> figure out how you use dynamicFilter

        //[HttpPost("GetListDynamic")]
        //public async Task<IActionResult> GetListDynamic([FromQuery] PaginationRequest paginationRequest, [FromBody] Dynamic? dynamic = null)
        //{
        //    GetCarsByDynamicQueryRequest request = new()
        //    {
        //        Dynamic = dynamic,
        //        PaginationRequest = paginationRequest
        //    };
        //    var response = await _mediator.Send(request);
        //    return Ok(response);
        //}





        [HttpGet("[action]")]
        public async Task<IActionResult> GetAvailableCars([FromRoute] GetAvailableCarsQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCarCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateCarCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]{brandId}")]
        public async Task<IActionResult> GetCarsPagedByBrand([FromRoute] int brandId, [FromQuery] PaginationRequest paginationRequest)
        {
            GetCarsPagedByBrandQueryRequest request = new()
            {
                BrandId = brandId,
                Pagination = paginationRequest
            };
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        // DELETE api/<CarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //TO DO --> ExceptionMiddleware
    }
}
