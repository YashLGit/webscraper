using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace WebScraper
{
    class Program
    {
        static void Main(String[] args)
        {
            // Send get request to my LinkedIn Page
            String url = "https://github.com/YashLGit";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get the username
            var nameElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='p-name vcard-fullname d-block overflow-hidden']");
            var name = nameElement.InnerText.Trim();
            Console.WriteLine("Name: " + name);

            // Get the description
            var descriptionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='p-note user-profile-bio mb-3 js-user-profile-bio f4']");
            var description = descriptionElement.InnerText.Trim();
            Console.WriteLine("Description: " + description);

            //Get the location
            var locationElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='p-label']");
            var location = locationElement.InnerText.Trim();
            Console.WriteLine("Location: " + location);
        }
    }
}