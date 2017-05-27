using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StableMarriedCouple
{
    class Link
    {//Node class to the LinkedList
        public int iData;//LinkedList store only integer value
        public Link next;//Reference to the nest link of the LinkedList
        //Constructor to the store value in LinkedList
        public Link(int id) {
            iData = id;
        }
    }
}
