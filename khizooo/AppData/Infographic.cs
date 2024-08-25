
using khizooo.AppData.SharedHelper;

namespace khizooo.AppData
{

    public class InfographicType
    {
        public long ID { get; set; }
        public string Title { get; set; }
    }

    public class Infographic
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
        public string List_IMG_URL { get; internal set; }
        public string VIDEO { get; set; }
        public string Desription { get; set; }
        public string Type { get; set; }
        public long InfographicTypeID { get; set; }
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

        private List<InfographicType> InfographicTypes = new List<InfographicType>(){
            new InfographicType() { ID = 0 , Title = "All"},
            new InfographicType() { ID = 1 , Title = "Blockchain"}
        };

        private List<Infographic> MyAllInfographics = new List<Infographic>()
        {
        new Infographic()
        {
            ID = 1,
            Slug = "how-blockchain-works",
            Title = "How Blockchain Works?",
            PunchLine = "Unlocking the Power of Blockchain: A Journey through Transparency, Security, and Innovation",
            SubTitle = "Blockchain | Infographic",
            Heading = "How Blockchain Works? - Blockchain - Infographic",
            IMG = "infographics/blockchain/how-blockchain-works.jpg",
            Type = "Infographic",
            InfographicTypeID = 1,
            Category = "Technologies",
            CreatedOn = "1st AUG 2023",

            URL = "/creative-works/infographic/detail/1/how-blockchain-works",
            Tags = "[\"all\", \"Infographic\", \"Blockchain\", \"how\"]",

            KeyTerms = new List<KeyTerm>()
            {
                new KeyTerm {
                    Location = "left",
                    Term = "Transaction",
                    Answer = "An exchange of value or data between parties recorded on the blockchain."
                },
                new KeyTerm {
                    Location = "left",
                    Term = "Network",
                    Answer = "A group of interconnected computers that communicate and share data."
                },
                new KeyTerm {
                    Location = "left",
                    Term = "Hash",
                    Answer = "A unique string of characters that represents data securely."
                },
                new KeyTerm {
                    Location = "left",
                    Term = "Decentralization",
                    Answer = "Distribution of control across multiple independent parties or nodes."
                },
                new KeyTerm {
                    Location = "left",
                    Term = "Database",
                    Answer = "An organized collection of structured data stored electronically."
                },
                new KeyTerm {
                    Location = "left",
                    Term = "Consensus Mechanism",
                    Answer = "A process used to agree on the validity of transactions in a network."
                },
                new KeyTerm {
                    Location = "right",
                    Term = "Cryptography",
                    Answer = "Techniques used to secure and protect information using mathematical methods."
                },
                new KeyTerm {
                    Location = "right",
                    Term = "Encryption",
                    Answer = "Converting data into a coded format to prevent unauthorized access."
                },
                new KeyTerm {
                    Location = "right",
                    Term = "Cryptocurrencies",
                    Answer = "Digital currencies that use blockchain technology for secure transactions."
                },
                new KeyTerm {
                    Location = "right",
                    Term = "Bitcoin",
                    Answer = "The first decentralized digital currency, enabling peer-to-peer transactions."
                },
                new KeyTerm {
                    Location = "right",
                    Term = "Supply Chain",
                    Answer = "The entire system of producing and delivering a product from raw materials to the end user."
                },
                new KeyTerm {
                    Location = "right",
                    Term = "Smart Contracts",
                    Answer = "Self-executing contracts with terms written into code on a blockchain."
                }
            },

            SeoTitle = "How Blockchain Works? - Infographic - KhizoOo",
            SeoKeyWords = "how blockchain works, blockchain infographic, blockchain glossary, blockchain technology, blockchain explained, blockchain basics, khizooo",
            SeoDescription = "Learn how blockchain works with our detailed infographic and glossary. Understand the key concepts and terminology behind blockchain technology.",

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
        new Infographic()
        {
            ID = 2,
            Slug = "blockchain-use-cases-in-finance",
            Title = "Blockchain Use Cases In Finance",
            PunchLine = "Altering Money with Blockchain: Secure, Straightforward, and Proficient Exchanges",
            SubTitle = "Blockchain | Infographic",
            Heading = "Blockchain Use-Cases In Finance Infographic - Blockchain - Infographic",
            IMG = "infographics/blockchain/blockchain-use-cases-in-finance.jpg",
            Type = "Infographic",
            InfographicTypeID = 1,
            Category = "Technologies",
            CreatedOn = "3rd MAR 2024",

            URL = "/creative-works/infographic/detail/2/blockchain-use-cases-in-finance",
            Tags = "[\"all\", \"infographic\", \"blockchain\", \"use-cases\"]",

            KeyTerms = new List<KeyTerm>()
            {
                new KeyTerm
                {
                    Location = "left",
                    Term = "Blockchain",
                    Answer = "A decentralized digital ledger that records transactions across multiple computers."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "Smart Contracts",
                    Answer = "Self-executing contracts with terms written in code on a blockchain."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "Digital Agreements",
                    Answer = "Contracts made and managed electronically, often using blockchain technology."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "Trade Finance",
                    Answer = "Financial services that facilitate international trade transactions and reduce risks."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "Transactions",
                    Answer = "The transfer of value or assets between parties, recorded on a blockchain."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "Asset Tokenization",
                    Answer = "Converting real-world assets into digital tokens on a blockchain for easier trading."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "NFT (Non-Fungible Token)",
                    Answer = "A unique digital asset representing ownership of specific items or content on a blockchain."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "KYC (Know Your Customer)",
                    Answer = "A process to verify the identity of clients to prevent fraud and illegal activities."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "Decentralized Finance (DeFi)",
                    Answer = "Financial services using blockchain to operate without traditional intermediaries like banks."
                }
            },

            SeoTitle = "Top Blockchain Use Cases in Finance - Infographic - KhizoOo",
            SeoKeyWords = "blockchain use cases in finance, blockchain applications, financial technology, blockchain benefits, finance innovations, blockchain glossary, finance infographic, khizooo",
            SeoDescription = "Explore the top blockchain use cases in finance with our comprehensive guide. Learn about innovative applications, benefits, and future trends. View our infographic and glossary for detailed insights.",

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
        new Infographic()
        {
            ID = 3,
            Slug = "blockchain-products",
            Title = "Blockchain Products",
            PunchLine = "Empowering the Future: Blockchain Products for Secure, Transparent, and Decentralized Solutions",
            SubTitle = "Blockchain | Infographic",
            Heading = "Blockchain Products - Blockchain - Infographic",
            IMG = "infographics/blockchain/blockchain-products.jpg",
            Type = "Infographic",
            InfographicTypeID = 1,
            Category = "Technologies",
            CreatedOn = "3rd AUG 2024",

            URL = "/creative-works/infographic/detail/3/blockchain-products",
            Tags = "[\"all\", \"Infographic\", \"blockchain\",\"information\"]",

            KeyTerms = new List<KeyTerm>()
            {
                new KeyTerm
                {
                    Location = "left",
                    Term = "Transacts Cryptocurrencies",
                    Answer = "The process of buying, selling, or exchanging digital currencies between users."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "Blockchain.com",
                    Answer = "A platform providing digital wallets and blockchain data for Bitcoin and other cryptocurrencies."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "Bitcoin",
                    Answer = "The first decentralized digital currency that allows peer-to-peer transactions without intermediaries."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "Ethereum",
                    Answer = "A blockchain platform that enables the creation of smart contracts and decentralized applications."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "Altcoins",
                    Answer = "Cryptocurrencies other than Bitcoin, including thousands of different coins with unique features."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "Blockchain Transactions",
                    Answer = "Transfers of cryptocurrency that are recorded on a blockchain ledger for transparency and security."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "Etherscan",
                    Answer = "A blockchain explorer for the Ethereum network, allowing users to view transactions and smart contracts."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "Cryptocurrency Payment",
                    Answer = "A transaction where digital currency is used to pay for goods or services."
                },
                new KeyTerm
                {
                    Location = "left",
                    Term = "BitPay",
                    Answer = "A payment processor that enables businesses to accept Bitcoin and other cryptocurrencies."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "Fidelity Digital Assets",
                    Answer = "A subsidiary of Fidelity Investments offering custody and trading services for cryptocurrencies."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "Trading",
                    Answer = "The buying and selling of cryptocurrencies on various exchanges to profit from price fluctuations."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "Celsius Network",
                    Answer = "A platform offering crypto lending, borrowing, and interest-earning opportunities."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "Crypto.com",
                    Answer = "A platform offering cryptocurrency exchange, wallet, and payment services."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "Coinbase",
                    Answer = "A popular cryptocurrency exchange that allows users to buy, sell, and store digital currencies."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "CoinMarketCap",
                    Answer = "A website providing data and information on the prices and market capitalization of cryptocurrencies."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "TradingView",
                    Answer = "A platform offering advanced charting tools and analysis for traders in financial markets, including crypto."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "Non-Fungible Tokens",
                    Answer = "Unique digital assets representing ownership of items like art, music, or collectibles on the blockchain."
                },
                new KeyTerm
                {
                    Location = "right",
                    Term = "OpenSea",
                    Answer = "A leading marketplace for buying, selling, and trading non-fungible tokens (NFTs)."
                }
            },

            SeoTitle = "Blockchain Products - Infographic - KhizoOo",
            SeoKeyWords = "Blockchain Products, Blockchain Solutions, Blockchain Technology, Blockchain Infographics, Blockchain Glossary, KhizoOo, Blockchain Innovations, khizooo",
            SeoDescription = "Discover a range of innovative blockchain products at KhizoOo. Our page features detailed infographics and a comprehensive glossary to enhance your understanding of blockchain technology. Explore our offerings and stay ahead in the blockchain industry.",

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

        public List<Infographic> GetMyInfographics(int Count)
        {
            List<Infographic> Data = new List<Infographic>();
            Data = MyAllInfographics.Take(Count).ToList();
            return Data;
        }

        public Infographic GetMyInfographic(long ID)
        {
            Infographic Data = new Infographic();
            Data = MyAllInfographics.FirstOrDefault(A => A.ID == ID);
            return Data;
        }

        public Infographic GetMyInfographic(string Slug)
        {
            Infographic Data = new Infographic();
            Data = MyAllInfographics.FirstOrDefault(A => A.Slug == Slug);
            return Data;
        }

        public Infographic GetMyInfographic(long ID, string Slug)
        {
            Infographic Data = new Infographic();
            Data = MyAllInfographics.FirstOrDefault(A => A.ID == ID && A.Slug == Slug);
            return Data;
        }

        public List<InfographicType> Get_Infographic_Types()
        {
            List<InfographicType> Data = new List<InfographicType>();
            Data = InfographicTypes.ToList();
            return Data;
        }

    }

}