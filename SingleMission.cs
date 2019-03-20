using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{

    /// <summary>
    /// A simple mission with only one function.
    /// </summary>
    public class SingleMission : IMission
    {
        private Op myOp;  // The function that will be preformed.

        public event EventHandler<double> OnCalculate;  // An Event of when a mission is activated

        /// <summary>
        /// A constructor. initializing the mission name and function.
        /// </summary>
        /// <param name="myOp">Mission's name</param>
        /// <param name="name">Mission's function</param>
        public SingleMission(Op myOp, string name)
        {
            this.Name = name;
            this.Type = "Single";
            this.myOp = myOp;
        }

        /// <summary>
        /// Mission name getter.
        /// </summary>
        public String Name { get; }

        /// <summary>
        /// Mission type getter.
        /// </summary>
        public String Type { get; }

        /// <summary>
        /// Calculate.
        /// Calculating the result.
        /// </summary>
        /// <param name="value">A double</param>
        /// <returns>A double</returns>
        public double Calculate(double value)
        {
            double ans = myOp(value);
            OnCalculate?.Invoke(this, ans);
            return ans;
        }
    }
}
