using System;
using System.Collections.Specialized;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Threading.Channels;
//Sarah Loyd ISM 6225 Assig 1
namespace Assignment1_Fall20
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintTriangle(n);

            int n2 = 5;
            PrintSeriesSum(n2);

            int[] A = new int[] { 1, 2, 2, 6 }; ;
            bool check = MonotonicCheck(A);
            Console.WriteLine(check);

            int[] nums = new int[] { 3, 1, 4, 1, 5 };
            int k = 2;
            int pairs = DiffPairs(nums, k);
            Console.WriteLine(pairs);

            string keyboard = "abcdefghijklmnopqrstuvwxyz";
            string word = "dis";
            int time = BullsKeyboard(keyboard, word);
            Console.WriteLine(time);

            string str1 = "goulls";
            string str2 = "gobulls";
            int minEdits = StringEdit(str1, str2);
            Console.WriteLine(minEdits);

        }

        public static void PrintTriangle(int x)
        {
            try
            {
                //QUESTION 1
                int a; // variable for rows
                int b; // variable for columns
                int c = x; //number of rows

                for (a = 1; a <= x; a++) //loop through all the rows
                {
                    for (b = 1; b <= x; b++) //loop through the columns
                    {// write spaces and stars
                        if (b >= c)
                            Console.Write("* "); 
                        else
                            Console.Write(" "); 
                    }
                    c--;
                    Console.Write("\n"); //next line
                }
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintTriangle()");
            }
        }

        public static void PrintSeriesSum(int n)
        {
            try
            {
                //QUESTION 2
                int a; //variable for the odd numbers
                int sum = 0; //tracking the sum

                Console.Write("The odd numbers are : ");

                for (a = 1; a <= n; a+=2) //loop n times, increment by 2 each time for odd numbers
                {
                    Console.Write(a);

                    //keep a running sum of each number
                    sum = sum + a;

                    // at the end, write a line feed, otherwise, write a comma
                    if (a < n)
                        Console.Write(", "); 
                    else
                        Console.Write("\n"); 
                }

                //display the sum
                Console.WriteLine("The sum is : " + sum);
            }
            catch
            {
                Console.WriteLine("Exception occured while computing PrintSeriesSum()");
            }
        }

        public static bool MonotonicCheck(int[] n)
        {
            try
            {
                //QUESTION 3
                bool result; //true or false
                int a; //variable for array loop
                int b = 0; //1=inc 2=dec tracks whether monotone increasing or decreasing

                result = true; //initially set to true for the case of no change

                for (a = 0; a <= n.Length; a++) //loop through each array value
                {
                    if (a == 0) //first time through establish if it is inc or dec using b to store it
                    {
                        if (n[a + 1] > n[a])
                            b = 1;
                        else if (n[a + 1] < n[a])
                            b = 2;
                    }
                    else // for every other loop, check if inc or dec and compare it to b to see if it stays inc or dec, if it flips, then set to false and stop
                    {
                        if ((n[a + 1] > n[a]) & (b == 2))
                        {
                            result = false;
                            a = n.Length;
                        } 
                        else if ((n[a + 1] < n[a]) & (b == 1))
                            result = false;
                            a = n.Length;
                    }
                }
                return result;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing MonotonicCheck()");
            }

            return false;
        }

        public static int DiffPairs(int[] J, int k)
        {
            try
            {
                // QUESTION 4
                int numPairs = 0; //number of pairs, initialized to 0
                int a; //for looping thorugh dedup array
                int searchResult; //result returned from the binarySearch function
                int[] deDup; //array without duplicates

                deDup = J.Distinct().ToArray(); //remove duplicate values from the array
                Array.Sort(deDup); //sort the array

                for (a = 0; a < deDup.Length - 1; a++) //loop through the array
                {
                    searchResult = binarySearch(deDup, a + 1, deDup.Length - 1, deDup[a] + k); //search the rest of the array for this array value + k

                    if (searchResult != -1) numPairs++; // if a match was found, increment the numPairs
                }
                return numPairs;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing DiffPairs()");
            }

            return 0;
        }

        //STANDARD BINARY SEARCH FUNCTION (used an online reference)///////////
        public static int binarySearch(int[] arr, int low, int high, int x)
        {
            if (high >= low)
            {
                int mid = low + (high - low) / 2;
                if (x == arr[mid])
                    return mid;
                if (x > arr[mid])
                    return binarySearch(arr, (mid + 1), high, x);
                else
                    return binarySearch(arr, low, (mid - 1), x);
            }

            return -1;
        }
        /////////////

        public static int BullsKeyboard(string keyboard, string word)
        {
            try
            {
                //QUESTION 5
                int time = 0; //total time
                int i = 0; //current position on the keyboard
                char[] keyboardArray = keyboard.ToCharArray(); //convert string to array


                foreach (char c in word) //loop thourgh each character in word
                {

                    for (i = 0; i < keyboardArray.Length - 1; i++) //for loop continues as long as current position is within keyboard length
                    {

                        if (keyboardArray[i] == c) //if the current position in the array is equal to the character then we found it, so increase the time by the number of the current position
                        {
                            time = time + i;
                        }
                    }
                }
                return time;
            }
            catch
            {
                Console.WriteLine("Exception occured while computing BullsKeyboard()");
            }

            return 0;
        }

        public static int StringEdit(string str1, string str2)
        {
            try
            {
                //QUESTION 6
                int a = str1.Length;
                int b = str2.Length;

                //This uses the known algorithm for minimum edit distance

                //if str1 is blank, then the number of edits equals length of str2
                if (a == 0)
                    return b;

                //if str2 is blank, then the number of edits equals length of str1
                if (b == 0)
                    return a;

                //compare last values in strings
                // if they're the same, just chop them off and recursively call the function
                if (str1[a - 1] == str2[b - 1])
                {
                    str1 = str1.Remove(a - 1);
                    str2 = str2.Remove(b - 1);
            
                    return StringEdit(str1, str2);
                }

                //otherwise, the min of the three surrounding elements is the answer
                return 1 + new int[] { StringEdit(str1, str2.Remove(b - 1)), // Insert 
                              StringEdit(str1.Remove(a - 1), str2), // Remove 
                              StringEdit(str1.Remove(a - 1), str2.Remove(b - 1)) // Replace 
                               }.Min(); 
            }
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
    }

}