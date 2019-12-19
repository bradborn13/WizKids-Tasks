using System;

namespace WizKids_Tasks
{
    class Program
    {
        static void task1()
        {
            Console.WriteLine("task1");
            string initialWord = "dog";
            char[] wordArray = initialWord.ToCharArray();
            Array.Reverse(wordArray);
            string reversedWord = new string(wordArray);
            Console.WriteLine(reversedWord);
            bool isWordPalindrome = initialWord.Equals(reversedWord);
            if (isWordPalindrome)
            {
                Console.WriteLine("Palindrome ");
            }
        }
        static void task2()
        {
            Console.WriteLine("task 2");
            //OPTION A
            string condition1 = "Foo";
            string condition2 = "Bar";
            for (int loopCount = 0; loopCount < 100; loopCount++)
            {
                Console.WriteLine(loopCount);
                if (loopCount % 2 == 0)
                {
                    Console.WriteLine(condition1);
                }
                if (loopCount % 5 == 0)
                {
                    Console.WriteLine(condition2);
                }
                if (loopCount % 2 == 0 && loopCount % 5 == 0)
                {
                    Console.WriteLine(condition1 + condition2);
                }
            }

            //Console.WriteLine("task2");
            //Option B
            //string condition1 = "Foo";
            //string condition2 = "Bar";
            //int loopCount = 0;

            //for (; ; )
            //{
            //    if (loopCount < 100)
            //    {
            //        Console.WriteLine(loopCount);

            //        if (loopCount % 2 == 0)
            //        {
            //            Console.WriteLine(condition1);
            //        }
            //        if (loopCount % 5 == 0)
            //        {
            //            Console.WriteLine(condition2);
            //        }
            //        if (loopCount % 2 == 0 && loopCount % 5 == 0)
            //        {
            //            Console.WriteLine(condition1 + condition2);
            //        }
            //        loopCount++;
            //    }
            //    else break;

            //}
        }
        static void Main(string[] args)
        {
            //task1();
            //task2
        }
    }
}
