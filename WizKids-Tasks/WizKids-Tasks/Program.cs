using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace WizKids_Tasks
{
    class Program
    {
        static void task1()
        {
            Console.WriteLine("task1");
            string initialWord = "mom";
            char[] wordArray = initialWord.ToCharArray();
            Array.Reverse(wordArray);
            string reversedWord = new string(wordArray);
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

        public static int GetDamerauLevenshteinDistance(string s, string t)
        {
            var bounds = new { Height = s.Length + 1, Width = t.Length + 1 };

            int[,] matrix = new int[bounds.Height, bounds.Width];

            for (int height = 0; height < bounds.Height; height++) { matrix[height, 0] = height; };
            for (int width = 0; width < bounds.Width; width++) { matrix[0, width] = width; };

            for (int height = 1; height < bounds.Height; height++)
            {
                for (int width = 1; width < bounds.Width; width++)
                {
                    int cost = (s[height - 1] == t[width - 1]) ? 0 : 1;
                    int insertion = matrix[height, width - 1] + 1;
                    int deletion = matrix[height - 1, width] + 1;
                    int substitution = matrix[height - 1, width - 1] + cost;

                    int distance = Math.Min(insertion, Math.Min(deletion, substitution));

                    if (height > 1 && width > 1 && s[height - 1] == t[width - 2] && s[height - 2] == t[width - 1])
                    {
                        distance = Math.Min(distance, matrix[height - 2, width - 2] + cost);
                    }

                    matrix[height, width] = distance;
                }
            }

            return matrix[bounds.Height - 1, bounds.Width - 1];
        }
        static void task4(string inputWord = null)
        {
            var originalWord = inputWord == null ? "test" : inputWord;
            var alphabet = "a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z";
            var alphabetList = alphabet.Replace(",", " ").Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<string> wordSuggestionList = new List<String>();
            var duplicateCount = 0;

            for (int i = 0; i <= originalWord.Length; i++)
            {

                //swapping
                if (i + 1 < originalWord.Length)
                {
                    var currentLetter = originalWord[i];
                    var nextLetter = originalWord[i + 1];
                    var wordOnSwap = new StringBuilder(originalWord);
                    wordOnSwap[i] = nextLetter;
                    wordOnSwap[i + 1] = currentLetter;
                    if (!(wordSuggestionList.Contains(wordOnSwap.ToString())))
                    {
                        wordSuggestionList.Add(wordOnSwap.ToString());
                    }
                    else
                    {
                        duplicateCount++;
                    }
                }

                //delete
                var wordOnDelete = new StringBuilder(originalWord).Remove(i == 0 ? i : i - 1, 1).ToString();
                if (!(wordSuggestionList.Contains(wordOnDelete.ToString())))
                {
                    wordSuggestionList.Add(wordOnDelete.ToString());
                }


                //insert
                foreach (string letter in alphabetList)
                {
                    var wordOnInsert = new StringBuilder(originalWord).Insert(i, letter).ToString();
                    int suggestedWordDamerauScore = GetDamerauLevenshteinDistance(originalWord, wordOnInsert);
                    if (suggestedWordDamerauScore == 1)
                    {
                        if (!(wordSuggestionList.Contains(wordOnInsert)))
                        {
                            wordSuggestionList.Add(wordOnInsert.ToString());
                        }
                        else
                        {
                            duplicateCount++;
                        }
                    }
                }

                //replace
                foreach (string letter in alphabetList)
                {
                    var wordOnReplace = new StringBuilder(originalWord).Remove(i == 0 ? 0 : i - 1, 1).Insert(i == 0 ? i : i - 1, letter).ToString();
                    int suggestedWordDamerauScore = GetDamerauLevenshteinDistance(originalWord.ToString(), wordOnReplace.ToString());
                    if (suggestedWordDamerauScore == 1)
                    {
                        if (!(wordSuggestionList.Contains(wordOnReplace)))
                        {
                            wordSuggestionList.Add(wordOnReplace);
                        }
                        else
                        {
                            duplicateCount++;
                        }
                    }
                }
            }

            //
            Console.WriteLine("Non-unique words count = " + duplicateCount);
            Console.WriteLine("Number of suggestions = " + wordSuggestionList.Count);
            foreach (var word in wordSuggestionList)
            {
                Console.WriteLine(word);
            }
        }
        static void Main(string[] args)
        {
            task1();
            task2();
            task3();
            // for running the expected "test" test (4a+ 4b)
            task4();
            //same as the one up top but now you can change the string variable 
            task4("vatican");
        }
    }
}
