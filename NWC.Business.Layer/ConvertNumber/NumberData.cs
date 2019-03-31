using log4net;
using NWC.Helper.Layer;
using System;

namespace NWC.Business.Layer
{
    public class NumberData : INumberData
    {
        private static ILog _Logger;

        public NumberData(ILog logger)
        {
            _Logger = logger;
        }

        public string ProcessNumbers(double number)
        {
            try
            {
               
                return MoneyToWords(number);
                
            }
            catch (OverflowException ex)
            {
                _Logger.Error(string.Format("ProcessData: Message {0} ,Stacktrace {1} ", ex.ToString(), ex.StackTrace.ToString()));
                return string.Empty;
            }
            catch (DivideByZeroException ex)
            {
                _Logger.Error(string.Format("ProcessData: Message {0} ,Stacktrace {1} ", ex.ToString(), ex.StackTrace.ToString()));
                return string.Empty;
            }
            catch (StackOverflowException ex)
            {
                _Logger.Error(string.Format("ProcessData: Message {0} ,Stacktrace {1} ", ex.ToString(), ex.StackTrace.ToString()));
                return string.Empty;
            }
            catch (Exception ex)
            {
                _Logger.Error(string.Format("ProcessData: Message {0} ,Stacktrace {1} ", ex.ToString(), ex.StackTrace.ToString()));
                return string.Empty;
            }
        }

        private string MoneyToWords(double value)
        {
            
                decimal money = Math.Round((decimal)value, 2);
                long number = (long)money;
                long decimalValue = 0;
                string dollar = string.Empty;
                string cents = string.Empty;
                dollar = NumberToWords(number);
                if (money.ToString().Contains("."))
                {
                    decimalValue = long.Parse(money.ToString().Split('.')[1]);
                    cents = NumberToWords(decimalValue);
                }

                //Get display messages
                var CurrencySubUnitSingular = ConfigurationHelper.GetConfigurations(Constants.CurrencySubUnitSingular);
                var CurrencyUnitSingular = ConfigurationHelper.GetConfigurations(Constants.CurrencyUnitSingular);
                var CurrencyUnitPlural = ConfigurationHelper.GetConfigurations(Constants.CurrencyUnitPlural);
                var CurrencySubUnitPlural = ConfigurationHelper.GetConfigurations(Constants.CurrencySubUnitPlural);

                string result = !string.IsNullOrEmpty(cents) ? (decimalValue == 1 ? string.Format("{0} {1} and {2} {3} Only.", dollar, CurrencyUnitPlural,cents, CurrencySubUnitSingular) : string.Format("{0} {1} and {2} {3} Only.", dollar, CurrencyUnitPlural,cents, CurrencySubUnitPlural)) : string.Format("{0} {1} Only.", dollar, CurrencyUnitSingular);
              
                return result;
           

        }

        private static string NumberToWords(long number)
        {
            string allowNegative = ConfigurationHelper.GetConfigurations(Constants.AllowNegative);

            bool flag = false;
            if (number < 0)
                return "NEGATIVE " + NumberToWords(Math.Abs(number));

            if (number == 0)
                return "ZERO";

            string words = "";
            BuildPlaceValue(ref number, ref words);
            words = BuildTensUnit(number, words);
            return words;
        }

        /// <summary>
        /// Responsible to build the place value
        /// </summary>
        /// <param name="number"></param>
        /// <param name="words"></param>
        private static void BuildPlaceValue(ref long number, ref string words)
        {
            var numberDictionary = ConfigurationHelper.GetConfigurations(Constants.NumberDictionary);
            if (!string.IsNullOrEmpty(numberDictionary))
            {
                var entries= numberDictionary.Split(',');

                foreach (var items in entries)
                {
                    var item = items.Split('|');
                    var numberItem = item[0];
                    var term = item[1];

                    if (!string.IsNullOrEmpty(numberItem) && !string.IsNullOrEmpty(term))
                    {
                        long value;
                        if (long.TryParse(numberItem, out value))
                        {
                            if ((number / value) > 0)
                            {
                                words += NumberToWords(number / value) + " " + term + " ";
                                number %= value;
                            }

                        }
                    }

                }

            }
        }

        /// <summary>
        /// Responsible to build the tens unit of the number
        /// </summary>
        /// <param name="number"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        private static string BuildTensUnit(long number, string words)
        {
            if (number > 0)
            {
                var unitsData = ConfigurationHelper.GetConfigurations(Constants.UnitsMap);
                var tensData = ConfigurationHelper.GetConfigurations(Constants.TensMap);
                var unitsMap = unitsData.Split(',');
                var tensMap = tensData.Split(',');

                if (unitsMap != null && unitsMap.Length > 1 && tensMap != null && tensMap.Length > 1)
                {
                    if (number < 20)
                        words += unitsMap[number];
                    else
                    {
                        words += tensMap[(number) / 10];
                        if ((number % 10) > 0)
                            words += "-" + unitsMap[(number) % 10];
                    }
                }

            }

            return words;
        }
    }
}
