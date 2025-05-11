
using khizooo.AppData.SharedHelper;

namespace khizooo.AppData
{
    public class Infographic
    {
        public string URL { get; set; }
        public string Tags { get; set; }
        public string Slug { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string IMG { get; set; }
        public string List_IMG_URL { get; internal set; }
        public string Type { get; set; }
        public string CreatedOn { get; set; }

        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string X { get; set; }
        public string TikTok { get; set; }
        public string Pinterest { get; set; }

        public List<KeyTerm> KeyTerms { get; set; }
        public string SeoTitle { get; set; }
        public string SeoKeyWords { get; set; }
        public string SeoDescription { get; set; }


        // PENDINGS
        public long ModuleID { get; set; }
        public string PunchLine { get; internal set; }
    }

    public class MyInfographics
    {
        private List<Infographic> MyAllInfographics = new List<Infographic>()
        {
        //new Infographic()
        //{
        //    Slug = "how-blockchain-works",
        //    Title = "How Blockchain Works?",
        //    PunchLine = "Unlocking the Power of Blockchain: A Journey through Transparency, Security, and Innovation",
        //    IMG = "images/info-test.png",
        //     Type = "Blockchain",
        //    CreatedOn = "1st AUG 2023",

        //    URL = "/infographic/how-blockchain-works",
        //    Tags = "[\"all\", \"Infographic\", \"Blockchain\", \"how\"]",

        //    KeyTerms = new List<KeyTerm>()
        //    {
        //        new KeyTerm {
        //            Location = "left",
        //            Term = "Transaction",
        //            Answer = "An exchange of value or data between parties recorded on the blockchain."
        //        },
        //        new KeyTerm {
        //            Location = "left",
        //            Term = "Network",
        //            Answer = "A group of interconnected computers that communicate and share data."
        //        },
        //        new KeyTerm {
        //            Location = "left",
        //            Term = "Hash",
        //            Answer = "A unique string of characters that represents data securely."
        //        },
        //        new KeyTerm {
        //            Location = "left",
        //            Term = "Decentralization",
        //            Answer = "Distribution of control across multiple independent parties or nodes."
        //        },
        //        new KeyTerm {
        //            Location = "left",
        //            Term = "Database",
        //            Answer = "An organized collection of structured data stored electronically."
        //        },
        //        new KeyTerm {
        //            Location = "left",
        //            Term = "Consensus Mechanism",
        //            Answer = "A process used to agree on the validity of transactions in a network."
        //        },
        //        new KeyTerm {
        //            Location = "right",
        //            Term = "Cryptography",
        //            Answer = "Techniques used to secure and protect information using mathematical methods."
        //        },
        //        new KeyTerm {
        //            Location = "right",
        //            Term = "Encryption",
        //            Answer = "Converting data into a coded format to prevent unauthorized access."
        //        },
        //        new KeyTerm {
        //            Location = "right",
        //            Term = "Cryptocurrencies",
        //            Answer = "Digital currencies that use blockchain technology for secure transactions."
        //        },
        //        new KeyTerm {
        //            Location = "right",
        //            Term = "Bitcoin",
        //            Answer = "The first decentralized digital currency, enabling peer-to-peer transactions."
        //        },
        //        new KeyTerm {
        //            Location = "right",
        //            Term = "Supply Chain",
        //            Answer = "The entire system of producing and delivering a product from raw materials to the end user."
        //        },
        //        new KeyTerm {
        //            Location = "right",
        //            Term = "Smart Contracts",
        //            Answer = "Self-executing contracts with terms written into code on a blockchain."
        //        }
        //    },

        //    SeoTitle = "How Blockchain Works? - Infographic - KhizoOo",
        //    SeoKeyWords = "how blockchain works, blockchain infographic, blockchain glossary, blockchain technology, blockchain explained, blockchain basics, khizooo",
        //    SeoDescription = "Learn how blockchain works with our detailed infographic and glossary. Understand the key concepts and terminology behind blockchain technology.",

        //    Facebook = "",
        //    Instagram = "",
        //      X = "",
        //      TikTok = "",
        //      Pinterest = ""
        //}
    };

        public List<Infographic> GetMyInfographics(int Count)
        {
            List<Infographic> Data = new List<Infographic>();
            Data = MyAllInfographics.Take(Count).ToList();
            return Data;
        }

        public Infographic GetMyInfographic(string Slug)
        {
            Infographic Data = new Infographic();
            Data = MyAllInfographics.FirstOrDefault(A => A.Slug == Slug);
            return Data;
        }

    }

}