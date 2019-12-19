# WizKids-Tasks
Description: This repository contains tasks received from WizKids as the first step in the hiring process

Tasks
1. Write a method that determines if a string is a palindrome or not.
2. Write a method that prints the numbers from 1 to 100, but for multiples of 3 print Foo, for multiples of 5 print Bar and for numbers that are multiples of both 3 and 5 print FooBar.
3. Write a method that can find and replace valid email adresses in a string.
For example, find and replace all valid email adresses in the following text:

Christian has the email address christian+123@gmail.com.
Christian's friend, John Cave-Brown, has the email address john.cave-brown@gmail.com.
John's daughter Kira studies at Oxford University and has the email adress Kira123@oxford.co.uk.
Her Twitter handle is @kira.cavebrown.
4. Write a method that can generate a list of words based on input word and alphabet.
In spell checking it is assumed that all words are wrong and alternative words are proposed if they fit better in the context. One way to generate alternative words is taking the original word and applying certain operations:

Deleting a letter.
Inserting a letter.
Replacing a letter.
Swapping two adjacent letters.
If only one operation is performed on the original word the Damerau-Levenshtein distance between the original word and the new alternative word is 1, for example, herroes [DELETE OPERATION] => heroes. If two or more operations are performed on the new alternative word(s) the Damerau-Levenshtein distance increases with the amount of operations, for example, herros [DELETE OPERATION] => heros [INSERT OPERATION] => heroes yields a Damerau-Levenshtein distance of 2.

The method should generate all possible alternative words based on the 4 operations listed above and maximum Damerau-Levenshtein distance = 1.

4.a Generate a list of alternative words using the word test, alphabet a-z (26 letters) and maximum Damerau-Levenshtein distance = 1?
4.b Write a method that can calculate the number of non-unique alternative words based on input word length and alphabet length (assuming maximum Damerau-Levenshtein distance = 1)*
* Without generating the word list, i.e. write a formula based on input word length and alphabet word length.
