using System;

namespace RedisSentinelClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Connecting to a sentinel with 3 node
            var conn = await ConnectionMultiplexer.ConnectAsync("192.168.106.210:6379,192.168.106.211:6379,192.168.106.212:6379");
            // Getting the default database instance(index 0)
            IDatabase db = conn.GetDatabase();

            // Set a key (Name)
            await db.StringSetAsync("Name", "Roozbeh Maheronnaghsh");
            // Get the value on 'Name' key
            string name = await db.StringGetAsync("Name");
            
            Console.WriteLine(name);
        }
    }
}
