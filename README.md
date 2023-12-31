# ProjectOne_ToDo
A Basic ToDo List build as a Console App. Should Save/Load lists and eventually integrate as Blazor WebApp

# ---------------- AUDIT TRAIL ----------------                 

- 11/13/23 bet - Initial Create 
- 11/18/23 bet - Added Basic To-Do Functionality: Add items to list
- 11/19/23 bet - Added Return, AddItem, printList, and RemoveItem functions
- 11/25/23 bet - Added Switch statement
- 12/3/23  bet - Fixed 'Return' Functionality in AddItem(), redundant 'Add <item> to list?' issue.
- 12/10/23 bet - Fixed 'Return' Functionality in RemoveItem(), added IsMapEmpty function and check in RemoveItem(), fixed issue when  trying to remove multiple items.


# Outline:
  -Console App:
	  C#
	  .Net 7.0

-Should have a Title
-Should be formatted
-Should be able to add numbers and letters
-Each new item added to list should be given a number
-You should be able to remove a single or multiple items
-If an item is removed, the remaining items should reorder 

Part 2:
-Create a Save/Load function

Part 3:
Convert to Blazor webApp	

# Things to Work On:


- Fully test RemoveItem function
  * Renumbering after removing item needs to be fixed (12/3/23 - Convert Dictionary to List?)
- Begin creating Try/Catch Exception handling for possible null inputs
- Begin Implementation of Save/Load functionality
