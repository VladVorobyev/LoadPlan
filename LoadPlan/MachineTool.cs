using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadPlan
{
    class MachineTool
    {
        int _id;
        string _name;
        //Conditions _condition=Conditions.Unused;
        int _time;
        /*public enum Conditions
        {
            Used,
            Unused
        }*/
        public string Name {
            get => _name;
            set => _name = value;
        }
        public int Id {
            get => _id;
            set => _id = value;
        }
        /*public Conditions Condition {
            get => _condition;
            set => _condition = value;
        }*/
        public int Time {
            get => _time;
            set => _time = value;
        }
    }
}
