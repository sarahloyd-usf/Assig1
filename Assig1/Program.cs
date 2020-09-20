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
                int a; // variable for columns?
                int b; // variable for rows?
                int c = x; //number of rows

                for (a = 1; a <= x; a++) //columns, for loop continues until
                {
                    for (b = 1; b <= x; b++) //rows, for loop continues until
                    {
                        if (b >= c)
                            Console.Write("* "); //star written if current row is greater or equal to input
                        else
                            Console.Write(" "); //no star written if current row is less than input
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
                int a; //variable for
                int sum = 0; //tracking the sum

                Console.Write("The odd numbers are : ");

                for (a = 1; a <= n; a+=2) //for loop starts at 1 and continues every 2 numbers
                {
                    Console.Write(a);

                    sum = sum + a;

                    if (a < n)
                        Console.Write(", "); //commas if...?
                    else
                        Console.Write("\n"); //otherwise next line
                }

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
                int a; //variable for??
                int b = 0; //1=inc 2=dec tracks whether monotone increasing or decreasing

                result = true; //initially set to true

                for (a = 0; a <= n.Length; a++) //for loop continues as long as...?
                {
                    if (a == 0)
                    {
                        if (n[a + 1] > n[a])
                            b = 1;
                        else if (n[a + 1] < n[a])
                            b = 2;
                    }
                    else
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
                int a; //vsriable for??
                int searchResult; //
                int[] deDup; //array without duplicates

                deDup = J.Distinct().ToArray();
                Array.Sort(deDup); //remove duplicates and sort

                for (a = 0; a < deDup.Length - 1; a++) //for loop continues as long as...?
                {
                    searchResult = binarySearch(deDup, a + 1, deDup.Length - 1, deDup[a] + k); //binary search to find...?

                    if (searchResult != -1) numPairs++;
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


                foreach (char c in word) //set c variable, characters in word
                {

                    for (i = 0; i < keyboardArray.Length - 1; i++) //for loop continues as long as current position is within keyboard length
                    {

                        if (keyboardArray[i] == c) //if the current position in the array is equal to the character, increase the time by the number of the current position
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

                //special case
                if (a == 0)
                    return b;

                //special case
                if (b == 0)
                    return a;

                //compare end values
                if (str1[a - 1] == str2[b - 1])
                {
                    str1 = str1.Remove(a - 1);
                    str2 = str2.Remove(b - 1);
            
                    return StringEdit(str1, str2);
                }

                return 1 + new int[] { StringEdit(str1, str2.Remove(b - 1)), // Insert 
                              StringEdit(str1.Remove(a - 1), str2), // Remove 
                              StringEdit(str1.Remove(a - 1), str2.Remove(b - 1)) // Replace 
                               }.Min(); //minimum value taken from array
            }
            catch
            {
                Console.WriteLine("Exception occured while computing StringEdit()");
            }

            return 0;
        }
    }

}