/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 09.04.2017
 * Время: 13:00
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Data;
using System.Windows.Forms;
using ExcelLibrary.SpreadSheet;

namespace Aggregator.Utilits
{
	/// <summary>
	/// Description of ExportExcel.
	/// </summary>
	public static class ExportExcel
	{
		//export Excel from DataSet
        public static void CreateWorkbook(String filePath, DataSet dataset)
        {
            //if (dataset.Tables.Count == 0) throw new ArgumentException("DataSet needs to have at least one DataTable", "dataset");
            if (dataset.Tables.Count == 0) {
            	MessageBox.Show("Нет данных для сохранения в Excel.");
            	return;
            }
 
            Workbook workbook = new Workbook();
            foreach (DataTable dt in dataset.Tables)
            {
                Worksheet worksheet = new Worksheet(dt.TableName);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    // Add column header
                    worksheet.Cells[0, i] = new Cell(dt.Columns[i].ColumnName);
 
                    // Populate row data
                    for (int j = 0; j < dt.Rows.Count; j++)
                        //Если нулевые значения, заменяем на пустые строки
                        worksheet.Cells[j + 1, i] = new Cell(dt.Rows[j][i] == DBNull.Value ? "" : dt.Rows[j][i]);
                }
                workbook.Worksheets.Add(worksheet);
            }
            workbook.Save(filePath);
        }
       //********************************
       // DataGridView to DataTable    
        public static DataTable ToDataTable(DataGridView dataGridView, string tableName)
        {
 
            DataGridView dgv = dataGridView;
            DataTable table = new DataTable(tableName);
            int iCol = 0;
 
            for (iCol = 0; iCol < dgv.Columns.Count; iCol++)
            {
               table.Columns.Add(dgv.Columns[iCol].Name);
            }
 
            foreach (DataGridViewRow row in dgv.Rows)
            {
 
                DataRow datarw = table.NewRow();
 
                for (iCol = 0; iCol < dgv.Columns.Count; iCol++)
                {
                        datarw[iCol] = row.Cells[iCol].Value;
                }
 
                table.Rows.Add(datarw);
            }
 
            return table;
        } 
	}
}
