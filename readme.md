# helpjuice.client
A .NET Standard/C# implementation of HelpJuice.com API v3.

| Name | Resources |
| ------ | ------ |
| API | https://help.helpjuice.com/en_US/api-v3/api-v3 |

#### Getting Started:
```
using System;
using HelpJuice.Client;

namespace HelpJuice.App
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var client = new HelpJuiceClient("https://youraccountname.helpjuice.com/api/v3/", "apikey");

            var users = client.GetUsers().Result;

            users.ForEach(user => Console.WriteLine($"{user.Id}. {user.Name}"));
            Console.Read();
        }
    }
}
```
