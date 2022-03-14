using System;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace InterviewCase
{
    class Program
    {
        static void Main(string[] args)
        {
            string link = "https://www.sahibinden.com/";  //link değişkenine çekeceğimiz web sayfasının linkini yazıyoruz.

            Uri url = new Uri(link); //Uri tipinde değişken linkimizi veriyoruz.

            WebClient client = new WebClient(); // webclient nesnesini kullanıyoruz bağlanmak için.

            client.Encoding = Encoding.UTF8; //türkçe karakter sorunu yapmaması için encoding utf8 yapıyoruz.

            string html = client.DownloadString(url); // siteye bağlanıp tüm sayfanın html içeriğini çekiyoruz.

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); //kütüphanemizi kullanıp htmldocument oluşturuyoruz.

            document.LoadHtml(html);//documunt değişkeninin html ine çektiğimiz htmli veriyoruz

            HtmlNodeCollection titles = document.DocumentNode.SelectNodes("/ html / body / div[7] / div[3] / div / div[3] / div[3] / ul");

            foreach (var title in titles)
            {
                link = title.Attributes["href"].Value;
                Console.WriteLine(title.InnerText);

            }


            Console.ReadLine();
        }
    }
}
