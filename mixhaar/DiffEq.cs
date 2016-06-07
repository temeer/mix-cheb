using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DiscreteFunctions;
using DiscreteFunctionsPlots;
using System.Linq;

namespace mixhaar
{
    public partial class DiffEq : GraphBuilders.GraphBuilder2DForm
    {
        private DiffEqSolver solver;
        Plot2D plotExact = new Plot2D("Exact");
        Plot2D plotNum = new Plot2D("Numerical");
        private double SegmentStart = 0;
        private double SegmentEnd = 99;



        public DiffEq()
        {
            InitializeComponent();
            GraphBuilder.DrawPlot(plotExact);
            GraphBuilder.DrawPlot(plotNum);
            Init();
        }


        public void Init()
        {
            Func<double, double> a2, a1, a0, f, exactSolution;
            double y0, y1;
            Example5(out a2, out a1, out a0, out f, out exactSolution, out y0, out y1);

            plotExact.DiscreteFunction = new DiscreteFunction2D(exactSolution, SegmentStart, SegmentEnd, 1000);
            plotExact.Refresh();
            solver = new DiffEqSolver(a2, a1, a0, f, 0, 0);
        }

        public void Example1(out Func<double, double> a2, out Func<double, double> a1, out Func<double, double> a0,
            out Func<double, double> f, out Func<double, double> exactSolution, out double y0, out double y1)
        {
            a2 = x => 1;
            a1 = x => 1;
            a0 = x => 2;
            f = t => 1 + t + t * t;
            exactSolution = t => t * t / 2;
            y0 = y1 = 0;
        }

        public void Example2(out Func<double, double> a2, out Func<double, double> a1, out Func<double, double> a0,
            out Func<double, double> f, out Func<double, double> exactSolution, out double y0, out double y1)
        {
            a2 = t => 1;
            a1 = t => t;
            a0 = t => 1 - t;
            f = t => 2 + 3 * t * t - t * t * t;
            exactSolution = t => t * t;
            y0 = y1 = 0;
        }

        public void Example3(out Func<double, double> a2, out Func<double, double> a1, out Func<double, double> a0,
            out Func<double, double> f, out Func<double, double> exactSolution, out double y0, out double y1)
        {
            a2 = t => 1;
            a1 = t => Math.Sqrt(t);
            a0 = t => Math.Sin(t);
            f = t => 6 * t + Math.Pow(t, 3) * Math.Sin(t) + 3 * Math.Pow(t, 2.5);
            exactSolution = t => t * t * t;
            y0 = y1 = 0;
        }

        public void Example4(out Func<double, double> a2, out Func<double, double> a1, out Func<double, double> a0,
            out Func<double, double> f, out Func<double, double> exactSolution, out double y0, out double y1)
        {
            a2 = t => 1;
            a1 = t => Math.Sqrt(t);
            a0 = t => Math.Sin(t);
            f = t => 6 * t + Math.Pow(t, 3) * Math.Sin(t) + 3 * Math.Pow(t, 2.5);
            exactSolution = t => t * t * t;
            y0 = y1 = 0;
        }
        public void Example5(out Func<double, double> a2, out Func<double, double> a1, out Func<double, double> a0,
        out Func<double, double> f, out Func<double, double> exactSolution, out double y0, out double y1)
        {
            a2 = t => 6;
            a1 = t => 1;
            a0 = t => 3;
            f = t => -0.06 * Math.Sin(0.1 * t) + 0.1 * Math.Cos(0.1 * t) + 3 * Math.Sin(0.1 * t);
            exactSolution = t => Math.Sin(0.1 * t);
            y0 = y1 = 0;
        }

        /*public Func<double, double> Solve()
        {
            int nodesCount = (int)nupNodesCount.Value;
            int coeffsCount = (int)nupCoeffsCount.Value;

            var nodes = Enumerable.Range(0, nodesCount).Select(j => SegmentStart + j * (SegmentEnd - SegmentStart) / (nodesCount - 1)).ToArray();
            return solver.Solve(nodes, coeffsCount);
        }*/

        public double[] Solve()
        {
            int nodesCount = (int)nupNodesCount.Value;
            int coeffsCount = (int)nupCoeffsCount.Value;

            //var nodes = Enumerable.Range(0, nodesCount).Select(j => SegmentStart + j * (SegmentEnd - SegmentStart) / (nodesCount - 1)).ToArray();
            int N = 100;
            return solver.Solve(N, coeffsCount);
        }

        public void Draw()
        {
            var numSolution = Solve();
            int N = 100;
            //plotNum.DiscreteFunction = new DiscreteFunction2D(numSolution, SegmentStart, SegmentEnd, 1000);
            double[] x = new double[N];
            for (int i = 0; i < N; i++) {
                x[i] = i;
            }

            plotNum.DiscreteFunction = new DiscreteFunction2D(x, numSolution);

            plotNum.Refresh();
        }

        private void nupNodesCount_ValueChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}
