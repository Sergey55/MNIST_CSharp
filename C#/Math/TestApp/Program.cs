namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new double[,]
            {
                {1, 1}, 
                {1, 1}
            };

            var m = new Math.Numeric.Double.Matrix(data);

            var r = m + m;
        }
    }
}
