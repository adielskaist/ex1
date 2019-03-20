using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public delegate double Op(double x);
    public class FunctionsContainer
    {
        Dictionary<string, Op> function;

        public FunctionsContainer()
        {
            function = new Dictionary<string, Op>();
        }

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
        public List<string> getAllMissions()
        {
            return new List<string>(function.Keys);
        }

    }
}
