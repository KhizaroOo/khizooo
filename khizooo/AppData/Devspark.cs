namespace khizooo.AppData
{
    public class Devspark
    {
        public string Key { get; set; } // Ensure this property exists
        public string Category { get; set; } // Ensure this property exists
        public List<DevsparkItem> Items { get; set; }
    }

    public class DevsparkItem
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
    }

}
