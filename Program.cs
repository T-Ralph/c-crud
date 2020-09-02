using System;
using System.Collections.Generic; //Using List

namespace c_assignment_crud_T_Ralph
{
    class Program
    {
        //Declare string array
        //static string[] listItems { get; set; } = new string[10]; //Using Array
        static List<string> listItems { get; set; } = new List<string>(); //Using List
        static void Main()
        {
            /*
                Title: C# Introduction Assignment – CRUD
                Purpose: This program allows users to maintain a list of items and allow the user to manipulate that list.
                Author: Tosin Raphael Olaniyi (T-Ralph)
                Date: August 16, 2020
                Doc: https://docs.google.com/document/d/13YDsWM5jF_yXE7JMDyhAaeAYZcQEO3C8VInZaHI0_DM/edit
            */
            
            //Greet the user
            Console.WriteLine("  -- ------------ ---------- - ----  \n| C# Introduction Assignment – CRUD |\n  -- ------------ ---------- - ----  ");
            Console.WriteLine("-> Name, Input and Manage your List of Items.");

            //Ask for input
            Console.Write("Name your List: ");
            Console.ReadLine();

            MainProcess(); //Run the MainProcess method
        }
        static void MainProcess()
        {
            string menuOptions; //declare datatype

            //Display menu and ask for input
            Console.WriteLine("\nWhat do you want to do? \n1. Create your List\n2. Read your List\n3. Update your List\n4. Delete an item from your List\n5. Exit the Program");
            Console.Write("Enter the corresponding option #: ");
            menuOptions = Console.ReadLine();

            switch (menuOptions)
            {
                case "1":
                    CreateList(); //Run the CreateList method
                    break;
                case "2":
                    ReadList(); //Run the ReadList method
                    break;
                case "3":
                    UpdateList(); //Run the UpdateList method
                    break;
                case "4":
                    DeleteList(); //Run the DeleteList method
                    break;
                case "5":
                    ExitProgram(); //Run the ExitProgram method
                    break;
                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

            MainProcess(); //Run the MainProcess method again
        }
        static void CreateList()
        {
            //Declare datatype
            string item = "";
            bool valid;

            /* Using Array
            Console.WriteLine("\nCreate your List");
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    valid = false;
                    //Ask for input
                    Console.Write($"Enter the item #{i + 1}: ");
                    item = Console.ReadLine();
                    if (ValidateItem(item))
                    {
                        listItems[i] = item.Trim();
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                } while (valid == false);
                
            }
            */

            //Using List
            Console.WriteLine("\nCreate your List");
            int i = 0;
            valid = false;
            bool checkDone = false;
            while (valid == false || checkDone == false)
            {
                //Ask for input
                Console.Write($"Enter the item #{i + 1}: ");
                item = Console.ReadLine();
                if (ValidateItem(item))
                {
                    if (item.ToLower() != "done")
                    {
                        listItems.Add(item.Trim());
                        valid = true;
                        i++;
                    }
                    else
                    {
                        checkDone = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
        static void ReadList()
        {
            //Display list
            //Array.Sort(listItems); //Using Array
            listItems.Sort(); //Using List
            Console.WriteLine("\nRead your List");
            //for (int i = 0; i < listItems.Length; i++) //Using Array
            for (int i = 0; i < listItems.Count; i++) //Using List
            {
                Console.WriteLine($"Item #{i + 1}: {listItems[i]}");
            }
        }
        static void UpdateList()
        {
            //Declare datatype
            string itemInput;
            int itemOption;
            string newItem;
            bool valid;

            Console.WriteLine("\nUpdate your List");
            ReadList();
            Console.Write("Enter the corresponding option # to update: ");
            itemInput = Console.ReadLine();

            if (ValidateItemIndex(itemInput))
            {
                itemOption = int.Parse(itemInput);

                do
                {
                    valid = false;
                    //Ask for input
                    Console.Write("Enter the corresponding new option item to update: ");
                    newItem = Console.ReadLine();
                    if (ValidateItem(newItem))
                    {
                        listItems[itemOption - 1] = newItem.Trim();
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                } while (valid == false);

                ReadList(); //Run the ReadList() method
            }
            else
            {
                Console.WriteLine("Invalid Option");
            }
        }
        static void DeleteList()
        {
            //Declare datatype
            string itemInput;
            int itemOption;

            Console.WriteLine("\nDelete an item from your List");
            ReadList();
            Console.Write("Enter the corresponding option # to delete: ");
            itemInput = Console.ReadLine();

            if (ValidateItemIndex(itemInput))
            {
                itemOption = int.Parse(itemInput);
                //listItems[itemOption - 1] = ""; //Remove the item //Using Array
                listItems.RemoveAt(itemOption - 1); //Using List
                ReadList(); //Run the ReadList() method
            }
            else
            {
                Console.WriteLine("Invalid Option");
            }
        }
        static bool ValidateItemIndex(string itemInput)
        {
            //Declare data type
            int itemOption;
            bool valid;

            //Check for valid options
            //if (int.TryParse(itemInput, out itemOption) && itemOption > 0 && itemOption < 10) //Using Array
            if (int.TryParse(itemInput, out itemOption) && itemOption > 0 && itemOption <= listItems.Count) //Using List
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;
        }
        static bool ValidateItem(string item)
        {
            bool valid; //Declare datatype

            //Check for valid input
            //if (!String.IsNullOrEmpty(item.ToLower().Trim()) && !String.IsNullOrWhiteSpace(item.ToLower().Trim()) && !Array.Exists(listItems, element => element == item.ToLower().Trim())) //Using Array
            if (!String.IsNullOrEmpty(item.ToLower().Trim()) && !String.IsNullOrWhiteSpace(item.ToLower().Trim()) && !listItems.Contains(item.ToLower().Trim())) //Using List
            {
                valid = true;
            }
            else
            {
                valid = false;
            }
            return valid;
        }
        static void ExitProgram()
        {
            //Exit the program
            Console.WriteLine("\n  ---------------------  \n| Program will exit now |\n| Bye                   |\n  ---------------------  \n");
            Environment.Exit(0);
        }
    }
}
