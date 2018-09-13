using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadPlan
{
    class ExcelFileService
    {
        public void Save(string filename, List<Operation> operationsList)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Лист1");
            worksheet.Cell("A" + 1).Value = "Расписание";
            worksheet.Cell("A" + 2).Value = "Id партии";
            worksheet.Cell("B" + 2).Value = "Номенклатура";
            worksheet.Cell("C" + 2).Value = "Оборудование";
            worksheet.Cell("D" + 2).Value = "Начальное время";
            worksheet.Cell("E" + 2).Value = "Конечное время";
            worksheet.Cell(3, 1).Value = operationsList.AsEnumerable();
            var rngTable = worksheet.Range("A1:E1");
            worksheet.Cell(1, 1).Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            rngTable.Merge();
            worksheet.Columns().AdjustToContents();
            workbook.SaveAs(filename);       
        }
    }
}
