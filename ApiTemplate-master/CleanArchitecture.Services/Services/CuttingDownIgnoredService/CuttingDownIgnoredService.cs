using CleanArchitecture.DataAccess.IUnitOfWorks;
using CleanArchitecture.DataAccess.Models.Fact_models;
using CleanArchitecture.Services.DTOs.CuttingDownIgnoredAddDto;
using CleanArchitecture.Services.Interfaces.ICuttingDownIgnoredService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using System.IO;
using iTextSharp.text.pdf;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace CleanArchitecture.Services.Services.CuttingDownIgnoredService
{
    public class CuttingDownIgnoredService : ICuttingDownIgnoredService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CuttingDownIgnoredService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cutting_Down_Ignored> AddAsync(CuttingDownIgnoredAddDto dto)
        {
            var entity = new Cutting_Down_Ignored
            {
                ActualCreatetDate = dto.ActualCreatetDate,
                SynchCreateDate = dto.SynchCreateDate,
                Cabel_Name = dto.Cabel_Name,
                Cabin_Name = dto.Cabin_Name,
                CreatedUser = dto.CreatedUser
            };

            await _unitOfWork.Repository<Cutting_Down_Ignored>().AddAsync(entity);
            await _unitOfWork.SaveAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var record = await _unitOfWork.Repository<Cutting_Down_Ignored>().GetByIdAsync(id);
            if (record == null)
                return false;

            _unitOfWork.Repository<Cutting_Down_Ignored>().Remove(record);
            await _unitOfWork.SaveAsync();
            return true;
        }

        public async Task<IEnumerable<Cutting_Down_Ignored>> GetAllAsync(int pageNumber, int pageSize)
        {
            var all = await _unitOfWork.Repository<Cutting_Down_Ignored>().GetAllAsync();
            return all.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public async Task<IEnumerable<Cutting_Down_Ignored>> SearchAsync(string query)
        {
            var repository = _unitOfWork.Repository<Cutting_Down_Ignored>();

            bool isNumber = int.TryParse(query, out int numberQuery);

            return await repository.FindAsync(x =>
                (isNumber && (
                    x.Cutting_Down_Incident_ID == numberQuery ||
                    (x.Cabel_Name != null && x.Cabel_Name == query) ||
                    (x.Cabin_Name != null && x.Cabin_Name == query)
                ))
            );
        }





        public async Task<byte[]> ExportIgnoredToExcelAsync()
        {
            var data = await _unitOfWork.Repository<Cutting_Down_Ignored>().GetAllAsync();

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Ignored Incidents");

            // Headers
            worksheet.Cell(1, 1).Value = "Incident ID";
            worksheet.Cell(1, 2).Value = "Cable Name";
            worksheet.Cell(1, 3).Value = "Cabin Name";
            worksheet.Cell(1, 4).Value = "Created User";
            worksheet.Cell(1, 5).Value = "Created Date";
            worksheet.Cell(1, 6).Value = "Synch Date";

            int row = 2;
            foreach (var record in data)
            {
                worksheet.Cell(row, 1).Value = record.Cutting_Down_Incident_ID;
                worksheet.Cell(row, 2).Value = record.Cabel_Name;
                worksheet.Cell(row, 3).Value = record.Cabin_Name;
                worksheet.Cell(row, 4).Value = record.CreatedUser;
                worksheet.Cell(row, 5).Value = record.ActualCreatetDate;
                worksheet.Cell(row, 6).Value = record.SynchCreateDate;
                row++;
            }

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        public async Task<byte[]> ExportIgnoredToPdfAsync()
        {
            var data = await _unitOfWork.Repository<Cutting_Down_Ignored>().GetAllAsync();

            using var ms = new MemoryStream();
            var writer = new iText.Kernel.Pdf.PdfWriter(ms);
            var pdf = new iText.Kernel.Pdf.PdfDocument(writer);
            var document = new Document(pdf);

            // Title
            document.Add(new Paragraph("Cutting Down Ignored Records").SetTextAlignment(TextAlignment.CENTER).SetFontSize(18));

            // Create a table with the number of columns matching your properties
            Table table = new Table(5, true);

            // Add headers
            table.AddHeaderCell("Incident ID");
            table.AddHeaderCell("Cutting Down Key");
            table.AddHeaderCell("Actual Create Date");
            table.AddHeaderCell("Synch Create Date");
            table.AddHeaderCell("Cable Name");
            // Add Cabin Name and CreatedUser if needed (expand columns accordingly)

            // Add rows
            foreach (var item in data)
            {
                table.AddCell(item.Cutting_Down_Incident_ID.ToString());
                table.AddCell(item.Cutting_Down_Key?.ToString() ?? "-");
                table.AddCell(item.ActualCreatetDate.ToString("yyyy-MM-dd HH:mm:ss"));
                table.AddCell(item.SynchCreateDate.ToString("yyyy-MM-dd HH:mm:ss"));
                table.AddCell(item.Cabel_Name ?? "-");
                // Add Cabin_Name and CreatedUser similarly if you added columns
            }

            document.Add(table);
            document.Close();

            return ms.ToArray();
        }

    }
}
