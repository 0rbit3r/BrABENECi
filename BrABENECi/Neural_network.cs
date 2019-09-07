using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrABENECi
{
    class Neural_network
    {
        public double[,] first_layer;//Pokud to bude pomalý, zkus int a převody
        public double[,] second_layer;
        public int first_level_size;
        public int sec_level_size = 6;
        public int third_level_size;
        public double[] output;

        public Neural_network(char[] genome, int sensor_num, int out_num, int offset)
        {
            first_level_size = sensor_num;
            third_level_size = out_num;
            output = new double[third_level_size];
            int k = offset;
            first_layer = new double[first_level_size + 1, sec_level_size];
            for (int i = 0; i < first_level_size + 1; i++)
            {
                for (int j = 0; j < sec_level_size; j++)
                {
                    first_layer[i,j] = (Convert.ToInt32(Convert.ToString(genome[k]) + Convert.ToString(genome[k+1])) - 50 ) / 25.0;
                    k += 2;
                }
            }
            second_layer = new double[sec_level_size + 1, third_level_size];
            for (int i = 0; i < sec_level_size + 1; i++)
            {
                for (int j = 0; j < third_level_size; j++)
                {
                    second_layer[i, j] = (Convert.ToInt32(Convert.ToString(genome[k]) + Convert.ToString(genome[k+1])) - 50 ) / 25.0;
                    k += 2;
                }
            }
        }

        public void Propagate(double[] input)
        {
            double[] sec_level = new double[sec_level_size];

            for (int i = 0; i < sec_level_size; i++)
            {
                double sum = 0;
                for (int j = 0; j < first_level_size; j++)
                {
                    sum += first_layer[j, i] * input[j];
                }
                sum += first_layer[first_level_size, i] * 1;//Bias
                sec_level[i] = 1.0 / (1.0 + Math.Exp(-sum));
            }
            for (int i = 0; i < third_level_size; i++)
            {
                double sum = 0;
                for (int j = 0; j < sec_level_size; j++)
                {
                    sum += second_layer[j, i] * sec_level[j];
                }
                sum += second_layer[sec_level_size, i] * 1;//Bias
                output[i] = Activation_function(sum);
            }
        }

        double Activation_function(double sum)
        {
            return (Math.Exp(sum) - Math.Exp(-sum)) / (Math.Exp(sum) + Math.Exp(-sum));
        }
    }
}
