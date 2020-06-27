using System;
using System.ComponentModel;//For AsyncCompletedEventHandler delegate
using System.Net;//For WebClient
using System.Threading;//For Thread.Sleep() method

namespace UsingWebClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Demonstration-.Event Based Asynchronous Program Demo.***");
            //Method1();
            #region The lenghty operation(download)
            Console.WriteLine("Starting a download operation.");
            WebClient webClient = new WebClient();
            //File location
            Uri myLocation = new Uri(@"C:\TestData\OriginalFile.txt");
            //Target location for download
            string targetLocation = @"C:\TestData\DownloadedFile.txt";
            webClient.DownloadFileAsync(myLocation, targetLocation);
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
            //same as
            //webClient.DownloadFileCompleted += DownloadCompleted;
            #endregion
            Method2();
            Console.WriteLine("End Main()...");
            Console.ReadKey();
        }
        //Method2
        private static void Method2()
        {
            Console.WriteLine("Method2() has started.");
            //Some small task
            //Thread.Sleep(100);
            Console.WriteLine("Method2() has finished.");
        }

        private static void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Successfully downloaded the file now.");
        }
        
    }
}

