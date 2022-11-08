using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Linq;
using System.Text.RegularExpressions;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для проверок на правильность ввода данных
    /// </summary>
  public static class CorrentInput
    {
        /// <summary>
        /// Метод проверки электронной почты на корректность
        /// </summary>
        /// <param name="email">Электронная почта</param>
        /// <returns>Корректна ли электронная почта</returns>
        public static bool IsCorrectEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        /// <summary>
        /// Метод проверки строки субъекта и города на корректность
        /// </summary>
        /// <param name="checkString"></param>
        /// <returns></returns>
        public static bool CheckNameOfStateOrCity(string checkString)
        {
            //if (Regex.IsMatch(checkString, @"^[а - я А - Я] + (?:[\s -][а - я А - Я] +) *$"))
            //    return true;
            //else
            //    return false;

            return true;
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
