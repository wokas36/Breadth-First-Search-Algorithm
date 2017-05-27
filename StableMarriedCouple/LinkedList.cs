using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StableMarriedCouple
{
    class LinkedList
    {
        private Link first;//Link to the first node
        //Constructor for the LinkedList
        public LinkedList() {
            first = null;
        }
        //Check whether LinkedList is empty
        public bool isEmpty() {
            return (first == null);
        }
        //Add an element to the linked list (Append)
        public void Add(int id) {
            Link newLink = new Link(id);
            newLink.next = first;
            first = newLink;
        }
        //Remove the first node from the linked list
        public Link Remove() {
            Link temp = first;
            first = first.next;
            return temp;
        }
    }
}
