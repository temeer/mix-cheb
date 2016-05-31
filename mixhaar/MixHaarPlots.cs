using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscreteFunctions;
using DiscreteFunctionsPlots;
using GraphBuilders;
using mixhaar.Functions;

namespace mixhaar
{
    public partial class MixHaarPlots : GraphBuilder2DForm
    {
        Plot2D plotTcheb = new Plot2D("Haar");
        Plot2D plotMix = new Plot2D("Mixed from Haar");

        public MixHaarPlots() : base(2)
        {
            InitializeComponent();
            Height = Height + 1;
            GetGraphBuilder(0).DrawPlot(plotTcheb);
            GetGraphBuilder(1).DrawPlot(plotMix);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //
        }

        void Draw(int r, int n)
        {
            int N = 1000;
            double[] x = Function.uniformGrid(-1, 1, N);
            double[] y0 = Function.Tchebs(n, x)[n];
            double[] y1 = Function.MixTcheb(n, N);

            if (n - r >= 1)
            {
                plotTcheb.DiscreteFunction = new DiscreteFunction2D(Functions.Function.Haar(n), 0, 1, N);
                //plotTcheb.DiscreteFunction = new DiscreteFunction2D(x=> Functions.Function.Tcheb(n, x), -1, 1, N);
                //plotTcheb.DiscreteFunction = new DiscreteFunction2D(x, y0);
                plotTcheb.Refresh();
            }
            plotMix.DiscreteFunction = new DiscreteFunction2D(Functions.Function.MixedHaar2(r, n), 0, 1, N);
            //plotMix.DiscreteFunction = new DiscreteFunction2D(x => Functions.Function.MixTcheb(n, x), -1, 1, N);
            //plotMix.DiscreteFunction = new DiscreteFunction2D(x, y1);
            plotMix.Refresh();

            //Console.WriteLine(Function.Tcheb(n, -1));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Draw((int)nupR.Value, (int)nupN.Value);
        }

        private void nupN_ValueChanged(object sender, EventArgs e)
        {
            Draw((int)nupR.Value, (int)nupN.Value);
        }

    }
}
