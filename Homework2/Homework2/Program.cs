using System;
using System.Collections.Generic;

namespace Homework2
{
    class Program
    {
        static bool inputIsValid = false;
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Buutti banking CLI!");
            Console.WriteLine("Hint: You can get help with the commands by typing \"help\".");

            List<User> allUsers = new List<User>();
            string input;

            while (true)
            {
                input = Console.ReadLine();

                if (input.Equals("help"))
                    Help();
                else if (input.Equals("quit"))
                    return;
                else if (input.Equals("create_account"))
                    allUsers.Add(Create_Account());
                else if (input.Equals("does_account_exist"))
                    Does_Account_Exist(allUsers);
                else if (input.Equals("account_balance"))
                    Account_Balance(allUsers);
                else if (input.Equals("withdraw_funds"))
                    Withdraw_Funds(allUsers);
                else if (input.Equals("deposit_funds"))
                    Deposit_Funds(allUsers);
                else if (input.Equals("transfer_funds"))
                    Transfer_Funds(allUsers);
            }
            
        }

        static void Help()
        {
            Console.WriteLine("\nHere's a list of commands you can use!\n");

            Console.Write("help\t\t\t");
            Console.WriteLine("Opens this dialog.");
            Console.Write("quit\t\t\t");
            Console.WriteLine("Quits the program.\n");

            Console.WriteLine("Account actions");
            Console.Write("create_account\t\t");
            Console.WriteLine("Opens a dialog for creating an account.");
            Console.Write("does_account_exist\t");
            Console.WriteLine("Opens a dialog for checking if an account exists.");
            Console.Write("account_balance\t\t");
            Console.WriteLine("Opens a dialog for logging in and prints the account balance.\n");

            Console.WriteLine("Fund actions");
            Console.Write("withdraw_funds\t\t");
            Console.WriteLine("Opens a dialog for withdrawing funds.");
            Console.Write("deposit_funds\t\t");
            Console.WriteLine("Opens a dialog for depositing funds.");
            Console.Write("transfer_funds\t\t");
            Console.WriteLine("Opens a dialog for transferring funds to another account.\n");
        }

        static User Create_Account()
        {
            string uName, uPassword;
            int uId;
            decimal uStartingBalance;

            Console.WriteLine("\nCreating a new user account!");
            Console.WriteLine("Insert your name.");
            uName = Console.ReadLine();
            Console.WriteLine("Hello, " + uName + "! It's great to have you as a client.");
            Console.WriteLine("How much is your initial deposit? (The minimum is 10€");

            do
            {
                inputIsValid = decimal.TryParse(Console.ReadLine(), out uStartingBalance);

                if (!inputIsValid)
                {
                    Console.WriteLine("Error handling input. Please try again: ");
                }
                else
                {
                    if (uStartingBalance < 10.0m)
                    {
                        Console.WriteLine("Unfortunately we can’t open an account for such a small account. Do you have any more cash with you?");
                        inputIsValid = false;
                    }
                    else
                    {
                        Console.WriteLine("Great, " + uName + "! You now have an account with a balance of " + uStartingBalance + ".");
                        Console.WriteLine("We’re happy to have you as a customer, and we want to ensure that your money is safe with us.");
                    }
                }
            } while (!inputIsValid);

            Console.WriteLine("Give us a password, which gives only you the access to your account.");
            uPassword = Console.ReadLine();
            Console.WriteLine("Your account is now created.");
            
            uId = GenerateId();
            Console.WriteLine("Account id: " + uId);
            Console.WriteLine("Store your account ID in a safe place.");

            User newUser = new User(uName, uPassword, uId, uStartingBalance);
            return newUser;
        }

        static void Does_Account_Exist(List<User> list)
        {
            int match = 0;
            Console.WriteLine("Checking if an account exists!");
            Console.WriteLine("Enter the account ID whose existence you want to verify.");
            FindAccount(list, match);
        }

        static void Account_Balance(List<User> list)
        {
            Console.WriteLine("Checking your account balance!");
            int match = 0;
            ValidateAccount(list, match);
            Console.WriteLine("Your account balance is " + list[match].Balance);

        }

        static void Withdraw_Funds(List<User> list)
        {
            int match = 0; 
            decimal withdrawAmount;
            Console.WriteLine("Withdrawing cash!");
            ValidateAccount(list, match);
            Console.WriteLine("How much money do you want to withdraw? (Current balance: " + list[match].Balance + ")");
            do
            {
                inputIsValid = inputIsValid = decimal.TryParse(Console.ReadLine(), out withdrawAmount);
                if (!inputIsValid)
                {
                    Console.WriteLine("Error handling input. Please try again: ");
                }
                else
                {
                    if (withdrawAmount < list[match].Balance && withdrawAmount > 0.0m)
                    {
                        decimal newBalance = list[match].WithdrawFunds(withdrawAmount);
                        Console.WriteLine("Withdrawing a cash sum of " + withdrawAmount + "€. Your account balance is now " + newBalance + "€.");
                    }
                    else
                    {
                        Console.WriteLine("Couldn't process amount. Please try again.");
                        inputIsValid = false;
                    }
                }
            } while (!inputIsValid);
        }

        static void Deposit_Funds(List<User> list)
        {
            int match = 0;
            decimal depositAmount;
            Console.WriteLine("Depositing cash!");
            ValidateAccount(list, match);
            Console.WriteLine("How much money do you want to deposit? (Current balance: " + list[match].Balance + ")");
            do
            {
                inputIsValid = inputIsValid = decimal.TryParse(Console.ReadLine(), out depositAmount);
                if (!inputIsValid)
                {
                    Console.WriteLine("Error handling input. Please try again: ");
                }
                else
                {
                    if (depositAmount > 0.0m)
                    {
                        decimal newBalance = list[match].DepositFunds(depositAmount);
                        Console.WriteLine("Depositing " + depositAmount + "€. Your account balance is now " + newBalance + "€.");
                    }
                    else
                    {
                        Console.WriteLine("Couldn't process amount. Please try again.");
                        inputIsValid = false;
                    }
                }
            } while (!inputIsValid);
        }

        static void Transfer_Funds(List<User> list)
        {
            int match = 0, match2 = 0;
            decimal transferAmount;
            Console.WriteLine("Transferring funds!");
            ValidateAccount(list, match);
            Console.WriteLine("How much money do you want to transfer? (Current balance: " + list[match].Balance + ")");

            do
            {
                inputIsValid = inputIsValid = decimal.TryParse(Console.ReadLine(), out transferAmount);
                if (!inputIsValid)
                {
                    Console.WriteLine("Error handling input. Please try again: ");
                }
                else
                {
                    if (transferAmount < list[match].Balance && transferAmount > 0)
                    {
                        decimal newBalance = list[match].WithdrawFunds(transferAmount);
                        //Console.WriteLine("Withdrawing a cash sum of " + transferAmount + "€. Your account balance is now " + newBalance + "€.");
                    }
                    else
                    {
                        Console.WriteLine("Couldn't process amount. Please try again.");
                        inputIsValid = false;
                    }
                }
            } while (!inputIsValid);

            Console.WriteLine("Which account ID do you want to transfer these funds to?");
            FindAccount(list, match2);
            list[match2].DepositFunds(transferAmount);
            Console.WriteLine($"Sending {transferAmount} from account ID {list[match].Id} to account ID {list[match2].Id}");
        }

        static int GenerateId()
        {
            int id = rnd.Next(0, 1000);
            return id;
        }

        static void ValidateAccount(List<User> list, int match)
        {
            Console.WriteLine("What is your account ID?");
            int checkId;
            bool foundMatch = false;
            match = 0;

            do
            {
                inputIsValid = int.TryParse(Console.ReadLine(), out checkId);
                if (!inputIsValid)
                {
                    Console.WriteLine("Error handling input. Please try again: ");
                }
                else
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Id == checkId)
                        {
                            foundMatch = true;
                            match = i;
                        }
                    }

                    if (!foundMatch)
                    {
                        Console.WriteLine("An account with that ID does not exist. Try again.");
                        inputIsValid = false;
                    }
                }
            } while (!inputIsValid);

            Console.WriteLine("Account found! Insert your password.");
            string checkPassword;

            for (int j = 0; j < 3; j++)
            {
                checkPassword = Console.ReadLine();
                if (list[match].Password.Equals(checkPassword))
                {
                    Console.WriteLine("Correct password. We validated you as " + list[match].Name);
                    break;
                }
                else if (!list[match].Password.Equals(checkPassword) && j == 2)
                {
                    Console.WriteLine("Password failed 3 times. Returning to main menu.");
                }
                else if (!list[match].Password.Equals(checkPassword))
                {
                    Console.WriteLine("Wrong password, try typing it again.");
                }
            }
        }

        static void FindAccount(List<User> list, int match)
        {
            bool foundMatch = false;
            int checkId;

            do
            {
                inputIsValid = int.TryParse(Console.ReadLine(), out checkId);

                if (!inputIsValid)
                {
                    Console.WriteLine("Error handling input. Please try again: ");
                }
                else
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].Id == checkId)
                        {
                            foundMatch = true;
                            match = i;
                            Console.WriteLine("This account exists.");
                        }
                    }

                    if (!foundMatch)
                    {
                        Console.WriteLine("An account with that ID does not exist. Try again.");
                        inputIsValid = false;
                    }
                }
            } while (!inputIsValid);
        }
    }
}
