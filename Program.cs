using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALBRIGHT_ASSIGNMENT_6_2
{
    internal class Program
    {
        // MSSA CCAD16 - 10DEC2024
        // CHRIS ALBRIGHT
        // ASSIGNMENT 6.2
        static void Main(string[] args)
        {
            // Assignment 6.2.1 ---------------------------------------------------------------------------------------------

            // Write a C# program to implement a stack by using array with push and pop operations.

            Console.WriteLine("Assignment 6.2.1 ----------------------------------------------------------------------------");
            Console.WriteLine("ARRAY 'STACK' PUSH/POPPER:");
            char hold1 = 'y';
            do
            {
                int[] array = { 1, 2, 3, 4, 5 };

                char hold2 = 'y';
                do
                {
                    Console.WriteLine($"\nOriginal array: {string.Join(", ",array)}");
                    Console.WriteLine("\ntype push or pop:");
                    string operation = Console.ReadLine();
                    switch (operation)
                    {
                        case "push":
                            Console.WriteLine("\nEnter an integer to push:");
                            int push = Convert.ToInt32(Console.ReadLine());
                            int[] newArrayPush = ArrayPush(push, array);
                            array = null;
                            array = newArrayPush;
                            Console.WriteLine("\nPushed Value: " + push);
                            Console.WriteLine($"\nArray after Push: {string.Join(", ", newArrayPush)}");
                            break;
                        case "pop":
                            var result = ArrayPop(array);
                            int[] newArrayPop = result.Item1;
                            Console.WriteLine("\nPopped Value: " + result.Item2);
                            Console.WriteLine($"\nArray after Pop: {string.Join(", ", result.Item1)}");
                            array = null;
                            array = newArrayPop;
                            break;
                        default:
                            Console.WriteLine("\nUnknown operation...");
                            break;
                    }
                    Console.WriteLine($"\nWant to push/pop again? type y/n");
                    hold2 = Console.ReadKey().KeyChar;
                    hold2 = Char.ToLower(hold2);
                }
                while (hold2 == 'y');

                Console.WriteLine($"\nWant to run assignment 6.2.1 again? type y/n");
                hold1 = Console.ReadKey().KeyChar;
                hold1 = Char.ToLower(hold1);

            }
            while (hold1 == 'y');


            // Assignment 6.2.2 ---------------------------------------------------------------------------------------------

            // Given an integer array nums, return an array answer such that answer[i] is equal to the product of all the
            // elements of nums except nums[i]. The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit
            // integer. You must write an algorithm that runs in O(n) time and without using the division operation.

            Console.WriteLine("\n\nAssignment 6.2.1 ----------------------------------------------------------------------------");
            Console.WriteLine("PRODUCT ARRAY RETURNER:");
            char hold3 = 'y';
            do
            {
                int[] nums = { 1, 2, 3, 4 };
                Console.WriteLine("\nOriginal array:");
                Console.Write("[ ");
                for (int i = 0; i < nums.Length; i++)
                {
                    Console.Write(nums[i] + ", ");
                }
                Console.Write("]");

                // N^2 Solution
                int[] numsProduct = {1,1,1,1};

                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        if (j == i)
                        {
                            continue;
                        }
                        int hold = nums[j];
                        numsProduct[i] = hold * numsProduct[i];
                    }
                }
                Console.WriteLine("\nN^2 Solution:");
                Console.Write("[ ");
                for (int i = 0; i < numsProduct.Length; i++)
                {
                    Console.Write(numsProduct[i]+", ");
                }
                Console.Write("]");

                //Linear Solution
                int[] nums2 = { 1, 2, 3, 4 };
                int[] numsMod = { 1, nums2[0], nums2[1], nums2[2], nums2[3], 1 };
                int[] nums2Left = { 1, 0, 0, 0 };
                int[] nums2Right = { 0, 0, 0, 1};
                for (int i = 1; i < nums2Left.Length; i++)
                {
                    nums2Left[i] = nums2Left[i-1] * numsMod[i];
                }
                for (int i = 2;i > -1; i--)
                {
                    nums2Right[i] = nums2Right[i+1] * numsMod[i+2];
                }
                Console.WriteLine("\nN (Linear) Solution:");
                Console.Write("[ ");
                for (int i = 0; i < nums2Right.Length; i++)
                {
                    nums2Right[i] = nums2Right[i] * nums2Left[i];
                    Console.Write(nums2Right[i] + ", ");
                }
                Console.Write("]");
                Console.WriteLine($"\n\nWant to run assignment 6.2.2 again? type y/n");
                hold3 = Console.ReadKey().KeyChar;
                hold3 = Char.ToLower(hold3);

            }
            while (hold3 == 'y');

            Console.WriteLine("Goodbye!");
        }
        //-----------------------------------------------------METHODS-------------------------------------------------------
        public static int[] ArrayPush(in int push, in int[] array)
        {
            int[] newArray = new int[array.Length + 1];
            for (int i = 0; i<array.Length; i++)
            {
                newArray[i] = array[i];
            }
            newArray[array.Length] = push;
            return newArray;
        }
        public static (int[],int) ArrayPop(in int[] array)
        {
            if (array.Length == 0 || array == null)
            {
                Console.WriteLine("Array is empty");
            }
            int poppedValue = array[array.Length - 1];
            int[] newArray = new int[array.Length-1];
            Array.Copy(array, newArray, array.Length-1);
            return (newArray, poppedValue);
        }
    }
}
