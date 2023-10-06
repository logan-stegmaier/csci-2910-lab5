using System.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft; 
using Newtonsoft.Json;

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

            // e1d7ed8ca711430ca69a84da53fae680 is my UUID for my Minecraft Profile. 
            // I could have another API call that would be username based which would fill in the link with just the UUID based on a username search
            // but I decided to go a little simpler and use my already existing profile


            HttpResponseMessage response = await client.GetAsync("https://sessionserver.mojang.com/session/minecraft/profile/e1d7ed8ca711430ca69a84da53fae680?unassigned=false");

            string json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };

            MinecraftData me = System.Text.Json.JsonSerializer.Deserialize<MinecraftData>(json, options)!; //using the MinecraftData class

            // MOJANG uses a Base64 String to Encode Skin and Cape URL data 
            // So, I have to decode it and let it be its JSON string and then do some funny code
            // thanks to Morgan I got to figure this fun stuff out

            me.value = Base64Decode(me.properties[0].value);  

            //ProfileData where this JSON will be spread out to store the data + attributes 

            ProfileData profileData = JsonConvert.DeserializeObject<ProfileData>(me.value)!; //me.value is the JSON decoded 

            
            Console.WriteLine(me);
            Console.WriteLine(profileData.ToString());
            
            // user entry below

            Console.WriteLine("Would you like to preview or download the skin?\n");
            Console.WriteLine("Enter 1 to PREVIEW the skin + cape -- this will open a web browser");
            Console.WriteLine("Enter 2 to DOWNLOAD the skin");
            Console.WriteLine("Enter any thing else to EXIT.\n");

            string userResponse = Console.ReadLine();

            while (userResponse == "1" || userResponse == "2")
            {

                if (userResponse == "1")
                {
                    Console.Clear();

                    OpenImage(profileData.textures.skin.url); // method to open the image in a web browser
                    OpenImage(profileData.textures.cape.url);

                    Console.WriteLine("\nWould you like to preview or download the skin?\n");
                    Console.WriteLine("Enter 1 to PREVIEW the skin + cape -- this will open a web browser");
                    Console.WriteLine("Enter 2 to DOWNLOAD the skin");
                    Console.WriteLine("Enter any thing else to EXIT.\n");

                    userResponse = Console.ReadLine();

                }
                else if (userResponse == "2")
                {
                    Console.Clear();

                    DownloadImage(profileData.textures.skin.url, "skin.png"); //method to download and save in downloads folder

                    Console.WriteLine("\nWould you like to preview or download the skin?\n");
                    Console.WriteLine("Enter 1 to PREVIEW the skin + cape -- this will open a web browser");
                    Console.WriteLine("Enter 2 to DOWNLOAD the skin");
                    Console.WriteLine("Enter any thing else to EXIT.\n");

                    userResponse = Console.ReadLine();
                }
             
            }
            if (userResponse != "1" || userResponse != "2")
            {
                Console.Clear(); 
                Console.WriteLine("\nThank you for checking out my API Program :) - Logan");
            }


        }

        public static string Base64Decode(string base64EncodedData) //decodes the Base64 value that Mojang provided in the API Call 
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData); //takes string and does funny convert
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes); //this method was actually pretty simple than what i had anticipated
        }


        static void OpenImage(string url) //opening the image
        {
            if (!string.IsNullOrEmpty(url)) //checking to ensure it's not empty
            {
                try
                {
                    Process.Start(new ProcessStartInfo //not sure entirely what this does BUT its like a windows command to do stuff in bckgrnd
                    {
                        FileName = url,
                        UseShellExecute = true
                    });
                    Console.WriteLine("[Image] Image has been opened.");
                }
                catch (Exception ex) // catch the error msg if there is one
                {
                    Console.WriteLine($"[Image] Error opening image: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("URL is not valid."); // likely a url problem or is null or unreadable sumn sumn
            }
        }

        static void DownloadImage(string url, string fileName) // download the image!!!
        {
            if (!string.IsNullOrEmpty(url)) // same thing as open image 
            {
                try
                {
                    //capture the pathing to downloads
                    string downloadsFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                    string filePath = Path.Combine(downloadsFolder, fileName);

                    using (WebClient client = new WebClient()) //using the webclient + url, use the DownloadFile method to install it to PC
                    {
                        client.DownloadFile(url, filePath);
                    }

                    // this is the msg that everything worked epicly
                    Console.WriteLine($"[Image] {fileName} has been downloaded and successfully saved to {filePath}.");
                }
                catch (Exception ex) // catch the error if one is presented
                {
                    Console.WriteLine($"[Image] Error: {ex.Message}"); // funny error message if there is one
                }
            }
            else
            {
                Console.WriteLine("URL is not valid.");
            }
        }


    }
}