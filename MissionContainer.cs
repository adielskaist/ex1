using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    /// <summary>
    /// A function delegation
    /// </summary>
    /// <param name="x">A double</param>
    /// <returns>A double</returns>
    public delegate double Op(double x);
    public class FunctionsContainer
    {
        Dictionary<string, Op> function;  // Functions dictionary

        /// <summary>
        /// A constructor, initializing the functions dictionary.
        /// </summary>
        public FunctionsContainer()
        {
            function = new Dictionary<string, Op>();
        }

        /// <summary>
        /// An indexer.
        /// Making use of the [] operator. adding and returning functions to the
        /// dictionary using a string as a key.
        /// </summary>
        /// <param name="s">A key</param>
        /// <returns>A simple function</returns>
        public Op this[string s] {
            set
            {
                function[s] = value;
            }
            get
            {
                if (!function.ContainsKey(s))
                {
                    function[s] = val => val;
                }
                return function[s];
            }
        }

        /// <summary>
        /// getAllMissions.
        /// </summary>
        /// <returns>A list with names of all the functions</returns>
        public List<string> getAllMissions()
        {
            return new List<string>(function.Keys);
        }

    }
}
