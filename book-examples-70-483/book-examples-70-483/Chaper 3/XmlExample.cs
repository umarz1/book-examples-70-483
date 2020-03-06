using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace book_examples_70_483.Chaper_3
{
    public class XmlExample
    {

        public class Track
        {
            public string Artist { get; set; }
            public string Title { get; set; }
        }

        public static void SerializeString()
        {
            var track = new Track();
            track.Artist = "Dave";
            track.Title = "Location";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Track));

            TextWriter serWriter = new StringWriter();

            xmlSerializer.Serialize(textWriter: serWriter, o: track);
            serWriter.Close();

            string trackXml = serWriter.ToString();

            //Xml to C#
            TextReader serReader = new StringReader(trackXml);

            var trackRetrieved1 = xmlSerializer.Deserialize(serReader) as Track;
            var trackRetrieved2 = (Track)xmlSerializer.Deserialize(serReader);


        }
    }
}
