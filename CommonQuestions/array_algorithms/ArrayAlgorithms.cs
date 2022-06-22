using System;
using System.Text;

namespace CommonQuestions
{
    public class ArrayAlgorithms
    {
        public static int[] CreateSubSet(int[] i_Array, int i_IdxStart, int i_IdxEnd)
        {
            int[] subset = new int[i_IdxEnd - i_IdxStart + 1];

            for (int i = i_IdxStart, j = 0; i <= i_IdxEnd; i++, j++)
            {
                subset[j] = i_Array[i];
            }

            return subset;
        }

        /// <summary>
        /// Gets the subarray containing the maximun sum of consecutive elements, and its sum value.
        /// </summary>
        /// <param name="i_Array"></param>
        /// <returns>Retunrs a <see cref="ArrayAns"/> object with the maximum subarray sum and its sum value</returns>
        public static ArrayAns GetStrongestSubSet(int[] i_Array)
        {
            int complexity = 0;
            int currMaxIdxEnd = 0;
            int currMaxIdxStart = 0;
            int currMax = 0;
            int tempMax = 0;

            for (int i = 0; i < i_Array.Length; i++)
            {
                int newMax = Math.Max(tempMax + i_Array[i], i_Array[i]);

                if (newMax == i_Array[i])
                {
                    currMaxIdxStart = i;
                }

                if (newMax > currMax)
                {
                    currMax = newMax;
                    currMaxIdxEnd = i;
                }

                tempMax = newMax;
                complexity++;
            }

            return new ArrayAns() {
                ResultArray = CreateSubSet(i_Array, currMaxIdxStart, currMaxIdxEnd),
                ResultVal = currMax,
                Complexity = complexity };
        }

        public static int GetStrongestSubSetSum(int[] i_Array, int i_StartIdx, int i_CurrentMax)
        {
            ////stop when reached the last element in the array
            ////returns the current max subset sum value
            if (i_StartIdx == i_Array.Length - 1)
            {
                return i_CurrentMax > i_Array[i_StartIdx] ?
                    i_CurrentMax : (i_CurrentMax + i_Array[i_StartIdx]) > i_CurrentMax ?
                    i_CurrentMax + i_Array[i_StartIdx] : i_Array[i_StartIdx];
                //return Math.Max(i_CurrentMax + i_Array[i_StartIdx], i_CurrentMax,i_Array[i_StartIdx]);
            }

            return i_CurrentMax + i_Array[i_StartIdx] > i_Array[i_StartIdx] ?
                GetStrongestSubSetSum(i_Array, i_StartIdx + 1, i_CurrentMax + i_Array[i_StartIdx]) :
                GetStrongestSubSetSum(i_Array, i_StartIdx + 1, i_Array[i_StartIdx]);

        }

        /// <summary>
        /// Gets an array containing the highest sums of consecutive elements in the input array, 
        /// and the maximum sum value of consecutive elements found.
        /// Recurrence relation function:
        /// S[i] = {                         
        ///                                  0 , i = 0
        ///         Max(S[i - 1] + A[j], A[j]) , i > 0 && j >= 0 
        ///        }
        /// Uses the aformentioned recurrence relation function to fill an array with the highest sums 
        /// of consecutive elements found in an array of integers.
        /// </summary>
        /// <param name="i_Array">an array of integeres</param>
        /// <returns>An array containing the highest subarrays sums.</returns>
        public static ArrayAns GetStrongestSubsetsSums(int[] i_Array)
        {
            int complexity = 0;
            //the recurrence relation array, to be filled with the max subarrays sum values
            int[] subSetSums = new int[i_Array.Length + 1];

            //the current max sum in the recurrence relation array 
            int currMax = 0;

            //defines the lowest possible max value, as the first element in the recurrence relation array.
            subSetSums[0] = 0;

            for (int i = 1, j = 0; i < subSetSums.Length && j < i_Array.Length; i++, j++)
            {
                //gets the maximum of two values:
                //[the last sum of the current consecutive elements + the new value] vs [the new value].
                //when maximum equals [the new value], a new subarray sum has started.
                int newMaxSubSetSum = Math.Max(subSetSums[i - 1] + i_Array[j], i_Array[j]);

                if (newMaxSubSetSum > currMax)
                {
                    currMax = newMaxSubSetSum;
                }

                //insert the new max to the recurrence relation array
                subSetSums[i] = newMaxSubSetSum;

                complexity++;
            }

            return new ArrayAns() { ResultArray = subSetSums, ResultVal = currMax, Complexity = complexity };
        }

        public static ArrayAns Fibonacci(int i_Position)
        {
            int fibonacci = 1;
            int current = 0;
            int complexity = 0;
            for (int i = 1; i < i_Position; i++)
            {
                int tmp = fibonacci;
                fibonacci += current;
                current = tmp;

                complexity++;
            }

            return new ArrayAns() { ResultVal = fibonacci, Complexity = complexity };
        }

        public static int FibonacciRecursive(int i_Position)
        {
            if(i_Position == 0)
            {
                return 0;
            }

            if (i_Position == 1)
            {
                return 1;
            }

            return FibonacciRecursive(i_Position - 2) + FibonacciRecursive(i_Position - 1);
        }

        public bool IsValueInArray(int[] i_Nums, int i_Val, int i_StartIndex)
        {
            if (i_Nums.Length == i_StartIndex)
            {
                return false;
            }

            return i_Nums[i_StartIndex] == 6 ?
                true : IsValueInArray(i_Nums, i_Val, i_StartIndex + 1);
        }
        public int CountValueInArray(int[] i_Nums, int i_Val, int i_Index)
        {
            if (i_Nums.Length == i_Index)
            {
                return 0;
            }

            return CountValueInArray(i_Nums, i_Val, i_Index + 1) + (i_Nums[i_Index] == i_Val ? 1 : 0);

        }
        public bool CountConsecutiveElementRelation(int[] nums, int index, Func<int, int, bool> i_Predicate)
        {
            if (nums.Length == index)
            {
                return false;
            }

            //return index < nums.Length - 1 && nums[index] * 10 == nums[index + 1] ? 
            //    true : CountConsecutiveElementRelation(nums, index + 1);

            return index < nums.Length - 1 && i_Predicate.Invoke(nums[index], nums[index + 1]) ?
                        true : CountConsecutiveElementRelation(nums, index + 1, i_Predicate);
        }
        public bool groupSum(int start, int[] nums, int target)
        {
            if (start >= nums.Length)
            {
                return target == 0;
            }

            return groupSum(start + 1, nums, target - nums[start]) ||
                    groupSum(start + 1, nums, target);
        }
        private bool splitArray(int[] nums, int start, int group1, int group2)
        {
            if (start >= nums.Length)
            {
                return group1 == group2;
            }

            return splitArray(nums, start + 1, nums[start] + group1, group2) ||
            splitArray(nums, start + 1, group1, nums[start] + group2);
        }
        public class ArrayAns
        {
            public int[] ResultArray { get; set; }
            public int ResultVal { get; set; }
            public int Complexity { get; set; }
        }

        public class Complexity
        {
            public string ComplexityText
            {
                get
                {
                    return "sf";
                }
            }

            public Complexity(int i_Steps, int i_CollectionSize)
            {
                double div = i_Steps / i_CollectionSize;
                double remainder = i_Steps % i_CollectionSize;

                if (div == 1) //O(n)
                {

                }
                else if (div > 1 && div < i_CollectionSize && remainder == 0)
                {

                }
                else if (div == i_CollectionSize) //O(n^2)
                {

                }
            }

            
        }
    }
}