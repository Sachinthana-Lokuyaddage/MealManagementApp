using MealManagementApp.Client.Dtos;
using MealManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace MealManagementApp.Controllers
{
    [Route("api/employee-meals")]
    //[Route("api/[controller]")]
    [ApiController]
    public class EmployeeMealController : ControllerBase
    {
        private readonly EmployeeMealService _mealService;

        public EmployeeMealController(EmployeeMealService mealService)
        {
            _mealService = mealService;
        }

        //[HttpGet("search")]
        //public async Task<ActionResult<IEnumerable<EmployeeMealDto>>> SearchEmployeeMeals(DateTime date, string breakTime)
        //{
        //    var meals = await _mealService.GetMealsByDateAndBreakTimeAsync(date, breakTime);

        //    if (meals == null || !meals.Any())
        //    {
        //        return NotFound(new { message = "No meals found for the selected date and break time." });
        //    }

        //    return Ok(meals);

        //}

        [HttpGet("search")]
        public async Task<ActionResult<List<EmployeeMealDto>>> SearchEmployeeMeals(DateTime date, string breakTime)
        {
            // Check if the date and break time are valid
            if (date == default(DateTime))
            {
                return BadRequest(new { message = "Invalid date format." });
            }

            var meals = await _mealService.GetMealsByDateAndBreakTimeAsync(date, breakTime);

            if (meals == null || !meals.Any())
            {
                return NotFound(new { message = "No meals found for the selected date and break time." });
            }

            return Ok(meals);
        }





    }
}
