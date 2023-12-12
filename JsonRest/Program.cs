using JsonRest;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

string baseUrl = "https://reqres.in/api/";
var client = new RestClient(baseUrl);
UserDataResponse response=new UserDataResponse();
GetSingleUser(client);
static void GetSingleUser(RestClient client)
{
    var getUserRequest = new RestRequest("users/5", Method.Get);

    var getUserResponse = client.Execute(getUserRequest);
    if (getUserResponse.StatusCode == System.Net.HttpStatusCode.OK)
    {
        //Desrialize JSON response content into C# object
       var response = JsonConvert.DeserializeObject<UserDataResponse>(getUserResponse.Content);
     //  Console.WriteLine(response);
        UserData? user = response.Data;
        Console.WriteLine($"User ID :{user?.Id}");
        Console.WriteLine($"User Email :{user?.Email}");
        Console.WriteLine($"User Name :{user?.FirstName} {user?.LastName}");
        Console.WriteLine($"User Avatar :{user?.Avatar}");

        
    }
    else
    {
        Console.WriteLine($"Error: {getUserResponse.ErrorMessage}");
    }
}