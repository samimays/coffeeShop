using System;
using System.Collections.Generic;
using System.Text;

namespace coffeeShop
{
    class Coffee
    {
        private double quantity;
        private String name;
        private double H, D, C;
        const int K = 20;

        public Coffee()
        {
            name = null;
        }

        public Coffee(String name, double demand, double unitCost)
        {
            this.name = name;
            C = unitCost;
            H = 0.3 * C;
            D = demand;
        }
        public float Q()
        {
            return (float)(Math.Sqrt(2 * D * K / H));
        }

        public void setQ(double quant)
        {
            quantity = quant;
        }

        public float TAC()
        {
            return (float)((quantity / 2 * H) + (D * K / quantity) + D * C);
        }

        public float T()
        {
            return (float)(quantity / D) * 12;
        }

        public override string ToString()
        {
            return String.Format("{0,-15} {1,-10:N2} {2,-10} {3,-10:N2} {4,-10:N2} {5,-10:N2}",
                name, C, (int)D, (int)Q(), (double)TAC(), (double)T());
        }
    }
}
