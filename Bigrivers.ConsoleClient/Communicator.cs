using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Bigrivers.Model;
using Newtonsoft.Json;

namespace Bigrivers.ConsoleClient
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
