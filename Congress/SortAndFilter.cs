using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Congress
{
    internal class SortAndFilter
    {
        public static void Run()
        {
            RestResponse response = GetMemberData();
            var membersDataStructure = JsonConvert.DeserializeObject<MembersDataStructure>(response.Content);
            OutputMemberList(membersDataStructure.results.SelectMany(n => n.members).ToList());

            SortOrFilter sortOrFilter = GetSortOrFilter();

            List<Member> returnMemberList = SortOrFilter(membersDataStructure, sortOrFilter);

            OutputMemberList(returnMemberList);
            Run();
        }

        private static RestResponse GetMemberData()
        {
            RestClient client = new RestClient("https://api.propublica.org/congress/v1/118/house/members.json");
            RestRequest request = new RestRequest(String.Empty, Method.Get);
            request.AddHeader("X-API-Key", "jSAN8y0XyCdFuAFxvxLrOMfSHOCOsNyTY7dcVh6q");
            var response = client.Execute(request);
            return response;
        }

        private static List<Member> SortOrFilter(MembersDataStructure? membersDataStructure, SortOrFilter sortOrFilter)
        {
            var returnMemberList = new List<Member>();
            if (sortOrFilter == Congress.SortOrFilter.Sort)
            {
                returnMemberList = membersDataStructure.results.SelectMany(n => n.members).OrderBy(n => n.state).ThenBy(n => n.district).ToList();
            }
            if (sortOrFilter == Congress.SortOrFilter.Filter)
            {
                string state = GetState();
                returnMemberList = membersDataStructure.results.SelectMany(n => n.members).Where(n => n.state == state).OrderBy(n => n.district).ToList();
            }

            return returnMemberList;
        }

        private static string GetState()
        {
            var state = Console.ReadLine().ToUpper();
            if (string.IsNullOrWhiteSpace(state) || !State.States.ContainsKey(state))
            {
                Console.WriteLine("gurl that aint a state.");
                GetState();
            }

            return State.States[state];
        }

        private static void OutputMemberList(List<Member> members)
        {
            foreach (var member in members)
            {
                Console.WriteLine($"Name: {member.first_name} {member.last_name} State: {member.state} Disctrict {member.district}");
            }
        }

        public static SortOrFilter GetSortOrFilter()
        {
            Console.WriteLine("Would you like to sort or filter?");
            string sortOrFilterRaw = Console.ReadLine();
            if (sortOrFilterRaw.ToUpper() == "SORT")
            {
                return Congress.SortOrFilter.Sort;
            }
            else if (sortOrFilterRaw.ToUpper() == "FILTER")
            {
                Console.WriteLine($"Which state would you like to {sortOrFilterRaw.ToLower()} by?");
                return Congress.SortOrFilter.Filter;
            }
            else
            {
                Console.WriteLine("huh...? wtf?");
                GetSortOrFilter();
            }
            return Congress.SortOrFilter.Unknown;
        }
    }
    public enum SortOrFilter
    {
        Sort,
        Filter,
        Unknown
    }
}
