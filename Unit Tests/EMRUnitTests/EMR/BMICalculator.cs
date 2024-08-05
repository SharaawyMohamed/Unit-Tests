using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR
{
    public class BMICalculator
    {
        public double BMICalculate(double heightInMeters,double WeightInKilos)
        {
            if (heightInMeters == 0) return 0;
            return WeightInKilos/(heightInMeters * heightInMeters);
        }
    }
}
