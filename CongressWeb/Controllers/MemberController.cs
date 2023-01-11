using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace CongressWeb.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MemberController : ControllerBase
    {
        public string MemberData = string.Empty;
        [HttpGet("MemberData")]
        //public List<string> GetMemberData()
        //{
        //    RestClient client = new RestClient("https://api.propublica.org/congress/v1/118/house/members.json");
        //    RestRequest request = new RestRequest(String.Empty, Method.Get);
        //    request.AddHeader("X-API-Key", "jSAN8y0XyCdFuAFxvxLrOMfSHOCOsNyTY7dcVh6q");
        //    var response = client.Execute(request);
        //    MemberData =  response.Content;
        //    return GetHTML();
        //}

        [HttpGet("fuckoff")]
        public List<string> GoFuckYourself()
        {
            return GetHTML();
        }
        public List<string> GetHTML()
        {
            var html = new List<object> { 
                new { Name = "Ron Johnson", State = "Wisconsin", District = "8" },
                new { Name = "Pauli Smally", State = "Your Mom", District = "69" },
                new { Name = "Yusef Poosef", State = "Asia", District = "12" }
            };
            return html.Select(n => JsonConvert.SerializeObject(n)).ToList();
        }
    }
}