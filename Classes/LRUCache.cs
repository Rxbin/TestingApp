using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestingApp.Classes
{
    public class LRUCache
    {
        private int capacity { get; set; }

        // Store the values and retrieve them quickly.
        private Dictionary<int, int> storage = new Dictionary<int, int>();

        // Store the nodes based on their keys. We can look up the nodes using their keys as they come in.
        private Dictionary<int, LinkedListNode<int>> nodeLookupStorage = new Dictionary<int, LinkedListNode<int>>();

        // Keep a list of nodes we touched. Keep them in order as them come in and update this list as they are touched.
        private LinkedList<int> leastRecentlyTouched = new LinkedList<int>();

        public LRUCache(int capacity)
        {
            this.capacity = capacity;
        }

        public int Get(int key)
        {
            if (!storage.ContainsKey(key))
                return -1;

            var currNode = nodeLookupStorage[key];

            // We touched this value to "Get" it so take it out of the list and set it at the front.
            leastRecentlyTouched.Remove(currNode);
            leastRecentlyTouched.AddFirst(currNode);

            return storage[key];
        }

        public void Put(int key, int value)
        {
            // Two cases here. 
            // 1. We aren't at max capacity (storage.Count < capacity)
            // 2. We are full, so we need to get the least recently touched node and remove it.
            //    Then we need to update the leastRecentlyTouched collection with the new "Put" node.

            if (!storage.ContainsKey(key))
            {
                if (storage.Count < capacity)
                {
                    storage.Add(key, value);

                    leastRecentlyTouched.AddFirst(new LinkedListNode<int>(value));
                    nodeLookupStorage.Add(key, leastRecentlyTouched.First);
                }
                else
                {
                    var lastNode = leastRecentlyTouched.Last;
                    leastRecentlyTouched.RemoveLast();
                    leastRecentlyTouched.AddFirst(new LinkedListNode<int>(value));

                    var storeKey = storage.Where(x => x.Value == lastNode.Value).First();
                    var nodeKey = nodeLookupStorage.Where(x => x.Value == lastNode).First();

                    storage.Remove(storeKey.Key);
                    storage.Add(key, value);
                    nodeLookupStorage.Remove(nodeKey.Key);
                    nodeLookupStorage.Add(key, leastRecentlyTouched.First);
                }
            }
            else
            {
                storage[key] = value;

                var currNode = nodeLookupStorage[key];

                leastRecentlyTouched.Remove(currNode);
                leastRecentlyTouched.AddFirst(currNode);
            }
        }

    }
}
