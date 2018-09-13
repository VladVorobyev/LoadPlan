using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadPlan
{
    class Nomenclature
    {
        int _id;
        string _nomenclature;
        public int Id {
            get => _id;
            set => _id = value;
        }
        public string NomenclatureName {
            get => _nomenclature;
            set => _nomenclature = value;
        }
    }
}
