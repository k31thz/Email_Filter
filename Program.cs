using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;



namespace Email_Filter
{
    class EmailFilter
    {
        public List<string> ClassifiedWords { get; set; }
    }
    class EmailContent
    {
        public string EmailContents { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Read the Json files
            string classifiedStringsList = File.ReadAllText("C:/Users/Jace/Source/Repos/Email_Filter/classifiedStrings.json");
            string emailContents = File.ReadAllText("C:/Users/Jace/Source/Repos/Email_Filter/emailContents.json");

            //Deserialize the classified words file
            EmailFilter emailFilter = JsonSerializer.Deserialize<EmailFilter>(classifiedStringsList);

            //Deserialize the email contents file
            EmailContent emailContent = JsonSerializer.Deserialize<EmailContent>(emailContents);

            //Get the classified words
            List<string> classifiedWords = emailFilter.ClassifiedWords;
            //Get email contents
            string emailText = emailContent.EmailContents;

            Tuple<bool, string> result = Filter.CensorEmail(classifiedWords, emailText);

            if (result.Item1)
            {
                Console.WriteLine("Classified item found: " + result.Item1);
                Console.WriteLine("Censored email content: " + result.Item2);
            } else
            {
                Console.WriteLine("No classified content was found");
            }
        }
    }
}
