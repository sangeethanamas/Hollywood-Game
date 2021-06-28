using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace hollywood
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get Question
            string strcountry = getDataFromXml();
            StringBuilder sbcountry = new StringBuilder();
            sbcountry.Append(strcountry);
            //Console.WriteLine(strcountry);
            // Print
            StringBuilder strmatch = getPrint(strcountry);
            Console.WriteLine(strmatch);
            //Guessing the letters
            char cguess;
            char[] guessarray = new char[26];
            int chances = 8;


            while ((chances != 0) && (!strmatch.Equals(sbcountry)))
            {
                Console.WriteLine("start guessing");
                cguess = Convert.ToChar(Console.ReadLine());
                cguess = char.ToUpper(cguess);
                strmatch = getDataFromcguess(cguess, strcountry, strmatch, ref chances);
                Console.WriteLine(strmatch);

            }



            Console.WriteLine("GAME OVER");
            Console.WriteLine("Country name : "+strcountry.ToString());
            Console.ReadLine();
        }
        public static string getDataFromXml()
        {
            Random random = new Random();
            string strcountry = "";
            int inode = random.Next(6);
            using (XmlReader reader = XmlReader.Create(@"C:\Users\hp1\source\repos\hollywood\hollywood\bin\Debug\Country.xml"))
            {
                while (reader.Read())
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load("Country.xml");
                    XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/World/country/pais");
                    strcountry = xmlNodeList[inode].InnerText;
                }
            }
            return strcountry;
        }
        public static StringBuilder getPrint(string strcountry)
        {
            StringBuilder strmatch = new StringBuilder();
            for (int icounter = 0; icounter < strcountry.Length; icounter++)
            {
                strmatch.Insert(icounter, "*");
            }
            return strmatch;
        }
        public static StringBuilder getDataFromcguess(char guess, string strcountry, StringBuilder strmatch, ref int chances)
        {
            int i = 0;

            for (int icounter = 0; icounter < strcountry.Length; icounter++)
            {
                if (strcountry[icounter] == guess)
                {
                    i = i + 1;
                    strmatch[icounter] = guess;

                }

            }
            if (i == 0)
            {
                chances = chances - 1;

            }
            Console.WriteLine(holly(chances));


            return strmatch;



        }

        public static string holly(int chances)
        {
            string strname = "HOLLYWOOD";

         

            if (strname.Length > chances+1)
            {
                strname = strname.Substring(0, chances+1);               
                           
               
            }
           

            return strname;
        }


    }
}






















