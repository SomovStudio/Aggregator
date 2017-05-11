/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 07.05.2017
 * Время: 7:25
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;
using System.Windows.Forms;
using ADOX;
using Aggregator.Data;

namespace Aggregator.Database.Config
{
	/// <summary>
	/// Description of CreateConfigDatabase.
	/// </summary>
	public class CreateConfigDatabase
	{
		Catalog ADOXCatalog;
		String path;
		
		public CreateConfigDatabase(String fileName)
		{
			path = fileName;
		}
		
		public bool Create()
		{
			try{
				ADOXCatalog = new Catalog();
				ADOXCatalog.Create(DataConfig.oledbConnectLineBegin + path + DataConfig.oledbConnectLineEnd + DataConfig.oledbConnectPass);
				return true;
			}catch(Exception ex){
				MessageBox.Show(ex.Message, "Ошибка");
				return false;
			}
		}
	}
}
