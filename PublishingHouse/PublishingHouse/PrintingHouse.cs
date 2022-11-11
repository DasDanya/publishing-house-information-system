using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse
{
    /// <summary>
    /// Класс для работы с типографией
    /// </summary>
    public class PrintingHouse
    {
        string name, numberPhone, email, typeState, nameState, city, typeStreet, nameStreet, numberHouse;

        public PrintingHouse(string name, string numberPhone, string email, string typeState, string nameState, string city, string typeStreet, string nameStreet, string numberHouse)
        {
            this.name = name;
            this.numberPhone = numberPhone;
            this.email = email;
            this.typeState = typeState;
            this.nameState = nameState;
            this.city = city;
            this.typeStreet = typeStreet;
            this.nameStreet = nameStreet;
            this.numberHouse = numberHouse;
        }

        public override string ToString()
        {
            return $"{name}\n {numberPhone}\n {email}\n {typeState}\n {nameState}\n {city}\n {typeStreet}\n {nameStreet}\n {numberHouse}";
        }
    }
}
