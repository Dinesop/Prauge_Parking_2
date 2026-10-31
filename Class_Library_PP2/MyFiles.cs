using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace Class_Library_PP2
{
    public static class MyFiles
    {// Där bor alla klasser och metoder som har med dataåtkomst att göra,
     // dvs Läsa fil, Spara fil och vad annat du kan behöva.
     // Förslagsvis har du en klass, till exempel MinaFiler,
     // med ett antal metoder, som Read, Save och så vidare.

        public static string Read(string filePath)
        {
            return System.IO.File.ReadAllText(filePath);
        }

        public static bool Save(string filePath, string content)
        {
            System.IO.File.WriteAllText(filePath, content);
            return true;
        }


        public static bool CheckForFile(string filePath)
        {
            if (System.IO.File.Exists(filePath)) return true;
            else return false;

        }
        public static bool CreateFile(string filePath)
        {
            System.IO.File.Create(filePath); return true;
        }
        public static bool WriteDictionaryToTxtFile(string filePath, Dictionary<string, decimal> dictionary)
        {
            StreamWriter reader = new StreamWriter(filePath);
            using (reader)
            {
                foreach (var entry in dictionary)
                    reader.WriteLine("{0} {1}", entry.Key, entry.Value);
            }

            return true;
        }


    }
}
