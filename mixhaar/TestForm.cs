using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscreteFunctionsPlots;


namespace mixhaar
{
    public partial class TestForm : GraphBuilders.GraphBuilder2DForm
    {
        Plot2D plot = new Plot2D();
        Plot2D plot2 = new Plot2D();
        public TestForm()
        {
            InitializeComponent();
            GraphBuilder.DrawPlot(plot);
            GraphBuilder.DrawPlot(plot2);


            Func<double, double> f = x => x * Math.Sin(x);

        }
    }
}
