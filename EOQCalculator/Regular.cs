using System;
using System.Collections.Generic;
using System.Text;

namespace coffeeShop
{
    class Regular : Coffee
    {
        RoastType roast;

        public Regular(String name, double demand, double unitCost, RoastType roast) :
            base(name, demand, unitCost)
        {
            this.roast = roast;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", base.ToString(), roast);
        }
    }
    enum RoastType
    {
        light = 1,
        medium,
        dark
    }
}
