using System;
using System.Collections;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Threading;

string? readInput;
int listItemNumber = 0;
Dictionary<string, int> map = new();

System.Console.WriteLine("=====\t\tTO-DO\t\t=====\n");
System.Console.WriteLine("Please Add an Item or type 'remove' if you've completed a task: ");

readInput = Console.ReadLine();

while(readInput != "exit")
{
    string? itemToAdd;

    if(!ValidInput(readInput))
    {
        System.Console.WriteLine("That is not a valid input. BREAK");
        break;
    }

    itemToAdd = readInput;

    System.Console.WriteLine($"Add {itemToAdd} to list? (Y/N?)");
    readInput = Console.ReadLine();

    if(readInput == "Y" || readInput == "y")
    {
       if(!map.ContainsKey(itemToAdd))
       {
        map.Add(itemToAdd,listItemNumber);
        listItemNumber = map.Count;
       }
       else 
        System.Console.WriteLine($"{itemToAdd} already exists, please try again: \n");
        
    }

    foreach(var kvp in map)
    {
        System.Console.WriteLine($"{kvp.Value}. {kvp.Key}");
    }

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

