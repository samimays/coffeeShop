using System;
using C = System.Console;

namespace coffeeShop
{
    class EOQCalculator
    {
        static void Main(string[] args)
        {
            //define the variables that will be used in the formula
            int arraySize = 2;
            double quantity, totalQ = 0;
            int count = 0;
            Coffee[] inventory = new Coffee[arraySize];
            double unitCost;
            double D;
            RoastType roast = 0;

            C.WriteLine("Welcome to the EOQ Calculator designed by Sami");
            C.WriteLine("Please enter q to quit or the name of the coffee");
            string brand = C.ReadLine();

            while (!(brand.ToLower().Equals("q")))
            {
                if (count == arraySize)
                {
                    arraySize += 2;
                    Array.Resize(ref inventory, arraySize);
                }

                C.WriteLine("Please enter the demand: ");
                D = Validation(C.ReadLine());

                C.WriteLine("Please enter the unit cost: ");
                unitCost = Validation(C.ReadLine());

                C.WriteLine("Please specify Regular coffee or Decaf Coffee: ");
                string type = C.ReadLine();

                if (type.ToLower().Equals("decaf"))
                {
                    C.WriteLine("Please enter the minimum quantity: ");
                    double q = Validation(C.ReadLine());
                    inventory[count] = new Decaf(brand, D, unitCost, q);
                }
                else
                {
                    C.WriteLine("Please enter a roast type using integers: " +
                        "1 = light, 2 = medium, 3 = dark");

                    int r = int.Parse(C.ReadLine());
                    roast = (RoastType)r;
                    inventory[count] = new Regular(brand, D, unitCost, roast);
                }

                quantity = inventory[count].Q();
                inventory[count].setQ(quantity);
                totalQ += quantity;
                count++;

                C.WriteLine("Please enter q to quit or the name of the coffee: ");
                brand = C.ReadLine();

            }
            if (totalQ != 0)
            {
                //need to write the toString line here
                C.WriteLine(String.Format("\n{0,-15} {1,-10} {2,-10} {3,-10} {4,-10} {5,-10} {6,-10}", "Name", "C($)", "Demand", "Q(lbs)", "TAC($)", "T(mon)", "Details"));
                for (int i = 0; i < inventory.Length; i++)
                {
                    if (inventory[i] != null)
                    {
                        C.WriteLine(inventory[i].ToString());
                    }
                }
            }

            C.WriteLine("If you purchase all of this coffee, you will need space to hold " +
                (int)totalQ + " lbs of coffee");
            C.WriteLine("Press any button to exit: ");
            C.Read();
        }

        //validates whether the number is positive or not
        static double Validation(string value)
        {
            double number;
            bool success = Double.TryParse(value, out number);
            while (!(success == true && number > 0))
            {
                C.WriteLine("Incorrect value, please enter a positive number grater than zero: ");
                success = Double.TryParse(C.ReadLine(), out number);
            }
            return number;
        }
    }
}
