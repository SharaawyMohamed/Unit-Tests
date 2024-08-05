using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondVersionOfTesting.Tests
{

    public class FakeWeightRepository : IDataRepository
    {
        IEnumerable<WeightCalculator> Weights;
        public FakeWeightRepository()
        {

            Weights = new List<WeightCalculator>()
            {
                new WeightCalculator() { Gender = 'M', Height = 180 },
                new WeightCalculator() { Gender = 'F', Height = 170 },
                new WeightCalculator() { Gender = 'F', Height = 1650 },
                new WeightCalculator() { Gender = 'M', Height = 185 },
            };
        }
        public IEnumerable<WeightCalculator> GetWeightsToCalculate()
        {
            return Weights.ToList();
        }
    }
}
