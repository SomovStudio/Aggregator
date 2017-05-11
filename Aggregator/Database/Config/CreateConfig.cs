/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 25.02.2017
 * Время: 10:52
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
	/// Description of CreateConfig.
	/// </summary>
	public static class CreateConfig
	{
		public static void Create()
		{
			/* Создание файла базы данных */
			CreateConfigDatabase createConfigDatabase;
			DataConfig.oledbConnectLineBegin = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";
			DataConfig.oledbConnectLineEnd = ";Jet OLEDB:Database Password=";
			DataConfig.oledbConnectPass = "12345";
			createConfigDatabase = new CreateConfigDatabase(DataConfig.configFile);
			if(createConfigDatabase.Create()){
				/* Создание таблиц */
				CreateConfigTables.TableDatabaseSettings();
				CreateConfigTables.TableSettings();
			}else{
				MessageBox.Show("Не удалось создать файл конфигурации." + Environment.NewLine + "Программа будет закрыта!", "Сообщение");
				Application.Exit();
			}
						
		}
	}
}
