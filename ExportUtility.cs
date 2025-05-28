using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Drawing;
using QuestPDF.Elements;
using System.Collections.Generic;

namespace admitere_facultate_C_
{

    public static class ExportUtility
    {

        public static void ExportDataGridViewToPdf(DataGridView dgv, string filePath, string title = "Export")
        {
            // Extract data from DataGridView
            var headers = new List<string>();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                headers.Add(col.HeaderText);
            }

            var rows = new List<List<string>>();
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                var rowData = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    rowData.Add(cell.Value?.ToString() ?? "");
                }
                rows.Add(rowData);
            }

            // Build the PDF
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(30);
                    page.Size(PageSizes.A4.Landscape());
                    page.Header().Text(title).FontSize(18).Bold().AlignCenter();

                    page.Content().Table(table =>
                    {
                        // define columns
                        table.ColumnsDefinition(columns =>
                        {
                            foreach (var _ in headers)
                                columns.RelativeColumn();
                        });

                        // header row
                        foreach (var header in headers)
                        {
                            table.Cell().Element(CellStyle).Text(header).SemiBold().FontColor(Colors.Blue.Darken2);
                        }

                        // data rows
                        foreach (var row in rows)
                        {
                            foreach (var cell in row)
                            {
                                table.Cell().Element(CellStyle).Text(cell);
                            }
                        }

                        static IContainer CellStyle(IContainer container) =>
                            container
                                .BorderBottom(1)
                                .BorderColor(Colors.Grey.Lighten2)
                                .PaddingVertical(5)
                                .PaddingHorizontal(5);
                    });
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.CurrentPageNumber();
                        text.Span(" / ");
                        text.TotalPages();
                    });
                });
            }).GeneratePdf(filePath);

            MessageBox.Show("Exported to PDF successfully!");
        }
    }

}
