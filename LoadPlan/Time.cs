using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadPlan
{
    class Time
    {
        int _machineToolId;
        int _nomenclatureId;
        int _operationTime;
        public int MachineToolId {
            get => _machineToolId;
            set => _machineToolId = value;
        }
        public int NomenclatureId {
            get => _nomenclatureId;
            set => _nomenclatureId = value;
        }
        public int OperationTime {
            get => _operationTime;
            set => _operationTime = value;
        }
        public static Time FindMinTime(List<Time> times,List<MachineTool> machineTools)
        {
            Time found = times.First();
            MachineTool firstTool;
            MachineTool secondTool;
            foreach (Time time in times)
            {
                firstTool = machineTools.Find(x => x.Id == time.MachineToolId);
                secondTool = machineTools.Find(x => x.Id == found.MachineToolId);
                if (time.OperationTime+firstTool.Time < found.OperationTime+secondTool.Time)
                    found = time;
            }
            return found;
        }
    }
}
