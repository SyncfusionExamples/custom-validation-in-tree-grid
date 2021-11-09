using System;
using System.ComponentModel.DataAnnotations;

namespace Custom_Validation.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class Tree
    {
        [Required(ErrorMessage = "Task ID  should not be empty")]
        public int? TaskId { get; set; }

        [Required(ErrorMessage = "Task Name  should not be empty")]
        public string TaskName { get; set; }

        public string Priority { get; set; }

        public int? Duration { get; set; }
        public int? ParentId { get; set; }

    }
}
