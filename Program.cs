using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Timer = System.Timers.Timer;


namespace BankSimulator
{
    class Program
    {

        //Person class holding info for person that is logging in 
        class Person
        {
            public int age;
            public string name;
            public int balance;
            public int Withdrawal;
            public int Deposit;
            public int withdrawalinput;
            public int depositinput;
        }
        

        public static void Main()
        {
            // variables to start or restart program, and text to start program
            string restart;
            string enter;
            Timer _timer = null;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ");
            Console.WriteLine("Please type in *Start* to begin the program");

            Console.ForegroundColor = ConsoleColor.Red;
            enter = Convert.ToString(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            if (enter == "Start")
            {
                Console.WriteLine(" ");
                Console.WriteLine("Hello and welcome to your personal bank account");
                Console.WriteLine(" ");
                Console.WriteLine("Please enter your name and age below");
                Console.WriteLine(" ");

            }
          
            Person person1 = new Person();
            Console.Write("Name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            person1.name = Convert.ToString(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" ");
            Console.WriteLine("Hello {0}", person1.name);
            Console.WriteLine(" ");
            Console.Write("Age: ");
            Console.ForegroundColor = ConsoleColor.Red;
            person1.age = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
            string captcharesultx;
            string captcharesulty;
            string DepositorWithdrawal;
            int desiredbalance;
            if (person1.age < 18)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Sorry, {0} you are too young to log into your account, please type in *R* then press enter to restart the program", person1.name);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Red;
                restart = Convert.ToString(Console.ReadLine());
                if (restart == "R")
                {
                    Main();
                }
            }
            else if (person1.age >= 18)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Now complete this simple Captcha. Type all the characters and press enter when done");
                Console.WriteLine(" ");
                Console.WriteLine("C0#$^@F");
                Console.WriteLine(" ");
                Console.Write("Captcha answer: ");
                Captcha(out captcharesulty);


                if (captcharesulty == "C0#$^@F")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" ");
                    Console.WriteLine("Correct, please wait a moment...");
                    Thread.Sleep(1000);
                    Console.WriteLine(" ");
                    Console.WriteLine("We are finding your account...");
                    Thread.Sleep(1000);
                    Console.WriteLine(" ");
                    Console.WriteLine("This may take a couple seconds...");
                    Thread.Sleep(3000);
                }

                else if (captcharesulty != "C0#$^@F")

                {
                    do
                    {
                        Console.WriteLine(" ");
                        Console.WriteLine("Incorrect, please try again");
                        Console.WriteLine(" ");
                        Console.WriteLine("C0#$^@F");
                        Console.WriteLine(" ");
                        Console.Write("Captcha answer: ");

                        Captcharetry(out captcharesultx);


                    } while (captcharesultx != "C0#$^@F");
                    if (captcharesultx == "C0#$^@F")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(" ");
                        Console.WriteLine("Correct, please wait a moment...");
                        Thread.Sleep(1000);
                        Console.WriteLine(" ");
                        Console.WriteLine("We are finding your account...");
                        Thread.Sleep(1000);
                        Console.WriteLine(" ");
                        Console.WriteLine("This may take a couple seconds...");
                        Thread.Sleep(3000);
                    }
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" ");
                Console.WriteLine("Ok, we have succesfully found your account and logged you in. Before we continue please choose your desired balance ");
                Console.WriteLine(" ");
                Console.Write("Desired balance: ");
                balance(out desiredbalance);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" ");
                Console.WriteLine("Your balance has been updated");
                Console.WriteLine(" ");
                Console.WriteLine(" ");
                Console.WriteLine("Taking you to your account, this may take a couple of seconds...");
                Thread.Sleep(6000);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("                                    WELCOME BACK {0}", person1.name);
                


                Console.WriteLine(" ");




                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("     Balance: {0}             Age: {1}             Withdrawals: {2}           Deposits: {3}", desiredbalance, person1.age, person1.Withdrawal,person1.Deposit);

                Thread.Sleep(4000);
                Console.WriteLine(" ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("If you want to make a Withdrawal or Deposit, just type *Withdrawal* or *Deposit*. To exit the program type *exit*");
                DepositorWithdrawal = Convert.ToString(Console.ReadLine());
                Console.WriteLine(" ");
                if (DepositorWithdrawal == "Withdrawal")
                {
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("How much would you like to withdraw?");
                    Console.WriteLine(" ");
                   
                    Console.Write("Withdrawal amount: ");
                    
                    person1.Withdrawal = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" ");
                    Console.WriteLine("Ok, {0} has been withdrawed, your account page will now refresh", person1.Withdrawal);
                    desiredbalance -= person1.Withdrawal;

                    Thread.Sleep(3000);
                    RefreshD();
                }

                if (DepositorWithdrawal == "Deposit")
                {
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("How much would you like to Deposit?");
                    
                    Console.Write("Deposit amount: ");
                    
                    person1.Deposit = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" ");
                    Console.WriteLine("Ok, {0} has been deposited, your account page will now refresh", person1.Deposit);
                    
                    desiredbalance += person1.Deposit;
                    Thread.Sleep(3000);
                    RefreshD();
                }
                if (DepositorWithdrawal == "exit")
                {
                    return;
                }
              

                void  RefreshD()
                {
                    /* READ ATTENTION READ!!!!!
                     * make sure to replace person1.Withdrawal = Convert.ToInt32(Console.ReadLine()); with person1.withdrawalinput and same for deposit
                     * then after make the input add onto the original withdrawal and deposit count. No need for if statments just put: withdrawal = withdrawal + withdrawal input
                     * same for deposit
                     * Also before it calls refresh method again, make sure to set the withdrawal/deposit input values back to 0, to avoid adding the existing inputs. 
                     *  This should fix any problems with the withdrawal and deposit system
                     *  My bank account simulator is finally finished with no problems!!!!
                     */

                    Console.Clear();
                    
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("                                    WELCOME BACK {0}", person1.name);



                    Console.WriteLine(" ");




                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("     Balance: {0}             Age: {1}             Withdrawals: {2}           Deposits: {3}", desiredbalance, person1.age, person1.Withdrawal, person1.Deposit);

                    Thread.Sleep(2000);
                    Console.WriteLine(" ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("If you want to make a Withdrawal or Deposit, just type *Withdrawal* or *Deposit*. To exit the program type *exit*");
                    DepositorWithdrawal = Convert.ToString(Console.ReadLine());
                    Console.WriteLine(" ");

                    if (DepositorWithdrawal == "Withdrawal")
                        
                    {
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(" ");
                        Console.WriteLine("How much would you like to withdraw?");
                        Console.WriteLine(" ");
                        Console.Write("Withdrawal amount: ");
                        
                        person1.withdrawalinput = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" ");
                        Console.WriteLine("Ok, {0} has been withdrawed, your account page will now refresh", person1.withdrawalinput);
                        desiredbalance -= person1.withdrawalinput;

                        person1.Withdrawal += person1.withdrawalinput;
                        Thread.Sleep(3000);
                        person1.withdrawalinput = 0;
                        RefreshD();
                        
                        
                    }
                   
                    if (DepositorWithdrawal == "Deposit")
                    {
                        Console.WriteLine(" ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(" ");
                            Console.WriteLine("How much would you like to Deposit?");
                            Console.WriteLine(" ");
                            Console.Write("Deposit amount: ");
                        
                        person1.depositinput = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(" ");

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" ");
                        Console.WriteLine("Ok, {0} has been deposited, your account page will now refresh", person1.depositinput);
                            desiredbalance += person1.depositinput;
                        person1.Deposit += person1.depositinput;

                            Thread.Sleep(3000);
                        person1.depositinput = 0;
                        RefreshD();

                        
                       
                    }
                    if (DepositorWithdrawal == "exit")
                    {
                        return;
                    }

                }
                   

                }

        }
        static void Captcha(out string captcha)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            captcha = Convert.ToString(Console.ReadLine());




        }







        static void Captcharetry(out string Captcha)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Captcha = Convert.ToString(Console.ReadLine());


        }

        static void balance(out int balance)

        {
            Console.ForegroundColor = ConsoleColor.Red;
            balance = Convert.ToInt32(Console.ReadLine());
        }

       
        } 
        
    } 
