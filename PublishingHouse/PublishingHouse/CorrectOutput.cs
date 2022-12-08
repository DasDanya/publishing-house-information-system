using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для преобразования введённых данных в правильный вид
    /// </summary>
    public static class CorrectOutput
    {
        /// <summary>
        /// Метод преобразования строки в правильный вид
        /// </summary>
        /// <param name="str">Строка</param>
        /// <returns>Правильная строка</returns>
        public static string CorrectStateOrCity(string str)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            char[] letters = str.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);

            for (int i = 1; i < letters.Length; i++)
            {
                if (letters[i - 1] == '-')
                    letters[i] = char.ToUpper(letters[i]);

                else
                    letters[i] = char.ToLower(letters[i]);

            }

            return new string(letters);
        }        
    }
}
