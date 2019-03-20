using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    /// <summary>
    /// A complex mission composed out of number of functions.
    /// </summary>
    public class ComposedMission : IMission
    {
        public event EventHandler<double> OnCalculate;  // An Event of when a mission is activated

        public event Op operations;  // All operations to be done in this mission
       
        /// <summary>
        /// A constructor
        /// </summary>
        /// <param name="name">The mission's name</param>
        public ComposedMission(string name) {
            this.Name = name;
            this.Type = "Composed";
        }
        
        /// <summary>
        /// Add.
        /// Adding an operation to the mission using builder design pattern.
        /// </summary>
        /// <param name="newOp">The new operation</param>
        /// <returns>This mission</returns>
        public ComposedMission Add(Op newOp)
        {
            operations += newOp;
            return this;
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
        /// Calculate
        /// Calculating the result using the delegated functions.
        /// </summary>
        /// <param name="value">A double to calculate</param>
        /// <returns>A calculated value</returns>
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
