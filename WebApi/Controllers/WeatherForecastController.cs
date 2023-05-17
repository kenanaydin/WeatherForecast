using Application.Features.ForecastFeatures.Commands;
using Application.Features.ForecastFeatures.Queries;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class WeatherForecastController : BaseApiController
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Creates new weather forecast record
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateForecastCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Returns all weather forecast records from database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllForecastsQuery()));
        }

        /// <summary>
        /// Gets forecast record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetForecastByIdQuery { Id = id }));
        }

        /// <summary>
        /// Gets weekly weather forecasts with a user friendly description based on temperature
        /// </summary>
        /// <param name="weekSelection"></param>
        /// <returns></returns>
        [HttpGet("{weekSelection}")]
        public async Task<IActionResult> GetByWeek(int weekSelection)
        {
            return Ok(await Mediator.Send(new GetForecastForWeekQuery { WeekSelection = weekSelection }));
        }

        /// <summary>
        /// Deletes weather forecast record by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteForecastByIdCommand { Id = id }));
        }

        /// <summary>
        /// Updates temperature value of a weather forecast record by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(int id, UpdateForecastCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}