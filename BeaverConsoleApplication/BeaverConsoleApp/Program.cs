using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using MySql.Data.MySqlClient;

namespace ConsoleApplication1
{
    public class Beaver
    {
        [XmlElement("BeaverCode")]
        public string code { get; set; }
    }

    public class Colony
    {
        [XmlElement("ColonyName")]
        public string name { get; set; }

        [XmlElement("Beavers")]
        public List<Beaver> beavers { get; set; } 

        public Colony()
        {
            beavers =new List<Beaver>();
        }
        
        public void addBeaver(Beaver b)
        {
            beavers.Add(b);
        }
    }

    class Program
    {
        static List<Colony> ColonyFromXML()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Colony>));
            TextReader textReader = new StreamReader(@"C:\movie.xml");
            List<Colony> colonies = (List<Colony>)deserializer.Deserialize(textReader);
            textReader.Close();

            return colonies;
        }

        static List<Beaver> BeaverFromXML()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Beaver>));
            TextReader textReader = new StreamReader(@"C:\movie.xml");
            List<Beaver> beavers = (List<Beaver>)deserializer.Deserialize(textReader);
            textReader.Close();

            return beavers;
        }

        static void Main(string[] args)
        {
            Colony boston = new Colony();
            Beaver fred = new Beaver();
            Beaver wilma = new Beaver();
            Beaver bambam = new Beaver();

            fred.code = "fred";
            wilma.code = "wilma";
            bambam.code = "bambam";

            boston.name = "Boston";
            boston.addBeaver(fred);
            boston.addBeaver(wilma);
            boston.addBeaver(bambam);


            var fileName = @"C:\beaver\colonies.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(Colony));
            using (TextWriter textWriter = new StreamWriter(fileName))
            {
                serializer.Serialize(textWriter, boston);
            }

            Colony colonyAgain;
            using (TextReader textReader = new StreamReader(fileName))
            {
                colonyAgain  = (Colony) serializer.Deserialize(textReader);
            }

            foreach (var beaver in colonyAgain.beavers) {
                Console.WriteLine(beaver.code);
            }


            
            //            XElement myXml = XElement.Load(@"X:\proj\baml\ws\DocX\xl\mad\mad\xl\sharedStrings.xml");
            //            Console.WriteLine(myXml);


            //            int[] myNumbers = { 1, 3, 23, 4, 52, 4, 6, 5 };
            //            int[] myNumbers2 = { 1, 3, 23, 25 };
            //            var twoDigits = from num in myNumbers
            //                            from num2 in myNumbers2
            //                            where num == num2
            //                            select new { First = num, Second = num2 };
            //            foreach (var num in twoDigits)
            //                Console.WriteLine(num.First + " " + num.Second);


            //            XElement Icecreams =
            //               new XElement("Icecreams",
            //                  new XElement("Icecream",
            //                      new XComment("Cherry Vanilla Icecream"),
            //                      new XElement("Flavor", "Cherry Vanilla"),
            //new XElement("ServingSize", "Half Cup"),
            //new XElement("Price", 10),
            //new XElement("Nutrition",
            //new XElement("TotalFat", "15g"),
            //new XElement("Cholesterol", "100mg"),
            //new XElement("Sugars", "22g"),
            //new XElement("Carbohydrate", "23g"),
            //new XElement("SaturatedFat", "9g"))));
            //            Icecreams.Add(
            //            new XElement("Icecream",
            //            new XComment("Strawberry Icecream"),
            //            new XElement("Flavor", "Strawberry"),
            //            new XElement("ServingSize", "Half Cup"),
            //            new XElement("Price", 10),
            //            new XElement("Nutrition",
            //            new XElement("TotalFat", "16g"),
            //            new XElement("Cholesterol", "95mg"),
            //            new XElement("Sugars", "22g"),
            //            new XElement("Carbohydrate", "23g"),
            //            new XElement("SaturatedFat", "10g"))));

            //            Console.WriteLine(Icecreams);

            //            var intermediate = from c in Icecreams.Elements("Icecream")
            //                               where (c.Element("Price").Value == "10")
            //                               orderby c.Element("Flavor").Value
            //                               select new XElement("Icecream",
            //                                   c.Element("Flavor").Value.ToUpper());

            //            XElement IcecreamsList = new XElement("IcecreamsList", (intermediate));
            //            Console.WriteLine(IcecreamsList);


            //            aMethod(3, z: "foo", y: "Flubble");

            Func<String, String, String> myFunc = (text, anotherText) => text + anotherText;


            Console.WriteLine("Length: " + myFunc.Invoke("ABCDEFGH", "Wobble"));

            //string MyConString = "SERVER=localhost;" +
            //    "DATABASE=baml2;" +
            //    "UID=root;" +
            //    "PASSWORD=iwtbde;";
            //MySqlConnection connection = new MySqlConnection(MyConString);
            //MySqlCommand command = connection.CreateCommand();
            //MySqlDataReader Reader;
            //command.CommandText = "select * from worksheet_entries";
            //connection.Open();
            //Reader = command.ExecuteReader();
            //while (Reader.Read())
            //{
            //    string thisrow = "";
            //    for (int i = 0; i < Reader.FieldCount; i++)
            //        thisrow += Reader.GetValue(i).ToString() + ",";
            //    Console.Out.WriteLine(thisrow);
            //}
            //connection.Close();
        }
        //static void aMethod(int x, string y = "Wibble", string z = "Wobble")
        //{

        //    Console.WriteLine(y + x + z);

        //}
    }





}
