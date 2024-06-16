using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace LinkqSnippets
{
    public class Snippets
    {
        static public void BasicLink()
        {
            string[] cars =
            {
                "BYD",
                "Lucid Motors",
                "NIO",
                "Rivian",
                "XPeng",
                "Abarth",
                "Alpine",
                "Caterham",
                "Donkervoort",
                "Lotus",
                "Morgan",
                "Pagani",
                "Radical"
            };

            // 1. select * from cars
            var cardList = from car in cars select car;

            foreach (var card in cardList)
            {
                Console.WriteLine(card);
            }

            // 2. select * from card where car is Alpine
            var alpineList = from car in cars where car.Contains("Alpine") select car;

            foreach (var alpine in alpineList)
            {
                Console.WriteLine(alpine);
            }
        }

        static public void LinkNumbers()
        {
            List<int> numbers = new List<int> { 1,2,4,5,6,7,8,9,45,2321,1,454,5,6,74,3,345,234,223,5,234 };

            //each number multiplied by 3
            //take all numbers, but 9
            //order numbers by ascending value

            var numberList = numbers.Select(num => num * 3)
                                    .Where(num => num != 9)
                                    .OrderBy(num => num);

            foreach (var number in numberList)
            {
                Console.WriteLine(number);
            }
        }

        static public void SearchExamples()
        {
            List<string> textList = new List<string>
            {
                "A",
                "B",
                "C",
                "D",
                "E",
                "F",
                "G",
                "H",
                "I",
                "J",
                "L",
                "M"
            };

            // 1. first of all elements
            var first = textList.First();

            //2. first element that is "C"
            var textC = textList.First(text => text.Equals("C"));

            //3. first element that contains "J"
            var textJ = textList.First(text => text.Contains("J"));

            //4. first element that contains "L" or default
            var firstOrDefault = textList.FirstOrDefault(text => text.Contains("L"));

            //5. single values
            var uniqueText = textList.Single();
            var uniqueDefaultText = textList.SingleOrDefault();

            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] othersNumbers = { 1, 3, 5, 7, 9 };

            // obtain not repeats numbers
            var numbersExcept = numbers.Except(othersNumbers);
            

        }



    }
}
