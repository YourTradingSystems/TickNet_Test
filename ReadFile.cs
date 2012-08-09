using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace TickNet
{
    class ReadFile
    {
         public List<string> parseCSV(string path)
        {
            List<string> parsedData = new List<string>();

            using (StreamReader readFile = new StreamReader(path))
            {
                string line;
                string[] row;

                while ((line = readFile.ReadLine()) != null)
                {
                    //row = line.Split(',');
                    parsedData.Add(line);
                }
                readFile.Close();
            }

           
            return parsedData;
        }
    }
}
