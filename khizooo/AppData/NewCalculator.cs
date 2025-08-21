using System.Collections.Generic;

namespace khizooo.AppData
{
    public class NewCalculator
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Live { get; set; }
        public string Icon { get; set; }
        public bool IsCategory { get; set; }
        public List<NewCalculatorTool> Tools { get; set; }
    }

    public class NewCalculatorTool
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Live { get; set; }
        public string Icon { get; set; }
        public bool IsCategory { get; set; }
    }
}