using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Custom_Validation.Data
{
    public class WeatherForecastService
    {
        public static List<Tree> list = new List<Tree>();

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        public List<Tree> GetTree()
        {
            if (list.Count == 0)
            {
                list.Add(new Tree() { TaskId = 1, TaskName = "Parent Task 1", Duration = 10, ParentId = null, Priority = "Low" });
                list.Add(new Tree() { TaskId = 2, TaskName = "Child task 1", Duration = 4, ParentId = 1, Priority = "Low" });
                list.Add(new Tree() { TaskId = 3, TaskName = "Child Task 2", Duration = 5, ParentId = 1, Priority = "Critical" });
                list.Add(new Tree() { TaskId = 4, TaskName = "Parent Task 2", Duration = 6, ParentId = null, Priority = "Low" });
                list.Add(new Tree() { TaskId = 5, TaskName = "Child Task 5", Duration = 9, ParentId = 4, Priority = "High" });
            }
            return list;
        }
    }
}
