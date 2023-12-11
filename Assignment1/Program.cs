using Newtonsoft.Json.Linq;
using RestSharp;


    string baseUrl = "https://jsonplaceholder.typicode.com/";
    var client = new RestClient(baseUrl);
    GetAllUsers(client);
    CreateUser(client);
    UpdateUser(client);
    DeleteUser(client);
    GetSingleUser(client,"5");

    //GET All Users
    static void GetAllUsers(RestClient client)
    {
        var getUserRequest = new RestRequest("users", Method.Get);
      

        var getUserResponse = client.Execute(getUserRequest);
        Console.WriteLine("GET Response: \n" + getUserResponse.Content);
    }

    //POST
    static void CreateUser(RestClient client)
    {
        var createUserRequest = new RestRequest("users", Method.Post);
        createUserRequest.AddHeader("Content-Type", "application/json");
        createUserRequest.AddJsonBody(new { name = "John Doe", job = "Sofware Developer" });

        var createUserResponse = client.Execute(createUserRequest);
        Console.WriteLine("POST Response: \n" + createUserResponse.Content);
    }

    //PUT
    static void UpdateUser(RestClient client)
    {
        var updateUserRequest = new RestRequest("users/2", Method.Put);
        updateUserRequest.AddHeader("Content-Type", "application/json");
        updateUserRequest.AddJsonBody(new { name = "Updated John Doe", job = "Senior Sofware Developer" });

        var updateUserResponse = client.Execute(updateUserRequest);
        Console.WriteLine("PUT Response: \n" + updateUserResponse.Content);
    }

    //DELETE
    static void DeleteUser(RestClient client)
    {
        var deleteUserRequest = new RestRequest("users/2", Method.Delete);
        var deleteUserResponse = client.Execute(deleteUserRequest);
        Console.WriteLine("DELETE Response: \n" + deleteUserResponse.Content);
    }

    //GET Single User
    static void GetSingleUser(RestClient client,string id)
    {
        var getUserRequest = new RestRequest("users/"+id, Method.Get);

        var getUserResponse = client.Execute(getUserRequest);
    Console.WriteLine("GET Singale Response: \n" + getUserResponse.Content);

}
       
    
