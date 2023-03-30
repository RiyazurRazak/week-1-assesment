using System.ComponentModel;
using System.Diagnostics;

namespace week_1_assesment
{

    class VendingMachine
    {
        private Stack<string> dispenser;
        public VendingMachine()
        {
            this.dispenser = new Stack<string>();
        }

        public void AddChocolates(string color, int count)
        {
            for(int i=0; i<count; i++)
            {
                dispenser.Push(color);
            }
           
        }

        public string[] RemoveChocolates(int count)
        {
            string container;
            string[] package = new string[count];
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

        public string[] DispenseChocolates(int count)
        {
            string container;
            string[] package = new string[count];
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

        public string[] DispenseChocolatesOfSameColor(string color)
        {
            
            string container;
            List<string>package = new List<string>();
            List<string> tempBox = new List<string>();
            int count = this.dispenser.Count();
            for (int itr = 0; itr <count; itr++)
            {
                if (this.dispenser.TryPeek(out container))
                {
                    if (container == color)
                    {
                        package.Add(this.dispenser.Pop());
                    }
                    else
                    {
                        tempBox.Add(this.dispenser.Pop());
                    } 
                }
                else
                {
                    throw new Exception("Dispenser is Empty");
                }
            }
            tempBox.Reverse();
            tempBox.ForEach((chocolate) => this.dispenser.Push(chocolate));
            return package.ToArray();
        }

        public int[] NoOfChocolates()
        {
            int[] count = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            string[] chocolates = this.dispenser.ToArray();
            for (int itr = 0; itr < chocolates.Length; itr++)
            {
                if (chocolates[itr] == "green") count[0]+= 1;
                else if (chocolates[itr] == "silver") count[1] += 1;
                else if (chocolates[itr] == "blue") count[2] += 1;
                else if (chocolates[itr] == "crimson") count[3] +=1;
                else if (chocolates[itr] == "purple") count[4] += 1;
                else if (chocolates[itr] == "red") count[5] += 1;
                else count[6]++;
            }
            return count;

        }

        public void ChangeChocolateColor(int count, string colorToChange, string changeColor)
        {
            string container;
            int changeColorCount = 0;
            int dispencerCount = this.dispenser.Count();
            for (int itr = 0; itr < dispencerCount; itr++)
            {
                if (changeColorCount == count) break;
                if (this.dispenser.TryPeek(out container))
                {
                   
                    if (container == colorToChange)
                    {
                        
                        changeColorCount += 1;
                        this.dispenser.Pop();
                    }

                }
            }
          
            for(int i=0; i< count; i++)
            {
                this.dispenser.Push(changeColor);
            }
           
        }

        public string RemoveChocolateOfColor(string color)
        {
            string chocolate = "";
            string container;
            int count = this.dispenser.Count();
            List<string> tempBox = new List<string>();
            for(int itr=0; itr<count; itr++)
            {
                if (this.dispenser.TryPeek(out container))
                {
                  
                    if(container == color)
                    {
                        chocolate = this.dispenser.Pop();
                        break;
                    }
                    else
                    {
                        tempBox.Add(this.dispenser.Pop());
                    }
                }
                else
                {
                    break;
                }
            }
            tempBox.Reverse();
            tempBox.ForEach((chocolate) => this.dispenser.Push(chocolate));
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
            string[] redChocolates = machine.DispenseChocolatesOfSameColor("red");
            Console.WriteLine("Red Chocolates "+ redChocolates.Length);
            machine.RemoveChocolates(2);
            machine.DispenseChocolates(2);
            int[] totalChocolatesAfter = machine.NoOfChocolates();
            foreach (int count in totalChocolatesAfter)
            {
                Console.WriteLine(count);
            }
            machine.ChangeChocolateColor(2, "blue", "red");
            Console.WriteLine("Blue Chocolate of Count 2 Changed to Red");
            int[] totalChocolatesAfterColorChange = machine.NoOfChocolates();
            foreach (int count in totalChocolatesAfterColorChange)
            {
                Console.WriteLine(count);
            }
            machine.RemoveChocolateOfColor("blue");
            Console.WriteLine("Blue Chocolate Removed");
            int[] totalChocolatesAfterBlueRemoved = machine.NoOfChocolates();
            foreach (int count in totalChocolatesAfterBlueRemoved)
            {
                Console.WriteLine(count);
            }

        }
    }
}