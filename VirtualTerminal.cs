using System.ComponentModel;
using System.Diagnostics;

namespace week_1_assesment
{

    public struct Chocolate
    {
        public int count;
        public string color;
    }
    class VendingMachine
    {
        private Stack<Chocolate> dispenser;
        public VendingMachine()
        {
            this.dispenser = new Stack<Chocolate>();
        }

        public void AddChocolates(string color, int count)
        {
            Chocolate chocolate = new Chocolate();
            chocolate.color = color;
            chocolate.count = count;
            dispenser.Push(chocolate);
        }

        public Chocolate[] RemoveChocolates(int count)
        {
            Chocolate container = new Chocolate();
            Chocolate[] package = new Chocolate[count];
            for (int itr=0; itr<count; itr++)
            {
                if(this.dispenser.TryPeek(out container))
                {
                    package[itr] = (this.dispenser.Pop());
                }
                else
                {
                    throw new Exception("Dispenser is Empty");
                }
            }
            return package;
        }

        public Chocolate[] DispenseChocolates(int count)
        {
            Chocolate container = new Chocolate();
            Chocolate[] package = new Chocolate[count];
            this.dispenser.Reverse();
            for (int itr = 0; itr < count; itr++)
            {
                if (this.dispenser.TryPeek(out container))
                {
                    package[itr] = (this.dispenser.Pop());
                }
                else
                {
                    throw new Exception("Dispenser is Empty");
                }
            }
            this.dispenser.Reverse();
            return package;
        }

        public Chocolate[] DispenseChocolatesOfSameColor(string color)
        {
            Chocolate container = new Chocolate();
            List<Chocolate>package = new List<Chocolate>();
            for (int itr = 0; itr <this.dispenser.Count(); itr++)
            {
                if (this.dispenser.TryPeek(out container))
                {
                    if(container.color == color)
                    {
                        package[itr] = (this.dispenser.Pop());
                    } 
                }
                else
                {
                    throw new Exception("Dispenser is Empty");
                }
            }
            return package.ToArray();
        }

        public int[] NoOfChocolates()
        {
            int[] count = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            Chocolate[] chocolates = this.dispenser.ToArray();
            for (int itr = 0; itr < chocolates.Length; itr++)
            {
                if (chocolates[itr].color == "green") count[0]+= chocolates[itr].count;
                else if (chocolates[itr].color == "silver") count[1] += chocolates[itr].count;
                else if (chocolates[itr].color == "blue") count[2] += chocolates[itr].count;
                else if (chocolates[itr].color == "crimson") count[3] += chocolates[itr].count;
                else if (chocolates[itr].color == "purple") count[4] += chocolates[itr].count;
                else if (chocolates[itr].color == "red") count[5] += chocolates[itr].count;
                else count[6]++;
            }
            return count;

        }

        public void ChangeChocolateColor(int count, string colorToChange, string changeColor)
        {
            Chocolate container = new Chocolate();
            int changeColorCount = 0;
            for (int itr = 0; itr < this.dispenser.Count; itr++)
            {
                if (changeColorCount == count) break;
                if (this.dispenser.TryPeek(out container))
                {
                    if (container.color == colorToChange)
                    {
                        container.color = changeColor;
                        changeColorCount += container.count;
                        this.dispenser.Pop();
                        this.dispenser.Push(container);
                    }

                }
            }
        }

        public Chocolate RemoveChocolateOfColor(string color)
        {
            Chocolate chocolate = new Chocolate();
            Chocolate container;
            while (this.dispenser.Count > 0)
            {
                if (this.dispenser.TryPeek(out container))
                {
                    if(container.color == color)
                    {
                        this.dispenser.Pop();
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            return chocolate;
        }
    }
    internal class VirtualTerminal
    {
        static void Main(string[] args)
        {

            VendingMachine machine = new VendingMachine();
            machine.AddChocolates("red", 3);
            machine.AddChocolates("blue", 5);
            machine.AddChocolates("green", 4);
            int[]  totalChocolates = machine.NoOfChocolates();
            foreach (int count in totalChocolates)
            {
                Console.WriteLine(count);
            }
            Chocolate[] redChocolates = machine.DispenseChocolatesOfSameColor("red");
            foreach (Chocolate chocolate in redChocolates)
            {
                Console.WriteLine(chocolate.color);
            }
            
        }
    }
}