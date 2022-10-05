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
            //menu
            Dictionary<string, decimal> availableItems = new Dictionary<string, decimal>();
            //shopping list
            List<string> shoppingList = new List<string>();

            availableItems.Add("Apples", 2.99m);
            availableItems.Add("Beer", 4.89m);
            availableItems.Add("Milk", 3.29m);
            availableItems.Add("Oreo", 5.99m);
            availableItems.Add("Cereal", 3.99m);
            availableItems.Add("Bread", 1.50m);
            availableItems.Add("Coffee", 4.89m);
            availableItems.Add("Coke", 5.99m);
           
            
            Console.WriteLine("Here is a list of items we carry. Please select an item to add it to you shopping list\n");
            Console.WriteLine("\tAvailable items\n");
            //prints menu items
            int menuNum = 1;
            foreach (KeyValuePair<string, decimal> kvp in availableItems)
            {
                Console.WriteLine($"{menuNum} \t{kvp.Key} \t${kvp.Value}");
                menuNum++;
            }
            
            //sets total to $0 at start
            decimal sum = 0;

            bool keepGoing = true;
            while (keepGoing)
            {
                
                string selectedItem = AddItemToList();

               

                if (availableItems.ContainsKey(selectedItem))
                {
                    decimal price = availableItems[selectedItem];

                    shoppingList.Add(selectedItem);
                    Console.WriteLine($"{selectedItem} ${price} added to your shopping list");
                 
                }
                else if (availableItems.ContainsKey(selectedItem) == false)
                {
                    Console.WriteLine($"Sorry, {selectedItem} that item is not available");
                    AddItemToList();
                }
                else
                {
                    Console.WriteLine("not there");
                }

                keepGoing = AddAnotherItem();
                
            }
            //prints final items and price
            Console.WriteLine("Here is your current Shopping List");
          
            foreach (string item in shoppingList)
            {
                decimal cost = availableItems[item];
                sum += cost;
                Console.WriteLine($"{item} ${cost}");
               
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
           Console.WriteLine("Would you like to add another item. Enter Y/N.");
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
  
