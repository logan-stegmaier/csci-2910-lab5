# csci-2910-lab5
Stegmaier, Logan

LAB 5: API

Most notable issues encountered: 
- Base64 String Value from Mojang left me clueless on how to approach it 
- Converting a JSON String back into an object that can be, once again, read and ToString()'d from the object
- Implementing Methods to Download and Open the Skin and Cape Images (Having issues using HTTPClient and using bytes to save)

How I solved these issues: 
- I heavily researched and utilized ChatGPT as a tool to combine my ideas together (in turn learning a new Class called Process which allows for Windows executable commands behind the scenes via programming)
- I had to research what the Mojang "Base64" Value String actually did as I was confused about its intended purpose
- Following the Base64 research, I found a method that was commonly used to decode it - turning it into JSON String
- JSON String needed to be read so I installed NewtonSoft JSON and used it in my project - using the methods to re-direct it into an object
- As previously mentioned, ChatGPT helped in swiftly building methods to download and view the images. I wanted to try using this as I wanted to see if I could expand on the API's functionality - I fully understood what was being done and made notes as I programmed
- I noticed HTTPClient wasn't doing me a solid in getting a good download so I referred to an older and still accepted C# Class called WebClient which had an inbuilt DownloadFile method. 
