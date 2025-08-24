
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
          new Art() { Slug = "1st-day-at-sea",Title = "1st Day at Sea",IMG = "artworks/img/1st-day-at-sea.jpg",Type = "Sticky Note" },
            new Art() { Slug = "a-sea-fish-story",Title = "A Sea Fish Story",IMG = "artworks/img/a-sea-fish-story.jpg",Type = "Sticky Note" },
            new Art() { Slug = "a-skull-rose-fusion",Title = "A Skull-Rose Fusion",IMG = "artworks/img/a-skull-rose-fusion.jpg",Type = "Sticky Note" },
            new Art() { Slug = "back-beauty",Title = "Back Beauty",IMG = "artworks/img/back-beauty.jpg",Type = "Sticky Note" },
            new Art() { Slug = "bearded-titan",Title = "Bearded Titan",IMG = "artworks/img/bearded-titan.jpg",Type = "Sticky Note" },
            new Art() { Slug = "beautiful-cats",Title = "Beautiful Cats",IMG = "artworks/img/beautiful-cats.jpg",Type = "Sticky Note" },
            new Art() { Slug = "beauty-in-eyes",Title = "Beauty in Eyes",IMG = "artworks/img/beauty-in-eyes.jpg",Type = "Sticky Note" },
            new Art() { Slug = "big-bang-theory",Title = "Big Bang Theory",IMG = "artworks/img/big-bang-theory.jpg",Type = "Sticky Note" },
            new Art() { Slug = "big-slave",Title = "Big Slave",IMG = "artworks/img/big-slave.jpg",Type = "Sticky Note" },
            new Art() { Slug = "big-things",Title = "Big Things",IMG = "artworks/img/big-things.jpg",Type = "Sticky Note" },
            new Art() { Slug = "blind-hope",Title = "Blind Hope",IMG = "artworks/img/blind-hope.jpg",Type = "Sticky Note" },
            new Art() { Slug = "blocked-view",Title = "Blocked View",IMG = "artworks/img/blocked-view.jpg",Type = "Sticky Note" },
            new Art() { Slug = "blooming-frog",Title = "Blooming Frog",IMG = "artworks/img/blooming-frog.jpg",Type = "Sticky Note" },
            new Art() { Slug = "blooming-genetics",Title = "Blooming Genetics",IMG = "artworks/img/blooming-genetics.jpg",Type = "Sticky Note" },
            new Art() { Slug = "blue-chef-remy",Title = "Blue Chef Remy",IMG = "artworks/img/blue-chef-remy.jpg",Type = "Sticky Note" },
            new Art() { Slug = "broken-hand",Title = "Broken Hand",IMG = "artworks/img/broken-hand.jpg",Type = "Sticky Note" },
            new Art() { Slug = "bubble-burst",Title = "Bubble Burst",IMG = "artworks/img/bubble-burst.jpg",Type = "Sticky Note" },
            new Art() { Slug = "butterfly",Title = "Butterfly",IMG = "artworks/img/butterfly.jpg",Type = "Sticky Note" },
            new Art() { Slug = "captured-mermaid",Title = "Captured Mermaid",IMG = "artworks/img/captured-mermaid.jpg",Type = "Sticky Note" },
            new Art() { Slug = "cat-and-coffee-mug",Title = "Cat and Coffee Mug",IMG = "artworks/img/cat-and-coffee-mug.jpg",Type = "Sticky Note" },
            new Art() { Slug = "chaotic-vision",Title = "Chaotic Vision",IMG = "artworks/img/chaotic-vision.jpg",Type = "Sticky Note" },
            new Art() { Slug = "crocodile-&-whiskey",Title = "Crocodile & Whiskey",IMG = "artworks/img/crocodile-&-whiskey.jpg",Type = "Sticky Note" },
            new Art() { Slug = "dead-land",Title = "Dead Land",IMG = "artworks/img/dead-land.jpg",Type = "Sticky Note" },
            new Art() { Slug = "dreamer",Title = "Dreamer",IMG = "artworks/img/dreamer.jpg",Type = "Sticky Note" },
            new Art() { Slug = "echoes-of-the-forest-house",Title = "Echoes of the Forest House",IMG = "artworks/img/echoes-of-the-forest-house.jpg",Type = "Sticky Note" },
            new Art() { Slug = "enchanted-lamp",Title = "Enchanted Lamp",IMG = "artworks/img/enchanted-lamp.jpg",Type = "Sticky Note" },
            new Art() { Slug = "enchanting-muse",Title = "Enchanting Muse",IMG = "artworks/img/enchanting-muse.jpg",Type = "Sticky Note" },
            new Art() { Slug = "eternal-blaze",Title = "Eternal Blaze",IMG = "artworks/img/eternal-blaze.jpg",Type = "Sticky Note" },
            new Art() { Slug = "expressions",Title = "Expressions",IMG = "artworks/img/expressions.jpg",Type = "Sticky Note" },
            new Art() { Slug = "eyes-that-speak",Title = "Eyes That Speak",IMG = "artworks/img/eyes-that-speak.jpg",Type = "Sticky Note" },
            new Art() { Slug = "fall-of-a-model",Title = "Fall of a Model",IMG = "artworks/img/fall-of-a-model.jpg",Type = "Sticky Note" },
            new Art() { Slug = "fanon-the-angry-bird",Title = "Fanon the Angry Bird",IMG = "artworks/img/fanon-the-angry-bird.jpg",Type = "Sticky Note" },
            new Art() { Slug = "flirting",Title = "Flirting",IMG = "artworks/img/flirting.jpg",Type = "Sticky Note" },
            new Art() { Slug = "flower-01",Title = "Flower 01",IMG = "artworks/img/flower-01.jpg",Type = "Sticky Note" },
            new Art() { Slug = "flower-02",Title = "Flower 02",IMG = "artworks/img/flower-02.jpg",Type = "Sticky Note" },
            new Art() { Slug = "flower-03",Title = "Flower 03",IMG = "artworks/img/flower-03.jpg",Type = "Sticky Note" },
            new Art() { Slug = "flower-04",Title = "Flower 04",IMG = "artworks/img/flower-04.jpg",Type = "Sticky Note" },
            new Art() { Slug = "flower-05",Title = "Flower 05",IMG = "artworks/img/flower-05.jpg",Type = "Sticky Note" },
            new Art() { Slug = "flowered-dreams",Title = "Flowered Dreams",IMG = "artworks/img/flowered-dreams.jpg",Type = "Sticky Note" },
            new Art() { Slug = "flying-key",Title = "Flying Key",IMG = "artworks/img/flying-key.jpg",Type = "Sticky Note" },
            new Art() { Slug = "fulgent-life",Title = "Fulgent Life",IMG = "artworks/img/fulgent-life.jpg",Type = "Sticky Note" },
            new Art() { Slug = "giraffe",Title = "Giraffe",IMG = "artworks/img/giraffe.jpg",Type = "Sticky Note" },
            new Art() { Slug = "girl-and-her-rose-crown",Title = "Girl and Her Rose Crown",IMG = "artworks/img/girl-and-her-rose-crown.jpg",Type = "Sticky Note" },
            new Art() { Slug = "girl-with-no-eyes",Title = "Girl With No Eyes",IMG = "artworks/img/girl-with-no-eyes.jpg",Type = "Sticky Note" },
            new Art() { Slug = "girl-with-painted-face",Title = "Girl with Painted Face",IMG = "artworks/img/girl-with-painted-face.jpg",Type = "Sticky Note" },
            new Art() { Slug = "glamour",Title = "Glamour",IMG = "artworks/img/glamour.jpg",Type = "Sticky Note" },
            new Art() { Slug = "good-morning",Title = "Good Morning",IMG = "artworks/img/good-morning.jpg",Type = "Sticky Note" },
            new Art() { Slug = "gothic-romance",Title = "Gothic Romance",IMG = "artworks/img/gothic-romance.jpg",Type = "Sticky Note" },
            new Art() { Slug = "great-sea-beast-terror",Title = "Great Sea Beast Terror",IMG = "artworks/img/great-sea-beast-terror.jpg",Type = "Sticky Note" },
            new Art() { Slug = "green-skirt-girl",Title = "Green Skirt Girl",IMG = "artworks/img/green-skirt-girl.jpg",Type = "Sticky Note" },
            new Art() { Slug = "guard-tower",Title = "Guard Tower",IMG = "artworks/img/guard-tower.jpg",Type = "Sticky Note" },
            new Art() { Slug = "hanging-kicks",Title = "Hanging Kicks",IMG = "artworks/img/hanging-kicks.jpg",Type = "Sticky Note" },
            new Art() { Slug = "haunted-book",Title = "Haunted Book",IMG = "artworks/img/haunted-book.jpg",Type = "Sticky Note" },
            new Art() { Slug = "haunted-cabin",Title = "Haunted Cabin",IMG = "artworks/img/haunted-cabin.jpg",Type = "Sticky Note" },
            new Art() { Slug = "haunted-red-fort-of-khziooo",Title = "Haunted Red Fort of Khziooo",IMG = "artworks/img/haunted-red-fort-of-khziooo.jpg",Type = "Sticky Note" },
            new Art() { Slug = "heart-grenade",Title = "Heart Grenade",IMG = "artworks/img/heart-grenade.jpg",Type = "Sticky Note" },
            new Art() { Slug = "house-blender",Title = "House Blender",IMG = "artworks/img/house-blender.jpg",Type = "Sticky Note" },
            new Art() { Slug = "huda",Title = "Huda",IMG = "artworks/img/huda.jpg",Type = "Sticky Note" },
            new Art() { Slug = "husband-punch",Title = "Husband Punch",IMG = "artworks/img/husband-punch.jpg",Type = "Sticky Note" },
            new Art() { Slug = "i-believe-i-can-fly",Title = "I Believe I Can FlY",IMG = "artworks/img/i-believe-i-can-fly.jpg",Type = "Sticky Note" },
            new Art() { Slug = "ice-cream",Title = "Ice cream",IMG = "artworks/img/ice-cream.jpg",Type = "Sticky Note" },
            new Art() { Slug = "jack-and-sally-01",Title = "Jack and Sally 01",IMG = "artworks/img/jack-and-sally-01.jpg",Type = "Sticky Note" },
            new Art() { Slug = "jack-and-sally-02",Title = "Jack and Sally 02",IMG = "artworks/img/jack-and-sally-02.jpg",Type = "Sticky Note" },
            new Art() { Slug = "jenni",Title = "Jenni",IMG = "artworks/img/jenni.jpg",Type = "Sticky Note" },
            new Art() { Slug = "junior-professor",Title = "Junior Professor",IMG = "artworks/img/junior-professor.jpg",Type = "Sticky Note" },
            new Art() { Slug = "key-of-hearts",Title = "Key of Hearts",IMG = "artworks/img/key-of-hearts.jpg",Type = "Sticky Note" },
            new Art() { Slug = "legendary-war-horse",Title = "Legendary War Horse",IMG = "artworks/img/legendary-war-horse.jpg",Type = "Sticky Note" },
            new Art() { Slug = "life-within-the-jar",Title = "Life Within the Jar",IMG = "artworks/img/life-within-the-jar.jpg",Type = "Sticky Note" },
            new Art() { Slug = "little-princess",Title = "Little Princess",IMG = "artworks/img/little-princess.jpg",Type = "Sticky Note" },
            new Art() { Slug = "lost-and-found",Title = "Lost and Found",IMG = "artworks/img/lost-and-found.jpg",Type = "Sticky Note" },
            new Art() { Slug = "luna-pink-cat",Title = "Luna Pink Cat",IMG = "artworks/img/luna-pink-cat.jpg",Type = "Sticky Note" },
            new Art() { Slug = "magical-pencil",Title = "Magical Pencil",IMG = "artworks/img/magical-pencil.jpg",Type = "Sticky Note" },
            new Art() { Slug = "midnight-muse",Title = "Midnight Muse",IMG = "artworks/img/midnight-muse.jpg",Type = "Sticky Note" },
            new Art() { Slug = "monster",Title = "Monster",IMG = "artworks/img/monster.jpg",Type = "Sticky Note" },
            new Art() { Slug = "morning-rituals",Title = "Morning Rituals",IMG = "artworks/img/morning-rituals.jpg",Type = "Sticky Note" },
            new Art() { Slug = "mortaliy-flame",Title = "Mortaliy Flame",IMG = "artworks/img/mortaliy-flame.jpg",Type = "Sticky Note" },
            new Art() { Slug = "my-max",Title = "My Max",IMG = "artworks/img/my-max.jpg",Type = "Sticky Note" },
            new Art() { Slug = "mysterious-brick-cave",Title = "Mysterious Brick Cave",IMG = "artworks/img/mysterious-brick-cave.jpg",Type = "Sticky Note" },
            new Art() { Slug = "mysterious-giantess",Title = "Mysterious Giantess",IMG = "artworks/img/mysterious-giantess.jpg",Type = "Sticky Note" },
            new Art() { Slug = "mystical-beauty",Title = "Mystical Beauty",IMG = "artworks/img/mystical-beauty.jpg",Type = "Sticky Note" },
            new Art() { Slug = "mystical-hand",Title = "Mystical Hand",IMG = "artworks/img/mystical-hand.jpg",Type = "Sticky Note" },
            new Art() { Slug = "naked-beauty",Title = "Naked Beauty",IMG = "artworks/img/naked-beauty.jpg",Type = "Sticky Note" },
            new Art() { Slug = "nature-excavation",Title = "Nature Excavation",IMG = "artworks/img/nature-excavation.jpg",Type = "Sticky Note" },
            new Art() { Slug = "ocean-light",Title = "Ocean Light",IMG = "artworks/img/ocean-light.jpg",Type = "Sticky Note" },
            new Art() { Slug = "peak-perfection",Title = "Peak Perfection",IMG = "artworks/img/peak-perfection.jpg",Type = "Sticky Note" },
            new Art() { Slug = "portal-to-the-past",Title = "Portal to the Past",IMG = "artworks/img/portal-to-the-past.jpg",Type = "Sticky Note" },
            new Art() { Slug = "positive-in-everything",Title = "Positive In Everything",IMG = "artworks/img/positive-in-everything.jpg",Type = "Sticky Note" },
            new Art() { Slug = "prey",Title = "Prey",IMG = "artworks/img/prey.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-01",Title = "Random 01",IMG = "artworks/img/random-01.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-02",Title = "Random 02",IMG = "artworks/img/random-02.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-03",Title = "Random 03",IMG = "artworks/img/random-03.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-04",Title = "Random 04",IMG = "artworks/img/random-04.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-05",Title = "Random 05",IMG = "artworks/img/random-05.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-06",Title = "Random 06",IMG = "artworks/img/random-06.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-07",Title = "Random 07",IMG = "artworks/img/random-07.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-08",Title = "Random 08",IMG = "artworks/img/random-08.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-09",Title = "Random 09",IMG = "artworks/img/random-09.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-10",Title = "Random 10",IMG = "artworks/img/random-10.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-11",Title = "Random 11",IMG = "artworks/img/random-11.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-12",Title = "Random 12",IMG = "artworks/img/random-12.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-13",Title = "Random 13",IMG = "artworks/img/random-13.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-14",Title = "Random 14",IMG = "artworks/img/random-14.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-15",Title = "Random 15",IMG = "artworks/img/random-15.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-16",Title = "Random 16",IMG = "artworks/img/random-16.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-17",Title = "Random 17",IMG = "artworks/img/random-17.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-18",Title = "Random 18",IMG = "artworks/img/random-18.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-19",Title = "Random 19",IMG = "artworks/img/random-19.jpg",Type = "Sticky Note" },
            new Art() { Slug = "random-20",Title = "Random 20",IMG = "artworks/img/random-20.jpg",Type = "Sticky Note" },
            new Art() { Slug = "rapunzel",Title = "Rapunzel",IMG = "artworks/img/rapunzel.jpg",Type = "Sticky Note" },
            new Art() { Slug = "rare-intelligent-&-slave-creature",Title = "Rare Intelligent & Slave Creature",IMG = "artworks/img/rare-intelligent-&-slave-creature.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-01",Title = "Raw Beauty 01",IMG = "artworks/img/raw-beauty-01.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-02",Title = "Raw Beauty 02",IMG = "artworks/img/raw-beauty-02.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-03",Title = "Raw Beauty 03",IMG = "artworks/img/raw-beauty-03.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-04",Title = "Raw Beauty 04",IMG = "artworks/img/raw-beauty-04.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-05",Title = "Raw Beauty 05",IMG = "artworks/img/raw-beauty-05.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-06",Title = "Raw Beauty 06",IMG = "artworks/img/raw-beauty-06.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-07",Title = "Raw Beauty 07",IMG = "artworks/img/raw-beauty-07.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-08",Title = "Raw Beauty 08",IMG = "artworks/img/raw-beauty-08.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-09",Title = "Raw Beauty 09",IMG = "artworks/img/raw-beauty-09.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-10",Title = "Raw Beauty 10",IMG = "artworks/img/raw-beauty-10.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-11",Title = "Raw Beauty 11",IMG = "artworks/img/raw-beauty-11.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-12",Title = "Raw Beauty 12",IMG = "artworks/img/raw-beauty-12.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-13",Title = "Raw Beauty 13",IMG = "artworks/img/raw-beauty-13.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-14",Title = "Raw Beauty 14",IMG = "artworks/img/raw-beauty-14.jpg",Type = "Sticky Note" },
            new Art() { Slug = "raw-beauty-15",Title = "Raw Beauty 15",IMG = "artworks/img/raw-beauty-15.jpg",Type = "Sticky Note" },
            new Art() { Slug = "rebirth",Title = "Rebirth",IMG = "artworks/img/rebirth.jpg",Type = "Sticky Note" },
            new Art() { Slug = "red-death",Title = "Red Death",IMG = "artworks/img/red-death.jpg",Type = "Sticky Note" },
            new Art() { Slug = "red-gandalf",Title = "Red Gandalf",IMG = "artworks/img/red-gandalf.jpg",Type = "Sticky Note" },
            new Art() { Slug = "rose-enchanted",Title = "Rose Enchanted",IMG = "artworks/img/rose-enchanted.jpg",Type = "Sticky Note" },
            new Art() { Slug = "rose-head",Title = "Rose Head",IMG = "artworks/img/rose-head.jpg",Type = "Sticky Note" },
            new Art() { Slug = "rustic-rum-cup",Title = "Rustic Rum Cup",IMG = "artworks/img/rustic-rum-cup.jpg",Type = "Sticky Note" },
            new Art() { Slug = "sad-water",Title = "Sad Water",IMG = "artworks/img/sad-water.jpg",Type = "Sticky Note" },
            new Art() { Slug = "seeing-speaking-listening",Title = "Seeing Speaking Listening",IMG = "artworks/img/seeing-speaking-listening.jpg",Type = "Sticky Note" },
            new Art() { Slug = "shadow-watcher",Title = "Shadow Watcher",IMG = "artworks/img/shadow-watcher.jpg",Type = "Sticky Note" },
            new Art() { Slug = "shiny-blue-eyes-girl",Title = "Shiny Blue Eyes Girl",IMG = "artworks/img/shiny-blue-eyes-girl.jpg",Type = "Sticky Note" },
            new Art() { Slug = "silent-bonds",Title = "Silent Bonds",IMG = "artworks/img/silent-bonds.jpg",Type = "Sticky Note" },
            new Art() { Slug = "silent-scream",Title = "Silent Scream",IMG = "artworks/img/silent-scream.jpg",Type = "Sticky Note" },
            new Art() { Slug = "smiling-nightmare",Title = "Smiling Nightmare",IMG = "artworks/img/smiling-nightmare.jpg",Type = "Sticky Note" },
            new Art() { Slug = "smoker-lips",Title = "Smoker Lips",IMG = "artworks/img/smoker-lips.jpg",Type = "Sticky Note" },
            new Art() { Slug = "space-love",Title = "Space Love",IMG = "artworks/img/space-love.jpg",Type = "Sticky Note" },
            new Art() { Slug = "speaking-eyes",Title = "Speaking Eyes",IMG = "artworks/img/speaking-eyes.jpg",Type = "Sticky Note" },
            new Art() { Slug = "story-of-the-acropolis",Title = "Story of the Acropolis",IMG = "artworks/img/story-of-the-acropolis.jpg",Type = "Sticky Note" },
            new Art() { Slug = "stylish-rooster",Title = "Stylish Rooster",IMG = "artworks/img/stylish-rooster.jpg",Type = "Sticky Note" },
            new Art() { Slug = "tale-of-ella-two-faces",Title = "Tale of Ella Two Faces",IMG = "artworks/img/tale-of-ella-two-faces.jpg",Type = "Sticky Note" },
            new Art() { Slug = "the-spot",Title = "The Spot",IMG = "artworks/img/the-spot.jpg",Type = "Sticky Note" },
            new Art() { Slug = "tree-house-01",Title = "Tree House 01",IMG = "artworks/img/tree-house-01.jpg",Type = "Sticky Note" },
            new Art() { Slug = "tree-house-02",Title = "Tree House 02",IMG = "artworks/img/tree-house-02.jpg",Type = "Sticky Note" },
            new Art() { Slug = "tree-house-03",Title = "Tree House 03",IMG = "artworks/img/tree-house-03.jpg",Type = "Sticky Note" },
            new Art() { Slug = "twisting-hand",Title = "Twisting Hand",IMG = "artworks/img/twisting-hand.jpg",Type = "Sticky Note" },
            new Art() { Slug = "unseen-whispers",Title = "Unseen Whispers",IMG = "artworks/img/unseen-whispers.jpg",Type = "Sticky Note" },
            new Art() { Slug = "unstoppable-strength",Title = "Unstoppable Strength",IMG = "artworks/img/unstoppable-strength.jpg",Type = "Sticky Note" },
            new Art() { Slug = "watchful-wanderer",Title = "Watchful Wanderer",IMG = "artworks/img/watchful-wanderer.jpg",Type = "Sticky Note" },
            new Art() { Slug = "whale-trip",Title = "Whale Trip",IMG = "artworks/img/whale-trip.jpg",Type = "Sticky Note" },
            new Art() { Slug = "wise-toad",Title = "Wise Toad",IMG = "artworks/img/wise-toad.jpg",Type = "Sticky Note" },
            new Art() { Slug = "young-girl-vs-dark-wind",Title = "Young Girl vs Dark Wind",IMG = "artworks/img/young-girl-vs-dark-wind.jpg",Type = "Sticky Note" },
            new Art() { Slug = "2-worlds-whale",Title = "2 Worlds Whale",IMG = "artworks/img/2-worlds-whale.jpg",Type = "Sticky Note" },
            new Art() { Slug = "dreams-&-reality",Title = "Dreams & Reality",IMG = "artworks/img/dreams-&-reality.jpg",Type = "Sticky Note" },
            new Art() { Slug = "lost-in-thought",Title = "Lost in Thought",IMG = "artworks/img/lost-in-thought.jpg",Type = "Sticky Note" },
            new Art() { Slug = "wild-eyed-wanderer",Title = "Wild Eyed Wanderer",IMG = "artworks/img/wild-eyed-wanderer.jpg",Type = "Sticky Note" },
            new Art() { Slug = "silent-screams",Title = "Silent Screams",IMG = "artworks/img/silent-screams.jpg",Type = "Sticky Note" },
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