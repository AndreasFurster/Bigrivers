using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Bigrivers.Server.Model;
using Newtonsoft.Json;

namespace Bigrivers.Client.ConsoleClient
{
    public class Communicator
    {
        public void HowToMakeRequestsToHttpBasedServices()
        {
            Uri serviceUri = new Uri("http://localhost:54240/api/Artist/Index");
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

                List<Artist> l = JsonConvert.DeserializeObject<List<Artist>>(jsontext);


                // Continue working with responseStream here...
            }
        }
    }
}
