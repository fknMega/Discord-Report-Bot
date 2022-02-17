// See https://aka.ms/new-console-template for more information
using Leaf.xNet;

Console.WriteLine("Your Token:");
var token = Console.ReadLine();


Console.WriteLine("Server id:");
var guildid = Console.ReadLine();


Console.WriteLine("Channel id:");
var channelid = Console.ReadLine();


Console.WriteLine("Message id:");
var messageid = Console.ReadLine();


Console.WriteLine("Reason:");
var reason = Console.ReadLine();
/* - reasons:
 
Type:
1 - Illegal Content
2 - Harrassment
3 - Spam or Phishing Links
4 - Self harm
5 - NSFW

  */


HttpRequest httpRequest = new HttpRequest();
httpRequest.Authorization = token;
httpRequest.UserAgentRandomize();

string url = "https://discord.com/api/v6/report";
string jsonData = "{\"channel_id\": \"" + channelid + "\", \"guild_id\": \"" + guildid + "\", \"message_id\": \"" + messageid + "\", \"reason\": \"" + reason + "\" }";
int total = 0;
int reported = 0;



while (true)
{
    total++;
    try
    {
        var response = httpRequest.Post(url, jsonData, "application/json");

        if (response.StatusCode.ToString() == "Created")
        {
            reported++;
            Console.WriteLine("Report Sent! (CODE: " + response.StatusCode+")");
        }
        else
        {
            Console.WriteLine("Error! (CODE: " + response.StatusCode);

        }
        Console.Title = "Total Requests sent: " + total + " Reported received: " + reported;
    }
    catch
    {
        Console.WriteLine("Error");
    }
}