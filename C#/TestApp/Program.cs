using System;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Math.Numeric.Double;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var nn = new NeuralNetwork.Network(784, 200, 10, 0.2);

            TrainNetwork(ref nn);

            TestNetwork(ref nn);

            Console.WriteLine("\nDone!\nPress Enter to exit");
            Console.ReadLine();
        }

        private static void TrainNetwork(ref NeuralNetwork.Network network) {
            var fileName = ConfigurationManager.AppSettings["trainData"];

            Stopwatch sw = Stopwatch.StartNew();

            Console.WriteLine("Training Neural Network.");

            WithFile(fileName, network, (parts, nn) => {
                var inputs = GetInputs(parts);

                var targets = GetTargets(parts[0]);

                nn.Train(inputs, targets);
            });

            sw.Stop();

            Console.WriteLine("Training is finished!\n");
            Console.WriteLine("Training took {0:0.000} ms", sw.ElapsedMilliseconds);
        }

        private static void TestNetwork(ref NeuralNetwork.Network network) {
            var fileName = ConfigurationManager.AppSettings["testData"];

            Console.WriteLine("\nTesting Neural Network.");

            Stopwatch sw = Stopwatch.StartNew();

            List<short> results = new List<short>();

            var counter = 0;

            WithFile(fileName, network, (parts, nn) =>
            {
                var expectedValue = parts[0];

                var inputs = GetInputs(parts);

                var result = nn.Query(inputs).MaxValueIndex();

                results.Add((short)((expectedValue == result) ? 1 : 0));

                counter++;
            });

            sw.Stop();

            Console.WriteLine("Testing is finished!\n");

            Console.WriteLine("Testing took {0:0.000} ms", sw.ElapsedMilliseconds);

            var foregroundColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\nSuccess rate is {0:0.000}%", (double)results.Sum(v => v) / counter);
            Console.ForegroundColor = foregroundColor;
        }

        private static void WithFile(string fileName, NeuralNetwork.Network network, Action<List<Int32>, NeuralNetwork.Network> action)
        {
            using (var file = File.OpenRead(fileName))
            {
                using (var streamReader = new StreamReader(file))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();

                        var parts = line.Split(',').Select(v => int.Parse(v)).ToList();

                        action(parts, network);
                    }
                }
            }
        }

        private static Matrix GetInputs(List<Int32> parts) {
            var inputData = new double[784, 1];

            for (int i = 1; i < 784; i++)
            {
                inputData[i, 0] = parts[i] / 255.0 * 0.99 + 0.01;
            }

            return new Matrix(inputData);
        }

        private static Matrix GetTargets(Int32 value)
        {
            var targetData = new double[10, 1];
            targetData[value, 0] = 0.99;

            return new Matrix(targetData);
        }
    }
}
