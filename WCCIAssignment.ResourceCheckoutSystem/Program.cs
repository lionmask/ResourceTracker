using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WCCIAssignment.ResourceCheckoutSystem
{
    //object Student -- I did not end up using this, but I think it would be the best data 
    //structure if the program had any more complexity.
    /* UNUSED OBJECTS for future updates
    public class Student
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public List<string> borrowedBooks { get; set; }
        public Student(string fName, string lName, List<string> borrowed)
        {
            fName = firstName;
            lName = lastName;
            borrowed = borrowedBooks;
        }
    }*/
    class Program
    {
        static string toLower(string input)
        {
            input = input.ToLower();
            return input;
        } //string to lowercase
        static void quit()
        {
            Console.WriteLine("Goodbye!    [3]");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Goodbye!    [2]");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Goodbye!    [1]");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Environment.Exit(0);
        } //evironment exit
        static void restart()
        {
            Console.Clear();
            Console.WriteLine("Restarting in 2 seconds");
            System.Threading.Thread.Sleep(2000);
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            Environment.Exit(0);
        } //starts new instance of program and closes old as same time
        static string getUserInput()
        {
            string input = Console.ReadLine();
            Console.Clear();
            input = input.ToUpper(); //note: will ignore numbers and can parse in main args
            //handle "quit"
            if (input == "QUIT" || input == "EXIT") { quit(); }
            //handle "restart"
            else if (input == "restart") { restart(); }
            return input;
        } //Input handler
        static void print(string message)
        {
            Console.WriteLine(message);
        } //print strings
        static void printArr(int[] arr)
        {
            string final = "{ ";
            char comma = ',';
            foreach (int s in arr)
            {
                final += s.ToString() + ", ";
            }
            string finale = final.Trim().Trim(comma) + " }";
            Console.WriteLine(finale);
        } //print arrays
        static void printList(List<string> l)
        {
            string final = "";
            foreach (string s in l)
            {
                final += s + "\n";
            }
            Console.WriteLine(final);
        }//print list of strings
        static void printKeys(Dictionary<string, List<string>> d)
        {
            List<string> studentNames = new List<string>(d.Keys);
            studentNames.Sort();
            foreach (string s in studentNames)
            {
                Console.WriteLine(" - " + s);
            }
        } //print dictionary keys
        static void breakLine()
        {
            Console.WriteLine("\n-----------------------------------------------------------------\n");
        } //inseart \n\n breakline \n\n
        static void Main(string[] args)
        {

            
            //declare vars
                //List - Menu  *method will display
            List<string> mainMenu = new List<string>()
            {"1 - View Students", "2 - View Resources", "3 - View Student Accounts", "4 - Check Out Item", "5 - Return Item", "\"Quit\" to quit" };
            //List - Available Resources
            string book1 = "C# FOR DUMMIES";
            string book2 = "C# FOR ZOMBIES";
            string book3 = "HOW TO SURVIVE WITH NO SLEEP";
            string book4 = "WHAT COLOR IS YOUR PARACHUTE?";
            string book5 = "ANNIE J. EASLEY BIOGRAPHY";
            string book6 = "WHERE THE RED FERN GROWS";
            string book7 = "HARRIET THE SPY";
            string book8 = "O'RIELY: JAVASCRIPT";
            string book9 = "ANNIE J. EASLEY BIOGRAPHY";
            string book10 = "ANNIE J. EASLEY BIOGRAPHY";
            List<string> availableResources = new List<string>
            { book1,book2, book3, book4, book5, book6, book7, book8, book9, book10 };
            string nothingMessage = "Nothing is checked out.";    
            //empty lists for students book borrow accounts
            List<string> rJonesBooks = new List<string>() { nothingMessage };
            List<string> aFatheemBooks = new List<string>() { nothingMessage };
            List<string> vKomovskiBooks = new List<string>() { nothingMessage };
            List<string> sWhiteBooks = new List<string>() { nothingMessage };
            List<string> kJoolaBooks = new List<string>() { nothingMessage };
                //Dictionary for Key: string of student names and Value: list of books checked out (starts empty);
            Dictionary<string, List<string>> studentAccounts = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase)
            {
                {"ROBERT JONES", rJonesBooks },
                {"ALI FATHEEM", rJonesBooks },
                {"VLADIMIR KOMOVSKI", vKomovskiBooks },
                {"SANDRA WHITE", sWhiteBooks },
                {"KIRSHA JOOLA", kJoolaBooks }
            };
            string error = "Error: Request Unavailable.";

            //Handler Logic
            bool infinity = true;
            while (infinity)
            {
                print("Bootcamp Resource Checkout System.\nAccurate. Reliable. Grossly underdeveloped.\n\n--Main Menu--\nEnter the number corresponding to your choice.");
                printList(mainMenu);
                Console.Write("\n> ");
                string userChoice = getUserInput();
                if (userChoice == "1")
                {
                    Console.WriteLine("Here are the student's names:"); //List student names
                    printKeys(studentAccounts);
                    breakLine();
                }
                else if (userChoice == "2")
                {
                    Console.WriteLine("Here are the available resources:"); //list available resources
                    if (availableResources.Count == 0)
                    {
                        Console.WriteLine("All resources are checked out.");
                        breakLine();
                    }
                    else
                    {
                        printList(availableResources);
                        breakLine();
                    }
                }
                else if (userChoice == "3")
                {
                    while (infinity)
                    {
                        print("Please enter the student's full name to view the account."); //get student name
                        printKeys(studentAccounts);
                        Console.WriteLine("\"Back\" to return to Main Menu\n\"Quit\" to quit");
                        Console.Write("\n>Student_Accounts> "); //dir ref
                        string userName = getUserInput();
                        if (studentAccounts.ContainsKey(userName)) // if the input was found
                        {
                            Console.WriteLine($"{userName}'s Account:\n");
                            printList(studentAccounts[userName]);
                            breakLine();
                        }
                        else if (userName == "BACK") //user wants to get back to main menu - break do loop
                        {
                            break;
                        }
                        else
                        {
                            print(error + "Please try again.\n");
                        }
                    }
                }
                else if (userChoice == "4")
                {
                    while (infinity)
                    {
                        Console.WriteLine("Please enter the student's full name to view the account.");
                        printKeys(studentAccounts);
                        Console.WriteLine("\"Back\" to return to Main Menu\n\"Quit\" to quit");
                        Console.Write("\n>Check_Out> "); string studentName = getUserInput(); //Ask for a student’s name
                        if (studentName == "BACK") //user wants to get back to main menu - break do loop
                        {
                            break;
                        }
                        else if (studentAccounts.ContainsKey(studentName)) // if the input was found
                        {
                            while (infinity) {
                                Console.WriteLine("Please enter the title of the item the student would like to borrow:\n"); //Ask for the title of the item
                                printList(availableResources);
                                print("\"Back\" to return to student selection");
                                string[] dir = studentName.Split(); 
                                Console.Write($"\n>Check_Out>{dir[0] + "_" + dir[1]}> ");
                                string resourceSelection = getUserInput();
                                if (availableResources.Contains(resourceSelection)) //if the resource is available
                                {
                                    if (studentAccounts[studentName].Contains(nothingMessage)) //remove nothing message from student's checkout list
                                    {
                                        studentAccounts[studentName].Remove(nothingMessage);
                                    }
                                    if (studentAccounts[studentName].Count == 3) //If a student has 3 items already checked out, when the student’s name is entered on the checkout screen, print “[Student Name] has checked out the max number of resources.”
                                    {
                                        print($"{studentName} has checked out the max number of resources.\n");
                                        breakLine();
                                        break;
                                    }
                                    studentAccounts[studentName].Add(resourceSelection); //add resouces to students dictionary value (list)
                                    availableResources.Remove(resourceSelection); //remove it from list of available
                                    print($"{studentName} checked out {resourceSelection}\n"); //If the item is available, print “[Student Name] checked out [Title]."
                                }
                                else if (resourceSelection == "BACK") //if user wants to go back
                                {
                                    break;
                                }
                                else
                                {
                                    print(error + "Please try again."); //If the title does not exist in the available resources, print “Error: Request Unavailable”
                                }
                            }
                        }
                        
                        else //If the student’s name does not exist, print “Error: Request unavailable”
                        {
                            print(error +  "Please try again.\n");
                        }
                    } 
                }
                else if(userChoice == "5")
                {
                    bool infinite = true;
                    while (infinite) //infinite loop with break as menu
                    {
                        Console.WriteLine("Please enter the student's full name to view the account.");
                        printKeys(studentAccounts);
                        Console.WriteLine("\"Back\" to return to Main Menu\n\"Quit\" to quit");
                        Console.Write("\n>Returns> ");
                        string studentName = getUserInput(); //Ask for a student’s name
                        if (studentName == "BACK") //user wants to get back to main menu - break do loop
                        {
                            break;
                        }
                        else if (studentAccounts.ContainsKey(studentName)) // if the input was found
                        {
                            while (infinite) // infinite loop with break
                            {
                                if (studentAccounts[studentName].Contains(nothingMessage)) //if the student has a nothign message in their account, tell the user there is nothing to return
                                {
                                    print($"{studentName} has nothing to return");
                                    break;
                                }
                                else
                                {
                                    print("Please enter the title of the item the student would like to return:\n"); //Ask for the title of the resource to be returned
                                    printList(studentAccounts[studentName]); // show the use a list of accounts
                                    print("\"Back\" to return to student selection");
                                    string[] dir = studentName.Split();
                                    Console.Write($"\n>Returns>{dir[0] + "_" + dir[1]}> ");
                                    string resourceSelection = getUserInput(); // get name
                                    if (studentAccounts[studentName].Contains(resourceSelection)) //if the name a students name
                                    {
                                        studentAccounts[studentName].Remove(resourceSelection); //remove the item from the students dictionary value list
                                        availableResources.Add(resourceSelection);
                                        if (studentAccounts[studentName].Count == 0) //if the list now has 0 items in it, add the nothing message
                                        {
                                            studentAccounts[studentName].Add(nothingMessage);
                                        }
                                        print($"{studentName} returned {resourceSelection}"); //If the item is available, print “[Student Name] checked out [Title]."
                                    }
                                    else if (resourceSelection == "BACK")
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        print(error + "Please try again."); //If the title does not exist in the available resources, print “Error: Request Unavailable”
                                    }
                                }
                            }
                        }

                        else //If the student’s name does not exist, print “Error: Request unavailable”
                        {
                            print(error + "Please try again.\n");
                        }
                    }
                }
            } // end of main while loop
        }
    }
}