using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashConverter
{
    public class Currency
    {
        public List<double> _amount = new List<double>();
        public double pln = 1;

        string linkeuro = "https://www.google.com/search?client=firefox-b-d&q=kurs+euro";
        string spaneuro = "//span[@class='DFlfde SwHCTb']";
        string linkdolar = "https://www.google.com/search?q=kurs+dolar&sxsrf=ALiCzsbaQPGjZ2uWwGgYwz0O04IxLL9ejA%3A1663183676345&source=hp&ei=PCsiY6TNEo_bgQadvKnYBg&iflsig=AJiK0e8AAAAAYyI5TKrWkZ4QfTwGAmQkC3UZ_AN0fiSp&ved=0ahUKEwik2-OBgpX6AhWPbcAKHR1eCmsQ4dUDCAY&uact=5&oq=kurs+dolar&gs_lcp=Cgdnd3Mtd2l6EAMyCQgjECcQRhCCAjILCAAQgAQQsQMQgwEyCwgAEIAEELEDEIMBMgsIABCABBCxAxCDATIICAAQgAQQsQMyCwgAEIAEELEDEIMBMgsIABCABBCxAxCDATILCAAQgAQQsQMQgwEyCwgAEIAEELEDEIMBMgUIABCABDoECCMQJzoKCAAQsQMQgwEQQzoECAAQQzoHCAAQsQMQQ1AAWJ8HYIkIaABwAHgAgAFziAGnB5IBAzcuM5gBAKABAQ&sclient=gws-wiz";
        string spandolar = "//span[@class='DFlfde SwHCTb']";
        string linkfunt = "https://www.google.com/search?q=kurs+funt&sxsrf=ALiCzsbRMx-T-iIAb6V3pjKfWj_vN8ZLRw%3A1663183678789&ei=PisiY9nkL5qbwPAPvMmRyAc&ved=0ahUKEwjZ-_qCgpX6AhWaDRAIHbxkBHkQ4dUDCA0&uact=5&oq=kurs+funt&gs_lcp=Cgdnd3Mtd2l6EAMyEAgAEIAEELEDEIMBEEYQggIyCwgAEIAEELEDEIMBMgsIABCABBCxAxCDATILCAAQgAQQsQMQgwEyCAgAEIAEELEDMgUIABCABDIFCAAQgAQyBQgAEIAEMgsIABCABBCxAxCDATILCAAQgAQQsQMQgwE6CggAEEcQ1gQQsAM6DQgAEEcQ1gQQsAMQyQM6BwgAELADEEM6BAgjECc6CggAELEDEIMBEEM6BAgAEEM6BwgAELEDEEM6CQgjECcQRhCCAkoECEEYAEoECEYYAFDW6ApY-PAKYNbzCmgCcAF4AIABmwGIAZ0HkgEDNi4zmAEAoAEByAEKwAEB&sclient=gws-wiz";
        string spanfunt = "//span[@class='DFlfde SwHCTb']";
        string linkfrank = "https://www.google.com/search?q=kurs+franka&sxsrf=ALiCzsbEKVVOj5EbfLQtJ7H-IeMkPvpqvg%3A1663184003161&ei=gywiY86rCczRqwHWlJf4Ag&oq=kurs+frank&gs_lcp=Cgdnd3Mtd2l6EAMYADIQCAAQgAQQsQMQgwEQRhCCAjILCAAQgAQQsQMQgwEyCwgAEIAEELEDEIMBMggIABCABBCxAzIICAAQgAQQsQMyBQgAEIAEMgUIABCABDIFCAAQgAQyCwgAEIAEELEDEIMBMgUIABCABDoKCAAQRxDWBBCwAzoHCAAQsAMQQzoECCMQJzoECAAQQzoKCAAQsQMQgwEQQzoHCAAQsQMQQzoJCCMQJxBGEIICSgQIQRgASgQIRhgAUKsGWLMYYOUgaAFwAXgAgAGiAogB9gmSAQUzLjYuMZgBAKABAcgBCsABAQ&sclient=gws-wiz";
        string spanfrank = "//span[@class='DFlfde SwHCTb']";
        private static double moneyvalue(string link, string span)
        {
            double value = 0;
            HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument document = website.Load($"{link}");
            var datalist = document.DocumentNode.SelectNodes($"{span}").ToList();
            foreach (var item in datalist)
            {
                value = Convert.ToDouble(item.InnerText);
            }
            return value;
        }
        public double euro()
        {
            double euro = moneyvalue(linkeuro, spaneuro);
            return euro;
        } 
        public double dolar()
        {
            double dolar = moneyvalue(linkdolar, spandolar);
            return dolar;
        }
        public double funt()
        {
            double funt = moneyvalue(linkfunt, spanfunt);
            return funt;
        }
        public double frank()
        {
            double frank = moneyvalue(linkfrank, spanfrank);
            return frank;
        }
        public double moneyconvert(double moneya, double moneyb)
        {
            double result = moneya / moneyb;
            return result;
        }
        public List<double> currencylist()
        {
            _amount.Add(euro());
            _amount.Add(dolar());
            _amount.Add(frank());
            _amount.Add(funt());
            _amount.Add(pln);
            return _amount;
        }
        private string nocurrency()
        {
            return "There is no currency like that.";
        }
        public double switchcurrency(string choice1, string choice2)
        {            
            double value = 0;
            switch (choice1)
            {
                case "1":
                    switch (choice2)
                    {
                        case "2":
                            value = moneyconvert(_amount[1], _amount[0]);
                            break;
                        case "3":
                            value = moneyconvert(_amount[1], _amount[3]);
                            break;
                        case "4":
                            value = moneyconvert(_amount[1], _amount[2]);
                            break;
                        case "5":
                            value = moneyconvert(_amount[1], _amount[4]);
                            break;
                        default:
                            nocurrency();
                            break;
                    }
                    break;
                case "2":
                    switch (choice2)
                    {
                        case "1":
                            value = moneyconvert(_amount[0], _amount[1]);
                            break;
                        case "3":
                            value = moneyconvert(_amount[0], _amount[3]);
                            break;
                        case "4":
                            value = moneyconvert(_amount[0], _amount[2]);
                            break;
                        case "5":
                            value = moneyconvert(_amount[0], _amount[4]);
                            break;
                        default:
                            nocurrency();
                            break;
                    }
                    break;
                case "3":
                    switch (choice2)
                    {
                        case "1":
                            value = moneyconvert(_amount[3], _amount[1]);
                            break;
                        case "2":
                            value = moneyconvert(_amount[3], _amount[0]);
                            break;
                        case "4":
                            value = moneyconvert(_amount[3], _amount[2]);
                            break;
                        case "5":
                            value = moneyconvert(_amount[3], _amount[4]);
                            break;
                        default:
                            nocurrency();
                            break;
                    }
                    break;
                case "4":
                    switch (choice2)
                    {
                        case "1":
                            value = moneyconvert(_amount[2], _amount[1]);
                            break;
                        case "2":
                            value = moneyconvert(_amount[2], _amount[0]);
                            break;
                        case "3":
                            value = moneyconvert(_amount[2], _amount[3]);
                            break;
                        case "5":
                            value = moneyconvert(_amount[2], _amount[4]);
                            break;
                        default:
                            nocurrency();
                            break;
                    }
                    break;
                case "5":
                    switch (choice2)
                    {
                        case "1":
                            value = moneyconvert(_amount[4], _amount[1]);
                            break;
                        case "2":
                            value = moneyconvert(_amount[4], _amount[0]);
                            break;
                        case "3":
                            value = moneyconvert(_amount[4], _amount[3]);
                            break;
                        case "4":
                            value = moneyconvert(_amount[4], _amount[2]);
                            break;
                        default:
                            nocurrency();
                            break;
                    }
                    break;
                default:
                    nocurrency();
                    break;
            }
            return value;
        }
    }
}
