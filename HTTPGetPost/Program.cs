using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;


namespace HTTPGetPost
{
    class Program
    {
        static void Main(string[] args)
        {
            //Sends request to testing site
            PostRequest("http://ptsv2.com");

            //Extracts HTTP data from chosen URL
            //GetRequest("http://www.google.com");

            

            Console.ReadKey();
        }

        //Get request
        async static void GetRequest(string url)
        {
            //initiate new http client
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    using (HttpContent content = response.Content)
                    {
                        //string mycontent = await content.ReadAsStringAsync();
                        HttpContentHeaders headers = content.Headers;

                        Console.WriteLine(content);
                    }
                    
                }
                    


            }
        }

        //Post request
        async static void PostRequest(string url)
        {
            //Creates list of string queries posted
            IEnumerable<KeyValuePair<string, string>> queries = new List<KeyValuePair<string, string>>()
            {
                //String queries
                new KeyValuePair<string, string>("query1","ryan"),
                new KeyValuePair<string, string>("query2","hadlow")
            };
            //creates a new url form taking queries
            HttpContent q = new FormUrlEncodedContent(queries);
            //initiate new http client
            using (HttpClient client = new HttpClient())
            {
                //send a post request to the specified url using the queries
                using (HttpResponseMessage response = await client.PostAsync(url, q))
                {
                    using (HttpContent content = response.Content)
                    {
                        //reads as a string
                        string mycontent = await content.ReadAsStringAsync();
                        //extract headers from url
                        HttpContentHeaders headers = content.Headers;

                        //display mycontent
                        Console.WriteLine(mycontent);
                    }

                }



            }
        }
    }
}
