using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Globant.Java2Net.Demos.FileManager
{    
    public class JsonFileReader<T>
    {    
        public event Action<IList<T>> OnFileRead;
        public void ReadJsonFile(string filePath)
        {
            using (StreamReader stReader = new StreamReader(filePath))
            {
                var json = stReader.ReadToEnd();
                List<T> elements = Newtonsoft.Json.JsonConvert.DeserializeObject<List<T>>(json);
                OnFileRead(elements);                    
            }
        }        
    }
}