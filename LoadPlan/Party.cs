using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadPlan
{
    class Party
    {
        int _id;
        int _nomenclatureId;
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public int NomenclatureId
        {
            get => _nomenclatureId;
            set => _nomenclatureId = value;
        }
    }
}
