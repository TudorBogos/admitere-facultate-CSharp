using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Drawing;
using QuestPDF.Elements;
using System.Collections.Generic;
using System.Text;


namespace admitere_facultate_C_
{
    /// <summary>
    /// Clasa pentru export pdf si CSV
    /// </summary>

    public static class ExportUtility
    {
        /// <summary>
        /// Exporta un DataGridView in format PDF.
        /// </summary>
        /// <param name="dgv">Controlul DataGridView ce contine datele</param>
        /// <param name="filePath">Calea fisierului CSV de iesire</param>
        /// <param name="title">Titlul ce va aparea in fisierul PDF</param>
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

        /// <summary>
        /// Exporta un DataGridView in format CSV.
        /// </summary>
        /// <param name="dgv">Controlul DataGridView ce contine datele</param>
        /// <param name="filePath">Calea fisierului CSV de iesire</param>
        public static void ExportDataGridViewToCsv(DataGridView dgv, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    // Scrie header-ul
                    List<string> headers = new List<string>();
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        headers.Add(EscapeCsvValue(column.HeaderText));
                    }
                    writer.WriteLine(string.Join(",", headers));

                    // Scrie randurile
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        if (row.IsNewRow) continue;

                        List<string> values = new List<string>();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            values.Add(EscapeCsvValue(cell.Value?.ToString() ?? ""));
                        }
                        writer.WriteLine(string.Join(",", values));
                    }
                }

                MessageBox.Show("Exportat cu succes in CSV!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la exportul CSV: " + ex.Message);
            }
        }

        /// <summary>
        /// Formateaza valorile pentru CSV (ex. virgule, ghilimele).
        /// </summary>
        private static string EscapeCsvValue(string value)
        {
            if (value.Contains(",") || value.Contains("\"") || value.Contains("\n"))
            {
                value = value.Replace("\"", "\"\"");
                return $"\"{value}\"";
            }
            return value;
        }

    }

}
