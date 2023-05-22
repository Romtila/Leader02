using System.Globalization;
using Leader.Domain.Entity;
using Leader02.Infrastructure;
using OfficeOpenXml;

namespace Leader02.DataSetsParser.Parsers;

public class LegalActParser
{
    private readonly Leader02Context _context;

    public LegalActParser(Leader02Context context)
    {
        _context = context;
    }

    public void LegalActParsing(string fileName)
    {
        var subDepartments = _context.SubDepartments.ToList();

        var existingFile = new FileInfo(fileName);

        using var package = new ExcelPackage(existingFile);
        var legalActs = new List<LegalAct>(420);

        var worksheet = package.Workbook.Worksheets[0];
        for (var i = 3; i < worksheet.Dimension.Rows; i++)
        {
            DateTime.TryParseExact(worksheet.Cells[i, 6].Value.ToString().Replace(".", string.Empty).Substring(0, 8), 
                "ddMMyyyy", CultureInfo.GetCultureInfo("ru-RU"), DateTimeStyles.None, out var documentDate);
            DateTime.TryParseExact(worksheet.Cells[i, 7].Value.ToString().Replace(".", string.Empty).Substring(0, 8), 
                "ddMMyyyy", CultureInfo.GetCultureInfo("ru-RU"), DateTimeStyles.None, out var publishDate);

            var legalAct = new LegalAct
            {
                Name = worksheet.Cells[i, 1].Value.ToString() ?? "", 
                DocumentDate = documentDate, 
                PublishDate = publishDate, 
                LegalActType = worksheet.Cells[i, 5].Value.ToString() ?? "", 
                LegalActUrl = "",
            };

            if (worksheet.Cells[i, 4].Value != null)
            {
                var searchingDepartment = worksheet.Cells[i, 4].Value.ToString().ToLower().TrimEnd(' ');
                var subDepartment = subDepartments.FirstOrDefault(x => 
                    x.Name.ToLower().Contains(searchingDepartment) ||
                    x.Name.ToLower() == searchingDepartment);
                
                if (subDepartment != null)
                {
                    legalAct.SubDepartment = subDepartment;
                    legalAct.Department = subDepartment.Department;
                }
            }

            if (legalAct.Department == null && worksheet.Cells[i, 3].Value != null)
            {
                var searchingDepartment = worksheet.Cells[i, 3].Value.ToString().ToLower().TrimEnd(' ');
                var department = subDepartments.FirstOrDefault(x => x.Department != null && (
                        x.Department.Name.ToLower().Contains(searchingDepartment) ||
                        x.Department.Name.ToLower() == searchingDepartment ||
                        x.Department.Abbreviation.ToLower().Contains(searchingDepartment) ||
                        x.Department.Abbreviation.ToLower() == searchingDepartment));
                if (department != null)
                {
                    legalAct.Department = department.Department;
                }
            }

            legalActs.Add(legalAct);
        }

        _context.LegalActs.AddRange(legalActs);
        _context.SaveChanges();
    }
}