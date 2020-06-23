using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestingApp.Classes;

namespace TestingApp
{
    class Program
    {
        #region ARRAY Questions
        //
        // Questions can be found here: https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/
        //

        // Brute Force finder.
        static int[] TwoSums(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++) 
            {
                for (int j = i + 1; j < nums.Length; j++) 
                {
                    int number = nums[i] + nums[j];

                    if (number == target)
                        return new int[] { nums[i], nums[j] };
                }
            }

            return null;
        }

        static ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
        {
            ListNode result = new ListNode(0);
            ListNode head = result;
            int carry = 0;

            while (l1 != null || l2 != null)
            {
                int sum = carry;

                if (l1 != null)
                {
                    sum += l1.val;
                    l1 = l1.Next;
                }

                if (l2 != null)
                {
                    sum += l2.val;
                    l2 = l2.Next;
                }

                if (sum >= 10)
                {
                    carry = sum / 10;
                    sum = sum % 10;
                }
                else
                {
                    carry = 0;
                }

                result.Next = new ListNode(sum);
                result = result.Next;
            }

            if (carry > 0)
            {
                result.Next = new ListNode(carry);
            }

            return head = head.Next;
        }

        // Removes duplicates from Array and returns the total.
        // This assumes that the array is sorted.
        int RemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;

            int curr = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[curr])
                {
                    curr++;
                    nums[curr] = nums[i];
                }
            }

            return curr + 1;
        }

        static int MaxProfit(int[] prices) 
        {
            int total = 0;

            for (int i = 0; i < prices.Length - 1; i++) 
            {
                if (prices[i] < prices[i + 1])
                {
                    total += prices[i + 1] - prices[i];
                }     
            }

            return total;
        }

        // Too much time spent according to solution..
        //public static void Rotate(int[] nums, int k)
        //{
        //    int curr = 0, prev = 0;

        //    for (int i = 0; i < k; i++) 
        //    {
        //        prev = nums[nums.Length - 1];

        //        for (int j = 0; j < nums.Length; j++)
        //        {
        //            curr = nums[j];
        //            nums[j] = prev;
        //            prev = curr;
        //        }
        //    }
        //}

        static void Rotate(int[] nums, int k)
        {
            k %= nums.Length;
            reverse(nums, 0, nums.Length - 1);
            reverse(nums, 0, k - 1);
            reverse(nums, k, nums.Length - 1);
        }

        static void reverse(int[] nums, int start, int end)
        {
            while (start < end)
            {
                int temp = nums[start];
                nums[start] = nums[end];
                nums[end] = temp;
                start++;
                end--;
            }
        }

        static bool ContainsDuplicate(int[] nums)
        {
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (nums[i] == nums[i + 1]) 
                    return true;
            }

            return false;
        }

        static int SingleNumber(int[] nums)
        {
            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 1; ++i)
            {
                if (nums[i] != nums[i + 1])
                    return nums[i];
                else
                    i++;
            }

            return nums[nums.Length - 1];
        }

        static int[] Intersect(int[] nums1, int[] nums2)
        {
            List<int> vals = new List<int>();
            List<int> nums2List = nums2.ToList();
            
            int total = vals.First(), prev = vals.First();

            foreach (var num in nums1) 
            {
                if (nums2List.Contains(num)) 
                {
                    vals.Add(num);
                    nums2List.Remove(num);
                }
            }

            StringBuilder sb = new StringBuilder();
            DateTime d = new DateTime();

            return vals.ToArray();
        }

        static void MoveZeroes(int[] nums) 
        {
            for (int i = 0; i < nums.Length; i++) 
            {
                if (nums[i] == 0)
                {
                    for (int j = i + 1; j < nums.Length; j++)
                    {
                        if (nums[j] != 0)
                        {
                            int temp = nums[i];
                            nums[i] = nums[j];
                            nums[j] = temp;

                            break;
                        }
                    }
                }
            }
        }

        static bool IsValidSudoku(char[][] board) 
        {
            HashSet<string> boardVals = new HashSet<string>();

            for (int i = 0; i < board.Length; i++) 
            {
                for (int j = 0; j < board.Length; j++) 
                {
                    char curr_val = board[i][j];

                    if (curr_val != '.') 
                    {
                        if (!boardVals.Add(string.Format("{0} found in row {1}", curr_val, i)) || 
                           (!boardVals.Add(string.Format("{0} found in column {1}", curr_val, j))) ||
                           (!boardVals.Add(string.Format("{0} found in box {1}-{2}", curr_val, i/3, j/3)))) 
                        {
                            return false;                        
                        }
                    }
                }
            }

            return true;
        }

        static List<string> preprocessDate(List<string> dates)
        {
            // Dictionary doesn't have to do unboxing like a Hashtable, so this will be the quickest.
            Dictionary<string, string> monthConverter = new Dictionary<string, string>();
            monthConverter.Add("Jan", "01");
            monthConverter.Add("Feb", "02");
            monthConverter.Add("Mar", "03");
            monthConverter.Add("Apr", "04");
            monthConverter.Add("May", "05");
            monthConverter.Add("Jun", "06");
            monthConverter.Add("Jul", "07");
            monthConverter.Add("Aug", "08");
            monthConverter.Add("Sep", "09");
            monthConverter.Add("Oct", "10");
            monthConverter.Add("Nov", "11");
            monthConverter.Add("Dec", "12");

            List<string> result = new List<string>();

            foreach (var date in dates)
            {
                string[] dateParts = date.Split(' ');
                string day = dateParts[0].TrimEnd('t', 'h');
                string year = dateParts[2];
                string month = monthConverter[dateParts[1]];

                DateTime time = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));

                result.Add(time.ToString("yyyy-MM-dd"));
            }

            return result;

        }

        #endregion

        static long arrayManipulation(int n, int[][] queries)
        {
            long answer;
            int[] array = new int[n];

            foreach (var val in queries)
            {
                for (int i = val[0]; i <= val[1]; i++)
                {
                    array[i] += val[2];
                }
            }

            answer = (long)array.Max();
            return answer;
        }

        static int StrongPasswordChecker(string s)
        {
            if (s.Length < 6 || s.Length > 20)
                return 1;

            List<char> dups = new List<char>();
            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;

            foreach (var letter in s)
            {
                if (!hasDigit && char.IsDigit(letter))
                    hasDigit = true;

                if (!hasUpper && char.IsUpper(letter))
                    hasUpper = true;

                if (!hasLower && char.IsLower(letter))
                    hasLower = true;

                if (dups.Contains(letter))
                {
                    dups.Add(letter);

                    if (dups.Count > 2)
                        return 1;
                }
                else
                {
                    dups.Clear();
                    dups.Add(letter);
                }

            }

            if (hasUpper && hasLower && hasDigit)
                return 0;
            else
                return 1;
        }

        static int LengthOfLongestSubstring(string s)
        {
            #region Mine

            //int prevLength = 1;
            //char[] array = s.ToArray();
            //List<char> seen = new List<char>();

            //// Standard string traversal.
            //for (int i = 0; i < s.Length; i++) 
            //{
            //    int count = 0;

            //    // Our look ahead.
            //    for (int j = i; j < s.Length; ++j) 
            //    {
            //        if (!seen.Contains(array[j]))
            //        {
            //            seen.Add(array[j]);
            //            count++;
            //        }
            //        else
            //        {
            //            seen.Clear();

            //            if(prevLength < count)
            //                prevLength = count;

            //            break;
            //        }

            //        if (prevLength < count)
            //            prevLength = count;
            //    }
            //}

            //return prevLength;

            #endregion Mine

            HashSet<char> set = new HashSet<char>();
            int j = 0;
            int i = 0;
            int max = 0;

            while (j < s.Length)
            {
                if (!set.Contains(s[j]))
                {
                    set.Add(s[j]);
                    j++;
                    max = Math.Max(set.Count(), max);
                }
                else
                {
                    set.Remove(s[i]);
                    i++;
                }
            }

            return max;
        }

        static int NumIslands(char[][] grid)
        {
            if (grid == null || grid.Length == 0)
                return 0;

            int numRows = grid.Length;
            int numCols = grid[0].Length;
            int numOfIslands = 0;

            for (int row = 0; row < numRows; ++row)
            {
                for (int col = 0; col < numCols; ++col)
                {
                    if (grid[row][col] == '1')
                    {
                        numOfIslands++;
                        depthFirstSearch(grid, row, col);
                    }
                }
            }

            return numOfIslands;
        }

        static void depthFirstSearch(char[][] grid, int row, int col)
        {
            int numRows = grid.Length;
            int numCols = grid[0].Length;

            // Some basic checks. If we hit a 0 just return, we are in the water.
            if (row < 0 || col < 0 || row >= numRows || col >= numCols || grid[row][col] == '0')
                return;

            // We are saying that the root node is going to trigger the island.
            // If we have at least one '1', we are sure to have at minimum one island.
            // This is updated in the main method.
            // We set the the other nodes that re '1' to '0' so that we don't hit them on the next search in
            // the main method.
            grid[row][col] = '0';

            // Continue the search.
            // In this case we want to look above, below, left and right of the current node.
            // Ignore diagonal direction.
            depthFirstSearch(grid, row + 1, col);
            depthFirstSearch(grid, row - 1, col);
            depthFirstSearch(grid, row, col + 1);
            depthFirstSearch(grid, row, col - 1);
        }

        static void Main(string[] args)
        {
            //char[][] board = new char[][]
            //{
            //    new char[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
            //    new char[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
            //    new char[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
            //    new char[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
            //    new char[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
            //    new char[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
            //    new char[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
            //    new char[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
            //    new char[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' },
            //};


        }
    }
}
