﻿using System;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Threading;

string? readInput;
int listItemNumber = 1;
Dictionary<string, int> map = new();

System.Console.WriteLine("=====\t\tTO-DO\t\t=====\n");
System.Console.WriteLine("Please Add an Item or type 'remove' if you've completed a task.\nYou can leave this app by typing 'exit': ");

readInput = Console.ReadLine();

while(readInput != "exit")
{
    
    AddItem();
    readInput = Console.ReadLine();
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

void AddItem()
{
    string? itemToAdd;
    
    if(!ValidInput(readInput))
    {
        System.Console.WriteLine("That is not a valid input.\nPlease add a valid item, type 'remove' to remove an item, or 'exit' to leave: ");
        return;
    }

    if(readInput == "remove")
    {
        RemoveItem();
        return;
    }

    itemToAdd = readInput;
    
        System.Console.WriteLine($"Add {itemToAdd} to list? (Y/N?)");
        readInput = Console.ReadLine();

        if(!Return(readInput))
        {
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

            printList(map);
        }

        System.Console.WriteLine("Add another item? (Y/N?)");
        readInput = Console.ReadLine();
}

void printList(Dictionary<string,int> map)
{
    foreach(var kvp in map)
    {
        System.Console.WriteLine($"{kvp.Value}. {kvp.Key}");
    }
}

void RemoveItem()
{
    string? itemToRemove;

    printList(map);

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
       if(!map.ContainsKey(itemToRemove))
       {
        System.Console.WriteLine($"{itemToRemove} doesn't exists, please try again: \n");
        itemToRemove = Console.ReadLine();

       }
       else 
        map.Remove(itemToRemove);
        listItemNumber = map.Count + 1;
        
        printList(map);
    }

}


