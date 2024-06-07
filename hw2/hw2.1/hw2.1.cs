using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using OfficeOpenXml;

namespace ExcelProcessorApp
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the path to the Excel file (.xlsx):");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath) && filePath.EndsWith(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                ProcessExcelFile(filePath);
            }
            else
            {
                Console.WriteLine("The specified path is not valid or the file is not an Excel file (.xlsx).");
            }
        }

        static void ProcessExcelFile(string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var workbook = package.Workbook;
                if (workbook.Worksheets.Count > 0)
                {
                    var worksheet = workbook.Worksheets[0];
                    var data = WorksheetToDataTable(worksheet);

                    DisplayDataInTable(data);
                    CalculateFrequency(data, "Ambitious (0-5)", "frequencyAmbitious");
                    CalculateFrequency(data, "height", "frequencyheight");
                    CalculateFrequency(data, "Sex", "frequencySex");
                    CalculateJointDistribution(data, "Sex", "Ambitious (0-5)", "jointDistributionSexAmbitious");
                }
                else
                {
                    Console.WriteLine("The Excel file does not contain data.");
                }
            }
        }

        static DataTable WorksheetToDataTable(ExcelWorksheet worksheet)
        {
            DataTable dt = new DataTable();
            foreach (var headerCell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                dt.Columns.Add(headerCell.Text);
            }

            for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
            {
                var wsRow = worksheet.Cells[row, 1, row, worksheet.Dimension.End.Column];
                DataRow dr = dt.NewRow();
                foreach (var cell in wsRow)
                {
                    dr[cell.Start.Column - 1] = cell.Text;
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }

        static void DisplayDataInTable(DataTable data)
        {
            foreach (DataColumn col in data.Columns)
            {
                Console.Write(col.ColumnName + "\t");
            }
            Console.WriteLine();

            foreach (DataRow row in data.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
        }

        static void CalculateFrequency(DataTable data, string variableName, string outputElementId)
        {
            var frequencies = new Dictionary<object, int>();
            var totalEntries = data.Rows.Count;

            foreach (DataRow row in data.Rows)
            {
                var value = row[variableName];

                if (frequencies.ContainsKey(value))
                {
                    frequencies[value]++;
                }
                else
                {
                    frequencies[value] = 1;
                }
            }

            Console.WriteLine("Variable: " + variableName);
            Console.WriteLine("Value\tAbsolute frequency\tRelative frequency\tPercentage frequency");
            foreach (var kvp in frequencies)
            {
                var value = kvp.Key;
                var frequency = kvp.Value;
                var relativeFrequency = (double)frequency / totalEntries;
                var percentage = (relativeFrequency * 100).ToString("0.00");
                Console.WriteLine($"{value}\t{frequency}\t{relativeFrequency:F2}\t{percentage}%");
            }
        }

        static void CalculateJointDistribution(DataTable data, string variable1, string variable2, string outputElementId)
        {
            var jointDistribution = new Dictionary<string, int>();
            var totalEntries = data.Rows.Count;

            foreach (DataRow row in data.Rows)
            {
                var value1 = row[variable1];
                var value2 = row[variable2];
                var key = $"{value1} | {value2}";

                if (jointDistribution.ContainsKey(key))
                {
                    jointDistribution[key]++;
                }
                else
                {
                    jointDistribution[key] = 1;
                }
            }

            Console.WriteLine($"JOINT DISTRIBUTION: {variable1} and {variable2}");
            Console.WriteLine("Value\tAbsolute frequency\tRelative frequency\tPercentage frequency");
            foreach (var kvp in jointDistribution)
            {
                var key = kvp.Key;
                var frequency = kvp.Value;
                var relativeFrequency = (double)frequency / totalEntries;
                var percentage = (relativeFrequency * 100).ToString("0.00");
                Console.WriteLine($"{key}\t{frequency}\t{relativeFrequency:F2}\t{percentage}%");
            }
        }
    }
}
