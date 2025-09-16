
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
        public string Live { get; internal set; }
        public bool IsCategory { get; internal set; }
    }

public class MyCalculators
    {

        private List<Calculator> MyAllCalculators = new List<Calculator>()
        {
            new Calculator()
            {
                Slug = "finance-calculators",
                Title = "Finance Calculators",
                Description = "Calculate finance related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-coins size-5\"><circle cx=\"8\" cy=\"8\" r=\"6\"></circle><path d=\"M18.09 10.37A6 6 0 1 1 10.34 18\"></path><path d=\"M7 6h1v4\"></path><path d=\"m16.71 13.88.7.71-2.82 2.82\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "math-calculators",
                Title = "Math Calculators",
                Description = "Calculate Math related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-radical size-5\"><path d=\"M3 12h3.28a1 1 0 0 1 .948.684l2.298 7.934a.5.5 0 0 0 .96-.044L13.82 4.771A1 1 0 0 1 14.792 4H21\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "everyday-life-calculators",
                Title = "Everyday Life Calculators",
                Description = "Calculate everyday life related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-armchair size-5\"><path d=\"M19 9V6a2 2 0 0 0-2-2H7a2 2 0 0 0-2 2v3\"></path><path d=\"M3 16a2 2 0 0 0 2 2h14a2 2 0 0 0 2-2v-5a2 2 0 0 0-4 0v1.5a.5.5 0 0 1-.5.5h-9a.5.5 0 0 1-.5-.5V11a2 2 0 0 0-4 0z\"></path><path d=\"M5 18v2\"></path><path d=\"M19 18v2\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "biology-calculators",
                Title = "Biology Calculators",
                Description = "Calculate biology related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-dna size-5\"><path d=\"m10 16 1.5 1.5\"></path><path d=\"m14 8-1.5-1.5\"></path><path d=\"M15 2c-1.798 1.998-2.518 3.995-2.807 5.993\"></path><path d=\"m16.5 10.5 1 1\"></path><path d=\"m17 6-2.891-2.891\"></path><path d=\"M2 15c6.667-6 13.333 0 20-6\"></path><path d=\"m20 9 .891.891\"></path><path d=\"M3.109 14.109 4 15\"></path><path d=\"m6.5 12.5 1 1\"></path><path d=\"m7 18 2.891 2.891\"></path><path d=\"M9 22c1.798-1.998 2.518-3.995 2.807-5.993\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "chemistry-calculators",
                Title = "Chemistry Calculators",
                Description = "Calculate chemistry related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-flask-conical size-5\"><path d=\"M14 2v6a2 2 0 0 0 .245.96l5.51 10.08A2 2 0 0 1 18 22H6a2 2 0 0 1-1.755-2.96l5.51-10.08A2 2 0 0 0 10 8V2\"></path><path d=\"M6.453 15h11.094\"></path><path d=\"M8.5 2h7\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "physics-calculators",
                Title = "Physics Calculators",
                Description = "Calculate physics related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-atom size-5\"><circle cx=\"12\" cy=\"12\" r=\"1\"></circle><path d=\"M20.2 20.2c2.04-2.03.02-7.36-4.5-11.9-4.54-4.52-9.87-6.54-11.9-4.5-2.04 2.03-.02 7.36 4.5 11.9 4.54 4.52 9.87 6.54 11.9 4.5Z\"></path><path d=\"M15.7 15.7c4.52-4.54 6.54-9.87 4.5-11.9-2.03-2.04-7.36-.02-11.9 4.5-4.52 4.54-6.54 9.87-4.5 11.9 2.03 2.04 7.36.02 11.9-4.5Z\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "color-calculators",
                Title = "Color Calculators",
                Description = "From color palettes to color shades, we have you covered.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-palette size-5\"><circle cx=\"13.5\" cy=\"6.5\" r=\".5\" fill=\"currentColor\"></circle><circle cx=\"17.5\" cy=\"10.5\" r=\".5\" fill=\"currentColor\"></circle><circle cx=\"8.5\" cy=\"7.5\" r=\".5\" fill=\"currentColor\"></circle><circle cx=\"6.5\" cy=\"12.5\" r=\".5\" fill=\"currentColor\"></circle><path d=\"M12 2C6.5 2 2 6.5 2 12s4.5 10 10 10c.926 0 1.648-.746 1.648-1.688 0-.437-.18-.835-.437-1.125-.29-.289-.438-.652-.438-1.125a1.64 1.64 0 0 1 1.668-1.668h1.996c3.051 0 5.555-2.503 5.555-5.554C21.965 6.012 17.461 2 12 2z\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "health-calculators",
                Title = "Health Calculators",
                Description = "Calculate health related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-heart-pulse size-5\"><path d=\"M19 14c1.49-1.46 3-3.21 3-5.5A5.5 5.5 0 0 0 16.5 3c-1.76 0-3 .5-4.5 2-1.5-1.5-2.74-2-4.5-2A5.5 5.5 0 0 0 2 8.5c0 2.3 1.5 4.05 3 5.5l7 7Z\"></path><path d=\"M3.22 12H9.5l.5-1 2 4.5 2-7 1.5 3.5h5.27\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "construction-calculators",
                Title = "Construction Calculators",
                Description = "Calculate construction related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-hammer size-5\"><path d=\"m15 12-8.373 8.373a1 1 0 1 1-3-3L12 9\"></path><path d=\"m18 15 4-4\"></path><path d=\"m21.5 11.5-1.914-1.914A2 2 0 0 1 19 8.172V7l-2.26-2.26a6 6 0 0 0-4.202-1.756L9 2.96l.92.82A6.18 6.18 0 0 1 12 8.4V10l2 2h1.172a2 2 0 0 1 1.414.586L18.5 14.5\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "unit-conversion-calculators",
                Title = "Unit Conversion Calculators",
                Description = "Calculate conversion related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-calculator size-5\"><rect width=\"16\" height=\"20\" x=\"4\" y=\"2\" rx=\"2\"></rect><line x1=\"8\" x2=\"16\" y1=\"6\" y2=\"6\"></line><line x1=\"16\" x2=\"16\" y1=\"14\" y2=\"18\"></line><path d=\"M16 10h.01\"></path><path d=\"M12 10h.01\"></path><path d=\"M8 10h.01\"></path><path d=\"M12 14h.01\"></path><path d=\"M8 14h.01\"></path><path d=\"M12 18h.01\"></path><path d=\"M8 18h.01\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "food-calculators",
                Title = "Food Calculators",
                Description = "Calculate food related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-wheat size-5\"><path d=\"M2 22 16 8\"></path><path d=\"M3.47 12.53 5 11l1.53 1.53a3.5 3.5 0 0 1 0 4.94L5 19l-1.53-1.53a3.5 3.5 0 0 1 0-4.94Z\"></path><path d=\"M7.47 8.53 9 7l1.53 1.53a3.5 3.5 0 0 1 0 4.94L9 15l-1.53-1.53a3.5 3.5 0 0 1 0-4.94Z\"></path><path d=\"M11.47 4.53 13 3l1.53 1.53a3.5 3.5 0 0 1 0 4.94L13 11l-1.53-1.53a3.5 3.5 0 0 1 0-4.94Z\"></path><path d=\"M20 2h2v2a4 4 0 0 1-4 4h-2V6a4 4 0 0 1 4-4Z\"></path><path d=\"M11.47 17.47 13 19l-1.53 1.53a3.5 3.5 0 0 1-4.94 0L5 19l1.53-1.53a3.5 3.5 0 0 1 4.94 0Z\"></path><path d=\"M15.47 13.47 17 15l-1.53 1.53a3.5 3.5 0 0 1-4.94 0L9 15l1.53-1.53a3.5 3.5 0 0 1 4.94 0Z\"></path><path d=\"M19.47 9.47 21 11l-1.53 1.53a3.5 3.5 0 0 1-4.94 0L13 11l1.53-1.53a3.5 3.5 0 0 1 4.94 0Z\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "sports-calculators",
                Title = "Sports Calculators",
                Description = "Calculate sports related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-medal size-5\"><path d=\"M7.21 15 2.66 7.14a2 2 0 0 1 .13-2.2L4.4 2.8A2 2 0 0 1 6 2h12a2 2 0 0 1 1.6.8l1.6 2.14a2 2 0 0 1 .14 2.2L16.79 15\"></path><path d=\"M11 12 5.12 2.2\"></path><path d=\"m13 12 5.88-9.8\"></path><path d=\"M8 7h8\"></path><circle cx=\"12\" cy=\"17\" r=\"5\"></circle><path d=\"M12 18v-2h-.5\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "text-calculators",
                Title = "Text Calculators",
                Description = "Text analysis calculators for word counting, unscrambling, and manipulation.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-book-a size-5\"><path d=\"M4 19.5v-15A2.5 2.5 0 0 1 6.5 2H19a1 1 0 0 1 1 1v18a1 1 0 0 1-1 1H6.5a1 1 0 0 1 0-5H20\"></path><path d=\"m8 13 4-7 4 7\"></path><path d=\"M9.1 11h5.7\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "fun-calculators",
                Title = "Fun Calculators",
                Description = "Fun calculator for all your computation needs",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-party-popper size-5\"><path d=\"M5.8 11.3 2 22l10.7-3.79\"></path><path d=\"M4 3h.01\"></path><path d=\"M22 8h.01\"></path><path d=\"M15 2h.01\"></path><path d=\"M22 20h.01\"></path><path d=\"m22 2-2.24.75a2.9 2.9 0 0 0-1.96 3.12c.1.86-.57 1.63-1.45 1.63h-.38c-.86 0-1.6.6-1.76 1.44L14 10\"></path><path d=\"m22 13-.82-.33c-.86-.34-1.82.2-1.98 1.11c-.11.7-.72 1.22-1.43 1.22H17\"></path><path d=\"m11 2 .33.82c.34.86-.2 1.82-1.11 1.98C9.52 4.9 9 5.52 9 6.23V7\"></path><path d=\"M11 13c1.93 1.93 2.83 4.17 2 5-.83.83-3.07-.07-5-2-1.93-1.93-2.83-4.17-2-5 .83-.83 3.07.07 5 2Z\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "time-date-calculators",
                Title = "Time & Date Calculators",
                Description = "Calculate time and date related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-timer size-5\"><line x1=\"10\" x2=\"14\" y1=\"2\" y2=\"2\"></line><line x1=\"12\" x2=\"15\" y1=\"14\" y2=\"11\"></line><circle cx=\"12\" cy=\"14\" r=\"8\"></circle></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "photography-calculators",
                Title = "Photography Calculators",
                Description = "Photography related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-image size-5\"><rect width=\"18\" height=\"18\" x=\"3\" y=\"3\" rx=\"2\" ry=\"2\"></rect><circle cx=\"9\" cy=\"9\" r=\"2\"></circle><path d=\"m21 15-3.086-3.086a2 2 0 0 0-2.828 0L6 21\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "crafting-calculators",
                Title = "Crafting Calculators",
                Description = "Crafting related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-scissors size-5\"><circle cx=\"6\" cy=\"6\" r=\"3\"></circle><path d=\"M8.12 8.12 12 12\"></path><path d=\"M20 4 8.12 15.88\"></path><circle cx=\"6\" cy=\"18\" r=\"3\"></circle><path d=\"M14.8 14.8 20 20\"></path></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "automotive-calculators",
                Title = "Automotive Calculators",
                Description = "Automative related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-car size-5\"><path d=\"M19 17h2c.6 0 1-.4 1-1v-3c0-.9-.7-1.7-1.5-1.9C18.7 10.6 16 10 16 10s-1.3-1.4-2.2-2.3c-.5-.4-1.1-.7-1.8-.7H5c-.6 0-1.1.4-1.4.9l-1.4 2.9A3.7 3.7 0 0 0 2 12v4c0 .6.4 1 1 1h2\"></path><circle cx=\"7\" cy=\"17\" r=\"2\"></circle><path d=\"M9 17h6\"></path><circle cx=\"17\" cy=\"17\" r=\"2\"></circle></svg>",
                Live = "yes",
                IsCategory = true
            },
            new Calculator()
            {
                Slug = "travel-calculators",
                Title = "Travel Calculators",
                Description = "Travel related calculations with ease.",
                Icon = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"lucide lucide-plane size-5\"><path d=\"M17.8 19.2 16 11l3.5-3.5C21 6 21.5 4 21 3c-1-.5-3 0-4.5 1.5L13 8 4.8 6.2c-.5-.1-.9.1-1.1.5l-.3.5c-.2.5-.1 1 .3 1.3L9 12l-2 3H4l-1 1 3 2 2 3 1-1v-3l3-2 3.5 5.3c.3.4.8.5 1.3.3l.5-.2c.4-.3.6-.7.5-1.2z\"></path></svg>",
                Live = "yes",
                IsCategory = true
            }
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