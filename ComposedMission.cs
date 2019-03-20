using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        public event EventHandler<double> OnCalculate;  // An Event of when a mission is activated

        public event Op operations;

        public ComposedMission(string name) {
            this.Name = name;
            this.Type = "Composed";
        }
        
        public ComposedMission Add(Op newOp)
        {
            operations += newOp;
            return this;
        }
        public String Name { get; }
        public String Type { get; }

        public double Calculate(double value)
        {
            double ans = value;
            var operationList = operations.GetInvocationList();
            foreach (Op op in operationList)
            {
                ans = op(ans);
            }
            OnCalculate?.Invoke(this, ans);
            return ans;
        }
    }
}
