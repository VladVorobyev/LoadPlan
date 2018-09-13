using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Excel = Microsoft.Office.Interop.Excel;
using ClosedXML.Excel;
using System.IO;
using System.Reflection;
using Microsoft.Win32;
using System.Windows;

namespace LoadPlan
{
    class TimeTableModel
    {
        public ObservableCollection<Operation> OperationCollection { get; }
        List<Nomenclature> _nomenclatures = new List<Nomenclature>();
        List<Party> _parties=new List<Party>();
        List<MachineTool> _machineTools=new List<MachineTool>();
        List<Time> _times=new List<Time>();
        public TimeTableModel()
        {
            OperationCollection= new ObservableCollection<Operation>();
            SetData();
            GetOperationCollection();
        }  
        void SetData()
        {
            LoadFromExcel("parties.xlsx");
            LoadFromExcel("nomenclatures.xlsx");
            LoadFromExcel("machine_tools.xlsx");
            LoadFromExcel("times.xlsx");
        }       
        void LoadFromExcel(string fileName)
        {
            var excelDirectory = @"..\..\Excel\";
            try
            {
                using (var workbook = new XLWorkbook(excelDirectory + fileName))
                // Берем в ней первый лист
                using (var worksheet = workbook.Worksheets.Worksheet(1))
                {// Перебираем диапазон нужных строк
                    foreach (var row in worksheet.RowsUsed())
                    {
                        if (row == worksheet.FirstRow()) { continue; }
                        switch (fileName)
                        {
                            case "parties.xlsx":
                                _parties.Add(GetParty(row));
                                break;
                            case "nomenclatures.xlsx":
                                _nomenclatures.Add(GetNomenclature(row));
                                break;
                            case "machine_tools.xlsx":
                                _machineTools.Add(GetMachineTool(row));
                                break;
                            case "times.xlsx":
                                _times.Add(GetTime(row));
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Party GetParty(IXLRow row)
        {
            Party party = new Party
            {
                Id = row.Cell(1).GetValue<int>(),
                NomenclatureId = row.Cell(2).GetValue<int>()
            };
            return party;
        }
        MachineTool GetMachineTool(IXLRow row)
        {
            MachineTool tool = new MachineTool
            {
                Id = row.Cell(1).GetValue<int>(),
                Name = row.Cell(2).GetValue<string>()
            };
            return tool;
        }
        Time GetTime(IXLRow row)
        {
            Time time = new Time
            {
                MachineToolId = row.Cell(1).GetValue<int>(),
                NomenclatureId= row.Cell(2).GetValue<int>(),
                OperationTime= row.Cell(3).GetValue<int>()
            };
            return time;
        }
        Nomenclature GetNomenclature(IXLRow row)
        {
            Nomenclature nomenclature = new Nomenclature
            {
                Id = row.Cell(1).GetValue<int>(),
                NomenclatureName = row.Cell(2).GetValue<string>()
            };
            return nomenclature;
        }
        void GetOperationCollection()
        {
            foreach (Party party in _parties)
            {               
                OperationCollection.Add(GetOperation(party));
            }
        }
        Operation GetOperation(Party party)
        {
            Operation operation=new Operation            
            {
                PartyId = party.Id,
                NomenclatureName = _nomenclatures.Find(x => x.Id == party.NomenclatureId).NomenclatureName
            };
            List<Time> times = _times.FindAll(x => x.NomenclatureId == party.NomenclatureId);
            Time time=Time.FindMinTime(times,_machineTools);
            MachineTool tool = _machineTools.Find(x => x.Id == time.MachineToolId);
            operation.MachineToolName = tool.Name;
            operation.StartTime =tool.Time;
            tool.Time +=time.OperationTime;
            operation.EndTime = tool.Time;
            return operation;
        }
    }
}
