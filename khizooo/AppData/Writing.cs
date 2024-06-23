namespace khizooo.AppData
{
	
    public class Writing
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
        public string ShortDesription { get; set; }
        public string Desription { get; set; }
        public string Type { get; set; }
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

    public class MyWritings
    {
        public static string BASEPATH = "http://localhost:7281";

        private List<Writing> MyAllWritings = new List<Writing>()
    {
       new Writing()
       {
              ID = 1,
              URL = BASEPATH + "/My-Art/1/Green-Skirt-Girl-Sticky-Note-Art",
              SITE_URL = "/My-Art/1/Green-Skirt-Girl-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\",]",
              Slug = "Green-Skirt-Girl-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Green Skirt Girl - Sticky Note - Art",
              Title = "Green Skirt Girl",
              SubTitle = "Sticky Note - Art",
              IMG = "images/myarts/Green-Skirt-Girl.jpg",
              VIDEO = "",
              ShortDesription = "Get ready to be spellbound as we investigate the motivation, the interaction, and the sheer magnificence of this craftsmanship piec",
              Desription = "<p class='Art-Detail-Text'>Welcome to my creative domain, where even a sticky note changes into a spellbinding show-stopper. How about we find the captivating universe of workmanship on sticky notes.</p><p class='Art-Detail-Text'>In this blog entry, I welcome you to dive into the captivating universe of my most recent drawing named \"Green Skirt Young lady\". A young lady wearing a delightful green concealed long skirt and a perfect white top, her multi-concealed earthy colored hair flowing with beauty. Get ready to be spellbound as we investigate the motivation, the interaction, and the sheer magnificence of this craftsmanship piece.</p><p class='Art-Detail-Text'>Each stroke of my pencil was an ongoing source of both pain and joy, cautiously making the many-sided subtleties that rejuvenate this young lady. The white top decorating her reflects virtue, honesty, and a feeling of ethereal excellence. The multi-concealed earthy colored hair is an embroidery of tones, catching the intricacy and uniqueness of the human soul. It murmurs accounts of versatility, development, and the incalculable encounters that shape our lives.</p><p class='Art-Detail-Text'>We should utilize the force of workmanship to elevate, rouse, and the vast potential outcomes that unfurl when innovativeness exceeds all logical limitations.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.\n</p>",
              Type = "Art",
              Category = "Sticky Note",
              CreatedOn = "27th JAN 2023",

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
          new Writing()
          {
              ID = 2,
              URL = BASEPATH + "/My-Art/2/Bearded-Man-Sticky-Note-Art",
              SITE_URL = "/My-Art/2/Bearded-Man-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\",]",
              Slug = "Bearded-Man-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Bearded Man - Sticky Note - Art",
              Title = "Bearded Man",
              SubTitle = "Sticky Note - Art",
              IMG = "images/myarts/Bearded-Man.jpg",
              VIDEO = "",
                            ShortDesription = "Get ready to be spellbound as we investigate the motivation, the interaction, and the sheer magnificence of this craftsmanship piec",
              Desription = @"<p class='Art-Detail-Text'>Discover the beauty in my latest artistic creation. A remarkable drawing of a bearded man on a sticky note. Through intricate strokes and masterful shading.</p><p class='Art-Detail-Text'>In this drawing, the bearded man's facial hair serves as an emblem of wisdom, strength, and rugged individuality. Every pen stroke delicately captures the coarse texture of the beard, revealing the dedication and patience required to nurture such an impressive growth.</p><p class='Art-Detail-Text'>My carefully crafted lines bring life to the bearded man's expressive eyes, exuding a sense of wisdom and experience. His eyes hint at hidden stories and invite viewers to imagine the adventures and knowledge he carries within.</p><p class='Art-Detail-Text'>Rendered on a humble sticky note, this art piece challenges the boundaries of creativity, reminding us that true artistry transcends the limitations of canvas or size. It is a testament to my ability to transform the ordinary into the extraordinary, turning a mundane office supply into a window to a world of imagination.</p><p class='Art-Detail-Text'>Allow this remarkable bearded man to captivate your senses, beckoning you to delve deeper into the realms of human complexity. Explore the power of a single artwork to tell a thousand tales, and join us on our website as we celebrate the fusion of art and inspiration. <p class=""Art-Detail-Text"">Visit[<a class=""L-C"" href=""/MyWorkFlow-MyArtfulness"">MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p>",
              Type = "Art",
              Category = "Sticky Note",
              CreatedOn = "1st FEB 2023",

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
          new Writing()
          {
              ID = 3,
              URL = BASEPATH + "/My-Art/3/Midnight-Muse-Sticky-Note-Art",
              SITE_URL = "/My-Art/3/Midnight-Muse-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\",]",
              Slug = "Midnight-Muse-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Midnight Muse - Sticky Note - Art",
              Title = "Midnight Muse",
              SubTitle = "Sticky Note - Art",
              IMG = "images/myarts/Midnight-Muse.jpg",
              VIDEO = "",
                            ShortDesription = "Get ready to be spellbound as we investigate the motivation, the interaction, and the sheer magnificence of this craftsmanship piec",
              Desription = "<p class='Art-Detail-Text'>The phrase \"Midnight\" evokes a sense of mystery and darkness, which contrasts with her radiant beauty.</p><p class='Art-Detail-Text'>The word \"Muse\" typically refers to a source of inspiration, and in this case, her beauty could be seen as inspiring others around her.</p><p class='Art-Detail-Text'>Overall, the title \"Midnight Muse\" conveys a sense of intrigue, beauty, and inspiration, making it a suitable title for the given context.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.\n</p>",
              Type = "Art",
              Category = "Sticky Note",
              CreatedOn = "3rd FEB 2023",

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
          },
          new Writing()
          {
              ID = 4,
              URL = BASEPATH + "/My-Art/4/Fire-Heart-Sticky-Note-Art",
              SITE_URL = "/My-Art/4/Fire-Heart-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\",]",
              Slug = "Fire-Heart-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Fire Heart - Sticky Note - Art",
              Title = "Fire Heart",
              SubTitle = "Sticky Note - Art",
              IMG = "images/myarts/Fire-Heart.jpg",
              VIDEO = "images/myarts/Fire-Heart.mp4",
                            ShortDesription = "Get ready to be spellbound as we investigate the motivation, the interaction, and the sheer magnificence of this craftsmanship piec",
              Desription = "<p class='Art-Detail-Text'>This art belongs to a lovely story of a young boy and a beautiful girl with some magical abilities.</p><p class='Art-Detail-Text'>Here is the story which i named “Fire Heart”\n \nOnce upon a time, in a small village tucked away in the rolling hills of a distant land, there lived a young boy named Kian. Kian was a simple boy, born into a family of farmers. He had a passion for tending the fields and caring for the livestock, but there was always something missing in his life.</p><p class='Art-Detail-Text'>One day, as he was walking through the fields, he saw a girl standing in the distance. She was unlike anyone he had ever seen before. She had fiery red hair, and her eyes sparkled like embers. Kian was immediately smitten.</p><p class='Art-Detail-Text'>The girl's name was Aria, and she too was from the village. But Aria was special. She possessed the power of fire, a rare and wondrous gift that she struggled to control. Kian was fascinated by her, and he found himself drawn to her like a lover.</p><p class='Art-Detail-Text'>Despite her fiery nature, Aria was shy and hesitant to open up to Kian. But as they spent more time together, they began to develop a deep connection. Kian's gentle nature and unwavering support made Aria feel safe and loved, and she slowly began to let down her guard.</p><p class='Art-Detail-Text'>As their relationship blossomed, Aria's powers began to grow stronger. She learned to harness her fiery energy, using it to light up the night sky and warm the hearts of those around her. Kian was always there to support her, never once flinching in the face of her powerful flames.</p><p class='Art-Detail-Text'>Together, Kian and Aria faced many challenges, but their love never wavered. They were a perfect match, a simple boy and a girl with the power of fire. And in the end, their love burned brighter than any flame, lighting up the sky for all to see.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.\n</p>",
              Type = "Art",
              Category = "Sticky Note",
              CreatedOn = "7th FEB 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 3,
              NextWorkID = 5
          },
          new Writing()
          {
              ID = 5,
              URL = BASEPATH + "/My-Art/5/Junior-Professor-Sticky-Note-Art",
              SITE_URL = "/My-Art/5/Junior-Professor-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\",]",
              Slug = "Junior-Professor-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Junior Professor - Sticky Note - Art",
              Title = "Junior Professor",
              SubTitle = "Sticky Note - Art",
              IMG = "images/myarts/Junior-Professor.jpg",
              VIDEO = "",
                            ShortDesription = "Get ready to be spellbound as we investigate the motivation, the interaction, and the sheer magnificence of this craftsmanship piec",
              Desription = "<p class='Art-Detail-Text'>A captivating cartoon depiction of a Junior Professor. Which is carefully sketched on a sticky note. In this charming creation, education meets playfulness, and wisdom is delivered with a smile.</p><p class='Art-Detail-Text'>On this small canvas, every line and curve comes alive, revealing the artist's ability to infuse personality into every stroke. From the carefully tousled hair to the endearing bow tie, this Junior Professor becomes an embodiment of the passion and dedication that fuel the pursuit of academia.</p><p class='Art-Detail-Text'>In a world that often takes itself too seriously, this delightful artwork reminds us that learning should be a joyful journey. The Junior Professor's mischievous grin and raised eyebrow invite us to approach education with a playful spirit, encouraging us to explore, question, and embrace new ideas.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.\n</p>",
              Type = "Art",
              Category = "Sticky Note",
              CreatedOn = "11th FEB 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 4,
              NextWorkID = 6
          }
    };

        public List<Writing> GetMyWritings(int Count)
        {
            List<Writing> Data = new List<Writing>();
            Data = MyAllWritings.Take(Count).ToList();
            return Data;
        }

        public Writing GetMyWriting(long ID)
        {
            Writing Data = new Writing();
            Data = MyAllWritings.FirstOrDefault(A => A.ID == ID);
            return Data;
        }

        public Writing GetMyWriting(string Slug)
        {
            Writing Data = new Writing();
            Data = MyAllWritings.FirstOrDefault(A => A.Slug == Slug);
            return Data;
        }

        public Writing GetMyWriting(long ID, string Slug)
        {
            Writing Data = new Writing();
            Data = MyAllWritings.FirstOrDefault(A => A.ID == ID && A.Slug == Slug);
            return Data;
        }

    }

}