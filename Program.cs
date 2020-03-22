using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharp2a
{
        class Round
        {
            public Round() { }
            public Round(double R)
            {
                if (R != 0)
                {
                    this.R = R;
                }
                else
                {
                    Console.WriteLine("Bad number");
                }
            }

            public void SetR(double R)
            {
                if (R != 0)
                {
                    this.R = R;
                }
                else
                {
                    Console.WriteLine("Bad number");
                }
            }
            private double R;
            private double L;
            private double S;

            private void findL()
            {
                double L = 2 * this.R * Math.PI;
                this.L = L;
            }

            public double GetL()
            {
                if (this.L == 0)
                {
                    findL();
                    return this.L;
                }
                else
                {
                    return this.L;
                }
            }

            public void ShowL()
            {
                if (this.L != 0)
                {
                    Console.WriteLine($"L is: {this.L}");
                }
                else
                {
                    Console.WriteLine("Nothing to show: L is 0, or undefined");
                }
            }

            private void findS()
            {
                double S = Math.Pow(this.R, 2) * Math.PI;
                this.S = S;
            }

            public double GetS()
            {
                if (this.S == 0)
                {
                    findS();
                    return this.S;
                }
                else
                {
                    return this.S;
                }
            }

            public void ShowS()
            {
                if (this.S != 0)
                {
                    Console.WriteLine($"S is: {this.S}");
                }
                else
                {
                    Console.WriteLine("Nothing to show: S is 0, or undefined");
                }
            }

        }

        class Cylinder : Round
        {
            public Cylinder(double R, double H)
            {
                if ((R != 0 && H != 0))
                {
                    this.R = R;
                    this.H = H;
                }
                else
                {
                    Console.WriteLine("Bad numbers");
                }
            }

            private double R;
            private double H;
            private double V;

            public void SetH(double H)
            {
                if (H != 0)
                {
                    this.H = H;
                }
            }
            private void findS()
            {
                if (this.R != 0 && this.H != 0)
                {
                    double V = Math.Pow(this.R, 2) * Math.PI * H;
                    this.V = V;
                }
                else
                {
                    Console.WriteLine("H or R undefined, or equals 0");
                }
            }

            public double GetV()
            {
                if (this.V == 0)
                {
                    findS();
                    return this.V;
                }
                else
                {
                    return this.V;
                }
            }

        }
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Enter amount of Rounds: ");
                int N = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Enter amount of Cylinders");
                int M = Int32.Parse(Console.ReadLine());

                Round[] roundMass = new Round[N];
                double tmpR = 0;
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine($"Enter {i}`s Round R element: ");
                    tmpR = Int32.Parse(Console.ReadLine());
                    roundMass[i] = new Round(tmpR);
                }

                double tmpH = 0;
                tmpR = 0;
                Cylinder[] cylinderMass = new Cylinder[M];
                for (int i = 0; i < M; i++)
                {
                    Console.WriteLine($"Enter {i}`s Cylinder H element: ");
                    tmpH = Int32.Parse(Console.ReadLine());
                    Console.WriteLine($"Enter {i}`s Cylinder R element: ");
                    tmpR = Int32.Parse(Console.ReadLine());
                    cylinderMass[i] = new Cylinder(tmpR, tmpH);
                }

                double sMax = 0;
                double tmpL = 0;
                for (int i = 0; i < N; i++)
                {
                    tmpL = roundMass[i].GetS();
                    if (tmpL > sMax)
                    {
                        sMax = tmpL;
                    }
                }
                Console.WriteLine($"Max S of Rounds is: {sMax}");

                double vSumm = 0;
                for (int i = 0; i < M; i++)
                {
                    vSumm += cylinderMass[i].GetV();
                }

                double vMiddle = vSumm / M;
                Console.WriteLine($"Middle of all V`s is: {vMiddle}");
            }
        }
    
}
    
