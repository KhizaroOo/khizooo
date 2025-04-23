
namespace khizooo.AppData
{

    public class Art
	{
        public string Slug { get; set; }
        public string Title { get; set; }
        public string IMG { get; set; }
        public string CreatedOn { get; set; }

        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string X { get; set; }
        public string TikTok { get; set; }
        public string Pinterest { get; set; }

        public string Agora { get; set; }
        public string OpenSea { get; set; }
        public string Rarible { get; set; }
        public string Mintable { get; set; }
        

        public string Type { get; set; }

        // PENDINGS
        public long NoduleID { get; set; }
    }

    public class MyArts
    {

        private List<Art> MyAllArts = new List<Art>()
        { 
          new Art()
          {
              Slug = "Green-Skirt-Girl-Sticky-Note-Art",
              Title = "Green Skirt Girl",
              IMG = "images/MyArts/Green-Skirt-Girl.jpg",
              Type = "Sticky Note",

              Facebook = "",
              Instagram = "",
              X = "",
              TikTok = "",
              Pinterest = "",
               
              Agora = "",
              OpenSea = "",
              Rarible = "",
              Mintable = ""
          },
          new Art()
          {
              Slug = "Bearded-Man-Sticky-Note-Art",
              Title = "Bearded Man",
              IMG = "images/MyArts/Bearded-Man.jpg",
              Type = "Sticky Note",

              Facebook = "",
              Instagram = "",
              X = "",
              TikTok = "",
              Pinterest = "",

              Agora = "",
              OpenSea = "",
              Rarible = "",
              Mintable = ""
          }
        };

        public List<Art> GetMyArts(int Count)
        {
            List<Art> Data = new List<Art>();
            Data = MyAllArts.Take(Count).ToList();
            return Data;
        }

        public Art GetMyArt(string Slug)
        {
            Art Data = new Art();
            Data = MyAllArts.FirstOrDefault(A => A.Slug == Slug);
            return Data;
        }

    }

}

