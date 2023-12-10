using System;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Threading;

string? readInput;
int listItemNumber = 1;
bool mapEmpty = false;
Dictionary<string, int> map = new();

System.Console.WriteLine("=====\t\tTO-DO\t\t=====\n");
System.Console.WriteLine("Welcome to the To-Do App!\nPlease Add an Item or type 'remove' if you've completed a task.\nYou can leave this app by typing 'exit': ");

readInput = Console.ReadLine();

while(readInput != "exit")
{
    //Create Switch
    switch(readInput)
    {
        case "remove":
        {
        
            while(!Return(readInput))
            {
                if(readInput == "exit")
                {
                    break;
                }
                else if (mapEmpty == true)
                {
                    break;
                }
                RemoveItem();
                mapEmpty = false;
            }
            break;
        }
        default:
        {
            AddItem();
            break;
        }
    }
    
    //readInput = Console.ReadLine();
}
System.Console.WriteLine("Exiting...");
Thread.Sleep(2000);


//Create Function to check if input is valid
bool ValidInput(string input)
{
    Regex rx = new Regex(@"[a-zA-Z]");

    if(rx.IsMatch(input))
    {
        return true;
    }

    return false;
}

bool Return(string input)
{
    if (input == "N" || input == "n")
    {
        return true;
    }

    return false;
}

bool IsMapEmpty(int count)
{
    if(count == 0)
    {
        return true;
    }

    return false;
}

void AddItem()
{
    string? itemToAdd;
    
    if(!ValidInput(readInput))
    {
        System.Console.WriteLine("That is not a valid input.\nPlease add a valid item, type 'remove' to remove an item, or 'exit' to leave: ");
        return;
    }

   
    itemToAdd = readInput;
    
        System.Console.WriteLine($"Add {itemToAdd} to list? (Y/N?)");
        readInput = Console.ReadLine();

        if(Return(readInput))
        {
            System.Console.WriteLine($"{itemToAdd} not added to list.\nPlease enter an item to add to list or type 'remove' to remove an item: ");
            readInput = Console.ReadLine();
            return;
        }

        if(readInput == "Y" || readInput == "y")
        {
           if(!map.ContainsKey(itemToAdd))
           {
            map.Add(itemToAdd,listItemNumber);

            listItemNumber = map.Count + 1;
           }
           else 
            System.Console.WriteLine($"{itemToAdd} already exists, please try again: \n");

            PrintList(map);

            System.Console.WriteLine("Add another item? (Y/N?)");
            readInput = Console.ReadLine();

            if(Return(readInput))
            {
                System.Console.WriteLine("Welcome to the To-Do App!\nPlease Add an Item or type 'remove' if you've completed a task.\nYou can leave this app by typing 'exit': ");

                readInput = Console.ReadLine();
                return;
            }

            System.Console.WriteLine("Please enter another item or type 'exit' to leave application: ");
            readInput = Console.ReadLine();

        }
}

void PrintList(Dictionary<string,int> map)
{
    foreach(var kvp in map)
    {
        System.Console.WriteLine($"{kvp.Value}. {kvp.Key}");
    }
}

void RemoveItem()
{
    string? itemToRemove;
    

    if(IsMapEmpty(map.Count))
    {
        System.Console.WriteLine("There are no items to remove, please add an item to the list or type 'exit' to leave app: ");
        readInput = Console.ReadLine();
        mapEmpty = true;
        return;
    }

    PrintList(map);

    System.Console.WriteLine("Please enter the item you would like to remove: ");
    readInput = Console.ReadLine();

    if(!ValidInput(readInput))
    {
        System.Console.WriteLine("This is not a valid input.\nPlease try again or type 'exit' to leave: ");
        readInput = Console.ReadLine();
    }

    itemToRemove = readInput;

    System.Console.WriteLine($"Remove {itemToRemove} to list? (Y/N?)");
    readInput = Console.ReadLine();

    if(readInput == "Y" || readInput == "y")
    {
       while(!map.ContainsKey(itemToRemove))
       {
        System.Console.WriteLine($"{itemToRemove} doesn't exists, please try again: \n");
        itemToRemove = Console.ReadLine();

       }
       
        map.Remove(itemToRemove);
        listItemNumber = map.Count;
        System.Console.WriteLine($"{itemToRemove} removed from list.\n\n");

        System.Console.WriteLine($"Would you like to remove another item? (Y/N)");
        readInput = Console.ReadLine();

        if(Return(readInput))
        {
            System.Console.WriteLine("Welcome to the To-Do App!\nPlease Add an Item or type 'remove' if you've completed a task.\nYou can leave this app by typing 'exit': ");

                readInput = Console.ReadLine();
                return;
        }
        
    }

}


