using Newtonsoft.Json;
using starshipStops.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace starshipStops
{
    public class Program
    {
        protected static HttpClient client = new HttpClient();
        protected const string urlApi = "https://swapi.co/api/starships/";
        protected static int distance = -1;
        protected static string urlParam = "";


        static void Main(string[] args)
        {
            Console.WriteLine("Specify a distance in MGLT (1000000 by default):");
            int.TryParse(Console.ReadLine(), out distance);
            distance = distance <= 0 ? 1000000 : distance;
            Console.WriteLine("Distance setted up to: " + distance + "\n");
            
            GetData().GetAwaiter().GetResult();

            Console.WriteLine("Execution finished. Press enter to exit.");
            Console.ReadLine();
        }

        /// <summary>
        /// Takes every starship and, if its MGLT and Consumables properties has a properly value, it calculates de Number of stops and prints the results.
        /// This function is called so much times as pages the API returns to us.
        /// </summary>
        /// <param name="shipsList">An enumerable of starships.</param>
        static void PrintInformation(IEnumerable<Starship> shipsList)
        {
            foreach (Starship s in shipsList)
            {
                // We just calculate these starships which has a MGLT and Consumable properties specified.
                if (s.MGLT != "unknown" && s.Consumables != "unknown") {
                    s.CalculateNoStops(distance);
                    Console.WriteLine(s.Name + " will stop " + s.NoStops + " times for resupply.");
                }
            }
        }

        /// <summary>
        /// A Task which connect to the swapi.co API and executes GET for every page of starships.
        /// </summary>
        /// <returns></returns>
        static async Task GetData()
        {
            client.BaseAddress = new Uri(urlApi);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            
            try
            {
                while (urlParam != null)
                {
                    string json = null;
                    json = await client.GetStringAsync(urlParam);

                    if (json != null)
                    {
                        RootCatalog data = new RootCatalog();
                        data = JsonConvert.DeserializeObject<RootCatalog>(json);
                        IEnumerable<Starship> starships = data.Results ?? null;

                        if (starships != null && starships.Count() > 0)
                        {
                            PrintInformation(starships);
                        }

                        // Target the next page to retrieve all the elements in the API.
                        urlParam = data.Next != null ? data.Next.ToString().Replace(urlApi, "") : null;
                    }

                    // We put this to have some breaks between each bunch of shown info.
                    Console.WriteLine("Press enter...");
                    Console.ReadLine();
                }
            }
            // We get covered by any possible issue, so the app does not just crash.
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }
    }
}
