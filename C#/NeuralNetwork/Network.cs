using System;

using Math.Numeric.Double;

namespace NeuralNetwork
{
    public class Network
    {
        private readonly int _inputNodes;
        private readonly int _hiddenNodes;
        private readonly int _outputNodes;

        private double _learningRate;

        private Matrix _wihMatrix;
        private Matrix _whoMatrix;

        private readonly Func<double, double> _af = (v) => (1 / (1 + System.Math.Pow(System.Math.E, v)));

        public Network(int inputNodes, int hiddenNodes, int outputNodes, double learningRate)
        {
            this._inputNodes = inputNodes;
            this._hiddenNodes = hiddenNodes;
            this._outputNodes = outputNodes;

            this._learningRate = learningRate;

            Init();
        }

        private void Init()
        {
            _wihMatrix = new Matrix(_hiddenNodes, _inputNodes);
            _whoMatrix = new Matrix(_outputNodes, _hiddenNodes);

            GenerateRandomWeights(ref _wihMatrix);
            GenerateRandomWeights(ref _whoMatrix);
        }

        public void Train(Matrix inputs, Matrix expectedOutputs)
        {
            var outputs = QueryInternal(inputs);

            var errors = expectedOutputs - outputs;
            //TODO:
        }

        public Matrix Query(Matrix inputs)
        {
            if (inputs.ColumnCount != 1 || inputs.RowCount != _inputNodes)
                throw new ArgumentException("Unexpected size of inbound array");

            var outputs = QueryInternal(inputs);

            return outputs;
        }

        private Matrix QueryInternal(Matrix inputs)
        {
            var hiddenOutputs = ApplyActivationFunction((Matrix)(_wihMatrix * inputs));
            var outputs = ApplyActivationFunction((Matrix)(_whoMatrix * hiddenOutputs));

            return outputs;
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

        private Matrix ApplyActivationFunction(Matrix matrix)
        {
            var result = new Matrix(matrix.RowCount, matrix.ColumnCount);

            for (int i = 0; i < matrix.RowCount; i++)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    result[i, j] = _af(matrix[i, j]);
                }
            }

            return result;
        }
    }
}
