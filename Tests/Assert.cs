using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    public class Assert : NUnit.Framework.Assert
    {
        public const double Eps = 0.000001;
        public static void AreEqual(double[] expected, double[] actual, double delta = Eps)
        {
            AreEqual(expected.Length, actual.Length);
            for (int i = 0; i < actual.Length; i++)
            {
                AreEqual(expected[i], actual[i], delta);
            }
        }

        public static void AreEqual(double[,] expected, double[,] actual, double delta = Eps)
        {
            AreEqual(expected.GetLength(0), actual.GetLength(0));
            AreEqual(expected.GetLength(1), actual.GetLength(1));
            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    AreEqual(expected[i, j], actual[i, j], delta);
                }
            }
        }
    }
}
