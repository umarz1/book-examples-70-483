using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace book_examples_70_483.Chaper_3
{
    public  class JsonExample
    {

        public class Track
        {
            public string Artist { get; set; }
            public string Title { get; set; }
        }

        public static void ProcessJsonSerialize()
        {
            var track = new Track();
            track.Artist = "Post Malone";
            track.Title = "Rockstar";

           var json = JsonConvert.SerializeObject(track);

        }
        public static void ProcessJsonDeserialize()
        {

            JObject json = JObject.Parse(File.ReadAllText(@"C:\Git\book-examples-70-483\book-examples-70-483\book-examples-70-483\Chaper 3\trackData.json"));

            var track = JsonConvert.DeserializeObject<Track>(json.ToString());
        }


        public static void JsonExceptionExample()
        {
            string invalidJson = "{\"Artist\": \"Bob Marley\", Title\": \"Buffulo Soldier\"}";

            try
            {
                Track trackRead = JsonConvert.DeserializeObject<Track>(invalidJson);
            }
            catch (JsonReaderException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
