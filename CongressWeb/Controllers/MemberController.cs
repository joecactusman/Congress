using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System.IO;

namespace CongressWeb.Controllers
{
    [ApiController]
    [Route("api/members")]
    public class MemberController : ControllerBase
    {
        public string MemberData = string.Empty;
        [HttpGet("MemberData")]
        public string GetMemberData()
        {
            //RestClient client = new RestClient("https://api.propublica.org/congress/v1/118/house/members.json");
            //RestRequest request = new RestRequest(String.Empty, Method.Get);
            //request.AddHeader("X-API-Key", "jSAN8y0XyCdFuAFxvxLrOMfSHOCOsNyTY7dcVh6q");
            //var response = client.Execute(request);
            //MemberData = response.Content;
            var file = System.IO.File.ReadAllText(@"C:\Users\jake.wengelski\Downloads\members.json");
            MembersDataStructure membersDataStructure = JsonConvert.DeserializeObject<MembersDataStructure>(file);
            string members = JsonConvert.SerializeObject(membersDataStructure.results.SelectMany(n => n.members));
            return members;
        }

        [HttpGet("SenateMemberData")]
        public string GetSenateMemberData()
        {
            //RestClient client = new RestClient("https://api.propublica.org/congress/v1/118/house/members.json");
            //RestRequest request = new RestRequest(String.Empty, Method.Get);
            //request.AddHeader("X-API-Key", "jSAN8y0XyCdFuAFxvxLrOMfSHOCOsNyTY7dcVh6q");
            //var response = client.Execute(request);
            //MemberData = response.Content;
            var file = System.IO.File.ReadAllText(@"C:\Users\jake.wengelski\Downloads\senatemembers.json");
            MembersDataStructure membersDataStructure = JsonConvert.DeserializeObject<MembersDataStructure>(file);
            string members = JsonConvert.SerializeObject(membersDataStructure.results.SelectMany(n => n.members));
            return members;
        }

        [HttpGet("Search/{searchInput}")]
        public string SearchMemberData(string searchInput)
        {
            string memberList = GetMemberData();
            List<Member> members = JsonConvert.DeserializeObject<List<Member>>(memberList);
            List<Member> searchedMembers = members.Where(n => n.first_name.StartsWith(searchInput, StringComparison.OrdinalIgnoreCase) || n.last_name.StartsWith(searchInput, StringComparison.OrdinalIgnoreCase)).ToList();
            return JsonConvert.SerializeObject(searchedMembers);
        }

        [HttpGet("SearchSenate/{searchInput}")]
        public string SearchSenateMemberData(string searchInput)
        {
            string memberList = GetSenateMemberData();
            List<Member> members = JsonConvert.DeserializeObject<List<Member>>(memberList);
            List<Member> searchedMembers = members.Where(n => n.first_name.StartsWith(searchInput, StringComparison.OrdinalIgnoreCase) || n.last_name.StartsWith(searchInput, StringComparison.OrdinalIgnoreCase)).ToList();
            return JsonConvert.SerializeObject(searchedMembers);
        }

        public class MemberTest
        {
            public string Name { get; set; }
            public string State { get; set; }
            public string District { get; set; }
        }
        public string GetHTML()
        {
            var members = new List<MemberTest> {
               new MemberTest {Name = "Ron Johnson",State = "Wisconsin", District = "8"},
                new MemberTest {Name = "Pauli Smally",State = "Your Mom", District =  "69"},
                new MemberTest{ Name  = "Yusef Poosef", State =  "Asia", District = "12"}
            };
            return JsonConvert.SerializeObject(members);
        }

        public class MembersDataStructure
        {
            public string? status { get; set; }
            public string? copyright { get; set; }
            public List<MembersRequestResult>? results { get; set; }
        }

        public class MembersRequestResult
        {
            public string? congress { get; set; }
            public string? chamber { get; set; }
            public int num_results { get; set; }
            public int offset { get; set; }
            public List<Member>? members { get; set; }
        }

        public class Member
        {
            public string? id { get; set; }
            public string? title { get; set; }
            public string? short_title { get; set; }
            public string? api_uri { get; set; }
            public string? first_name { get; set; }
            public string? middle_name { get; set; }
            public string? last_name { get; set; }
            public string? suffix { get; set; }
            public string? date_of_birth { get; set; }
            public string? gender { get; set; }
            public string? party { get; set; }
            public string? leadership_role { get; set; }
            public string? twitter_account { get; set; }
            public string? facebook_account { get; set; }
            public string? youtube_account { get; set; }
            public string? govtrack_id { get; set; }
            public string? cspan_id { get; set; }
            public string? votesmart_id { get; set; }
            public string? icpsr_id { get; set; }
            public string? crp_id { get; set; }
            public string? google_entity_id { get; set; }
            public string? fec_candidate_id { get; set; }
            public string? url { get; set; }
            public string? rss_url { get; set; }
            public string? contact_form { get; set; }
            public string? in_office { get; set; }
            public string? cook_pvi { get; set; }
            public string? dw_nominate { get; set; }
            public string? ideal_point { get; set; }
            public string? seniority { get; set; }
            public string? next_election { get; set; }
            public string? total_votes { get; set; }
            public string? missed_votes { get; set; }
            public string? total_present { get; set; }
            public string? last_updated { get; set; }
            public string? ocd_id { get; set; }
            public string? office { get; set; }
            public string? phone { get; set; }
            public string? fax { get; set; }
            public string? state { get; set; }
            public string? district { get; set; }
            public string? at_large { get; set; }
            public string? geoid { get; set; }
        }
        public class State
        {
            public static Dictionary<string, string> States = new()
            {
                { "ALABAMA", "AL" },
                { "ALASKA", "AK" },
                { "ARIZONA", "AZ" },
                { "ARKANSAS", "AR" },
                { "CALIFORNIA", "CA" },
                { "COLORADO", "CO" },
                { "CONNECTICUT", "CT" },
                { "DELAWARE", "DE" },
                { "DISTRICT OF COLUMBIA", "DC" },
                { "FLORIDA", "FL" },
                { "GEORGIA", "GA" },
                { "HAWAII", "HI" },
                { "IDAHO", "ID" },
                { "ILLINOIS", "IL" },
                { "INDIANA", "IN" },
                { "IOWA", "IA" },
                { "KANSAS", "KS" },
                { "KENTUCKY", "KY" },
                { "LOUISIANA", "LA" },
                { "MAINE", "ME" },
                { "MARYLAND", "MD" },
                { "MASSACHUSETTS", "MA" },
                { "MICHIGAN", "MI" },
                { "MINNESOTA", "MN" },
                { "MISSISSIPPI", "MS" },
                { "MISSOURI", "MO" },
                { "MONTANA", "MT" },
                { "NEBRASKA", "NE" },
                { "NEVADA", "NV" },
                { "NEW HAMPSHIRE", "NH" },
                { "NEW JERSEY", "NJ" },
                { "NEW MEXICO", "NM" },
                { "NEW YORK", "NY" },
                { "NORTH CAROLINA", "NC" },
                { "NORTH DAKOTA", "ND" },
                { "OHIO", "OH" },
                { "OKLAHOMA", "OK" },
                { "OREGON", "OR" },
                { "PENNSYLVANIA", "PA" },
                { "RHODE ISLAND", "RI" },
                { "SOUTH CAROLINA", "SC" },
                { "SOUTH DAKOTA", "SD" },
                { "TENNESSEE", "TN" },
                { "TEXAS", "TX" },
                { "UTAH", "UT" },
                { "VERMONT", "VT" },
                { "VIRGINIA", "VA" },
                { "WASHINGTON", "WA" },
                { "WEST VIRGINIA", "WV" },
                { "WISCONSIN", "WI" },
                { "WYOMING", "WY" }
            };
        }
    }
}