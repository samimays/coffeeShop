using System;
using System.Collections.Generic;
using System.Text;

namespace coffeeShop
{
    class Decaf : Coffee
    {
        private double minQuantity;

        public Decaf(String name, double demand, double unitCost, double mq) :
            base(name, demand, unitCost)
        {
            minQuantity = mq;
        }

        public override string ToString()
        {
            return String.Format("{0} {1,-10:N2}", base.ToString(), (int)minQuantity);
        }
    }
}
