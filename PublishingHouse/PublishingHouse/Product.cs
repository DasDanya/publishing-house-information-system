using System;
using System.Collections.Generic;
using System.Text;

namespace PublishingHouse
{
   public class Product
    {

        string name;
        int numberEdition;

        public string Name { get { return name; } }
        public int NumberEdition { get { return numberEdition; } }

        public Product(string name, int numberEdition)
        {
            this.name = name;
            this.numberEdition = numberEdition;
        }
    }
}
