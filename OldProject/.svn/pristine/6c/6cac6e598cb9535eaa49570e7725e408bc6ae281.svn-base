using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HeDiesAtTheEnd.Classes.Save_Function
{
    class Saving
    {
        static void serialize(Classes.Character.Player playerToSerialize, string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, playerToSerialize);
            stream.Close();
        }

        static Classes.Character.Player deserialize(string fileName)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            Classes.Character.Player deserializedPlayer = (Classes.Character.Player)formatter.Deserialize(stream);
            stream.Close();

            return deserializedPlayer;
        }
    }
}
