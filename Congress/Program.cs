using Congress;
using Newtonsoft.Json;
using RestSharp;

try
{
    SortAndFilter.Run();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.Read();
}
