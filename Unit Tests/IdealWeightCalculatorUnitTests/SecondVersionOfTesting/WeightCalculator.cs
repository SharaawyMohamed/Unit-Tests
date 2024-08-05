using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondVersionOfTesting
{
    public class WeightCalculator
    {
        public double Height { get; set; }
        public char Gender { get; set; }
        private readonly IDataRepository _repository;
        public WeightCalculator() { }
        public WeightCalculator(IDataRepository repository)
        {
            _repository = repository;
        }
        public double test()
        {
            if (Gender == 'M' || Gender == 'm') return (Height - 100) - (Height - 150) / 4;
            else if (Gender == 'F' || Gender == 'f') return (Height - 100) - (Height - 150) / 2;
            throw new ArgumentException("Gender Argument is not correct you can enter (M | F)");
        }
        public List<double> IdealWeights()
        {
            var res = new List<double>();
            var data = _repository.GetWeightsToCalculate();
            foreach (var i in data)
            {
                Gender = i.Gender;
                Height = i.Height;
                res.Add(test());
            }
            return res;
        }

        public bool ValidateGender()
        {
            return Gender switch
            {
                'M' => true,
                'm' => true,
                'F' => true,
                'f' => true,
                _ => false
            };
        }
    }
}
