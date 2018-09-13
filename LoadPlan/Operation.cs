using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadPlan
{
    class Operation
    {
        int _partyId;
        string _nomenclatureName;
        string _machineToolName;
        int _startTime;
        int _endTime;

        public int PartyId {
            get => _partyId;
            set => _partyId = value;
        }
        public string NomenclatureName {
            get => _nomenclatureName;
            set => _nomenclatureName = value;
        }
        public string MachineToolName {
            get => _machineToolName;
            set => _machineToolName = value;
        }
        public int StartTime {
            get => _startTime;
            set => _startTime = value;
        }
        public int EndTime {
            get => _endTime;
            set => _endTime = value;
        }
    }
}
