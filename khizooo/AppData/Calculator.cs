
using System.Text.Json;

namespace khizooo.AppData
{

    public class Calculator
    {
        public string Slug { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Count { get; set; }
    }

public class MyCalculators
    {

        private List<Calculator> MyAllCalculators = new List<Calculator>()
        {
            new Calculator() { Slug = "finance-calculator", Title = "Finance Calculator", Description = "Calculate finance related calculations with ease." },
            new Calculator() { Slug = "math-calculator", Title = "Math Calculator", Description = "Calculate math related calculations with ease." },
            new Calculator() { Slug = "everyday-life-calculator", Title = "Everyday Life Calculator", Description = "Calculate everyday life related calculations with ease." },
            new Calculator() { Slug = "biology-calculator", Title = "Biology Calculator", Description = "Calculate biology related calculations with ease." },
            new Calculator() { Slug = "chemistry-calculator", Title = "Chemistry Calculator", Description = "Calculate chemistry related calculations with ease." },
            new Calculator() { Slug = "physics-calculator", Title = "Physics Calculator", Description = "Calculate physics related calculations with ease." },
            new Calculator() { Slug = "color-tools", Title = "Color Tools", Description = "From color palettes to color shades, we have you covered." },
            new Calculator() { Slug = "health-calculator", Title = "Health Calculator", Description = "Calculate health related calculations with ease." },
            new Calculator() { Slug = "construction-calculator", Title = "Construction Calculator", Description = "Calculate construction related calculations with ease." },
            new Calculator() { Slug = "unit-conversion-calculator", Title = "Unit Conversion Calculator", Description = "Calculate conversion related calculations with ease." },
            new Calculator() { Slug = "food-calculator", Title = "Food Calculator", Description = "Calculate food related calculations with ease." },
            new Calculator() { Slug = "sports-calculator", Title = "Sports Calculator", Description = "Calculate sports related calculations with ease." },
            new Calculator() { Slug = "text-tools", Title = "Text Tools", Description = "Text analysis tools for word counting, unscrambling, and manipulation." },
            new Calculator() { Slug = "fun-calculator", Title = "Fun Calculator", Description = "Fun calculator for all your computation needs." },
            new Calculator() { Slug = "time-date", Title = "Time & Date", Description = "Calculate time and date related calculations with ease." },
            new Calculator() { Slug = "photography", Title = "Photography", Description = "Photography related calculations with ease." },
            new Calculator() { Slug = "crafting", Title = "Crafting", Description = "Crafting related calculations with ease." },
            new Calculator() { Slug = "automotive-calculator", Title = "Automotive Calculator", Description = "Automotive related calculations with ease." },
            new Calculator() { Slug = "travel-calculator", Title = "Travel Calculator", Description = "Travel related calculations with ease." }
        };


        public List<Calculator> GetMyCalculators(int Count)
        {
            List<Calculator> Data = new List<Calculator>();
            Data = MyAllCalculators.Take(Count).ToList();
            return Data;
        }

        public Calculator GetMyCalculator(string Slug)
        {
            Calculator Data = new Calculator();
            Data = MyAllCalculators.FirstOrDefault(A => A.Slug == Slug);
            return Data;
        }

    }

}