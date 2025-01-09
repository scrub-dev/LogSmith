using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logsmith.Utils.WeightedChance
{
    public class WeightedChanceParameter(Action func, double ratio)
    {
        public Action Func { get; } = func;
        public double Ratio { get; } = ratio;
    }
}
