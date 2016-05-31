using System;
using mixhaar;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class DiffEqSolverTests
    {
        [Test]
        public void ConstructMatrixTest()
        {
            // Arrange
            var a = 3;
            var b = 2;
            Func<double, double> f = t => 6 * t * t * t + 25 * t * t + 12 * t - 2;

            var solver = new DiffEqSolver(x => 1, x => a, x => b, f, 0, 0);

            int n = 3;
            double[] nodes = { 0, 0.5, 1 };

            double[,] A;
            double[] B;

            // Act
            solver.ConstructMatrix(nodes, n, out A, out B);


            // Assert
            Assert.AreEqual(nodes.Length, A.GetLength(0));
            Assert.AreEqual(n, A.GetLength(1));
            Assert.AreEqual(nodes.Length, B.Length);

            Assert.AreEqual(new[] { f(0), f(0.5), f(1) }, B);
        }
    }
}
