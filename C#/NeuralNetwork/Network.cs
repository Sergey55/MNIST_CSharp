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

            init();
        }

        private void init()
        {
            wihMatrix = new Matrix(hiddenNodes, inputNodes);
            whoMatrix = new Matrix(outputNodes, hiddenNodes);
        }

        public void Train()
        {
            //TODO:
        }

        public void Query()
        {
            //TODO:
        }
    }
}
