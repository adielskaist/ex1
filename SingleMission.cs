using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        private Op myOp;
        public SingleMission(Op myOp, string name)
        {
            this.Name = name;
            this.Type = "Single";
            this.myOp = myOp;
        }
        public event EventHandler<double> OnCalculate;  // An Event of when a mission is activated

        public String Name { get; }
        public String Type { get; }

        public double Calculate(double value)
        {
            double ans = myOp(value);
            OnCalculate?.Invoke(this, ans);
            return ans;
        }
    }
}
