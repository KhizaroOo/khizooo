
namespace khizooo.AppData
{

    public class Freebie
    {
        public string Slug { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Count { get; set; }
    }

    public class MyFreebies
    {

        private List<Freebie> MyAllFreebies = new List<Freebie>()
{
    new Freebie() { Slug = "icons", Title = "Icons", Icon = "⭐", Count = "0", Description = "Handpicked free icons to power your projects with style and clarity." },
    new Freebie() { Slug = "illustrations", Title = "Illustrations", Icon = "🧩", Count = "0", Description = "Creative vector and digital illustrations to enrich your visuals." },
    new Freebie() { Slug = "photos", Title = "Photos", Icon = "📸", Count = "0", Description = "High-quality free stock photos for every design and idea." },
    new Freebie() { Slug = "videos", Title = "Videos", Icon = "📽️", Count = "0", Description = "Free video clips, animations & stock footage for creatives." },
    new Freebie() { Slug = "colors", Title = "Colors", Icon = "🟣", Count = "0", Description = "Beautiful palettes and gradients to spark design inspiration." },
    new Freebie() { Slug = "backgrounds", Title = "Backgrounds", Icon = "🌅", Count = "0", Description = "Stunning textures, gradients & wallpapers to set the scene." },
    new Freebie() { Slug = "typography", Title = "Typography", Icon = "🔠", Count = "0", Description = "A variety of fonts and typefaces for impactful storytelling." },
    new Freebie() { Slug = "3d", Title = "3D", Icon = "🔮", Count = "0", Description = "Free 3D assets, models & elements for modern visuals." },
    new Freebie() { Slug = "libraries", Title = "Libraries", Icon = "📦", Count = "0", Description = "Useful frameworks and libraries to speed up development." },
    new Freebie() { Slug = "blogs", Title = "Blogs", Icon = "📰", Count = "0", Description = "Curated blogs sharing insights, tutorials & creative stories." },
    new Freebie() { Slug = "tools", Title = "Tools", Icon = "⚡", Count = "0", Description = "Powerful free tools to design, build & boost productivity." },
    new Freebie() { Slug = "inspirations", Title = "Inspirations", Icon = "🌟", Count = "0", Description = "A gallery of ideas, concepts & trends to spark creativity." },
    new Freebie() { Slug = "components", Title = "Components", Icon = "🧱", Count = "0", Description = "Ready-to-use UI kits and components for faster design." }
};



        public List<Freebie> GetMyFreebies(int Count)
        {
            List<Freebie> Data = new List<Freebie>();
            Data = MyAllFreebies.Take(Count).ToList();
            return Data;
        }

        public Freebie GetMyFreebie(string Slug)
        {
            Freebie Data = new Freebie();
            Data = MyAllFreebies.FirstOrDefault(A => A.Slug == Slug);
            return Data;
        }

    }

}