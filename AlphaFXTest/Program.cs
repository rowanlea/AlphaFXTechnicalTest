using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaFXTechnicalTest
{
    class Program
    {
        // This was done under the assumption that the test is so simple it does not require: breaking down into multiple methods, multiple classes, unit tests
        static void Main(string[] args)
        {
            //Read the file from the base project location, assuming that you keep the project settings to copy file to output folder
            string text = System.IO.File.ReadAllText(@"lotr.txt");

            //Alternatively I could have learnt to use regular expressions, but it wasn't panning out
            string[] delimeters = new string[] { ",", ".", "!", "\'", " ", "\'s", "\n", "*", "(", ")", "\r", ";", ":", "-" };

            // A dictionary is used because it can only contain each key once (which I'm using for found words)
            Dictionary<string, int> words = new Dictionary<string, int>();

            //Split the text based on the delimeters defined above
            foreach (string word in text.Split(delimeters, StringSplitOptions.RemoveEmptyEntries))
            {
                // If the dictionary already contains the word then it increases the count by 1, else it adds the word to the dictionary
                if (!words.TryAdd(word, 1))
                {
                    words[word]++;
                }
            }

            // If i order them by descending based on the word count then it will give me a list containing the most used words at the top
            var ordered = words.OrderByDescending(x => x.Value);

            Console.WriteLine("Top ten most words found in text");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i + 1}. '{ordered.ElementAt(i).Key}' was found {ordered.ElementAt(i).Value} times");
            }

            Console.ReadKey();
        }
    }
}
