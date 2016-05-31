using System;
using System.Collections.Generic;
using System.Linq;
using mixhaar.Functions;

namespace mixhaar
{
    public class DiffEqSolver
    {
        private Func<double, double> a2, a1, a0;
        double y0, y1;
        private Func<double, double> f;

        /// <summary>
        /// Solves differential equation y''(t)+ay'(t)+by(t)=f(t), y(0)=y0, y'(0)=y1
        /// </summary>
        /// <param name="a1"></param>
        /// <param name="a0"></param>
        /// <param name="f"></param>
        public DiffEqSolver(Func<double, double> a2, Func<double, double> a1, Func<double, double> a0, Func<double, double> f, double y0, double y1)
        {
            this.a2 = a2;
            this.a1 = a1;
            this.a0 = a0;
            this.f = f;
            this.y0 = y0;
            this.y1 = y1;
        }


        /// <summary>
        /// Constructs matrix A and vector B for linear system of equations Ax=B
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="n"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        public void ConstructMatrix(double[] nodes, int n, out double[,] A, out double[] B)
        {
            var m = nodes.Length;
            A = new double[m, n];
            B = new double[m];
            for (int j = 0; j < m; j++)
            {
                var t = nodes[j];
                for (int k = 0; k < n; k++)
                {
                    A[j, k] = a2(t) * Function.Haar(k + 1)(t) + 
                        a1(t) * Function.MixedHaar2(1, k + 1 + 1)(t) + a0(t) * Function.MixedHaar2(2, k + 1 + 2)(t);
                }
                B[j] = f(t) - a1(t) * y1 - a0(t) * (y0 + y1 * t);
            }
        }

        public Func<double, double> Solve(double[] nodes, int n)
        {
            double[,] A;
            double[] B;
            ConstructMatrix(nodes, n, out A, out B);
            var yk = mathlib.LinearSystem.Solve(A, B);
            return MakeFromCoeffs(y0, y1, yk);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coeffs"></param>
        /// <returns></returns>
        private static Func<double, double> MakeFromCoeffs(double y0, double y1, double[] coeffs)
        {
            var n = coeffs.Length;
            var haar2 = new Func<double, double>[n];
            for (int k = 0; k < n; k++)
            {
                haar2[k] = Function.MixedHaar2(2, k + 1 + 2);
            }

            return t =>
                y0 + y1 * t + coeffs.Select((yk, k) => yk * haar2[k](t)).Sum();
        }
    }
}