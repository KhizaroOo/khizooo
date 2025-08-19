
namespace khizooo.AppData
{

    public class Converter
    {
        public string Slug { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Count { get; set; }
    }

    public class MyConverters
    {

        private List<Converter> MyAllConverters = new List<Converter>()
        {
            new Converter() { Slug = "angle-converter", Title = "Angle Converter", Description = "Convert between degrees, radians, gradians, and more." },
            new Converter() { Slug = "area-converter", Title = "Area Converter", Description = "Convert between square meters, acres, hectares, and more." },
            new Converter() { Slug = "data-storage-converter", Title = "Data Storage Converter", Description = "Convert between bytes, kilobytes, megabytes, gigabytes, etc." },
            new Converter() { Slug = "energy-converter", Title = "Energy Converter", Description = "Convert between joules, watt-hours, BTU, and more." },
            new Converter() { Slug = "force-converter", Title = "Force Converter", Description = "Convert between newtons, pound-force, kilogram-force, and more." },
            new Converter() { Slug = "length-converter", Title = "Length Converter", Description = "Convert between meters, feet, inches, kilometers, miles, and more." },
            new Converter() { Slug = "weight-converter", Title = "Weight Converter", Description = "Convert between kilograms, pounds, ounces, grams, and more." },
            new Converter() { Slug = "power-converter", Title = "Power Converter", Description = "Convert between watts, kilowatts, horsepower, etc." },
            new Converter() { Slug = "pressure-converter", Title = "Pressure Converter", Description = "Convert between pascals, bars, atmospheres, PSI, and more." },
            new Converter() { Slug = "temperature-converter", Title = "Temperature Converter", Description = "Convert between Celsius, Fahrenheit, Kelvin, etc." },
            new Converter() { Slug = "time-converter", Title = "Time Converter", Description = "Convert between seconds, minutes, hours, days, and more." },
            new Converter() { Slug = "volume-converter", Title = "Volume Converter", Description = "Convert between liters, gallons, cubic meters, fluid ounces, etc." }
        };

        public List<Converter> GetMyConverters(int Count)
        {
            List<Converter> Data = new List<Converter>();
            Data = MyAllConverters.Take(Count).ToList();
            return Data;
        }

        public Converter GetMyConverter(string Slug)
        {
            Converter Data = new Converter();
            Data = MyAllConverters.FirstOrDefault(A => A.Slug == Slug);
            return Data;
        }

    }

}