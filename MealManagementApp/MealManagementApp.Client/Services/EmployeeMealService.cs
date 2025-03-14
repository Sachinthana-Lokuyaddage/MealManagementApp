using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using MealManagementApp.Client.Dtos;

namespace MealManagementApp.Client.Services
{
    public class EmployeeMealService
    {
        private readonly HttpClient _httpClient;

        public EmployeeMealService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EmployeeMealDto>> SearchMealsAsync(DateTime date, string breakTime)
        {
            var meals = await _httpClient.GetFromJsonAsync<List<EmployeeMealDto>>($"api/employee-meals/search?date={date:yyyy-MM-dd}&breakTime={breakTime}");
            return meals ?? new List<EmployeeMealDto>();
        }
    }
}
