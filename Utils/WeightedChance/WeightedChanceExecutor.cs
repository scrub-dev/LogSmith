using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logsmith.Utils.WeightedChance
{
    public class WeightedChanceExecutor()
    {
        public static void Execute(List<WeightedChanceParameter> parameters)
        {
            double numericValue = new Random().NextDouble() * parameters.Sum(p => p.Ratio);

            foreach (WeightedChanceParameter parameter in parameters)
            {
                numericValue -= parameter.Ratio;

                if (!(numericValue <= 0))
                    continue;

                parameter.Func();
                return;
            }

        }
    }
}
