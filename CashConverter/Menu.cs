using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashConverter
{
    public class Menu
    {
        Currency _currency = new Currency();
        private string currencytable()
        {
            return "Available currency:\n" +
        "1. USD\n" +
        "2. EUR\n" +
        "3. GBP\n" +
        "4. CHF\n" +
        "5. PLN\n";
        }
        private void taptocontinue()
        {
            Console.WriteLine("Tap any key to continue");
            Console.ReadKey();
        }
        private string youget(string choice)
        {

            return $"For 1 {numtocurr()[choice]} you get: ";
        }
        private Dictionary<string, string> numtocurr()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("1", "USD");
            result.Add("2", "EUR");
            result.Add("3", "GBP");
            result.Add("4", "CHF");
            result.Add("5", "PLN");
            return result;
        }
        public void MainMenu()
        {
            _currency.currencylist();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Currency Coverter App\n" +
                "There are your options:\n" +
                "1. Money exchange\n" +
                "2. Currency course\n" +
                "3. Quit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Console.WriteLine(currencytable());
                        Console.WriteLine("What have you got?");
                        string ownedcurrency = Console.ReadLine();
                        Console.WriteLine("What do you need?");
                        string wantedcurrency = Console.ReadLine();
                        Console.WriteLine("How much you got?");
                        double ownedmoney = -1;
                        while (ownedmoney == -1)
                        {
                            try
                            {
                                ownedmoney = double.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Oops something goes wrong. Insert amount of your money.");
                            }
                        }
                        Console.WriteLine("You get: ");
                        Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(ownedcurrency,wantedcurrency)*ownedmoney) + " " + numtocurr()[wantedcurrency]);
                        taptocontinue();
                        break;
                    case "2":
                        Console.WriteLine(currencytable());
                        Console.WriteLine("You want to see currency course according to...");
                        string choicecourse = Console.ReadLine();
                        if (choicecourse == "1")
                        {
                            Console.WriteLine(youget(choicecourse));
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "2")) + "EUR");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "3")) + "GBP");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "4")) + "CHF");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "5")) + "PLN");
                        }
                        else if (choicecourse == "2")
                        {
                            Console.WriteLine(youget(choicecourse));
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "1")) + "USD");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "3")) + "GBP");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "4")) + "CHF");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "5")) + "PLN");
                        }
                        else if (choicecourse == "3")
                        {
                            Console.WriteLine(youget(choicecourse));
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "1")) + "USD");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "2")) + "EUR");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "4")) + "GBP");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "5")) + "PLN");
                        }
                        else if (choicecourse == "4")
                        {
                            Console.WriteLine(youget(choicecourse));
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "1")) + "USD");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "2")) + "EUR");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "3")) + "GBP");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "5")) + "PLN");
                        }
                        else if (choicecourse == "5")
                        {
                            Console.WriteLine(youget(choicecourse));
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "1")) + "USD");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "2")) + "EUR");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "3")) + "GBP");
                            Console.WriteLine(String.Format("{0:0.00}", _currency.switchcurrency(choicecourse, "4")) + "CHF");
                        }
                        taptocontinue();
                        break;
                    case "3":
                        return;
                        break;
                    default:
                        Console.WriteLine("No option like that");
                        taptocontinue();
                        break;
                }
            }
        }
    }
}
