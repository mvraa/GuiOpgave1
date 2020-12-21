using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GuiEksamen.Models
{
    //Borrowed from Agent Assignment solution.
    public class Repository
    {
        
        internal static void ReadFile(string fileName, out ObservableCollection<User> debtorCreditors)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to deserialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<User>));
            TextReader reader = new StreamReader(fileName);
            // Deserialize all the debtors.
            debtorCreditors = (ObservableCollection<User>)serializer.Deserialize(reader);
            reader.Close();
        }

        internal static void SaveFile(string fileName, ObservableCollection<User> debtorCreditors)
        {
            // Create an instance of the XmlSerializer class and specify the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ObservableCollection<User>));
            TextWriter writer = new StreamWriter(fileName);
            // Serialize all the agents.
            serializer.Serialize(writer, debtorCreditors);
            writer.Close();
        }
    }
}
