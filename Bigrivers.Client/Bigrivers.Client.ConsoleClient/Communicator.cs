using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace Bigrivers.Client.ConsoleClient
{
    public class Communicator
    {
        public void HowToMakeRequestsToHttpBasedServices()
        {
            Uri serviceUri = new Uri("http://localhost:54240/odata/Artists");
            WebClient downloader = new WebClient();
            downloader.OpenReadCompleted += new OpenReadCompletedEventHandler(downloader_OpenReadCompleted);
            downloader.OpenReadAsync(serviceUri);
        }

        void downloader_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            Console.WriteLine("Answer received.");

            if (e.Error == null)
            {
                //Stream responseStream = e.Result;

                string jsontext;

                using (StreamReader reader = new StreamReader(e.Result))
                {
                    jsontext = reader.ReadToEnd();
                }

                Console.WriteLine("JSON answer: \n " + jsontext + "\n");

                //List<Artist> l = JsonConvert.DeserializeObject<List<Artist>>(jsontext);

                // Console.WriteLine("Artists received: " + l.Count.ToString() );

                // Continue working with responseStream here...
                Console.WriteLine("now lets implement conversion to objects...");
            }
        }
    }
}
