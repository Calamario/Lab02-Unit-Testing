using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit_Testing
{
    public class Program
    {
        public static decimal Balance = 5000;

        public static void Main(string[] args)
        {
            Welcome();
            // Sets up a flag for the do while loop
            bool flag = true;
            do
            {
                int userInput = MainMenu();
                flag = startApp(userInput);

            } while (flag);
            Console.WriteLine("Goodbye");

        }
        /// <summary>
        /// A simple method that writes in in the console
        /// </summary>
        public static void Welcome()
        {
            Console.WriteLine("Welcome to my bank!");
            Console.Write("Press Enter to continue:");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Main Menu method, Asks user for input. Has try-catch to check for correct value entered by user.
        /// If user inputs any invalid value, app will close
        /// </summary>
        /// <returns> An int entered by user </returns>
        public static int MainMenu()
        {
            Console.WriteLine("1) View Balance");
            Console.WriteLine("2) Withdraw Money");
            Console.WriteLine("3) Deposit Money");
            Console.WriteLine("4) Exit");
            int userInput = 4;
            try
            {
                userInput = Int32.Parse(Console.ReadLine());
                return userInput;
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
                Console.WriteLine("Please enter correct value.");
                Console.ReadLine();

            }
            return userInput;
        }

        /// <summary>
        /// Takes the chosen option from the user as the parameter, Depending on their action 
        /// invokes the apporpriate action.
        /// </summary>
        /// <param name="chosen"> an int entered by MainMenu is passed in </param>
        /// <returns> A boolean to see if the user wants to quit the app </returns>
        public static bool startApp(int chosen)
        {
            if (chosen == 1)
            {
                ViewBalance();
                return true;
            }
            if (chosen == 2)
            {
                try
                {
                    WithdrawCash();
                    return true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Transaction Incomplete");
                    
                }
                finally
                {
                    Console.WriteLine("Exiting ATM");
                    Console.ReadLine();
                }
            }
            if (chosen == 3)
            {
                try
                {
                    DepositCash();
                    return true;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Transaction Incomplete");
                }
                finally
                {
                    Console.WriteLine("Exiting ATM");
                    Console.ReadLine();
                }
            }
            if (chosen == 4)
            {
                return false;
            }
            return false;
        }

        /// <summary>
        /// Consoles the current balance 
        /// </summary>
        public static void ViewBalance()
        {
            Console.WriteLine("You have chosen 1. View Balance");
            Console.WriteLine($"You currently have ${Balance} in your account");
            Console.Write("Press Enter to return to Menu.");
            Console.ReadLine();
            Console.Clear();
        }

        /// <summary>
        /// Asks the user for a decimal to take out from balance.
        /// If the value asked for is too much, negative or 0, and invalid will console error messages
        /// </summary>
        public static void WithdrawCash()
        {
            Console.WriteLine($"You currently have ${Balance} in your account");
            Console.WriteLine("How much would you like to take out?");
            try
            {
                decimal takeoutCash = System.Convert.ToDecimal(Console.ReadLine());
                if (takeoutCash <= 0)
                {
                    Console.WriteLine("Please enter a valid amount");
                    Console.ReadLine();
                    Console.Clear();
                }
                else if (takeoutCash > Balance)
                {
                    Console.WriteLine("Error - you do not have enough savings.");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    decimal newBalance = CalculateBalanceWithdraw(takeoutCash);
                    Balance = newBalance;
                    Console.WriteLine("Transaction complete");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        /// <summary>
        /// Asks the user for a valid amount to add to their balance. If the input is negative or 0 consoles
        /// error message
        /// </summary>
        public static void DepositCash()
        {
            Console.WriteLine($"You currently have ${Balance} in your account");
            Console.WriteLine("How much would you like to put in?");
            try
            {
                decimal putInCash = System.Convert.ToDecimal(Console.ReadLine());
                if (putInCash <= 0)
                {
                    Console.WriteLine("Please enter a valid amount");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    decimal newBalance = CalculateBalanceDeposit(putInCash);
                    Balance = newBalance;
                    Console.WriteLine("Transaction complete");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Calculates the amount the remaining balance after the user withdraws
        /// </summary>
        /// <param name="cash"> takes in the user inputted valid decimal </param>
        /// <returns> the new balance for their account </returns>
        public static decimal CalculateBalanceWithdraw(decimal cash)
        {
            decimal newBalance = Balance - cash;
            return newBalance;
        }

        /// <summary>
        /// Calculates the amount the remaining balance after the user deposits
        /// </summary>
        /// <param name="cash"> takes in the user inputted valid decimal </param>
        /// <returns> the new balance for their account </returns>
        public static decimal CalculateBalanceDeposit(decimal cash)
        {
            decimal newBalance = Balance + cash;
            return newBalance;
        }

    }
}
