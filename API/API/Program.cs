﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await MinecraftCall();

        }

        public static async Task MinecraftCall()
        {

            var client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://sessionserver.mojang.com/session/minecraft/profile/e1d7ed8ca711430ca69a84da53fae680");

            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            MinecraftData me = JsonSerializer.Deserialize<MinecraftData>(json, options);

            me.value = Base64Decode(me.properties[0].value);

            var jsonObject = JsonSerializer.Deserialize<MinecraftData>(me.value, options);
            
            Console.WriteLine(me + "\n");
        }

        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}