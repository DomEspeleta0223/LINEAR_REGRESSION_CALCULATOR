using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;

public class CALC_CODE
{
    static void Main(string[] args)
    {
        for (; ; )
        {
            Console.WriteLine("Hi! I'm Dominic. Welcome to my Correlation Calculator!");
            Console.WriteLine("This Calculator Uses Linear Regression For Calculating Correlation");

            Console.Write("\nEnter Number/Count (n):\t");
            int n = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("\nPlease Enter Values For X:\t");
            double[] X = new double[n];
            double SigmaX = 0;
            double SigmaX2 = 0;
            int ni = n - 1;
            double X2;

            for (int nx = 0; nx <= ni; nx++)
            {
                Console.Write("\nEnter Here:\t");
                X[nx] = Convert.ToDouble(Console.ReadLine());

                SigmaX = SigmaX + X[nx];

                X2 = X[nx] * X[nx];
                SigmaX2 = SigmaX2 + X2;
            }


            Console.WriteLine("\nPlease Enter Values For Y:\t");
            double[] Y = new double[n];
            double SigmaY = 0;
            double SigmaY2 = 0;
            double SigmaXY = 0;
            double Y2;
            double XY;

            for (int nx = 0; nx <= ni; nx++)
            {
                Console.Write("\nEnter Here:\t");
                Y[nx] = Convert.ToDouble(Console.ReadLine());

                SigmaY = SigmaY + Y[nx];
                XY = X[nx] * Y[nx];
                Y2 = Y[nx] * Y[nx];
                SigmaY2 = SigmaY2 + Y2;
                SigmaXY = SigmaXY + XY;
            }

            double Byx = (((n * SigmaXY) - (SigmaX * SigmaY)) / ((n * SigmaX2) - (SigmaX * SigmaX)));
            double XMean = (SigmaX) / n;
            double YMean = (SigmaY) / n;
            double Ayx = YMean - Byx * XMean;
            double[] YHat = new double[n];
            double[] YYHat = new double[n];
            double SigmaYYHat2 = 0;

            for (int nx = 0; nx <= ni; nx++)
            {
                YHat[nx] = Ayx + (Byx * X[nx]);
                YYHat[nx] = Y[nx] - YHat[nx];
                double YYHat2 = YYHat[nx] * YYHat[nx];
                SigmaYYHat2 = SigmaYYHat2 + YYHat2;
            }
            double y = (SigmaY2 - ((SigmaY * SigmaY) / n));
            double Error = (SigmaYYHat2 / y) * 100;
            double Percentage = ((y - SigmaYYHat2) / y) * 100;

            double ByxAbs = Math.Abs(Byx);
            if (Byx >= 0)
            {
                string sign = " + ";
                Console.WriteLine("\nEquation:\t" + "Y = " + Ayx + sign + ByxAbs + "X");
            }
            else
            {
                string sign = " - ";
                Console.WriteLine("\nEquation:\t" + "Y = " + Ayx + sign + ByxAbs + "X");
            }
            
            Console.WriteLine("\n" + Percentage + "% of the scores of the variable Y is attributed to their scores in variable X");
            Console.WriteLine("\nYou Can Press Any Key To Clear All!");

            Console.ReadKey();
            Console.Clear();
        }
    }
}
