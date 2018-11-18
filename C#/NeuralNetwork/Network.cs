using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Math.Numeric.Double;

namespace NeuralNetwork
{
    public class Network
    {
        private int inputNodes;
        private int hiddenNodes;
        private int outputNodes;

        private double learningRate;

        private Matrix wihMatrix;
        private Matrix whoMatrix;

        public Network(int inputNodes, int hiddenNodes, int outputNodes, double learningRate)
        {
            this.inputNodes = inputNodes;
            this.hiddenNodes = hiddenNodes;
            this.outputNodes = outputNodes;

            this.learningRate = learningRate;

            Init();
        }

        private void Init()
        {
            wihMatrix = new Matrix(hiddenNodes, inputNodes);
            whoMatrix = new Matrix(outputNodes, hiddenNodes);

            GenerateRandomWeights(ref wihMatrix);
            GenerateRandomWeights(ref whoMatrix);
        }

        public void Train()
        {
            //TODO:
        }

        public void Query(double[] inputData)
        {
            if (inputData.Length != inputNodes)
                throw new ArgumentException("Unexpected size of inbound array");

            var
            //TODO:
        }

        private void GenerateRandomWeights(ref Matrix matrix)
        {
            var rnd = new Random();

            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    matrix[i, j] = rnd.NextDouble() - 0.5;
                }
            }
        }
    }
}
