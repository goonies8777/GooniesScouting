using Newtonsoft.Json.Linq;

using RestSharp;

using GooniesScouting.Business.Model;

namespace GooniesScouting.Business.Services
{
    public class OrangeAllianceService
    {
        private readonly string _orangeAllianceApiEndPoint = "https://theorangealliance.org/api";
        private readonly string _apiToken = "ove6biHOg782fBekuhs20dSguga1VkBU5NO3M3Y0rcU=";
        public RestClient CreateClient(){
            RestClientOptions opts = new RestClientOptions(_orangeAllianceApiEndPoint);
            RestClient client = new RestClient(opts);
            client.AddDefaultHeader("X-Application-Origin", "FTC-Scouting-Goonies8777");
            client.AddDefaultHeader("X-TOA-Key", _apiToken);
            
            return client;
        }

        public IEnumerable<FtcEvent> GetEvents()
        {
            RestClient client = CreateClient();
            List<FtcEvent> ftcEvents = new List<FtcEvent>();
            RestRequest request = new RestRequest("event?region_key=FIM&season_key=2425");

            try
            {
                RestResponse response = client.Get(request);
                JArray jsonResponse = JArray.Parse(response.Content.ToString());

                foreach (var item in jsonResponse)
                {
                    FtcEvent ftcEvent = item.ToObject<FtcEvent>();
                    ftcEvents.Add(ftcEvent);
                }
            }
            catch (Exception ex) 
            {
                System.Console.WriteLine(ex.Message);
            }
            return ftcEvents;
        }
    }
}