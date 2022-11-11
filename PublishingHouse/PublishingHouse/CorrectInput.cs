using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для проверок на правильность ввода данных
    /// </summary>
  public static class CorrectInput
    {
        /// <summary>
        /// Метод проверки электронной почты на корректность
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns>Корректна ли электронная почта</returns>
        public static bool IsCorrectEmail(string email)
        {  
            return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }


        /// <summary>
        /// Метод проверки строки субъекта и города на корректность
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns></returns>
        public static bool CheckNameOfStateOrCity(string checkString)
        {
            return Regex.IsMatch(checkString, @"^[А-Яа-я]*(?:[\s-][А-Яа-я]*)*$");

            //return Regex.IsMatch(checkString, @"^\p{Lu}\p{L}*(?:[\s-]\p{Lu}\p{L}*)*$");

        }


        /// <summary>
        /// Метод проверки номера дома на корректность
        /// </summary>
        /// <param name="house">Номер дома</param>
        /// <returns>Корректен ли номер дома</returns>
        public static bool IsCorrectNumberOfHouse(string house)
        {
            if (Regex.IsMatch(house, @"^[1-9]\d*(?: ?(?:[А-Га-г]|[/] ?\d+))?$"))
                return true;
            else
                return false;
        }
    }
}
