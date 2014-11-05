using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalGame.Classes.Items
{
    [Serializable]
    public class Item : IComparable
    {
        public int Grade { get; protected set; }
        public Type ItemType { get; protected set; }
        public string ItemDescription { get; protected set; }
        public string ItemName { get; protected set; }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
