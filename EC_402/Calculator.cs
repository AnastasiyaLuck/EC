using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EC402
{
    public class Calculator
    {
        double res = 0;
        float maxRegionInsolation = 0;
        float greenCost;
        float maxConsumption;
        int regionIndex;
        float exchangeRateDollar;
        float averageConsumption;
        float exchangeRateEuro;
        float[] temp = new float[12];
        float[,] sunInsolation = new float[,] { {1.07f, 1.87f, 2.95f, 3.96f, 5.25f, 5.22f, 5.25f, 4.67f, 3.12f, 1.94f, 1.02f, 0.86f,},
                                                {1.02f, 1.77f, 2.83f, 3.91f, 5.05f, 5.08f, 4.94f, 4.55f, 3.01f, 1.83f, 1.05f, 0.79f,},
                                                {1.07f, 1.89f, 2.94f, 3.92f, 5.19f, 5.30f, 5.16f, 4.68f, 3.21f, 1.97f, 1.10f, 0.90f,},
                                                {1.21f, 1.99f, 2.98f, 4.05f, 5.55f, 5.57f, 5.70f, 5.08f, 3.66f, 2.27f, 1.20f, 0.96f,},
                                                {1.21f, 1.99f, 2.94f, 4.04f, 5.48f, 5.55f, 5.66f, 5.09f, 3.67f, 2.24f, 1.23f, 0.96f,},
                                                {1.01f, 1.82f, 2.87f, 3.88f, 5.16f, 5.19f, 5.04f, 4.66f, 3.06f, 1.87f, 1.04f, 0.83f,},
                                                {1.13f, 1.91f, 3.01f, 4.03f, 5.01f, 5.31f, 5.25f, 4.82f, 3.33f, 2.02f, 1.19f, 0.88f,},
                                                {1.21f, 2.00f, 2.91f, 4.20f, 5.62f, 5.72f, 5.88f, 5.18f, 3.87f, 2.44f, 1.25f, 0.95f,},
                                                {1.19f, 1.93f, 2.84f, 3.68f, 4.54f, 4.75f, 4.76f, 4.40f, 3.06f, 2.00f, 1.20f, 0.94f,},
                                                {1.07f, 1.87f, 2.95f, 3.96f, 5.25f, 5.22f, 5.25f, 4.67f, 3.12f, 1.94f, 1.02f, 0.86f,},
                                                {1.20f, 1.95f, 2.96f, 4.07f, 5.47f, 5.49f, 5.57f, 4.92f, 3.57f, 2.24f, 1.14f, 0.96f,},
                                                {1.23f, 2.06f, 3.05f, 4.05f, 5.46f, 5.57f, 5.65f, 4.99f, 3.62f, 2.23f, 1.26f, 0.93f,},
                                                {1.08f, 1.83f, 2.82f, 3.78f, 4.67f, 4.83f, 4.83f, 4.45f, 3.00f, 1.85f, 1.06f, 0.83f,},
                                                {1.25f, 2.10f, 3.07f, 4.38f, 5.65f, 5.85f, 6.03f, 5.34f, 3.93f, 2.52f, 1.36f, 1.04f,},
                                                {1.25f, 2.11f, 3.08f, 4.38f, 5.65f, 5.85f, 6.04f, 5.33f, 3.93f, 2.52f, 1.36f, 1.04f,},
                                                {1.18f, 1.96f, 3.05f, 4.00f, 5.40f, 5.44f, 5.51f, 4.87f, 3.42f, 2.11f, 1.15f, 0.91f,},
                                                {1.01f, 1.81f, 2.83f, 3.87f, 5.08f, 5.17f, 4.98f, 4.58f, 3.02f, 1.87f, 1.04f, 0.81f,},
                                                {1.13f, 1.93f, 3.05f, 3.98f, 5.27f, 5.32f, 5.38f, 4.67f, 3.19f, 1.98f, 1.10f, 0.86f,},
                                                {1.09f, 1.86f, 2.85f, 3.85f, 4.84f, 5.00f, 4.93f, 4.51f, 3.08f, 1.91f, 1.09f, 0.85f,},
                                                {1.19f, 2.02f, 3.05f, 3.92f, 5.38f, 5.46f, 5.56f, 4.88f, 3.49f, 2.10f, 1.19f, 0.90f,},
                                                {1.30f, 2.13f, 3.08f, 4.36f, 5.68f, 5.76f, 6.00f, 5.29f, 4.00f, 2.57f, 1.36f, 1.04f,},
                                                {1.09f, 1.86f, 2.87f, 3.85f, 5.08f, 5.21f, 5.04f, 4.58f, 3.14f, 1.98f, 1.10f, 0.87f,},
                                                {1.15f, 1.91f, 2.94f, 3.99f, 5.44f, 5.46f, 5.54f, 4.87f, 3.40f, 2.13f, 1.09f, 0.91f,},
                                                {0.99f, 1.80f, 2.92f, 3.96f, 5.17f, 5.19f, 5.12f, 4.54f, 3.00f, 1.86f, 0.98f, 0.75f,},
                                                {1.19f, 1.93f, 2.84f, 3.68f, 4.54f, 4.75f, 4.76f, 4.40f, 3.06f, 2.00f, 1.20f, 0.94f,}};
        public void Create(int regionIndex, float exchangeRateDollar, float exchangeRateEuro, float maxConsumption, float averageConsumption = 200)
        {
            this.regionIndex = regionIndex;
            this.exchangeRateDollar = exchangeRateDollar;
            this.exchangeRateEuro = exchangeRateEuro;
            this.maxConsumption = maxConsumption;
            this.averageConsumption = averageConsumption;
        }
        public void Create(int regionIndex, float exchangeRateDollar, float exchangeRateEuro, int numberOfPeople)
        {
            this.regionIndex = regionIndex;
            this.exchangeRateDollar = exchangeRateDollar;
            this.exchangeRateEuro = exchangeRateEuro;
            this.maxConsumption = 115 * numberOfPeople;
            this.averageConsumption = 30 * numberOfPeople;
        }
        public void Create(int regionIndex, float exchangeRateDollar, float exchangeRateEuro, long numberOfRooms)
        {
            this.regionIndex = regionIndex;
            this.exchangeRateDollar = exchangeRateDollar;
            this.exchangeRateEuro = exchangeRateEuro;
            this.maxConsumption = 90 * numberOfRooms;
            this.averageConsumption = 50 * numberOfRooms;
        }
        public double Calc()
        {
            res = 0;
            CalcCreatedElecticity();
            CalcGreenCost();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] -= averageConsumption;
                if (temp[i] > 0)
                {
                    temp[i] *= greenCost;
                    res += temp[i];
                }
            }
            res = GetCost() / res;
            return res;
        }
        private void CalcCreatedElecticity()
        {
            GetMaxValue();
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = (sunInsolation[(int)regionIndex, i] / maxRegionInsolation) * maxConsumption;
            }
        }
        private void GetMaxValue()
        {
            maxRegionInsolation = sunInsolation[regionIndex, 0];
            for (int i = 0; i < 12; i++)
            {
                if (maxRegionInsolation < sunInsolation[regionIndex, i])
                {
                    maxRegionInsolation = sunInsolation[regionIndex, i];
                }
            }
        }
        private float GetCost()
        {
            return 4420.6f * exchangeRateDollar;
        }
        private void CalcGreenCost()
        {
            greenCost = 18 * exchangeRateEuro / 100;
        }
    }
}
