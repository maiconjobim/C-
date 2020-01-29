using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SyncronizerTeamWork.Entities.QuickType;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SyncronizerTeamWork.Controller
{
    class GetTeamWork
    {


        public static void  GetProjects(string username)
        {

            string baseUrl = "https://sequor.teamwork.com";
            string action = "/projects.json";

            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get,baseUrl + action);
      
            string password = "XXX";

            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

            HttpResponseMessage response = client.SendAsync(request).Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var projects = JsonConvert.DeserializeObject<Coordinate>(response.Content.ReadAsStringAsync().Result);
            
            }
            


        }








    }
}
