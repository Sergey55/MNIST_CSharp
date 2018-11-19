namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var nn = new NeuralNetwork.Network(3, 3, 3, 0.1);

            var inputs = new Math.Numeric.Double.Matrix(new double[,]{ { 0.5 }, { 0.3 }, { 0.7 } });
            var targets = new Math.Numeric.Double.Matrix(new double[,] { { 0.01 }, { 0.99 }, { 0.01 } });

            nn.Train(inputs, targets);
        }
    }
}
