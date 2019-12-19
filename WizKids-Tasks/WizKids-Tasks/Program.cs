using System;
using System.Text.RegularExpressions;

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
        static void task3()
        {
            string originalText = "Christian has the email address christian+123@gmail.com. Christian's friend, John Cave-Brown, has the email address john.cave-brown@gmail.com. John's daughter Kira studies at Oxford University and has the email address Kira123@oxford.co.uk. Her twitter handle is @kira.cavebrown.";
            string modifiedText = originalText;
            Regex emailRegex = new Regex(@"^([\w\.\-+]+)@([\w\-]+)((\.(\w){2,3})+)");
            String punctuationRegexPattern = @"[\p{P}-[()\-.@ ]]";
            var textRemovePunctiation = Regex.Replace(originalText, punctuationRegexPattern, "");
            var textSplit = textRemovePunctiation.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in textSplit)
            {
                var regexFixDotEmailCondition = word[word.Length - 1].ToString() == ".";
                var filteredWord = regexFixDotEmailCondition ? word.Remove(word.Length - 1) : word;
                Match isEmailValid = emailRegex.Match(filteredWord);
                if (isEmailValid.Success)
                {
                    modifiedText = regexFixDotEmailCondition ? modifiedText.Replace(word, "!!!.") : modifiedText.Replace(word, "!!!");
                }
            }

            Console.WriteLine(originalText);
            Console.WriteLine(modifiedText);

        }
        static void Main(string[] args)
        {
            //task1();
            //task2();
            //task3();
        }
    }
}
