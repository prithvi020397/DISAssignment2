using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Computational_Poblem_Solving
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Question 1");
            int n = 7;
            PrintPatternAnyComplexity(n);
            PrintPatternLinearComplexity(n);


            Console.WriteLine("Question 2");
            int[] array1 = new int[] { 1, 3, 5, 4, 7 };
            int result = LongestSubSeq(array1);
            Console.WriteLine(result);

            Console.WriteLine("Question 3");
            int[] array2 = new int[] { 1, 2, 3, 4, 5, 5 };
            PrintTwoParts(array2);


            Console.WriteLine("Question 4");
            int[] array3 = new int[] { -4, -1, 0, 3, 10 };
            int[] result2 = SortedSquares(array3);
            for(int i=0; i<result2.Length; i++)
            {
                Console.Write(result2[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine("Question 5");
            int[] nums1 = { 3, 4, 5, 6, 7 };
            int[] nums2 = { 5, 6, 7, 8, 9 };
            int[] intersect1 = Intersect(nums1, nums2);
            for (int i = 0; i < intersect1.Length; i++)
            {
                Console.Write(intersect1[i] + " ");
            }
            Console.WriteLine();


            Console.WriteLine("Question 6");
            int[] arr = new int[] { 1, 2, 2, 1, 1, 3 };
            Console.WriteLine(UniqueOccurrences(arr));

            Console.WriteLine("Question 7");
            int[] numbers = { 0, 1, 3, 50, 75 };
            int lower = 0;
            int upper = 99;
            List<String> ResultList = Ranges(numbers, lower, upper);
            foreach(String l in ResultList)
            {
                Console.WriteLine(l);
            }

            Console.WriteLine("Question 8");
            string[] names = new string[] { "pes", "fifa", "gta", "pes(2019)" };
            string[] namesResult = UniqFolderNames(names);
            foreach(string s in namesResult)
            {
                Console.WriteLine(s);
            }

        }

        public static void PrintPatternAnyComplexity(int n)

        {
            try
            {
                //loop to print new line
                for (int i = 1; i <= n; i++)
                {
                    // to print the number of stars
                    for (int j = 1; j <= i; j++)
                    {
                        Console.Write("*");
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        public static void PrintPatternLinearComplexity(int n)

        {
            try
            {
                // Variable initialization 
                int i = 1;
                // Loop to print  pattern 
                int curr_star = 0;
                for (i = 1; i <= n;)
                {
                    // If current star count is less than 
                    // current line number 
                    if (curr_star < i)
                    {
                        Console.Write("*");
                        curr_star++;
                        continue;
                    }
                    // Else time to print a new line 
                    if (curr_star == i)
                    {
                        Console.WriteLine();
                        i++;
                        curr_star = 0;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        public static int LongestSubSeq(int[] nums)
        {
            try
            {
                int max = 1;
                int cnt = 1;
                int prev = nums[0];
                for (int i = 1; i < nums.Length; i++)
                {
                    // Check if the current number is greater than the earlier one
                    if (prev < nums[i])
                    {
                        // If it is greater, increment the count and continue.
                        cnt++;
                    }
                    else if (prev >= nums[i] || i == nums.Length - 1)
                    {
                        /* If it is not greater, replace the max with cnt if cnt
                        is more and setting it back to 0 to check for the next subsequence. */
                        if (cnt > max)
                        {
                            max = cnt;
                        }
                        cnt = 0;
                    }
                    prev = nums[i];
                }
                return max;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void PrintTwoParts(int[] array2)
        {
            try
            {
                int leftsum = 0;
                bool flag = false;
                //counting the whole sum of array

                for (int i = 0; i < array2.Length; i++)
                {
                    leftsum += array2[i];
                }
                int rightsum = 0;
                int j = 0;
                for (j = array2.Length - 1; j >= 0; j--)
                {
                    // adding the right elements
                    rightsum += array2[j];
                    // subtracting the right elements from leftsum
                    leftsum -= array2[j];
                    // breaking out of loop if leftsum and rightsum are equal
                    if (leftsum == rightsum)
                    {
                        Console.WriteLine("subarray-point is :" + j);
                        flag = true;
                        break;
                    }

                }
                if (flag)
                {
                    Console.WriteLine("Two subarrays are ");
                    Console.WriteLine();
                    Console.WriteLine("first subarray : ");

                    //printing the sub-arrays
                    for (int k = 0; k < j; k++)
                    {
                        Console.Write(array2[k] + " ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("second subarray : ");

                    for (int k = j; k < array2.Length; k++)
                    {
                        Console.Write(array2[k] + " ");
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Given array cannot be split into two arrays");
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static int[] SortedSquares(int[] A)
        {
            try
            {
                int[] S = new int[A.Length];
                int i = 0, ct = 0;
                for (ct = 0; ct < A.Length; ct++)
                {
                    // To check how many numbers are negative in the non decreasing order
                    if (A[ct] < 0)
                    {
                        i++;
                    }
                    // Replace the elements of array with their squares
                    A[ct] = A[ct] * A[ct];
                }
                int j = i;
                i = j - 1;
                ct = 0;
                // i for the squares of negative elements, j for the squares of positives
                while (i >= 0 && j < A.Length)
                {
                    // Replace it with the lower element of i and j
                    if (A[i] < A[j])
                    {
                        S[ct++] = A[i--];
                    }
                    else
                    {
                        S[ct++] = A[j++];
                    }
                }
                // To add any remaining elements from ith index
                while (i >= 0)
                {
                    S[ct++] = A[i--];
                }
                // To add any remaining elements from jth index
                while (j < A.Length)
                {
                    S[ct++] = A[j++];
                }
                return S;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int[] Intersect(int[] nums1, int[] nums2)
        {
            try
            {
                //declaring a dictionary to store elements of nums1
                IDictionary<int, int> dict1 = new Dictionary<int, int>();
                for (int i = 0; i < nums1.Length; i++)
                {
                    //selecting only the unique elements
                    if (!dict1.ContainsKey(nums1[i]))
                        dict1.Add(nums1[i], 0);
                    dict1[nums1[i]] = dict1[nums1[i]]+1;
                }
                //creating a hashset whichstores only unique values from nums2
                List<int> list2 = new List<int>();
                for (int i = 0; i < nums2.Length; i++)
                {
                    //adding elements to list2,iff dict1 contains nums2  elements
                    if (dict1.ContainsKey(nums2[i]) && dict1[nums2[i]]>0)
                    {
                        list2.Add(nums2[i]);
                        dict1[nums2[i]] = dict1[nums2[i]] - 1;
                    }
                }
                return list2.ToArray();
            }
            catch
            {
                throw;
            }
        }


        public static bool UniqueOccurrences(int[] arr)
        {
            try
            {
                Dictionary<int, int> occ = new Dictionary<int, int>();
                // Loop over all the elements of array
                for (int i = 0; i < arr.Length; i++)
                {
                    // Check if the key already exists in Dictionary. If not, add it to the dictionary
                    if (!occ.ContainsKey(arr[i]))
                    {
                        occ.Add(arr[i], 0);
                    }
                    // Add 1 to the value to note the occurence of the element
                    occ[arr[i]] = occ[arr[i]] + 1;
                }
                // To group by with values of dictionary
                var temp = occ.GroupBy(x => x.Value);
                // If the length of values group and dictionary is same, true is to be returned
                return temp.Count() == occ.Count;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static List<String> Ranges(int[] numbers, int lower, int upper)
        {
            try
            {
                List<string> missing_ranges = new List<string>();
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] > lower)
                    {
                        // printing only the lower range values if difference is 1
                        if (numbers[i] - lower == 1)
                        {
                            missing_ranges.Add(lower + "");
                        }
                        // printing the ranges
                        else
                        {
                            missing_ranges.Add(lower + "->" + (numbers[i] - 1));
                        }
                    }
                    // increasing lower by 1 to iterate again
                    lower = numbers[i] + 1;

                }
                //checking missing range after the last element in array
                if (lower < upper)
                {
                    missing_ranges.Add(lower + "->" + upper);
                }

                return missing_ranges;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static string[] UniqFolderNames(string[] names)
        {
            try
            {
                Dictionary<string, int> folder = new Dictionary<string, int>();
                string[] output = new string[names.Length];
                for (int i = 0; i < names.Length; i++)
                {
                    string name = names[i];
                    // Check if the name already exists, if not add and continue with next iteration
                    if (!folder.ContainsKey(name))
                    {
                        folder.Add(name, 1);
                        continue;
                    }
                    bool flag = true;
                    int j = 1;
                    while (flag)
                    {
                        // Check if the name+j exists in the dictionary if not add.
                        if (!folder.ContainsKey(name + "(" + j + ")"))
                        {
                            folder.Add(name + "(" + j + ")", 1);
                            flag = false;
                        }
                        j++;
                    }
                }
                int k = 0;
                // To add all keys into output to return
                foreach (var obj in folder)
                {
                    output[k] = obj.Key;
                    k++;
                }
                return output;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }

}
