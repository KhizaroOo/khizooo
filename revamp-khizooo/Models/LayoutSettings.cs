using System;
namespace revamp_khizooo.Models
{
	public class LayoutSettings
	{
        
        public List<(int, string)> LayoutSections = new List<(int, string)>();
        public List<(int, int, string, string, string, int)> TopNavbar = new List<(int, int, string, string, string, int)>();

        public LayoutSettings()
        {
            LayoutSections = new List<(int, string)>
            {
                ( 1,"Flash-Screen-Loader" ),
                ( 2, "Top_Navbar" ),
                ( 3, "Left_Top_Section" ),
                ( 4, "Left_Middle_Section" ),
                ( 5, "Footer" ),
                ( 6, "Right-Page-Content" )
            };

            //TopNavbar = new List<(int, int, string, string, string, int)>
            //{
            //    (2,1, "Landing Page", "Myself", "Informations about me", 0),
            //    (2,2, "Porfolio", "Myself", "Detail informations about me", 0),
            //    (2,3, "Artworks", "My Creative Works", "Explore my vibrant and imaginative artworks, which is reflecting my passion for creativity.", 0),
            //    (2,4, "Infographics", "My Creative Works", "Discover my visually engaging infographics, which is designed to simplify complex information.", 0),
            //    (2,5, "ToolsBox", "My Creative Works", "Discover the essential web tools and resources, which will surely help your web experience.", 0),
            //    (2,6, "Writings", "My Creative Works", "Read my writings where creativity meets insight, covering many topics with unique perspective.", 0),
            //    (2,7, "", "", "", 0),
            //    (2,8, "", "", "", 1),
            //    (2,9, "", "", "", 2),
            //    (2,10, "", "", "", 3)
            //};

        }

    }

    public class TopNavbar
    {
        public string ModalTile { get; set; }
        public string CategoryTypeTitle { get; set; }
        public string PageTitle { get; set; }
    }


}

