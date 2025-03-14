using Microsoft.EntityFrameworkCore;
using MealManagementApp.Client.Dtos;
using MealManagementApp.Data;

namespace MealManagementApp.Services
{
    public class EmployeeMealService
    {
        private readonly MealDbContext _context;

        public EmployeeMealService(MealDbContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeMealDto>> GetMealsByDateAndBreakTimeAsync(DateTime date, string breakTime)
        {
            var meals = await _context.EmployeeMeal
                .Where(m => m.CreatedDateTime.HasValue && m.CreatedDateTime.Value.Date == date.Date && m.BreakTime == breakTime)
                .ToListAsync();

            return meals.Select(m => new EmployeeMealDto
            {
                Id = m.Id,
                CreatedDateTime = (DateTime)m.CreatedDateTime,
                RFID = m.RFID,
                BreakTime = m.BreakTime,
                StationId = m.StationId
            }).ToList();

        }
    }
}
