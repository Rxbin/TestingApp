using System;
using System.Collections.Generic;
using System.Text;

namespace TestingApp.Classes
{
    public class ListNode
    {
        public int val;
        public ListNode Next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.Next = next;
        }
    }
}
