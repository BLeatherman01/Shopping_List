using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace Shopping_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> availableItems = new Dictionary<string, decimal>();
            List<string> shoppingList = new List<string>();

            availableItems.Add("Apples", 2.99m);
            availableItems.Add("Oranges", 1.89m);
            availableItems.Add("Milk", 3.29m);
            availableItems.Add("Oreo", 5.99m);
            availableItems.Add("Cereal", 3.99m);
            availableItems.Add("Bread", 1.50m);
            availableItems.Add("Coffee", 4.89m);
            availableItems.Add("Coke", 5.99m);
           
            
            Console.WriteLine("Here is a list of items we carry. Please select an item to add it to you shopping list\n");
            Console.WriteLine("Available items\n");

            foreach (KeyValuePair<string, decimal> kvp in availableItems)
            {
                Console.WriteLine($"{kvp.Key} ${kvp.Value}");
            }
            decimal sum = 0;

            bool keepGoing = true;

            while (keepGoing)
            {
                
                string selectedItem = AddItemToList();

                decimal price = availableItems[selectedItem];

                if (availableItems.ContainsKey(selectedItem))
                {
                    shoppingList.Add(selectedItem);
                    Console.WriteLine($"{selectedItem} {price} added to your shopping list");
                }
                else
                {
                    Console.WriteLine("Sorry, that item is not available");
                    AddItemToList();
                }

                keepGoing = AddAnotherItem();

            }
            Console.WriteLine("Here is your current Shopping List");
            
            foreach (string item in shoppingList)
            {
                decimal cost = availableItems[item];
                sum += cost;
                Console.WriteLine($"{item} {cost}");
               
            }
           
            Console.WriteLine($"Your total is ${sum}");

        }

        public static string AddItemToList()
        {
            Console.WriteLine("\nPlease enter the item you would like to add");
            string input = Console.ReadLine();
            
            return char.ToUpper(input[0]) + input.Substring(1);

        }

       public static bool AddAnotherItem()
       {
           Console.WriteLine("Would you like to add another item");
           string userInput = Console.ReadLine().ToLower();

           if (userInput == "yes" || userInput == "y")
           {
               return true;
           }
           else if (userInput == "no" || userInput == "n")
           {
               return false;
           }
           else
           {
               Console.WriteLine("Please enter Yes or No");
               return AddAnotherItem();
           }
       }
              
    }
}
  
