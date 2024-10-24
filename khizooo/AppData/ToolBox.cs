﻿namespace khizooo.AppData
{

    public class ToolBoxType
    {
        public long ID { get; set; }
        public string Title { get; set; }
    }

    public class ToolBox
    {
        public long ID { get; set; }
        public string URL { get; set; }
        public string SITE_URL { get; set; }
        public string LiveURL { get; set; }
        public string Tags { get; set; }
        public string Slug { get; set; }
        public string DataGroup { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string IMG { get; set; }
        public string VIDEO { get; set; }
        public string Desription { get; set; }
        public string Type { get; set; }
        public long ToolBoxTypeID { get; set; }
        public string Category { get; set; }
        public string CreatedOn { get; set; }

        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string YouTube { get; set; }
        public string OpenSea { get; set; }
        public string Twitter { get; set; }
        public string TikTok { get; set; }
        public string LinkedIn { get; set; }
        public string Pinterest { get; set; }
        public string Snapchat { get; set; }

        public long PreviousWorkID { get; set; }
        public long NextWorkID { get; set; }

        // PENDINGS
        public long ModuleID { get; set; }
    }

    public class MyToolBoxes
    {

        private List<ToolBoxType> ToolBoxTypes = new List<ToolBoxType>(){
            new ToolBoxType() { ID = 0 , Title = "All"},
            new ToolBoxType() { ID = 1 , Title = "UI/UX"},
            new ToolBoxType() { ID = 2 , Title = "Generators"}
        };

        private List<ToolBox> MyAllToolBoxes = new List<ToolBox>()
        {
            new ToolBox()
            {
                  ID = 1,
                  URL = "/creative-works/toolbox/1/color-contrast-checker",
                  Tags = "[\"ToolBox\",\"UI/UX\"]",
                  Slug = "Color-Contrast-Checker",
                  DataGroup = "[\"all\",\"UI/UX\"]",
                  Heading = "Color Contrast Checker - UI/UX - ToolBox",
                  Title = "Color Contrast Checker",
                  SubTitle = "UI/UX | ToolBox",
                  IMG = "images/mytoolboxes/color-contrast-checker.png",
                  VIDEO = "",
                  Desription = "",
                  Type = "ToolBox",
                  ToolBoxTypeID = 1,
                  Category = "UI/UX",
                  CreatedOn = "1st MAR 2024",

                  Facebook = "",
                  Instagram = "",
                  LinkedIn = "",
                  YouTube = "",
                  OpenSea = "",
                  Twitter = "",
                  TikTok = "",
                  Pinterest = "",
                  Snapchat = "",

                  PreviousWorkID = 0,
                  NextWorkID = 2
              },
            new ToolBox()
            {
                  ID = 2,
                  URL = "/creative-works/toolbox/2/password-generator",
                  Tags = "[\"ToolBox\",\"creative-works/toolbox/2/password-generator\"]",
                  Slug = "Password-Generator",
                  DataGroup = "[\"all\",\"Generator\"]",
                  Heading = "Password Generator | ToolBox",
                  Title = "Password Generator",
                  SubTitle = "Generator - ToolBox",
                  IMG = "images/mytoolboxes/password-generator.png",
                  VIDEO = "",
                  Desription = "",
                  Type = "ToolBox",
                  ToolBoxTypeID = 2,
                  Category = "Generator",
                  CreatedOn = "1st MAY 2024",

                  Facebook = "",
                  Instagram = "",
                  LinkedIn = "",
                  YouTube = "",
                  OpenSea = "",
                  Twitter = "",
                  TikTok = "",
                  Pinterest = "",
                  Snapchat = "",

                  PreviousWorkID = 1,
                  NextWorkID = 3
            },
            new ToolBox()
            {
                  ID = 3,
                  URL = "/creative-works/toolbox/3/gradient-color-generator",
                  Tags = "[\"ToolBox\",\"creative-works/toolbox/3/gradient-color-generator\"]",
                  Slug = "Gradient-Color-Generator",
                  DataGroup = "[\"all\",\"Generator\"]",
                  Heading = "Gradient Color Generator | ToolBox",
                  Title = "Gradient Color Generator",
                  SubTitle = "Generator - ToolBox",
                  IMG = "images/mytoolboxes/gradient-color-generator.png",
                  VIDEO = "",
                  Desription = "",
                  Type = "ToolBox",
                  ToolBoxTypeID = 2,
                  Category = "Generator",
                  CreatedOn = "1st AUG 2024",

                  Facebook = "",
                  Instagram = "",
                  LinkedIn = "",
                  YouTube = "",
                  OpenSea = "",
                  Twitter = "",
                  TikTok = "",
                  Pinterest = "",
                  Snapchat = "",

                  PreviousWorkID = 2,
                  NextWorkID = 4
              }
        };

        public List<ToolBox> GetMyToolBoxes(int Count)
        {
            List<ToolBox> Data = new List<ToolBox>();
            Data = MyAllToolBoxes.Take(Count).ToList();
            return Data;
        }

        public ToolBox GetMyToolBox(long ID)
        {
            ToolBox Data = new ToolBox();
            Data = MyAllToolBoxes.FirstOrDefault(A => A.ID == ID);
            return Data;
        }

        public ToolBox GetMyToolBox(string Slug)
        {
            ToolBox Data = new ToolBox();
            Data = MyAllToolBoxes.FirstOrDefault(A => A.Slug == Slug);
            return Data;
        }

        public ToolBox GetMyToolBox(long ID, string Slug)
        {
            ToolBox Data = new ToolBox();
            Data = MyAllToolBoxes.FirstOrDefault(A => A.ID == ID && A.Slug == Slug);
            return Data;
        }

        public List<ToolBoxType> Get_ToolBox_Types()
        {
            List<ToolBoxType> Data = new List<ToolBoxType>();
            Data = ToolBoxTypes.ToList();
            return Data;
        }

        #region Basic Pattern Repositries

        private List<BasicPattern> BasicPatterns = new List<BasicPattern>()
        {
            new BasicPattern() {
                  ID = 1,
                  Title = "Pattern #1",
                  Categories = "#lines, #directional",
                  URL = "/images/mytoolboxes/basicpatterns/1.svg",
                  FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"4\" height=\"4\" viewBox=\"0 0 4 4\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-1\" patternUnits=\"userSpaceOnUse\" width=\"4\" height=\"4\">\n    <path d=\"M-1,1 l2,-2 M0,4 l4,-4 M3,5 l2,-2\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"4\" height=\"4\" fill=\"url(#pattern-1)\" />\n</svg>",
                  Pattern = "<pattern id=\"pattern-1\" patternUnits=\"userSpaceOnUse\" width=\"4\" height=\"4\">\n    <path d=\"M-1,1 l2,-2 M0,4 l4,-4 M3,5 l2,-2\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
              },
            new BasicPattern() {
                  ID = 2,
                  Title = "Pattern #2",
                  Categories = "#lines, #directional",
                  URL = "/images/mytoolboxes/basicpatterns/2.svg",
                  FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"4\" height=\"4\" viewBox=\"0 0 4 4\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-2\" patternUnits=\"userSpaceOnUse\" width=\"4\" height=\"4\">\n    <path d=\"M0,0 l4,4\n             M-1,3 l2,2\n             M3,-1 l2,2\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"4\" height=\"4\" fill=\"url(#pattern-2)\" />\n</svg>",
                  Pattern = "<pattern id=\"pattern-2\" patternUnits=\"userSpaceOnUse\" width=\"4\" height=\"4\">\n    <path d=\"M0,0 l4,4\n             M-1,3 l2,2\n             M3,-1 l2,2\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
              },
            new BasicPattern() {
                  ID = 3,
                  Title = "Pattern #3",
                  Categories = "#lines, #directional",
                  URL = "/images/mytoolboxes/basicpatterns/3.svg",
                  FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"8\" height=\"8\" viewBox=\"0 0 8 8\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-3\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M-1,1 l4,-4 M0,8 l8,-8 M6,10 l4,-4\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"8\" height=\"8\" fill=\"url(#pattern-3)\" />\n</svg>",
                  Pattern = "<pattern id=\"pattern-3\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M-1,1 l4,-4 M0,8 l8,-8 M6,10 l4,-4\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
              },
            new BasicPattern() {
                ID = 4,
                Title = "Pattern #4",
                  Categories = "#lines, #directional",
                URL = "/images/mytoolboxes/basicpatterns/4.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"8\" height=\"8\" viewBox=\"0 0 8 8\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-4\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M0,0 l8,8\n             M-1,7 l4,4\n             M7,-1 l4,4\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"8\" height=\"8\" fill=\"url(#pattern-4)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-4\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M0,0 l8,8\n             M-1,7 l4,4\n             M7,-1 l4,4\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 5,
                Title = "Pattern #5",
                  Categories = "#lines, #directional",
                URL = "/images/mytoolboxes/basicpatterns/5.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"6\" height=\"6\" viewBox=\"0 0 6 6\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-5\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M-1,1 l2,-2 M0,6 l6,-6 M5,7 l2,-2\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"6\" height=\"6\" fill=\"url(#pattern-5)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-5\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M-1,1 l2,-2 M0,6 l6,-6 M5,7 l2,-2\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 6,
                Title = "Pattern #6",
                  Categories = "#lines, #directional",
                URL = "/images/mytoolboxes/basicpatterns/6.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"6\" height=\"6\" viewBox=\"0 0 6 6\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-6\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M7,1 l-2,-2 M0,0 l6,6 M1,7 l-2,-2\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"6\" height=\"6\" fill=\"url(#pattern-6)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-6\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M7,1 l-2,-2 M0,0 l6,6 M1,7 l-2,-2\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 7,
                Title = "Pattern #7",
                Categories = "#lines, #mesh",
                URL = "/images/mytoolboxes/basicpatterns/7.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"6\" height=\"6\" viewBox=\"0 0 6 6\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-7\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M0,0 l6,6 M6,0 l-6,6\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"6\" height=\"6\" fill=\"url(#pattern-7)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-7\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M0,0 l6,6 M6,0 l-6,6\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 8,
                 Title = "Pattern #8",
                Categories = "#lines, #mesh",
                URL = "/images/mytoolboxes/basicpatterns/8.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"8\" height=\"8\" viewBox=\"0 0 8 8\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-8\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M0,0 l8,8\n             M8,0 l-8,8\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"8\" height=\"8\" fill=\"url(#pattern-8)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-8\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M0,0 l8,8\n             M8,0 l-8,8\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 9,
                 Title = "Pattern #9",
                Categories = "#lines, #mesh",
                URL = "/images/mytoolboxes/basicpatterns/9.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"12\" height=\"12\" viewBox=\"0 0 12 12\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-9\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <path d=\"M0,0 l12,12 M12,0 l-12,12\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"12\" height=\"12\" fill=\"url(#pattern-9)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-9\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <path d=\"M0,0 l12,12 M12,0 l-12,12\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 10,
                 Title = "Pattern #10",
                Categories = "#lines, #mesh",
                URL = "/images/mytoolboxes/basicpatterns/10.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"4\" height=\"4\" viewBox=\"0 0 4 4\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-10\" patternUnits=\"userSpaceOnUse\" width=\"4\" height=\"4\">\n    <path d=\"M2,0 l0,4 M0,2 l4,0\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"4\" height=\"4\" fill=\"url(#pattern-10)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-10\" patternUnits=\"userSpaceOnUse\" width=\"4\" height=\"4\">\n    <path d=\"M2,0 l0,4 M0,2 l4,0\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 11,
                 Title = "Pattern #11",
                Categories = "#lines, #mesh",
                URL = "/images/mytoolboxes/basicpatterns/11.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"6\" height=\"6\" viewBox=\"0 0 6 6\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-11\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M3,0 l0,6 M0,3 l6,0\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"6\" height=\"6\" fill=\"url(#pattern-11)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-11\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M3,0 l0,6 M0,3 l6,0\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 12,
                 Title = "Pattern #12",
                Categories = "#lines, #mesh",
                URL = "/images/mytoolboxes/basicpatterns/12.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"8\" height=\"8\" viewBox=\"0 0 8 8\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-12\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M4,0 l0,8 M0,4 l8,0\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"8\" height=\"8\" fill=\"url(#pattern-12)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-12\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M4,0 l0,8 M0,4 l8,0\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 13,
                 Title = "Pattern #13",
                Categories = "#lines, #mesh",
                URL = "/images/mytoolboxes/basicpatterns/13.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"12\" height=\"12\" viewBox=\"0 0 12 12\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-13\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <path d=\"M6,0 l0,12 M0,6 l12,0\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"12\" height=\"12\" fill=\"url(#pattern-13)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-13\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <path d=\"M6,0 l0,12 M0,6 l12,0\" stroke=\"currentcolor\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 14,
                Title = "Pattern #14",
                Categories = "#lines, #waves, #horizontal",
                URL = "/images/mytoolboxes/basicpatterns/14.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"6\" height=\"6\" viewBox=\"0 0 6 6\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-14\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M-1,5 l2,2 M5,7 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 3,3 6,0\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"6\" height=\"6\" fill=\"url(#pattern-14)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-14\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M-1,5 l2,2 M5,7 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 3,3 6,0\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 15,
                Title = "Pattern #15",
                Categories = "#lines, #waves, #horizontal",
                URL = "/images/mytoolboxes/basicpatterns/15.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"8\" height=\"8\" viewBox=\"0 0 8 8\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-15\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M-1,7 l2,2 M7,9 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 4,4 8,0\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"8\" height=\"8\" fill=\"url(#pattern-15)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-15\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M-1,7 l2,2 M7,9 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 4,4 8,0\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 16,
                Title = "Pattern #16",
                Categories = "#lines, #waves, #horizontal",
                URL = "/images/mytoolboxes/basicpatterns/16.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"12\" height=\"12\" viewBox=\"0 0 12 12\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-16\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <path d=\"M-1,11 l2,2 M11,13 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 6,6 12,0\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"12\" height=\"12\" fill=\"url(#pattern-16)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-16\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <path d=\"M-1,11 l2,2 M11,13 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 6,6 12,0\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 17,
                Title = "Pattern #17",
                Categories = "#circles, #centered",
                URL = "/images/mytoolboxes/basicpatterns/17.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"8\" height=\"8\" viewBox=\"0 0 8 8\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-17\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <circle cx=\"4\" cy=\"4\" r=\"2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"8\" height=\"8\" fill=\"url(#pattern-17)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-17\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <circle cx=\"4\" cy=\"4\" r=\"2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 18,
                 Title = "Pattern #18",
                Categories = "#circles, #centered",
                URL = "/images/mytoolboxes/basicpatterns/18.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"12\" height=\"12\" viewBox=\"0 0 12 12\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-18\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <circle cx=\"6\" cy=\"6\" r=\"3\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"12\" height=\"12\" fill=\"url(#pattern-18)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-18\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <circle cx=\"6\" cy=\"6\" r=\"3\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 19,
                 Title = "Pattern #19",
                Categories = "#circles, #centered",
                URL = "/images/mytoolboxes/basicpatterns/19.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"16\" height=\"16\" viewBox=\"0 0 16 16\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-19\" patternUnits=\"userSpaceOnUse\" width=\"16\" height=\"16\">\n    <circle cx=\"8\" cy=\"8\" r=\"4\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"16\" height=\"16\" fill=\"url(#pattern-19)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-19\" patternUnits=\"userSpaceOnUse\" width=\"16\" height=\"16\">\n    <circle cx=\"8\" cy=\"8\" r=\"4\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 20,
                 Title = "Pattern #20",
                Categories = "#circles, #off-centered",
                URL = "/images/mytoolboxes/basicpatterns/20.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"12\" height=\"12\" viewBox=\"0 0 12 12\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-20\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <circle cx=\"0\" cy=\"6\" r=\"2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"12\" cy=\"6\" r=\"2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"6\" cy=\"0\" r=\"2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"6\" cy=\"12\" r=\"2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"12\" height=\"12\" fill=\"url(#pattern-20)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-20\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <circle cx=\"0\" cy=\"6\" r=\"2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"12\" cy=\"6\" r=\"2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"6\" cy=\"0\" r=\"2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"6\" cy=\"12\" r=\"2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 21,
                Title = "Pattern #21",
                Categories = "#circles, #off-centered",
                URL = "/images/mytoolboxes/basicpatterns/21.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"16\" height=\"16\" viewBox=\"0 0 16 16\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-21\" patternUnits=\"userSpaceOnUse\" width=\"16\" height=\"16\">\n    <circle cx=\"0\" cy=\"8\" r=\"3\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"16\" cy=\"8\" r=\"3\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"8\" cy=\"0\" r=\"3\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"8\" cy=\"16\" r=\"3\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"16\" height=\"16\" fill=\"url(#pattern-21)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-21\" patternUnits=\"userSpaceOnUse\" width=\"16\" height=\"16\">\n    <circle cx=\"0\" cy=\"8\" r=\"3\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"16\" cy=\"8\" r=\"3\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"8\" cy=\"0\" r=\"3\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"8\" cy=\"16\" r=\"3\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 22,
                Title = "Pattern #22",
                Categories = "#circles, #off-centered",
                URL = "/images/mytoolboxes/basicpatterns/22.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-22\" patternUnits=\"userSpaceOnUse\" width=\"24\" height=\"24\">\n    <circle cx=\"0\" cy=\"12\" r=\"4\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"24\" cy=\"12\" r=\"4\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"12\" cy=\"0\" r=\"4\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"12\" cy=\"24\" r=\"4\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"24\" height=\"24\" fill=\"url(#pattern-22)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-22\" patternUnits=\"userSpaceOnUse\" width=\"24\" height=\"24\">\n    <circle cx=\"0\" cy=\"12\" r=\"4\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"24\" cy=\"12\" r=\"4\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"12\" cy=\"0\" r=\"4\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <circle cx=\"12\" cy=\"24\" r=\"4\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
                
            },
            new BasicPattern() {
                ID = 23,
                 Title = "Pattern #23",
                Categories = "#points, #centered",
                URL = "/images/mytoolboxes/basicpatterns/23.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"4\" height=\"4\" viewBox=\"0 0 4 4\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-23\" patternUnits=\"userSpaceOnUse\" width=\"4\" height=\"4\">\n    <rect width=\"2\" height=\"2\" x=\"0\" y=\"0\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"4\" height=\"4\" fill=\"url(#pattern-23)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-23\" patternUnits=\"userSpaceOnUse\" width=\"4\" height=\"4\">\n    <rect width=\"2\" height=\"2\" x=\"0\" y=\"0\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 24,
                 Title = "Pattern #24",
                Categories = "#points, #centered",
                URL = "/images/mytoolboxes/basicpatterns/24.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"6\" height=\"6\" viewBox=\"0 0 6 6\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-24\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <rect width=\"2\" height=\"2\" x=\"0\" y=\"0\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"6\" height=\"6\" fill=\"url(#pattern-24)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-24\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <rect width=\"2\" height=\"2\" x=\"0\" y=\"0\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 25,
                 Title = "Pattern #25",
                Categories = "#points, #centered",
                URL = "/images/mytoolboxes/basicpatterns/25.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"8\" height=\"8\" viewBox=\"0 0 8 8\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-25\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <rect width=\"2\" height=\"2\" x=\"0\" y=\"0\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"8\" height=\"8\" fill=\"url(#pattern-25)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-25\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <rect width=\"2\" height=\"2\" x=\"0\" y=\"0\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 26,
                 Title = "Pattern #26",
                Categories = "#points, #centered",
                URL = "/images/mytoolboxes/basicpatterns/26.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"12\" height=\"12\" viewBox=\"0 0 12 12\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-26\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <rect width=\"2\" height=\"2\" x=\"0\" y=\"0\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"12\" height=\"12\" fill=\"url(#pattern-26)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-26\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <rect width=\"2\" height=\"2\" x=\"0\" y=\"0\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 27,
                 Title = "Pattern #27",
                Categories = "#points, #off-centered",
                URL = "/images/mytoolboxes/basicpatterns/27.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"6\" height=\"6\" viewBox=\"0 0 6 6\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-27\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M2,2 l2,0 l0,2 l-2,0 l0,-2 M0,0 l1,0 l0,1 l-1,0 l0,-1 M5,0 l1,0 l0,1 l-1,0 l0,-1 M0,5 l1,0 l0,1 l-1,0 l0,-1 M5,5 l1,0 l0,1 l-1,0 l0,-1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"6\" height=\"6\" fill=\"url(#pattern-27)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-27\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M2,2 l2,0 l0,2 l-2,0 l0,-2 M0,0 l1,0 l0,1 l-1,0 l0,-1 M5,0 l1,0 l0,1 l-1,0 l0,-1 M0,5 l1,0 l0,1 l-1,0 l0,-1 M5,5 l1,0 l0,1 l-1,0 l0,-1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 28,
                 Title = "Pattern #28",
                Categories = "#points, #off-centered",
                URL = "/images/mytoolboxes/basicpatterns/28.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"8\" height=\"8\" viewBox=\"0 0 8 8\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-28\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M3,3 l2,0 l0,2 l-2,0 l0,-2 M0,0 l1,0 l0,1 l-1,0 l0,-1 M7,0 l1,0 l0,1 l-1,0 l0,-1 M0,7 l1,0 l0,1 l-1,0 l0,-1 M7,7 l1,0 l0,1 l-1,0 l0,-1\" fill=\"hotpink\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"8\" height=\"8\" fill=\"url(#pattern-28)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-28\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M3,3 l2,0 l0,2 l-2,0 l0,-2 M0,0 l1,0 l0,1 l-1,0 l0,-1 M7,0 l1,0 l0,1 l-1,0 l0,-1 M0,7 l1,0 l0,1 l-1,0 l0,-1 M7,7 l1,0 l0,1 l-1,0 l0,-1\" fill=\"hotpink\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 29,
                 Title = "Pattern #29",
                Categories = "#points, #off-centered",
                URL = "/images/mytoolboxes/basicpatterns/29.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"12\" height=\"12\" viewBox=\"0 0 12 12\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-29\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <path d=\"M5,5 l2,0 l0,2 l-2,0 l0,-2 M0,0 l1,0 l0,1 l-1,0 l0,-1 M11,0 l1,0 l0,1 l-1,0 l0,-1 M0,11 l1,0 l0,1 l-1,0 l0,-1 M11,11 l1,0 l0,1 l-1,0 l0,-1\" fill=\"hotpink\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"12\" height=\"12\" fill=\"url(#pattern-29)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-29\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <path d=\"M5,5 l2,0 l0,2 l-2,0 l0,-2 M0,0 l1,0 l0,1 l-1,0 l0,-1 M11,0 l1,0 l0,1 l-1,0 l0,-1 M0,11 l1,0 l0,1 l-1,0 l0,-1 M11,11 l1,0 l0,1 l-1,0 l0,-1\" fill=\"hotpink\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 30,
                 Title = "Pattern #30",
                Categories = "#points, #off-centered",
                URL = "/images/mytoolboxes/basicpatterns/30.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"16\" height=\"16\" viewBox=\"0 0 16 16\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-30\" patternUnits=\"userSpaceOnUse\" width=\"16\" height=\"16\">\n    <path d=\"M7,7 l2,0 l0,2 l-2,0 l0,-2 M0,0 l1,0 l0,1 l-1,0 l0,-1 M15,0 l1,0 l0,1 l-1,0 l0,-1 M0,15 l1,0 l0,1 l-1,0 l0,-1 M15,15 l1,0 l0,1 l-1,0 l0,-1\" fill=\"hotpink\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"16\" height=\"16\" fill=\"url(#pattern-30)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-30\" patternUnits=\"userSpaceOnUse\" width=\"16\" height=\"16\">\n    <path d=\"M7,7 l2,0 l0,2 l-2,0 l0,-2 M0,0 l1,0 l0,1 l-1,0 l0,-1 M15,0 l1,0 l0,1 l-1,0 l0,-1 M0,15 l1,0 l0,1 l-1,0 l0,-1 M15,15 l1,0 l0,1 l-1,0 l0,-1\" fill=\"hotpink\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 31,
                 Title = "Pattern #31",
                Categories = "#dots",
                URL = "/images/mytoolboxes/basicpatterns/31.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"4\" height=\"4\" viewBox=\"0 0 4 4\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-31\" patternUnits=\"userSpaceOnUse\" width=\"4\" height=\"4\">\n    <circle cx=\"2\" cy=\"2\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"4\" height=\"4\" fill=\"url(#pattern-31)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-31\" patternUnits=\"userSpaceOnUse\" width=\"4\" height=\"4\">\n    <circle cx=\"2\" cy=\"2\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 32,
                 Title = "Pattern #32",
                Categories = "#dots",
                URL = "/images/mytoolboxes/basicpatterns/32.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"6\" height=\"6\" viewBox=\"0 0 6 6\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-32\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <circle cx=\"3\" cy=\"3\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"6\" height=\"6\" fill=\"url(#pattern-32)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-32\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <circle cx=\"3\" cy=\"3\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 33,
                 Title = "Pattern #33",
                Categories = "#dots",
                URL = "/images/mytoolboxes/basicpatterns/33.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"8\" height=\"8\" viewBox=\"0 0 8 8\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-33\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <circle cx=\"4\" cy=\"4\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"8\" height=\"8\" fill=\"url(#pattern-33)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-33\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <circle cx=\"4\" cy=\"4\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 34,
                 Title = "Pattern #34",
                Categories = "#dots",
                URL = "/images/mytoolboxes/basicpatterns/34.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"12\" height=\"12\" viewBox=\"0 0 12 12\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-34\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <circle cx=\"6\" cy=\"6\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"12\" height=\"12\" fill=\"url(#pattern-34)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-34\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <circle cx=\"6\" cy=\"6\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 35,
                 Title = "Pattern #35",
                Categories = "#dots",
                URL = "/images/mytoolboxes/basicpatterns/35.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"6\" height=\"6\" viewBox=\"0 0 6 6\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-35\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <circle cx=\"0\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"0\" cy=\"6\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"6\" cy=\"6\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"6\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"3\" cy=\"3\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"6\" height=\"6\" fill=\"url(#pattern-35)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-35\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <circle cx=\"0\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"0\" cy=\"6\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"6\" cy=\"6\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"6\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"3\" cy=\"3\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 36,
                 Title = "Pattern #36",
                Categories = "#dots",
                URL = "/images/mytoolboxes/basicpatterns/36.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"8\" height=\"8\" viewBox=\"0 0 8 8\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-36\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <circle cx=\"0\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"0\" cy=\"8\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"8\" cy=\"8\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"8\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"4\" cy=\"4\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"8\" height=\"8\" fill=\"url(#pattern-36)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-36\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <circle cx=\"0\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"0\" cy=\"8\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"8\" cy=\"8\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"8\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"4\" cy=\"4\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 37,
                 Title = "Pattern #37",
                Categories = "#dots",
                URL = "/images/mytoolboxes/basicpatterns/37.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"12\" height=\"12\" viewBox=\"0 0 12 12\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-37\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <circle cx=\"0\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"0\" cy=\"12\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"12\" cy=\"12\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"12\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"6\" cy=\"6\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"12\" height=\"12\" fill=\"url(#pattern-37)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-37\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <circle cx=\"0\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"0\" cy=\"12\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"12\" cy=\"12\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"12\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"6\" cy=\"6\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 38,
                 Title = "Pattern #38",
                Categories = "#dots",
                URL = "/images/mytoolboxes/basicpatterns/38.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"16\" height=\"16\" viewBox=\"0 0 16 16\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-38\" patternUnits=\"userSpaceOnUse\" width=\"16\" height=\"16\">\n    <circle cx=\"0\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"0\" cy=\"16\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"16\" cy=\"16\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"16\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"8\" cy=\"8\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"16\" height=\"16\" fill=\"url(#pattern-38)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-38\" patternUnits=\"userSpaceOnUse\" width=\"16\" height=\"16\">\n    <circle cx=\"0\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"0\" cy=\"16\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"16\" cy=\"16\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"16\" cy=\"0\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n    <circle cx=\"8\" cy=\"8\" r=\"1\" fill=\"currentcolor\" style=\"fill: var(--pattern-channel-1, currentcolor)\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 39,
                 Title = "Pattern #39",
                Categories = "#lines, #waves, #vertical",
                URL = "/images/mytoolboxes/basicpatterns/39.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"6\" height=\"6\" viewBox=\"0 0 6 6\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-39\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M5,-1 l2,2 M5,7 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 3,3 0,6\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"6\" height=\"6\" fill=\"url(#pattern-39)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-39\" patternUnits=\"userSpaceOnUse\" width=\"6\" height=\"6\">\n    <path d=\"M5,-1 l2,2 M5,7 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 3,3 0,6\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 40,
                  Title = "Pattern #40",
                Categories = "#lines, #waves, #vertical",
                URL = "/images/mytoolboxes/basicpatterns/40.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"8\" height=\"8\" viewBox=\"0 0 8 8\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-40\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M7,-1 l2,2 M7,9 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 4,4 0,8\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"8\" height=\"8\" fill=\"url(#pattern-40)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-40\" patternUnits=\"userSpaceOnUse\" width=\"8\" height=\"8\">\n    <path d=\"M7,-1 l2,2 M7,9 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 4,4 0,8\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
            },
            new BasicPattern() {
                ID = 41,
                  Title = "Pattern #41",
                Categories = "#lines, #waves, #vertical",
                URL = "/images/mytoolboxes/basicpatterns/41.svg",
                FullCode = "<svg xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" width=\"12\" height=\"12\" viewBox=\"0 0 12 12\" xml:space=\"preserve\">\n    <defs>\n        <pattern id=\"pattern-41\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <path d=\"M11,-1 l2,2 M11,13 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 6,6 0,12\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>\n    </defs>\n    <rect x=\"0\" y=\"0\" width=\"12\" height=\"12\" fill=\"url(#pattern-41)\" />\n</svg>",
                Pattern = "<pattern id=\"pattern-41\" patternUnits=\"userSpaceOnUse\" width=\"12\" height=\"12\">\n    <path d=\"M11,-1 l2,2 M11,13 l2,-2\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n    <polyline points=\"0,0 6,6 0,12\" style=\"stroke: var(--pattern-channel-1, currentcolor)\" fill=\"none\" />\n</pattern>"
            }
        };

        public List<BasicPattern> GetBasicPatterns(int Count)
        {
            List<BasicPattern> Data = new List<BasicPattern>();
            Data = BasicPatterns.Take(Count).ToList();
            return Data;
        }

        #endregion

    }

    public class BasicPattern
    {
        public long ID { get; set; }
        public string Title { get; set; }
        public string Categories { get; set; }
        public string URL { get; set; }
        public string FullCode { get; set; }
        public string Pattern { get; set; }
    }


}

