/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 20.04.2017
 * Время: 10:16
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using Aggregator.Data;
using Aggregator.Client.Directories;
using Aggregator.Utilits;
using ExcelLibrary.SpreadSheet;

namespace Aggregator.Utilits
{
	/// <summary>
	/// Description of FormCalculationCostRealization.
	/// </summary>
	public partial class CalculationCostRealization : Form
	{
		public CalculationCostRealization()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		int selectTableLine = -1;		// выбранная строка в таблице
		
		void calculate()
		{
			if(listViewNomenclature.Items.Count > 0){
				double totalAmount = 0;
				double totalPrice = 0;
				double totalSum = 0;
				
				double amount = 0;
				double price = 0;
				double sum = 0;
				
				double price2 = 0;
				double result = 0;
				
				int count = listViewNomenclature.Items.Count;
				for(int i = 0; i < count; i++){
					amount = Conversion.StringToDouble(listViewNomenclature.Items[i].SubItems[3].Text);
					price = Conversion.StringToDouble(listViewNomenclature.Items[i].SubItems[4].Text);
					sum = Math.Round((price * amount), 2);
					totalAmount += amount;
					totalPrice += price;
					totalSum += sum;
					
					listViewNomenclature.Items[i].SubItems[5].Text = Conversion.StringToMoney(Conversion.StringToDouble(sum.ToString()).ToString());
				}
				
				totalAmount = Math.Round(totalAmount, 2);
				textBox1.Text = Conversion.StringToMoney(Conversion.StringToDouble(totalAmount.ToString()).ToString());
				
				totalPrice = Math.Round(totalPrice, 2);
				textBox2.Text = Conversion.StringToMoney(Conversion.StringToDouble(totalPrice.ToString()).ToString());
				
				totalSum = Math.Round(totalSum, 2);
				textBox3.Text = Conversion.StringToMoney(Conversion.StringToDouble(totalSum.ToString()).ToString());
				
				costPriceTextBox.Text = textBox3.Text;
				
				price2 = totalSum * Conversion.StringToDouble(extraChargeTextBox.Text) / 100;
				price2 = Math.Round(price2, 2);
				price2TextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(price2.ToString()).ToString());
				
				result = price2 + totalSum;
				result = Math.Round(result, 2);
				resultTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(result.ToString()).ToString());
			}else{
				amountTextBox.Text = "0,00";
				priceTextBox.Text = "0,00";
				textBox1.Text = "0,00";
				textBox2.Text = "0,00";
				textBox3.Text = "0,00";
				costPriceTextBox.Text = "0,00";
				price2TextBox.Text = "0,00";
				resultTextBox.Text = "0,00";
			}
		}
		
		void search()
		{
			String str;
			for(int i = 0; i < listViewNomenclature.Items.Count; i++){
				str = listViewNomenclature.Items[i].SubItems[1].Text;
				if(str.Contains(comboBox1.Text)){
					listViewNomenclature.FocusedItem = listViewNomenclature.Items[i];
					listViewNomenclature.Items[i].Selected = true;
					listViewNomenclature.Select();
					listViewNomenclature.EnsureVisible(i);
					break;
				}
			}
		}
		
		/* =================================================================================================
		 * РАЗДЕЛ: СОБЫТИЙ
		 * =================================================================================================
		 */	
		void FormCalculationCostRealizationLoad(object sender, EventArgs e)
		{
			Utilits.Console.Log(Text + ": открыт.");
		}
		void ButtonNomenclatureAddClick(object sender, EventArgs e)
		{
			if(DataForms.FNomenclature != null) DataForms.FNomenclature.Close();
			if(DataForms.FNomenclature == null) {
				DataForms.FNomenclature = new FormNomenclature();
				DataForms.FNomenclature.MdiParent = DataForms.FClient;
				DataForms.FNomenclature.ListViewReturnValue = listViewNomenclature;
				DataForms.FNomenclature.TypeReturnValue = "name&units&amount&price&sum";
				DataForms.FNomenclature.ShowMenuReturnValue();
				DataForms.FNomenclature.Show();
			}
		}
		void ListViewNomenclatureSelectedIndexChanged(object sender, EventArgs e)
		{
			if(listViewNomenclature.SelectedItems.Count > 0){
				selectTableLine = listViewNomenclature.SelectedItems[0].Index;
				groupBox1.Text = listViewNomenclature.Items[selectTableLine].SubItems[1].Text;
				unitsTextBox.Text = listViewNomenclature.Items[selectTableLine].SubItems[2].Text;
				amountTextBox.Text = listViewNomenclature.Items[selectTableLine].SubItems[3].Text;
				priceTextBox.Text = listViewNomenclature.Items[selectTableLine].SubItems[4].Text;
			}
		}
		void UnitsTextBoxTextChanged(object sender, EventArgs e)
		{
			if(listViewNomenclature.Items.Count > 0 && selectTableLine > -1){
				listViewNomenclature.Items[selectTableLine].SubItems[2].Text = unitsTextBox.Text;
			}
		}
		void Button8Click(object sender, EventArgs e)
		{
			if(DataForms.FUnits != null) DataForms.FUnits.Close();
			if(DataForms.FUnits == null) {
				DataForms.FUnits = new FormUnits();
				DataForms.FUnits.MdiParent = DataForms.FClient;
				DataForms.FUnits.TextBoxReturnValue = unitsTextBox;
				DataForms.FUnits.ShowMenuReturnValue();
				DataForms.FUnits.Show();
			}
		}
		void Button9Click(object sender, EventArgs e)
		{
			unitsTextBox.Clear();
		}
		void AmountTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = amountTextBox.Text;
				amountTextBox.Clear();
				amountTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
				if(amountTextBox.Text == "" || Conversion.checkString(amountTextBox.Text) == false) amountTextBox.Text = "0,00";
				calculate();
			}
		}
		void AmountTextBoxTextChanged(object sender, EventArgs e)
		{
			if(amountTextBox.Text == "" || Conversion.checkString(amountTextBox.Text) == false) amountTextBox.Text = "0,00";
			if(listViewNomenclature.Items.Count > 0 && selectTableLine > -1){
				listViewNomenclature.Items[selectTableLine].SubItems[3].Text = amountTextBox.Text;
				calculate();
			}
		}
		void AmountTextBoxLostFocus(object sender, EventArgs e)
		{
			String Value = amountTextBox.Text;
			amountTextBox.Clear();
			amountTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
			if(amountTextBox.Text == "" || Conversion.checkString(amountTextBox.Text) == false) amountTextBox.Text = "0,00";
			calculate();
		}
		void Button6Click(object sender, EventArgs e)
		{
			amountTextBox.Text = "0,00";
			calculate();
		}
		void Button7Click(object sender, EventArgs e)
		{
			Calculator Calc = new Calculator();
			Calc.TextBoxReturnValue = amountTextBox;
			Calc.MdiParent = DataForms.FClient;
			Calc.Show();
		}
		void PriceTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = priceTextBox.Text;
				priceTextBox.Clear();
				priceTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
				if(priceTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) priceTextBox.Text = "0,00";
				calculate();
			}
		}
		void PriceTextBoxTextChanged(object sender, EventArgs e)
		{
			if(priceTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) priceTextBox.Text = "0,00";
			if(listViewNomenclature.Items.Count > 0 && selectTableLine > -1){
				listViewNomenclature.Items[selectTableLine].SubItems[4].Text = priceTextBox.Text;
				calculate();
			}
		}
		void PriceTextBoxLostFocus(object sender, EventArgs e)
		{
			String Value = priceTextBox.Text;
			priceTextBox.Clear();
			priceTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
			if(priceTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) priceTextBox.Text = "0,00";
			calculate();
		}
		void Button13Click(object sender, EventArgs e)
		{
			Calculator Calc = new Calculator();
			Calc.TextBoxReturnValue = priceTextBox;
			Calc.MdiParent = DataForms.FClient;
			Calc.Show();
		}
		void Button14Click(object sender, EventArgs e)
		{
			priceTextBox.Text = "0,00";
			calculate();
		}
		void Button5Click(object sender, EventArgs e)
		{
			Calculator Calc = new Calculator();
			Calc.TextBoxReturnValue = extraChargeTextBox;
			Calc.MdiParent = DataForms.FClient;
			Calc.Show();
		}
		void Button10Click(object sender, EventArgs e)
		{
			extraChargeTextBox.Text = "0,00";
			calculate();
		}
		void ExtraChargeTextBoxTextChanged(object sender, EventArgs e)
		{
			if(extraChargeTextBox.Text == "" || Conversion.checkString(priceTextBox.Text) == false) extraChargeTextBox.Text = "0,00";
			if(listViewNomenclature.Items.Count > 0){
				calculate();
			}
		}
		void ExtraChargeTextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab){
				String Value = extraChargeTextBox.Text;
				extraChargeTextBox.Clear();
				extraChargeTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
				if(extraChargeTextBox.Text == "" || Conversion.checkString(extraChargeTextBox.Text) == false) extraChargeTextBox.Text = "0,00";
				calculate();
			}
		}
		void ExtraChargeTextBoxLostFocus(object sender, EventArgs e)
		{
			String Value = extraChargeTextBox.Text;
			extraChargeTextBox.Clear();
			extraChargeTextBox.Text = Conversion.StringToMoney(Conversion.StringToDouble(Value).ToString());
			if(extraChargeTextBox.Text == "" || Conversion.checkString(extraChargeTextBox.Text) == false) extraChargeTextBox.Text = "0,00";
			calculate();
		}
		void ButtonNomenclaturesAddClick(object sender, EventArgs e)
		{
			if(DataForms.FNomenclature != null) DataForms.FNomenclature.Close();
			if(DataForms.FNomenclature == null) {
				DataForms.FNomenclature = new FormNomenclature();
				DataForms.FNomenclature.MdiParent = DataForms.FClient;
				DataForms.FNomenclature.ListViewReturnValue = listViewNomenclature;
				DataForms.FNomenclature.TypeReturnValue = "folder&CalcCostRealization";
				DataForms.FNomenclature.ShowMenuReturnValue();
				DataForms.FNomenclature.Show();
			}
		}
		void ButtonNomenclatureDeleteClick(object sender, EventArgs e)
		{
			if(listViewNomenclature.SelectedItems.Count > 0) {
				listViewNomenclature.Items[listViewNomenclature.SelectedItems[0].Index].Remove();
				selectTableLine = -1;
				groupBox1.Text = "...";
				unitsTextBox.Clear();
				amountTextBox.Text = "0,00";
				priceTextBox.Text =  "0,00";
				calculate();
			}
			
		}
		void ButtonNomenclaturesDeleteClick(object sender, EventArgs e)
		{
			while(listViewNomenclature.Items.Count > 0){
				listViewNomenclature.Items[0].Remove();
			}
			selectTableLine = -1;
			groupBox1.Text = "...";
			unitsTextBox.Clear();
			amountTextBox.Text = "0,00";
			priceTextBox.Text =  "0,00";
			calculate();
		}
		void FindButtonClick(object sender, EventArgs e)
		{
			if(comboBox1.Text != "") comboBox1.Items.Add(comboBox1.Text);
			search();
		}
		void ComboBox1KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter){
				if(comboBox1.Text != "") comboBox1.Items.Add(comboBox1.Text);
				search();
			}
		}
		void ButtonSaveExcelClick(object sender, EventArgs e)
		{
			if(listViewNomenclature.Items.Count == 0) {
				MessageBox.Show("Таблица номенклатуры пустая, добавьте номенклатуру!", "Сообщение");
				return;
			}
			if(saveFileDialog1.ShowDialog() == DialogResult.OK){
				
	            Workbook workbook = new Workbook();
	            
	            Worksheet worksheet = new Worksheet("Лист1");
	            worksheet.Cells[0, 0] = new Cell("№п/п:");
	            worksheet.Cells[0, 1] = new Cell("Наименование:");
	            worksheet.Cells[0, 2] = new Cell("Ед.изм.:");
	            worksheet.Cells[0, 3] = new Cell("Вес/Кол-во:");
	            worksheet.Cells[0, 4] = new Cell("Цена:");
	            worksheet.Cells[0, 5] = new Cell("Сумма:");
	            
	            int count = listViewNomenclature.Items.Count;
	            for(int i = 0; i < count; i++){
	            	worksheet.Cells[i + 1, 0] = new Cell(i);
	            	worksheet.Cells[i + 1, 1] = new Cell(listViewNomenclature.Items[i].SubItems[1].Text);
	            	worksheet.Cells[i + 1, 2] = new Cell(listViewNomenclature.Items[i].SubItems[2].Text);
	            	worksheet.Cells[i + 1, 3] = new Cell(listViewNomenclature.Items[i].SubItems[3].Text);
	            	worksheet.Cells[i + 1, 4] = new Cell(listViewNomenclature.Items[i].SubItems[4].Text);
	            	worksheet.Cells[i + 1, 5] = new Cell(listViewNomenclature.Items[i].SubItems[5].Text);
	            }
	            
	            count++;
	            worksheet.Cells[count, 0] = new Cell("Всего:");
	            worksheet.Cells[count, 1] = new Cell("");
	            worksheet.Cells[count, 2] = new Cell("");
	            worksheet.Cells[count, 3] = new Cell(textBox1.Text);
	            worksheet.Cells[count, 4] = new Cell(textBox2.Text);
	            worksheet.Cells[count, 5] = new Cell(textBox3.Text);
	            
	            count++;
	            worksheet.Cells[count, 0] = new Cell("Себестоимость:");
	            worksheet.Cells[count, 1] = new Cell(costPriceTextBox.Text);
	            
	            count++;
	            worksheet.Cells[count, 0] = new Cell("Торговая наценка (%):");
	            worksheet.Cells[count, 1] = new Cell(extraChargeTextBox.Text);
	            worksheet.Cells[count, 2] = new Cell(price2TextBox.Text);
	            
	            count++;
	            worksheet.Cells[count, 0] = new Cell("Стоимость реализации:");
	            worksheet.Cells[count, 1] = new Cell(resultTextBox.Text);
	            
	            workbook.Worksheets.Add(worksheet);
	            
	            workbook.Save(saveFileDialog1.FileName);
	            
	            MessageBox.Show("Файл сохранен!", "Сообщение");
			}
		}
		void ButtonCancelClick(object sender, EventArgs e)
		{
			Close();
		}
		
		int printLine = 0;
		void PrintDocument1PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			int PosY = 0;
			if(printLine == 0){
				// Заголовок документа
				e.Graphics.DrawString("РАСЧЁТ СТОИМОСТИ РЕАЛИЗАЦИИ", new Font("Microsoft Sans Serif", 14, FontStyle.Regular), Brushes.Black, 20, PosY);
				// ТАБЛИЧНАЯ ЧАСТЬ: Загрузка данных из таблицы
				PosY += 60;
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 250, 25));
				e.Graphics.DrawString("Наименование:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 5, PosY);
				
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(255, PosY, 65, 25));
				e.Graphics.DrawString("Ед. изм:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 260, PosY);
				
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(325, PosY, 100, 25));
				e.Graphics.DrawString("Кол-во:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 330, PosY);
				
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(430, PosY, 100, 25));
				e.Graphics.DrawString("Цена:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 435, PosY);
				
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(535, PosY, 100, 25));
				e.Graphics.DrawString("Сумма:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 540, PosY);
				PosY += 30;
				e.Graphics.DrawLine(new Pen(Color.Black), 0, PosY, 650, PosY);
				PosY += 30;
			}
			
			String textName;
			for(int i = printLine; i < listViewNomenclature.Items.Count; i++){
				//    Наименование
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 250, 25));
				textName = listViewNomenclature.Items[i].SubItems[1].Text;
				if(textName.Length > 30) textName = textName.Substring(0, 30);
				e.Graphics.DrawString(textName, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 5, PosY);
				//    Ед. изм.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(255, PosY, 65, 25));
				e.Graphics.DrawString(listViewNomenclature.Items[i].SubItems[2].Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 260, PosY);
				//    Количество.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(325, PosY, 100, 25));
				e.Graphics.DrawString(listViewNomenclature.Items[i].SubItems[3].Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 330, PosY);
				//    Цена.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(430, PosY, 100, 25));
				e.Graphics.DrawString(listViewNomenclature.Items[i].SubItems[4].Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 435, PosY);
				//    Сумма.
				e.Graphics.FillRectangle(Brushes.White, new Rectangle(535, PosY, 100, 25));
				e.Graphics.DrawString(listViewNomenclature.Items[i].SubItems[5].Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 540, PosY);
				
				printLine++;
				PosY += 30;
				
				if(PosY >= 1000) {
					e.HasMorePages = true;
					return;
				}
			}
			
			
			if((PosY + 150) >= 1000) {
				e.HasMorePages = true;
				return;
			}
			
			PosY += 30;
			e.Graphics.DrawLine(new Pen(Color.Black), 0, PosY, 650, PosY);
			//	Всего.
			PosY += 30;
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 250, 25));
			e.Graphics.DrawString("Всего:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 5, PosY);
			//    Количество.
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(325, PosY, 100, 25));
			e.Graphics.DrawString(textBox1.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 330, PosY);
			//    Цена.
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(430, PosY, 100, 25));
			e.Graphics.DrawString(textBox2.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 435, PosY);
			//    Сумма.
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(535, PosY, 100, 25));
			e.Graphics.DrawString(textBox3.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 540, PosY);
			
			PosY += 30;
			//    Себестоимость
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 250, 25));
			e.Graphics.DrawString("Себестоимость:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 5, PosY);
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(535, PosY, 100, 25));
			e.Graphics.DrawString(costPriceTextBox.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 540, PosY);
			
			PosY += 30;
			//    Торговая наценка
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 250, 25));
			e.Graphics.DrawString("Торговая наценка (%):", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 5, PosY);
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(325, PosY, 100, 25));
			e.Graphics.DrawString(extraChargeTextBox.Text + "%", new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 330, PosY);
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(430, PosY, 100, 25));
			e.Graphics.DrawString(price2TextBox.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 435, PosY);
			
			PosY += 30;
			//    Стоимость реализации
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(0, PosY, 250, 25));
			e.Graphics.DrawString("Стоимость реализации:", new Font("Microsoft Sans Serif", 10, FontStyle.Bold), Brushes.Black, 5, PosY);
			e.Graphics.FillRectangle(Brushes.White, new Rectangle(535, PosY, 100, 25));
			e.Graphics.DrawString(resultTextBox.Text, new Font("Microsoft Sans Serif", 10, FontStyle.Regular), Brushes.Black, 540, PosY);
				
		}
		void ButtonPrintPreviewClick(object sender, EventArgs e)
		{
			printLine = 0;
			PrintPreviewDialog ppd = new PrintPreviewDialog();
			ppd.Document = printDocument1;
			ppd.MdiParent = DataForms.FClient;
			ppd.Show();
		}
		void ButtonPrintClick(object sender, EventArgs e)
		{
			printLine = 0;
			if(printDialog1.ShowDialog() == DialogResult.OK){
				printDialog1.Document.Print();
			}
		}
		void FormCalculationCostRealizationActivated(object sender, EventArgs e)
		{
			DataForms.FClient.messageInStatus(this.Text);
		}
		void FormCalculationCostRealizationFormClosed(object sender, FormClosedEventArgs e)
		{
			DataForms.FClient.messageInStatus("...");
			Utilits.Console.Log(Text + ": закрыт.");
			Dispose();
		}
			

	}
}
