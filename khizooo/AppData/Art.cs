﻿
namespace khizooo.AppData
{

    public class ArtworkType
    {
        public long ID { get; set; }
        public string Title { get; set; }
    }

    public class Art
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

        public long ArtworkTypeID { get; set; }

        // PENDINGS
        public long ShowingLocationID { get; set; }
    }

    public class MyArts
    {

        private List<ArtworkType> ArtworkTypes = new List<ArtworkType>(){
            new ArtworkType() { ID = 0 , Title = "All"},
            new ArtworkType() { ID = 1 , Title = "Sticky Note"}
        };

        private List<Art> MyAllArts = new List<Art>()
        { 
          new Art()
          {
              ID = 1,
              URL = "/creative-works/artwork/detail/1/Green-Skirt-Girl-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/1/Green-Skirt-Girl-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Green-Skirt-Girl-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Green Skirt Girl - Sticky Note - Art",
              Title = "Green Skirt Girl",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Green-Skirt-Girl.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my creative domain, where even a sticky note changes into a spellbinding show-stopper. How about we find the captivating universe of workmanship on sticky notes.</p><p class='Art-Detail-Text'>In this blog entry, I welcome you to dive into the captivating universe of my most recent drawing named \"Green Skirt Young lady\". A young lady wearing a delightful green concealed long skirt and a perfect white top, her multi-concealed earthy colored hair flowing with beauty. Get ready to be spellbound as we investigate the motivation, the interaction, and the sheer magnificence of this craftsmanship piece.</p><p class='Art-Detail-Text'>Each stroke of my pencil was an ongoing source of both pain and joy, cautiously making the many-sided subtleties that rejuvenate this young lady. The white top decorating her reflects virtue, honesty, and a feeling of ethereal excellence. The multi-concealed earthy colored hair is an embroidery of tones, catching the intricacy and uniqueness of the human soul. It murmurs accounts of versatility, development, and the incalculable encounters that shape our lives.</p><p class='Art-Detail-Text'>We should utilize the force of workmanship to elevate, rouse, and the vast potential outcomes that unfurl when innovativeness exceeds all logical limitations.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art",
              ArtworkTypeID = 1,
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
          new Art()
          {
              ID = 2,
              URL = "/creative-works/artwork/detail/2/Bearded-Man-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/2/Bearded-Man-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Bearded-Man-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Bearded Man - Sticky Note - Art",
              Title = "Bearded Man",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Bearded-Man.jpg",
              VIDEO = "",
              Desription = @"<p class='Art-Detail-Text'>Discover the beauty in my latest artistic creation. A remarkable drawing of a bearded man on a sticky note. Through intricate strokes and masterful shading.</p><p class='Art-Detail-Text'>In this drawing, the bearded man's facial hair serves as an emblem of wisdom, strength, and rugged individuality. Every pen stroke delicately captures the coarse texture of the beard, revealing the dedication and patience required to nurture such an impressive growth.</p><p class='Art-Detail-Text'>My carefully crafted lines bring life to the bearded man's expressive eyes, exuding a sense of wisdom and experience. His eyes hint at hidden stories and invite viewers to imagine the adventures and knowledge he carries within.</p><p class='Art-Detail-Text'>Rendered on a humble sticky note, this art piece challenges the boundaries of creativity, reminding us that true artistry transcends the limitations of canvas or size. It is a testament to my ability to transform the ordinary into the extraordinary, turning a mundane office supply into a window to a world of imagination.</p><p class='Art-Detail-Text'>Allow this remarkable bearded man to captivate your senses, beckoning you to delve deeper into the realms of human complexity. Explore the power of a single artwork to tell a thousand tales, and join us on our website as we celebrate the fusion of art and inspiration. <p class=""Art-Detail-Text"">Visit[<a class=""L-C"" href=""/MyWorkFlow-MyArtfulness"">MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p>",
              Type = "Art", ArtworkTypeID = 1,
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
          new Art()
          {
              ID = 3,
              URL = "/creative-works/artwork/detail/3/Midnight-Muse-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/3/Midnight-Muse-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Midnight-Muse-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Midnight Muse - Sticky Note - Art",
              Title = "Midnight Muse",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Midnight-Muse.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>The phrase \"Midnight\" evokes a sense of mystery and darkness, which contrasts with her radiant beauty.</p><p class='Art-Detail-Text'>The word \"Muse\" typically refers to a source of inspiration, and in this case, her beauty could be seen as inspiring others around her.</p><p class='Art-Detail-Text'>Overall, the title \"Midnight Muse\" conveys a sense of intrigue, beauty, and inspiration, making it a suitable title for the given context.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
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
          new Art()
          {
              ID = 4,
              URL = "/creative-works/artwork/detail/4/Fire-Heart-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/4/Fire-Heart-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Fire-Heart-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Fire Heart - Sticky Note - Art",
              Title = "Fire Heart",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Fire-Heart.jpg",
              VIDEO = "images/MyArts/Fire-Heart.mp4",
              Desription = "<p class='Art-Detail-Text'>This art belongs to a lovely story of a young boy and a beautiful girl with some magical abilities.</p><p class='Art-Detail-Text'>Here is the story which i named “Fire Heart” Once upon a time, in a small village tucked away in the rolling hills of a distant land, there lived a young boy named Kian. Kian was a simple boy, born into a family of farmers. He had a passion for tending the fields and caring for the livestock, but there was always something missing in his life.</p><p class='Art-Detail-Text'>One day, as he was walking through the fields, he saw a girl standing in the distance. She was unlike anyone he had ever seen before. She had fiery red hair, and her eyes sparkled like embers. Kian was immediately smitten.</p><p class='Art-Detail-Text'>The girl's name was Aria, and she too was from the village. But Aria was special. She possessed the power of fire, a rare and wondrous gift that she struggled to control. Kian was fascinated by her, and he found himself drawn to her like a lover.</p><p class='Art-Detail-Text'>Despite her fiery nature, Aria was shy and hesitant to open up to Kian. But as they spent more time together, they began to develop a deep connection. Kian's gentle nature and unwavering support made Aria feel safe and loved, and she slowly began to let down her guard.</p><p class='Art-Detail-Text'>As their relationship blossomed, Aria's powers began to grow stronger. She learned to harness her fiery energy, using it to light up the night sky and warm the hearts of those around her. Kian was always there to support her, never once flinching in the face of her powerful flames.</p><p class='Art-Detail-Text'>Together, Kian and Aria faced many challenges, but their love never wavered. They were a perfect match, a simple boy and a girl with the power of fire. And in the end, their love burned brighter than any flame, lighting up the sky for all to see.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
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
          new Art()
          {
              ID = 5,
              URL = "/creative-works/artwork/detail/5/Junior-Professor-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/5/Junior-Professor-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Junior-Professor-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Junior Professor - Sticky Note - Art",
              Title = "Junior Professor",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Junior-Professor.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>A captivating cartoon depiction of a Junior Professor. Which is carefully sketched on a sticky note. In this charming creation, education meets playfulness, and wisdom is delivered with a smile.</p><p class='Art-Detail-Text'>On this small canvas, every line and curve comes alive, revealing the artist's ability to infuse personality into every stroke. From the carefully tousled hair to the endearing bow tie, this Junior Professor becomes an embodiment of the passion and dedication that fuel the pursuit of academia.</p><p class='Art-Detail-Text'>In a world that often takes itself too seriously, this delightful artwork reminds us that learning should be a joyful journey. The Junior Professor's mischievous grin and raised eyebrow invite us to approach education with a playful spirit, encouraging us to explore, question, and embrace new ideas.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
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
          },
          new Art()
          {
              ID = 6,
              URL = "/creative-works/artwork/detail/6/Colorful-Elephant-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/6/Colorful-Elephant-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Colorful-Elephant-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Colorful Elephant - Sticky Note - Art",
              Title = "Colorful Elephant",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Colorful-Elephant.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>This stunning artwork captures the majesty and grace of these magnificent creatures, using vibrant hues and intricate details to create a truly mesmerizing image.</p><p class='Art-Detail-Text'>Whether you're a lover of animals, art, or simply appreciate the finer things in life, a colorful elephant painting is sure to brighten up any space.</p><p class='Art-Detail-Text'>Rendered on a tiny sticky note, this artwork defies the boundaries of conventional canvases, proving that true artistry knows no limitations. It invites us to see the extraordinary in the ordinary, turning a simple office supply into a portal to a world where imagination reigns supreme.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "16th FEB 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 5,
              NextWorkID = 7
          },
          new Art()
          {
              ID = 7,
              URL = "/creative-works/artwork/detail/7/Peak-Perfection-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/7/Peak-Perfection-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Peak-Perfection-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Peak Perfection - Sticky Note - Art",
              Title = "Peak Perfection",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Peak-Perfection.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>A charming house perched at the summit of a majestic mountain, drawn on a sticky note. This miniature artwork effortlessly transports you to a world of serenity and natural beauty.</p><p class='Art-Detail-Text'>\"Peak Perfection\" is The Splendor of Living on a Mountain.</p><p class='Art-Detail-Text'>Allow the vision of this mountain retreat to transport you to a place of serenity, and discover the transformative power of art on the most unexpected canvas.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "19th FEB 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 6,
              NextWorkID = 8
          },
          new Art()
          {
              ID = 8,
              URL = "/creative-works/artwork/detail/8/The-Spot-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/8/The-Spot-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "The-Spot-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "The Spot - Sticky Note - Art",
              Title = "The Spot",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/The-Spot.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Beautifully built houses on a large tree. ‘The Spot’ is the place of healers.</p><p class='Art-Detail-Text'>This could refer to a hidden or secret location that people go to for various reasons. It could be a spot where people go to relax, a spot where people go to hide, or even a spot where people go to party.</p><p class='Art-Detail-Text'>Drawing on a humble sticky note, this art piece challenges the boundaries of creativity</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "26th FEB 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 7,
              NextWorkID = 9
          },
          new Art()
          {
              ID = 9,
              URL = "/creative-works/artwork/detail/9/Young-Girl-vs-Dark-Wind-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/9/Young-Girl-vs-Dark-Wind-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Young-Girl-vs-Dark-Wind-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Girl vs Dark Wind - Sticky Note - Art",
              Title = "Girl vs Dark Wind",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Young-Girl-vs-Dark-Wind.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>This art belongs to a beautiful story named “Young Girl vs Dark Wind”. So here is the story.</p><p class='Art-Detail-Text'>In a village, there lived a young girl named Mia. She was a curious and kind-hearted girl with a love for animals. One day, while exploring the nearby woods, she stumbled upon a wounded bird with a broken wing. Mia's heart filled with compassion, and she gently picked up the bird, vowing to help it.</p><p class='Art-Detail-Text'>Mia took the bird home and made a cozy nest for it. She carefully splinted its wing and provided food and water. Day by day, the bird grew stronger under Mia's tender care. As it healed, they formed a special bond.</p><p class='Art-Detail-Text'>One evening, as Mia sat near the window, a soft melody filled the air. The bird, now able to fly, perched on her windowsill and chirped joyfully. Mia understood that the bird was saying goodbye. With a bittersweet feeling, she opened the window, allowing the bird to soar into the sky.</p><p class='Art-Detail-Text'>Months passed, and Mia missed her feathery friend. But one sunny morning, as she strolled through the woods, she heard a familiar chirping. There, in a clearing, stood the bird, surrounded by other creatures Mia had helped over time. They had come together to thank her for her kindness.</p><p class='Art-Detail-Text'>Overwhelmed with joy, Mia realized that her acts of compassion had created a community of grateful animals. From that day forward, Mia continued her mission, caring for and protecting the wildlife around her. And the village, inspired by her selflessness, joined her in creating a harmonious world where kindness and love thrived.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "1st MARCH 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 8,
              NextWorkID = 10
          },
          new Art()
          {
              ID = 10,
              URL = "/creative-works/artwork/detail/10/Portal-To-The-Past-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/10/Portal-To-The-Past-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Portal-To-The-Past-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Portal To The Past - Sticky Note - Art",
              Title = "Portal To The Past",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Portal-To-The-Past.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>This art belongs to a beautiful story named “Portal To The Past”. So here is the story.</p><p class='Art-Detail-Text'>In a village, there lived a young girl named Mia. She was a curious and kind-hearted girl with a love for animals. One day, while exploring the nearby woods, she stumbled upon a wounded bird with a broken wing. Mia's heart filled with compassion, and she gently picked up the bird, vowing to help it.</p><p class='Art-Detail-Text'>Mia took the bird home and made a cozy nest for it. She carefully splinted its wing and provided food and water. Day by day, the bird grew stronger under Mia's tender care. As it healed, they formed a special bond.</p><p class='Art-Detail-Text'>One evening, as Mia sat near the window, a soft melody filled the air. The bird, now able to fly, perched on her windowsill and chirped joyfully. Mia understood that the bird was saying goodbye. With a bittersweet feeling, she opened the window, allowing the bird to soar into the sky.</p><p class='Art-Detail-Text'>Months passed, and Mia missed her feathery friend. But one sunny morning, as she strolled through the woods, she heard a familiar chirping. There, in a clearing, stood the bird, surrounded by other creatures Mia had helped over time. They had come together to thank her for her kindness.</p><p class='Art-Detail-Text'>Overwhelmed with joy, Mia realized that her acts of compassion had created a community of grateful animals. From that day forward, Mia continued her mission, caring for and protecting the wildlife around her. And the village, inspired by her selflessness, joined her in creating a harmonious world where kindness and love thrived.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "3rd MARCH 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 9,
              NextWorkID = 11
          },
          new Art()
          {
              ID = 11,
              URL = "/creative-works/artwork/detail/11/Little-Angel-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/11/Little-Angel-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Little-Angel-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Little Angel - Sticky Note - Art",
              Title = "Little Angel",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Little-Angel.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where imagination takes flight on the tiniest of canvases. As a drawing artist, I find joy in creating intricate and meaningful art. In this blog post, I want to share with you a heartfelt drawing I made.A tribute to my beloved NIECE with majestic wings and curly hair.</p><p class='Art-Detail-Text'>The paper's limitations only fueled my creativity, challenging me to express intricate details and emotions within a confined space. This artwork holds a special place in my heart as it is dedicated to my beloved niece.</p><p class='Art-Detail-Text'>A visual testament to the power of art and the love that inspires it. May it remind you of the precious bonds you hold with your own loved ones and the infinite possibilities that unfold when creativity knows no boundaries.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "5th MARCH 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 10,
              NextWorkID = 12
          },
          new Art()
          {
              ID = 12,
              URL = "/creative-works/artwork/detail/12/Aurora-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/12/Aurora-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Aurora-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Aurora - Sticky Note - Art",
              Title = "Aurora",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Aurora.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where imagination takes flight on the tiniest of canvases. As a drawing artist, I find joy in creating intricate and meaningful art. In this blog post, I want to share with you a heartfelt drawing I made. A tribute to my beloved Aurora.</p><p class='Art-Detail-Text'>Meet Aurora, a captivating vision of grace and elegance. With a name derived from the ethereal lights that dance across the night sky, Aurora embodies a radiant charm that effortlessly captures hearts.</p><p class='Art-Detail-Text'>Blessed with an enchanting smile and eyes that hold a universe of warmth, Aurora possesses a timeless beauty that transcends fleeting trends. Her presence illuminates every room, drawing others in with an irresistible magnetism.</p><p class='Art-Detail-Text'>But Aurora's allure extends beyond her physical appearance. Her spirit is as luminous as the dawn itself. With a heart full of kindness and compassion, she spreads positivity and uplifts those around her. Her gentle words and empathetic nature create a safe haven for others to find solace and support.</p><p class='Art-Detail-Text'>Aurora's love for the arts is a testament to her creativity and imagination. Whether it's painting, writing, or dancing, she effortlessly expresses herself, infusing every stroke, word, and step with a touch of magic.</p><p class='Art-Detail-Text'>As a true adventurer at heart, Aurora embraces the wonders of the natural world. She finds solace in the whispering winds, delights in the vibrant colors of blooming flowers, and seeks inspiration within the embrace of nature's embrace.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "7th MARCH 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 11,
              NextWorkID = 13
          },
          new Art()
          {
              ID = 13,
              URL = "/creative-works/artwork/detail/13/A-Treehouse-Dream-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/13/A-Treehouse-Dream-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "A-Treehouse-Dream-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "A Treehouse Dream - Sticky Note - Art",
              Title = "A Treehouse Dream",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/A-Treehouse-Dream.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where imagination takes flight on the tiniest of canvases. As a drawing artist, I find joy in creating intricate and meaningful art. In this blog post, I want to share with you a heartfelt drawing I made. A sketch of a Treehouse which I can dream of.</p><p class='Art-Detail-Text'>At first glance, the drawing captures the essence of childhood fantasies.Every stroke and line tells a story, as the treehouse stands as a sanctuary of adventure and secret hideaways. The leaves of the tree sway gently, as if whispering tales of childhood dreams and endless possibilities.</p><p class='Art-Detail-Text'>The beauty of sticky note art lies in its simplicity and accessibility. Through this unique medium, the artist has transformed an ordinary office supply into a captivating piece of visual storytelling. The limitations of the sticky note's size have only fueled the artist's creativity, resulting in a charming and evocative creation.</p><p class='Art-Detail-Text'>Beyond its visual appeal, the treehouse holds symbolic meaning. It represents the resilience and boundless imagination of childhood. It reminds us to embrace our inner child and cherish the wonder of simpler times.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "13th MARCH 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 12,
              NextWorkID = 14
          },
          new Art()
          {
              ID = 14,
              URL = "/creative-works/artwork/detail/14/Find-Positive-In-Everything-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/14/Find-Positive-In-Everything-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Find-Positive-In-Everything-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Find Positive In Everything - Sticky Note - Art",
              Title = "Find Positive In Everything",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Find-Positive-In-Everything.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where sticky notes transform into captivating pieces of art that carry profound messages. As a drawing artist, I find inspiration in the simplest of things, using sticky notes as my canvas to spread positivity and embrace the beauty found in everyday life. In this post, I want to share a particular artwork titled \"Find-Positive-In-Everything\" where three winners emerge, and an unexpected twist unfolds, revealing the incredible power of a positive mindset. \"Find-Positive-In-Everything\" is a vibrant and expressive piece created on a sticky note.</p><p class='Art-Detail-Text'>The third-place winner becomes the focal point of the artwork's unique twist. Unlike conventional scenarios, this contestant doesn't feel disappointed or overshadowed by securing the third position. On the contrary, an overwhelming sense of positivity radiates from their smile, surpassing the first and second-place winners.</p><p class='Art-Detail-Text'>This artwork serves as a powerful reminder of the impact positivity can have on our lives. While others might perceive the third position as a setback, the exuberant character redefines the notion of winning. Their contagious positivity elevates the entire competition, shifting the focus from mere rankings to celebrating personal growth, resilience, and a genuine appreciation for the journey itself.</p><p class='Art-Detail-Text'>Through the eyes of the third-place winner, we witness the transformative power of a positive mindset. Their ability to find joy and gratitude in every situation is a testament to the idea that true fulfillment and happiness lie within our perspectives, rather than external achievements.</p><p class='Art-Detail-Text'>\"Find-Positive-In-Everything\" inspires viewers to reflect on their own lives and embrace the philosophy of finding positivity in every aspect, regardless of the outcome. It encourages us to shift our focus from comparisons and self-criticism to a mindset that fosters personal growth, resilience, and a genuine appreciation for life's journey.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "18th MARCH 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 13,
              NextWorkID = 15
          },
          new Art()
          {
              ID = 15,
              URL = "/creative-works/artwork/detail/15/Love-Day-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/15/Love-Day-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Love-Day-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Love Day - Sticky Note - Art",
              Title = "Love Day",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Love-Day.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Love Day, also known as Valentine's Day, is a special occasion that celebrates love and affection. As a drawing artist, I find joy in capturing the essence of this day through my unique art. In this post, I want to share with you the beauty and charm of my drawings on sticky notes, specifically created to celebrate the 14th of February, Love Day.</p><p class='Art-Detail-Text'>Sticky note art is a captivating form of expression that combines simplicity and creativity. The small canvas of a sticky note allows me to convey heartfelt messages and emotions with just a few strokes of a pen or marker.</p><p class='Art-Detail-Text'>Love Day is a time to celebrate the beauty of love, and my sticky note art offers a delightful and heartfelt way to express those sentiments. Whether it's through adorable illustrations or personalized drawings, my aim is to bring joy and warmth to people's hearts on this special day. Let my art be a small token of love that can brighten someone's day and serve as a reminder of the love that surrounds us all.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "21st MARCH 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 14,
              NextWorkID = 16
          },
          new Art()
          {
              ID = 16,
              URL = "/creative-works/artwork/detail/16/Cat-In-The-Coffee-Mug-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/16/Cat-In-The-Coffee-Mug-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Cat-In-The-Coffee-Mug-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Cat In The Coffee Mug - Sticky Note - Art",
              Title = "Cat In The Coffee Mug",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Cat-In-The-Coffee-Mug.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to the enchanting realm of sticky note artistry, where creativity knows no bounds. As a passionate drawing artist, I invite you to embark on a journey through my captivating collection of drawings created on sticky notes. In this post, I delve into a series of four mesmerizing images that showcase the magical transformation of a coffee mug into a gateway to a whimsical world. Prepare to be amazed as we unveil the hidden wonders within these small adhesive canvases.</p><p class='Art-Detail-Text'>Cats and coffee are two of the most beloved things in the world, and what could be better than combining them in a single mug? A cat in a coffee mug is a fun and creative way to show your love for both your furry friend and your favorite hot beverage.</p><p class='Art-Detail-Text'>Rendered with precise lines and delicate shading, the mug stands prominently on the sticky note.</p><p class='Art-Detail-Text'>As your eyes shift to the second image, you discover a delightful surprise. Nestled within the confines of the mug, small ears emerge, hinting at something beyond the ordinary. These tiny ears pique your curiosity and invite you to explore the unexpected secrets hidden within the Coffee Mug.</p><p class='Art-Detail-Text'>The third image unveils a captivating twist in the story. The small ears now reveal their true nature—they belong to a black cat. With meticulous strokes and a touch of mystique, the cat's ears materialize.</p><p class='Art-Detail-Text'>Finally, as you gaze at the fourth and final image, the narrative reaches its climax. The coffee cup tumbles and a beautiful black color small cat comes out from the Coffee Mug. </p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "23rd MARCH 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 15,
              NextWorkID = 17
          },
          new Art()
          {
              ID = 17,
              URL = "/creative-works/artwork/detail/17/Embracing-Joy-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/17/Embracing-Joy-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Embracing-Joy-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Embracing Joy - Sticky Note - Art",
              Title = "Embracing Joy",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Embracing-Joy.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where sticky notes become a canvas for spreading happiness and positivity! As a drawing artist, I find inspiration in the simplest of things. Through my drawings, I capture the essence of joy, using colorful emojis to express different happy moods.</p><p class='Art-Detail-Text'>Imagine a world where happiness is as easy as peeling a sticky note and sticking it to your heart. With my sticky note drawings, I aim to bring a smile to your face and uplift your spirits.</p><p class='Art-Detail-Text'>Emojis have become a universal language of emotions, transcending barriers and conveying feelings with simplicity and clarity. By using emojis in my sticky note drawings, I aim to connect with people on a deeper level, speaking directly to their hearts. Whether it's a simple thumbs-up, a gleeful face, or a dancing figure and many more, these emojis encapsulate the essence of happiness and positivity.</p><p class='Art-Detail-Text'>Through my art, I invite you to embrace joy as a powerful catalyst for happiness and positivity in your life. Each sticky note drawing is a gentle reminder to seek moments of joy, even in the smallest of things.</p><p class='Art-Detail-Text'>In a world that often feels chaotic and overwhelming, embracing joy becomes a conscious choice.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "25th MARCH 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 15,
              NextWorkID = 17
          },
          new Art()
          {
              ID = 18,
              URL = "/creative-works/artwork/detail/18/I-Believe-I-Can-Fly-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/18/I-Believe-I-Can-Fly-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "I-Believe-I-Can-Fly-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "I Believe I Can Fly - Sticky Note - Art",
              Title = "I Believe, I Can Fly",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/I-Believe-I-Can-Fly.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I transform the ordinary into something extraordinary. As a drawing artist, I find inspiration in everyday objects and moments, and I bring them to life on sticky notes and canvas. In this post, I invite you to explore one of my unique creations. A drawing on a sticky note titled \"I Believe I Can Fly\".</p><p class='Art-Detail-Text'>In \"I Believe I Can Fly,\" I wanted to capture a sense of whimsy and imagination. The drawing depicts a weed cigarette with wings, symbolizing the idea that even the simplest things can inspire us to reach new heights. The wings represent the power of belief and the boundless potential within each of us.</p><p class='Art-Detail-Text'>I started with a humble sticky note, which provided a small canvas for my imagination to take flight. Using a combination of vibrant markers, I carefully sketched the weed cigarette with attention to detail, bringing it to life with intricate patterns and textures. The addition of the wings was a whimsical touch, adding a sense of magic and freedom to the artwork.</p><p class='Art-Detail-Text'>I want to deliver this message through my art in this post. \"I Believe I Can Fly\" conveys a message of empowerment and self-belief. It reminds us that no matter our circumstances, we have the ability to soar beyond limitations and embrace our dreams. The simple act of believing in ourselves can give us the courage to overcome obstacles and achieve greatness.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "2nd APRIL 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 17,
              NextWorkID = 19
          },
          new Art()
          {
              ID = 19,
              URL = "/creative-works/artwork/detail/19/Tree-House-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/19/Tree-House-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Tree-House-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Tree House - Sticky Note - Art",
              Title = "Tree House",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Tree-House.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I transform the ordinary into something extraordinary. As a drawing artist, I find inspiration in everyday objects and moments, and I bring them to life on sticky notes and canvas. In this post, I want to share with you a beautiful drawing I made. A sketch of a Treehouse of a kid.</p><p class='Art-Detail-Text'>The focal point of the drawing is a magnificent treehouse nestled among the branches of a miniature tree. Every stroke of the pen brings the treehouse to life, showcasing its playful design and cozy allure. From the intricately crafted wooden planks to the quaint windows and the charming front door, the treehouse becomes a place of wonder and adventure.</p><p class='Art-Detail-Text'>The branches of the short-sized tree embrace the treehouse, forming a perfect sanctuary for a young child's imagination to roam freely.</p><p class='Art-Detail-Text'>Creating this drawing on a sticky note is a testament to my creativity and adaptability as an artist.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "3rd APRIL 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 18,
              NextWorkID = 20
          },
          new Art()
          {
              ID = 20,
              URL = "/creative-works/artwork/detail/20/Above-Earth-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/20/Above-Earth-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Above-Earth-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Above Earth - Sticky Note - Art",
              Title = "Above Earth",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Above-Earth.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I transform the ordinary into something extraordinary. As a drawing artist, I find inspiration in everyday objects and moments, and I bring them to life on sticky notes and canvas. In this post, I want to share with you a beautiful drawing I made. A sketch of a Treehouse. I called this Treehouse drawing ‘Above Earth’. </p><p class='Art-Detail-Text'>A tree house is a type of structure that is built around, on top of, or among the branches of one or more trees. They are typically made for recreational purposes, such as for children to play in or for adults to use as a quiet place to relax and enjoy nature. Tree houses can range from simple platforms built with a few planks of wood to more elaborate structures with multiple rooms, windows, and even running water.</p><p class='Art-Detail-Text'>The history of tree houses dates back to ancient civilizations, where they were used as fortifications or lookout points. In more recent times, tree houses have become a popular form of outdoor recreation for children and adults alike. They are often seen as a symbol of childhood adventures and playfulness, and are often associated with magical and imaginative worlds.</p><p class='Art-Detail-Text'>Building a tree house requires careful consideration of the trees and the surrounding environment. It's important to choose sturdy, healthy trees that can support the weight of the structure. In addition, it's crucial to obtain necessary permits and follow any local building codes and regulations to ensure the safety of those using the tree house.</p><p class='Art-Detail-Text'>There are many different styles and designs for tree houses, ranging from traditional wooden platforms to modern structures made from steel and glass. Some tree houses are even designed to be environmentally sustainable, with features like solar panels and rainwater collection systems.</p><p class='Art-Detail-Text'>Regardless of the design, a tree house offers a unique and exciting experience for those who use it. It provides a sense of adventure and escape, and is a great way to connect with nature and enjoy the outdoors. Whether you're a child or an adult, a tree house can be a wonderful place to play, relax, and create memories that will last a lifetime.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "6th APRIL 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 19,
              NextWorkID = 21
          },
          new Art()
          {
              ID = 21,
              URL = "/creative-works/artwork/detail/21/Fulgent-Life-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/21/Fulgent-Life-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Fulgent-Life-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Fulgent Life - Sticky Note - Art",
              Title = "Fulgent Life",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Fulgent-Life.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I transform the ordinary into something extraordinary. As a drawing artist, I find inspiration in everyday objects and moments, and I bring them to life on sticky notes and canvas. In this post, I want to share with you a beautiful drawing I made. A sketch of a Treehouse. I called this Treehouse drawing ‘Fulgent Life’. </p><p class='Art-Detail-Text'>‘Fulgent Life’ is a term that can be used to describe a life that is full of brightness, radiance, and vitality. It suggests a life that is abundant and flourishing, with a sense of energy, purpose, and positivity. A fulgent life can refer to a life that is lived with joy, passion, and a sense of fulfillment, where one's unique talents and gifts are allowed to shine and bring happiness to others.</p><p class='Art-Detail-Text'>The term \"fulgent\" is often associated with words like brilliant, dazzling and when used to describe life, it suggests a life that is full of light and shining with the potential to inspire and uplift others. A fulgent life is one that is lived to the fullest, with a deep appreciation for the wonders of the world and a desire to make a positive impact on the world around us.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "12th APRIL 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 20,
              NextWorkID = 22
          },
          new Art()
          {
              ID = 22,
              URL = "/creative-works/artwork/detail/22/Nature-Excavation-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/22/Nature-Excavation-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Nature-Excavation-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Nature Excavation - Sticky Note - Art",
              Title = "Nature Excavation",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Nature-Excavation.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I transform the ordinary into something extraordinary. As a drawing artist, I find inspiration in everyday objects and moments, and I bring them to life on sticky notes and canvas. In this post, I want to share with you a beautiful drawing I made. A sketch of a Treehouse. I called this Treehouse drawing ‘Fulgent Life’. </p><p class='Art-Detail-Text'>Nature excavation refers to the process of exploring and uncovering the natural beauty and resources of an area. This can include various activities such as geologic surveys, mineral exploration, wildlife studies, and archaeological surveys. The purpose of nature excavation can be for scientific research, to understand the natural resources of an area and their potential for use, or simply for the enjoyment and appreciation of the beauty and diversity of nature.</p><p class='Art-Detail-Text'>Nature excavation can also refer to the process of uncovering and exploring the hidden wonders of nature that are buried beneath the surface. This can include the excavation of fossil beds, the discovery of underground caves and rivers, or the excavation of ancient ruins. By exploring and uncovering these hidden treasures, we can gain a better understanding of the natural world and the diverse ecosystems that exist within it.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "21th APRIL 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 21,
              NextWorkID = 23
          },
          new Art()
          {
              ID = 23,
              URL = "/creative-works/artwork/detail/23/Cats-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/23/Cats-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Cats-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Cats - Sticky Note - Art",
              Title = "Cats",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Cats.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I transform the ordinary into something extraordinary. As a drawing artist, I find inspiration in everyday objects and moments, and I bring them to life on sticky notes and canvas. In this post, I want to share with you a beautiful drawing I made. A sketch of two Cats watching through water glass.</p><p class='Art-Detail-Text'>Cats are mysterious creatures, with eyes that gleam like emeralds and soft fur that feels like silk. They are independent, yet loving, and have a way of bringing joy and comfort to those around them. Their graceful movements and playful antics are a constant source of entertainment. Whether they're lounging in a sunbeam, hunting for invisible prey, or simply demanding attention with a loud meow, cats have a way of making us smile. </p><p class='Art-Detail-Text'>They are truly one of nature's wonders, and a blessing to those lucky enough to call them family.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "28th APRIL 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 22,
              NextWorkID = 24
          },
          new Art()
          {
              ID = 24,
              URL = "/creative-works/artwork/detail/24/Long-Distance-Relationships-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/24/Long-Distance-Relationships-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Long-Distance-Relationships-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Long-Distance Relationships - Sticky Note - Art",
              Title = "Long-Distance Relationships",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Long-Distance-Relationships.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I transform the ordinary into something extraordinary. As a drawing artist, I find inspiration in everyday objects and moments, and I bring them to life on sticky notes and canvas. In this post, I want to share with you a beautiful drawing I made. A sketch Which is showing a Long-Distance Relationship.</p><p class='Art-Detail-Text'>Long-distance relationships can be a challenge, but they can also be a rewarding and fulfilling experience. In a long-distance relationship, open and honest communication is essential to building trust and staying connected with your partner. </p><p class='Art-Detail-Text'>Technology can be a useful tool for staying in touch, but it's important to also make time for visits and maintain independence. By setting clear goals and expectations, making an effort to stay connected, and investing in the relationship, a long-distance romance can not only survive, but thrive. </p><p class='Art-Detail-Text'>Despite the distance, the love and connection between partners can grow stronger and deepen over time.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "1st MAY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 23,
              NextWorkID = 25
          },
          new Art()
          {
              ID = 25,
              URL = "/creative-works/artwork/detail/25/The-Rose-Enchanted-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/25/The-Rose-Enchanted-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "The-Rose-Enchanted-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "The Rose Enchanted - Sticky Note - Art",
              Title = "The Rose Enchanted",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/The-Rose-Enchanted.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I transform the ordinary into something extraordinary. As a drawing artist, I find inspiration in everyday objects and moments, and I bring them to life on sticky notes and canvas. In this post, I want to share with you a beautiful drawing I made. A sketch Which is showing a girl who takes off her skirt and in the skirt red flowers drop off. I called this art ‘The Rose Enchanted’.</p><p class='Art-Detail-Text'>\"The Rose Enchanted: A Celebration of a Girl and Her Flowers\" is a tribute to the beauty and grace of a young woman who is constantly surrounded by the timeless symbol of love: red roses.</p><p class='Art-Detail-Text'>This girl, who we will call the \"Rose Enchanted,\" is someone who radiates positivity and joy, and her love for flowers is contagious. Whether it's a single rose given to her by an admirer, or a bouquet presented by a loved one, the Rose Enchanted sees the beauty in each petal and the love in each stem.</p><p class='Art-Detail-Text'>Her love for roses is not just limited to receiving them, but also in giving them to others. She shares her love for flowers with others, spreading joy and happiness wherever she goes. And, like the roses she loves, the Rose Enchanted is a symbol of beauty, grace, and love that inspires those around her.</p><p class='Art-Detail-Text'>This celebration of a girl and her flowers is a tribute to the Rose Enchanted, and a reminder that even the simplest of gifts can bring happiness and joy. So, let us join together in honoring the Rose Enchanted, and may her love for roses continue to bloom and bring joy to those around her.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "2nd MAy 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 24,
              NextWorkID = 26
          },
          new Art()
          {
              ID = 26,
              URL = "/creative-works/artwork/detail/26/The-Thorny-Beauty-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/26/The-Thorny-Beauty-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "The-Thorny-Beauty-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "The Thorny Beauty - Sticky Note - Art",
              Title = "The Thorny Beauty",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/The-Thorny-Beauty.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I transform the ordinary into something extraordinary. As a drawing artist, I find inspiration in everyday objects and moments, and I bring them to life on sticky notes and canvas. In this post, I want to share with you a beautiful drawing I made. A sketch Which is showing a girl who has a beautiful flower as head and she has thorny skin. I called this art ‘The Thorny Beauty.</p><p class='Art-Detail-Text'>A young girl resembles a flower with a blooming head and spiky prickles covering her body. Despite her delicate appearance, she is protected and ready to defend herself from any harm. Her unique beauty stands out in a crowd, capturing the attention of all who see her. She walks with grace, radiating confidence and strength, reminding us that true beauty lies within.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "5th MAY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 25,
              NextWorkID = 27
          },
          new Art()
          {
              ID = 27,
              URL = "/creative-works/artwork/detail/27/Beach-Beauty-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/27/Beach-Beauty-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Beach-Beauty-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Beach Beauty - Sticky Note - Art",
              Title = "Beach Beauty",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Beach-Beauty.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I transform the ordinary into something extraordinary. As a drawing artist, I find inspiration in everyday objects and moments, and I bring them to life on sticky notes and canvas. In this post, I want to share with you a beautiful drawing I made. A sketch Which is showing a girl who wears a bikini. I called this art ‘Beach Beauty'.</p><p class='Art-Detail-Text'>Art has the power to evoke emotions, challenge perceptions, and inspire conversations. Through my drawings on sticky notes, I invite you to explore the interplay between simplicity and complexity, as well as the beauty found in unexpected places. I hope that this drawing of a beautiful girl in a bikini sparks your imagination and encourages you to see the artistry in everyday moments.</p><p class='Art-Detail-Text'>Thank you for joining me on this artistic journey. Stay tuned for more captivating creations and explorations into the world of art through sticky notes and knife paintings on canvas. Let's continue to appreciate the beauty that surrounds us and find inspiration in the remarkable and unexpected.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "11th MAY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 26,
              NextWorkID = 28
          },
          new Art()
          {
              ID = 28,
              URL = "/creative-works/artwork/detail/28/Big-Bang-Theory-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/28/Big-Bang-Theory-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Big-Bang-Theory-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Big Bang Theory - Sticky Note - Art",
              Title = "Big Bang Theory",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Big-Bang-Theory.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I transform the ordinary into something extraordinary. As a drawing artist, I find inspiration in everyday objects and moments, and I bring them to life on sticky notes and canvas. In this post, I want to share with you a beautiful drawing I made. A sketch Which is showing a Big Bang Theory concept.</p><p class='Art-Detail-Text'>I create this sticky note Art for represent Big Bang Theory and I named this Art 'Big Bang Theory'</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "13th MAY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 27,
              NextWorkID = 29
          },
          new Art()
          {
              ID = 29,
              URL = "/creative-works/artwork/detail/29/Sophia-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/29/Sophia-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Sophia-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Sophia - Sticky Note - Art",
              Title = "Sophia",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Sophia.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where imagination takes flight on the tiniest of canvases. As a drawing artist, I find joy in creating intricate and meaningful art. In this blog post, I want to share with you a heartfelt drawing I made. A tribute to my beloved Sophia.</p><p class='Art-Detail-Text'>In the realm of art, creativity knows no boundaries. With a simple sticky note as their canvas, KhizoOo showcases their extraordinary talent and ability to transform everyday objects into stunning works of art.</p><p class='Art-Detail-Text'>At the heart of this post is Sophia, an exquisite creation born from the artist's imagination. With each stroke of the pen, Sophia springs to life, radiating an aura of grace and charm. The delicate lines and precise details demonstrate the artist's mastery of their craft, showcasing a deep understanding of form, light, and emotion.</p><p class='Art-Detail-Text'>Through Sophia's portrait, I capture a sense of ethereal beauty, evoking a mood that resonates with viewers. The subtle interplay of shadows and highlights adds depth to her character, while her expressive eyes invite us to explore her story. Sophia becomes more than just a drawing; she becomes a vessel for emotions and narratives that can be uniquely interpreted by each observer.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "17th MAY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 28,
              NextWorkID = 30
          },
          new Art()
          {
              ID = 30,
              URL = "/creative-works/artwork/detail/30/Isabella-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/30/Isabella-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Isabella-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Isabella - Sticky Note - Art",
              Title = "Isabella",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Isabella.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where imagination takes flight on the tiniest of canvases. As a drawing artist, I find joy in creating intricate and meaningful art. In this blog post, I want to share with you a heartfelt drawing I made. A tribute to my beloved Isabella.</p><p class='Art-Detail-Text'>Isabella, the central figure of my drawing, is a character that embodies emotion, depth, and the power of expression. Created on a humble sticky note canvas, Isabella's portrait comes alive through intricate details, vibrant colors, and a profound sense of presence.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "19th MAY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 29,
              NextWorkID = 31
          },
          new Art()
          {
              ID = 31,
              URL = "/creative-works/artwork/detail/31/Olivia-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/31/Olivia-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Olivia-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Olivia - Sticky Note - Art",
              Title = "Olivia",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Olivia.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where creativity knows no boundaries. As a drawing artist, I find inspiration in the simplest of things, even the sticky note. In this post, I want to introduce you to a special creation of mine. A delightful drawing on a sticky note featuring a charming and kind-hearted lady named Olivia.</p><p class='Art-Detail-Text'>The drawing portrays Olivia, a lady whose warmth and caring nature radiate from the page. Using the limited space of a sticky note, I captured her endearing personality and attention to detail. Olivia's chubby cheeks and warm smile reflect her jovial nature.</p><p class='Art-Detail-Text'>Olivia's sweet and helpful nature shines through in her expressive eyes and gentle posture. She embodies the essence of kindness and compassion, always ready to lend a hand to those in need.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "21st MAY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 30,
              NextWorkID = 32
          },
          new Art()
          {
              ID = 32,
              URL = "/creative-works/artwork/detail/32/Ava-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/32/Ava-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Ava-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Ava - Sticky Note - Art",
              Title = "Ava",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Ava.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic realm, where creativity knows no bounds! As a drawing artist, I find inspiration in the most unexpected places.Today i want to introduce you to one of my captivating creations on a humble sticky note. Allow me to present Ava, a remarkable character who embodies both inner strength and captivating beauty.</p><p class='Art-Detail-Text'>In a world of artistry, Ava emerges as a symbol of resilience and intelligence. Though depicted as skinny, her allure lies not in conventional standards of beauty but in the unique charm that emanates from her captivating face. The depth of her eyes reflects a mind that brims with wisdom and determination.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "24th MAY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 31,
              NextWorkID = 33
          },
          new Art()
          {
              ID = 33,
              URL = "/creative-works/artwork/detail/33/Mia-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/33/Mia-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Mia-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Mia - Sticky Note - Art",
              Title = "Mia",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Mia.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic realm, where creativity knows no bounds! As a drawing artist, I find inspiration in the most unexpected places. In this blog post, I invite you to explore the captivating world of Mia - The Mind Reader, a character I've brought to life through my unique drawing style.</p><p class='Art-Detail-Text'>Mia is a slender and fashion-forward girl who possesses an uncanny and dangerous ability. The power to read minds. Captured on a humble sticky note, Mia's presence is striking, drawing you into her world of enigma and intrigue.</p><p class='Art-Detail-Text'>The most captivating aspect of Mia's character lies in her extraordinary power—the ability to read minds. As you gaze into her piercing eyes, you can sense the intensity of her gift. The illustration skillfully captures her power.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "25th MAY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 32,
              NextWorkID = 34
          },
          new Art()
          {
              ID = 34,
              URL = "/creative-works/artwork/detail/34/Kia-Sia-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/34/Kia-Sia-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Kia-Sia-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Kia-Sia - Sticky Note - Art",
              Title = "Kia-Sia",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Kia-Sia.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic realm, where creativity knows no bounds! As a drawing artist, I find inspiration in the most unexpected places. Today, I want to introduce you to a unique piece I created featuring two extraordinary sisters, Kia and Sia. While their names may sound innocent, their impact on the world is nothing short of dangerous.</p><p class='Art-Detail-Text'>Kia, the older sister, possesses an air of mystery with her piercing gaze and flowing ebony hair. Her eyes seem to hold a secret knowledge, hinting at the depths of her dangerous persona. With a subtle smirk playing on her lips, Kia exudes an aura of power and mischief.</p><p class='Art-Detail-Text'>In contrast, Sia, the younger sister, exudes an alluring charm that can draw anyone under her spell. Her vibrant red hair cascades down her shoulders, framing a mischievous smile. With a glint in her eyes, Sia carries an undeniable charisma, hiding her treacherous nature behind a veil of innocence.</p><p class='Art-Detail-Text'>Behind their mesmerizing appearance lies a darker truth. Kia and Sia possess extraordinary abilities that make them dangerous to the world. They are not to be taken lightly, as their actions can have far-reaching consequences. Their dynamic presence serves as a reminder that even the most enchanting figures can hold a power that can either protect or destroy.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "27th MAY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 33,
              NextWorkID = 35
          },
          new Art()
          {
              ID = 35,
              URL = "/creative-works/artwork/detail/35/Lily-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/35/Lily-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Lily-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Lily - Sticky Note - Art",
              Title = "Lily",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Lily.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to the mesmerizing world of sticky note art! In this post, we delve into the captivating drawing of Lily, a girl who embodies beauty, fashion, and wealth.</p><p class='Art-Detail-Text'>I captures the essence of Lily's beauty, fashion-forward attitude, and rich lifestyle. Each stroke of the pen on the sticky note canvas reveals a story, inviting viewers to immerse themselves in Lily's world.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "28th MAY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 34,
              NextWorkID = 36
          },
          new Art()
          {
              ID = 36,
              URL = "/creative-works/artwork/detail/36/Charlotte-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/36/Charlotte-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Charlotte-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Charlotte - Sticky Note - Art",
              Title = "Charlotte",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Charlotte.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to the mesmerizing world of sticky note art! In this post, we delve into the captivating drawing of Charlotte, a girl who has a very beautiful smile & her big eyes always attract people.</p><p class='Art-Detail-Text'>Charlotte's eyes sparkle with a depth that captivates the viewer, inviting them into her world. Her smile radiates warmth and joy, leaving a lasting impression on all who encounter her delicate portrait.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "1st JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 35,
              NextWorkID = 37
          },
          new Art()
          {
              ID = 37,
              URL = "/creative-works/artwork/detail/37/Amelia-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/37/Amelia-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Amelia-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Amelia - Sticky Note - Art",
              Title = "Amelia",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Amelia.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to the vibrant world of Amelia, a girl whose life bursts with color and imagination. As a drawing artist, I have captured her story on sticky notes, creating captivating visuals that bring her colorful world to life.</p><p class='Art-Detail-Text'>Amelia's world unfolds on these tiny squares, showcasing her joyful spirit and adventurous nature. The limited space presents a delightful challenge, urging me to express Amelia's vibrant life in a concise and impactful manner.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "2nd JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 36,
              NextWorkID = 38
          },
          new Art()
          {
              ID = 38,
              URL = "/creative-works/artwork/detail/38/Grace-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/38/Grace-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Grace-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Grace - Sticky Note - Art",
              Title = "Grace",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Grace.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to the mesmerizing world of sticky note art! In this post, we delve into the captivating drawing of a beautiful girl named Grace. With her name serving as an inspiration, the artist has brilliantly captured the essence of grace and elegance on a humble sticky note canvas.</p><p class='Art-Detail-Text'>Her eyes are filled with wisdom and kindness, reflecting a depth of character that goes beyond her physical beauty. The artist has masterfully captured the nuances of Grace's persona, evoking a sense of admiration and intrigue.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "5th JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 37,
              NextWorkID = 39
          },
          new Art()
          {
              ID = 39,
              URL = "/creative-works/artwork/detail/39/Stella-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/39/Stella-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Stella-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Stella - Sticky Note - Art",
              Title = "Stella",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Stella.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to the mesmerizing world of sticky note art, where creativity knows no bounds! In this post, we delve into the captivating drawings created by me. Prepare to be enchanted as we introduce you to Stella, a vibrant character who brings music and dance to life through my artistic vision.</p><p class='Art-Detail-Text'>She is a free-spirited girl with an infectious love for music and an eternal dance in her heart. Stella's radiant energy and perpetual motion make her the perfect muse for my drawing.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "3rd JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 38,
              NextWorkID = 40
          },
           new Art()
          {
              ID = 40,
              URL = "/creative-works/artwork/detail/40/Lia-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/43/Lia-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Lia-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Lia - Sticky Note - Art",
              Title = "Lia",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Lia.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where creativity knows no bounds! As a drawing artist, I find inspiration in the simplest of things, and my medium of choice is the sticky note. Today, I am delighted to present to you a captivating drawing featuring a girl named Lia, whose beauty and allure come to life on this tiny canvas.</p><p class='Art-Detail-Text'>Lia embodies the concept of beauty in its purest form. Her delicately curved figure exudes confidence, capturing the essence of feminine strength. Every element of her features, from the softness of her eyes to the gentle curve of her smile, reflects a captivating allure that draws viewers into her world.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "6th JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 39,
              NextWorkID = 41
          },
          new Art()
          {
              ID = 41,
              URL = "/creative-works/artwork/detail/41/Alice-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/41/Alice-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Alice-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Alice - Sticky Note - Art",
              Title = "Alice",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Alice.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my world of artistry! </p><p class='Art-Detail-Text'>In this post, I am delighted to share with you a unique drawing I created on sticky notes. In this particular artwork, I draw a captivating character named Alice, who possesses a mix of beauty and complexity.</p><p class='Art-Detail-Text'>Alice's appearance is that of a classic beauty, with soft, flowing hair and delicate features. The details of her face are carefully captured. Alice is depicted as someone who smokes excessively, hinting at a deeper complexity within her character.</p><p class='Art-Detail-Text'>n</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "7th JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 40,
              NextWorkID = 42
          },
          new Art()
          {
              ID = 42,
              URL = "/creative-works/artwork/detail/42/Blossom-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/42/Blossom-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Blossom-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Blossom - Sticky Note - Art",
              Title = "Blossom",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Blossom.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to the world of sticky note art, where imagination knows no bounds and creativity finds its voice. In this post, we delve into the captivating drawings of a talented artist who brings to life a charming character named Blossom. A girl who embodies beauty, humor, and a remarkable range of facial expressions.</p><p class='Art-Detail-Text'>In the realm of art, creativity often finds its way onto unconventional canvases, and sticky notes serve as the medium for the artist's boundless imagination.</p><p class='Art-Detail-Text'>Blossom, the star of these sticky note drawings, is a captivating girl with an undeniable allure. Her beauty radiates from the pages, drawing viewers into her whimsical world. But what truly sets Blossom apart is her ability to captivate hearts with her infectious sense of humor and a myriad of facial expressions.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "8th JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 41,
              NextWorkID = 43
          },
          new Art()
          {
              ID = 43,
              URL = "/creative-works/artwork/detail/43/Little-Princess-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/43/Little-Princess-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Little-Princess-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Little Princess - Sticky Note - Art",
              Title = "Little Princess",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Little-Princess.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to the world of sticky note art, I want to introduce you to one of my favorite creations. A charming little princess character that has captured the hearts of many.</p><p class='Art-Detail-Text'>Meet the Little Princess, a delightful character brought to life on a small sticky note canvas. With her flowing gown, twinkling eyes, and a crown perched upon her head, she exudes an air of grace and innocence.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "9th JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 42,
              NextWorkID = 43
          },
          new Art()
          {
              ID = 44,
              URL = "/creative-works/artwork/detail/44/Astro-Love-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/44/Astro-Love-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Astro-Love-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Astro Love - Sticky Note - Art",
              Title = "Astro Love",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Astro-Love.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where imagination knows no bounds! As a drawing artist specializing in sticky note art, I love transforming these tiny pieces of paper into captivating creations. In this blog post, I am excited to share one of my most beloved works. A delightful doodle featuring an astronaut and his celestial surprise for his beloved.</p><p class='Art-Detail-Text'>Imagine a cosmic scene unfolding on a sticky note canvas. In this artwork, an astronaut floats gracefully amidst a backdrop of swirling galaxies and shining stars. </p><p class='Art-Detail-Text'>With a gentle smile, he presents a bouquet of balloons that resemble colorful planets, each one representing a unique and precious moment shared between the astronaut and his lover.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "11th JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 43,
              NextWorkID = 45
          },
          new Art()
          {
              ID = 45,
              URL = "/creative-works/artwork/detail/45/Freedom-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/45/Freedom-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Freedom-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Freedom - Sticky Note - Art",
              Title = "Freedom",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Freedom.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where creativity knows no bounds. In this website post, I want to share with you one of my unique creations. A captivating drawing on a sticky note that encapsulates the essence of freedom. </p><p class='Art-Detail-Text'>With just a simple doodle, I have brought to life a scene where a girl's face is hidden amidst the clouds, seemingly soaring through the sky. Join me as we explore the story behind this whimsical artwork and the message of liberation it conveys.</p><p class='Art-Detail-Text'>In this particular drawing, I have taken inspiration from the boundless nature of the sky and the concept of personal freedom.</p><p class='Art-Detail-Text'>The girl appears to be floating in the air, as if defying the constraints of gravity.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "13th JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 44,
              NextWorkID = 46
          },
          new Art()
          {
              ID = 46,
              URL = "/creative-works/artwork/detail/46/Rapunzel-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/46/Rapunzel-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Rapunzel-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Rapunzel - Sticky Note - Art",
              Title = "Rapunzel",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Rapunzel.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I breathe life into the humble sticky note and create captivating doodles that mesmerize the senses. In this post, I would like to showcase a unique creation of mine. A stunning drawing on a sticky note featuring a mesmerizing depiction of a pretty girl with impossibly long hair.</p><p class='Art-Detail-Text'>In this particular artwork, I wanted to capture the essence of enchantment and whimsy. The drawing portrays a pretty girl lying gracefully on the earth, her long hair cascading around her in a perfect circle. </p><p class='Art-Detail-Text'>The flowing locks, meticulously crafted on the sticky note canvas, create a captivating sight, as if the girl has been enveloped by a magical halo of her own tresses.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "15th JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 45,
              NextWorkID = 47
          },
          new Art()
          {
              ID = 47,
              URL = "/creative-works/artwork/detail/47/Unveiling-Beauty-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/47/Unveiling-Beauty-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Unveiling-Beauty-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Unveiling Beauty - Sticky Note - Art",
              Title = "Unveiling Beauty",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Unveiling-Beauty.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to the captivating world of sticky note artistry! As a drawing artist, I am thrilled to share with you one of my unique creations. A mesmerizing doodle that showcases the beauty of hidden faces. </p><p class='Art-Detail-Text'>In this artwork, I have skillfully blended the delicate lines of a beautiful girl's face with an array of diverse hands, symbolizing the multitude of individuals who shape our lives.</p><p class='Art-Detail-Text'>Using the humble medium of sticky notes, I have crafted a stunning piece that effortlessly blends simplicity and complexity. At first glance, the doodle appears to be a collection of colorful hands, each with its own distinct style and character.</p><p class='Art-Detail-Text'>This artwork conveys a powerful message about the interconnectedness of humanity and the beauty that lies within each individual. The diversity of the hands symbolizes the unique qualities and experiences that shape our identities. It reminds us that our individuality is not separate from the collective, but rather a part of a larger tapestry of humanity.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "19th JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 46,
              NextWorkID = 48
          },
          new Art()
          {
              ID = 48,
              URL = "/creative-works/artwork/detail/48/Little-Professor-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/48/Little-Professor-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Little-Professor-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Little Professor - Sticky Note - Art",
              Title = "Little Professor",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Little-Professor.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to the whimsical world of sticky note drawings, where creativity knows no bounds. In this post, we dive into the captivating artistry of a talented drawing artist who specializes in transforming humble sticky notes into miniature works of art.</p><p class='Art-Detail-Text'>In this post, we have delved into the captivating world of sticky note drawings and explored the endearing character of the Little Professor. Through the artist's skill and creativity, sticky notes have transformed into captivating works of art, proving that inspiration can be found in the simplest of mediums.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "23rd JUNE 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 47,
              NextWorkID = 49
          },
          new Art()
          {
              ID = 49,
              URL = "/creative-works/artwork/detail/49/Beauty-Behind-Flowers-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/49/Beauty-Behind-Flowers-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Beauty-Behind-Flowers-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Beauty Behind Flowers - Sticky Note - Art",
              Title = "Beauty Behind Flowers",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Beauty-Behind-Flowers.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Welcome to my artistic world, where I weave captivating tales on tiny canvases known as sticky notes. As a drawing artist, I find joy and inspiration in the simplest of things. In this post, I want to share with you one of my favorite creations. A mesmerizing doodle featuring a beautiful girl hiding her face behind a bouquet of flowers.</p><p class='Art-Detail-Text'>As a drawing artist, I find joy in the process of creating art that touches hearts and sparks imagination. My doodle of the beautiful girl behind the flowers is just one of the many stories I weave with my art. With each drawing, I hope to inspire a sense of wonder in the world around us and encourage viewers to find beauty in the simplest of moments.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "1st JULY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 48,
              NextWorkID = 50
          },
          new Art()
          {
              ID = 50,
              URL = "/creative-works/artwork/detail/50/Art-&-Depression-Sticky-Note-Art",
              SITE_URL = "/creative-works/artwork/detail/50/Art-&-Depression-Sticky-Note-Art",
              Tags = "[\"Art\",\"Sticky-Note\"]",
              Slug = "Art-&-Depression-Sticky-Note-Art",
              DataGroup = "[\"all\",\"stickynotes\"]",
              Heading = "Art & Depression - Sticky Note - Art",
              Title = "Art & Depression",
              SubTitle = "Sticky Note - Art",
              IMG = "images/MyArts/Art-&-Depression.jpg",
              VIDEO = "",
              Desription = "<p class='Art-Detail-Text'>Creating art on sticky notes has become my artistic signature, allowing me to explore emotions, thoughts, and vulnerabilities through abstract expression. I invite you to explore my gallery and experience the depth of emotions that these tiny masterpieces hold. Let us embrace the power of art to foster understanding and connection as we navigate the complexities of life and emotions together.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='/MyWorkFlow-MyArtfulness'>MORE</a>] to step into a world where creativity dances with imagination. Where colors come alive. Art whispers its secrets.</p><p class='Art-Detail-Text'>Visit [<a class='L-C' href='https://opensea.io/KhizoOo_'>MORE</a>] to visit my OpenSea account.</p>",
              Type = "Art", ArtworkTypeID = 1,
              Category = "Sticky Note",
              CreatedOn = "2nd JULY 2023",

              Facebook = "",
              Instagram = "",
              LinkedIn = "",
              YouTube = "",
              OpenSea = "",
              Twitter = "",
              TikTok = "",
              Pinterest = "",
              Snapchat = "",

              PreviousWorkID = 49,
              NextWorkID = 51
          },
        };

        public List<Art> GetMyArts(int Count)
        {
            List<Art> Data = new List<Art>();
            Data = MyAllArts.Take(Count).ToList();
            return Data;
        }

        public Art GetMyArt(long ID)
        {
            Art Data = new Art();
            Data = MyAllArts.FirstOrDefault(A => A.ID == ID);
            return Data;
        }

        public Art GetMyArt(string Slug)
        {
            Art Data = new Art();
            Data = MyAllArts.FirstOrDefault(A => A.Slug == Slug);
            return Data;
        }

        public Art GetMyArt(long ID , string Slug)
        {
            Art Data = new Art();
            Data = MyAllArts.FirstOrDefault(A => A.ID == ID && A.Slug == Slug);
            return Data;
        }

        public List<ArtworkType> Get_Artwork_Types()
        {
            List<ArtworkType> Data = new List<ArtworkType>();
            Data = ArtworkTypes.ToList();
            return Data;
        }
    }

}

