using System;
using System.Collections.Generic;
using System.Linq;
using mixhaar.Functions;
using mathlib;

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

        static double velichina(int x, int k, int r, int N) {
            double res = 1.0;

            for (int i = 0; i < r; i++) {
                res = res * ((double)x - i) / ((double)k - i) *
                    ((double)N + r - x - 1.0 - i) / (N - 1.0 - i);
            }

            if (r % 2 == 0) {
                return res;
            } else {
                return -res;
            }
            
        }

        static double velichina2(int x, int k, int r, int N)
        {
            double res = 0.0;
            double tmp;

            for (int l = 0; l <= k; l++) {
                tmp = 1.0;

                for (int i = 0; i < l; i++) {
                    tmp = tmp * ((double)k - i) / ((double)N - 1.0 - i);
                }
                for (int i = l + 1; i <= k + l; i++) {
                    tmp = tmp * i;
                }
                for (int i = 0; i < r; i++) {
                    tmp = tmp * ((double)x - i) / ((double)l + r - i);
                }
                for (int i = 0; i < l; i++) {
                    tmp = tmp * ((double)x - r - i) / (i+1.0);
                }

                res = res + Math.Pow(-1, l) * tmp;

            }
            
            if (k % 2 == 0) {
                return res;
            } else {
                return -res;
            }

        }

        static double H(int k, int r, int N)
        {
            return Math.Sqrt(
                ChebRobustCalc.hnN(k - r, N - r, r) / ChebRobustCalc.hnN(k, N, 0)
            );
        }        
        public static double[] tau2(int r, int m, int N) {
            string s;
            int k = m - r;
            double[] tauRR = new double[N];
            
            if (m >= 2*r) {            
                double[] tau = ChebRobustCalc.ChebUltrasphRecFromCenter(k - r, N - r, r, out s)[k - r];
                for (int x = 0; x < r; x++) { tauRR[x] = 0.0; }

                double Hrr = H(k, r, N);

                for (int x = r; x < N; x++) {
                    tauRR[x] = Hrr * tau[x - r] * velichina(x, k, r, N);
                }
            } else if ((m < 2 * r) && (m >= r)) {
                for (int x = 0; x < r; x++) { tauRR[x] = 0.0; }

                for (int x = r; x < N; x++) {
                    tauRR[x] = velichina2(x, k, r, N) / Math.Sqrt(ChebRobustCalc.hnN(k, N, 0));
                }

            } else {
                for (int x = 0; x < m; x++) {  tauRR[x] = 0.0; }

                for (int x = m; x < N; x++) {
                    tauRR[x] = 1.0;
                    for (int i = 0; i < m; i++) {
                        tauRR[x] = tauRR[x] * ((double)x - i) / ((double)m - i);
                    }
                }
            }
            return tauRR;
        }
        
       
        /// <summary>
        /// Constructs matrix A and vector B for linear system of equations Ax=B
        /// </summary>
        /// <param name="nodes"></param>
        /// <param name="n"></param>
        /// <param name="A"></param>
        /// <param name="B"></param>
        public void ConstructMatrix(int N, int n, out double[,] A, out double[] B)
        {
            string s;

            A = new double[N, n];
            B = new double[N];

            double[][] tau = ChebRobustCalc.ChebUltrasphRecFromCenter(n, N, 0, out s);

            double[][] tau_1 = new double[n + 3][];
            double[][] tau_2 = new double[n + 3][];
            for (int k = 0; k < n + 3; k++) {
                tau_1[k] = tau2(1, k, N);
                tau_2[k] = tau2(2, k, N);
            }


            for (int j = 0; j < N; j++)
            {
                for (int k = 0; k < n; k++)
                {
//                    A[j, k] = a2(t) * Function.Haar(k + 1)(t) + 
//                        a1(t) * Function.MixedHaar2(1, k + 1 + 1)(t) + a0(t) * Function.MixedHaar2(2, k + 1 + 2)(t);
                    A[j, k] = a2(j) * tau[k][j] +
                        a1(j) * tau_1[k + 1][j] + a0(j) * tau_2[k + 2][j];
                }
                B[j] = f(j) - a1(j) * y1 - a0(j) * (y0 + y1 * j);
            }
        }

        /*public Func<double, double> Solve(double[] nodes, int n)
        {
            double[,] A;
            double[] B;
            ConstructMatrix(nodes.Length, n, out A, out B);
            var yk = mathlib.LinearSystem.Solve(A, B);
            return MakeFromCoeffs(y0, y1, yk);
        }*/
        public double[] Solve(int N, int n)
        {
            double[,] A;
            double[] B;
            ConstructMatrix(N, n, out A, out B);
            var yk = mathlib.LinearSystem.Solve(A, B);
            return MakeFromCoeffs(y0, y1, yk, N);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coeffs"></param>
        /// <returns></returns>
        /*private static Func<double, double> MakeFromCoeffs(double y0, double y1, double[] coeffs)
        {
            var n = coeffs.Length;
            var haar2 = new Func<double, double>[n];
            for (int k = 0; k < n; k++) 
            {
                haar2[k] = Function.MixedHaar2(2, k + 1 + 2);
            }

            return t =>
                y0 + y1 * t + coeffs.Select((yk, k) => yk * haar2[k](t)).Sum();
        }*/
        private static double[] MakeFromCoeffs(double y0, double y1, double[] coeffs, int N)
        {
            int n= coeffs.Length;

            double[][] tau_2 = new double[n+3][];
            for (int k = 0; k <= n + 2; k++) {
                tau_2[k] = tau2(2, k, N);
            }


            double[] res = new double[N];
            for (int j = 0; j < N; j++) {
                res[j] = 0.0;
                for (int k = 0; k < n; k++) {
			       res[j] +=  y0 + y1 * j + coeffs[k] * tau_2[k + 2][j];
			    }
            }
            return res;

        }
    }
}