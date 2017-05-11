/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 18.03.2017
 * Время: 8:39
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;

namespace Aggregator.Utilits
{
	/// <summary>
	/// Description of Conversion.
	/// </summary>
	public static class Conversion
	{
		/* Проверка числа на отсутствие запрешенных символов*/
		public static bool checkString(String Str)
		{
			bool point = false;
			for(int i = 0; i < Str.Length; i++)
			{
				if(Str[i].ToString() != "," && Str[i].ToString() != "." && Str[i].ToString() != "1" && Str[i].ToString() != "2" && Str[i].ToString() != "3" && Str[i].ToString() != "4" && Str[i].ToString() != "5" && Str[i].ToString() != "6" && Str[i].ToString() != "7" && Str[i].ToString() != "8" && Str[i].ToString() != "9" && Str[i].ToString() != "0"){
					return false; // число седержит запрещенные символы.
				}
				if(Str[i].ToString() == "," || Str[i].ToString() == "."){
					if(point)return false; // число седержит больше одного разделительного знака
					else point = true;
				}
				
			}
			return true; // проверка прошла успешно.
		}
		
		/* Перевод строки в денежное выражение */
		public static String StringToMoney(String Str)
		{
			if(Str != ""){
				String StrEdit = "";
				String StrResult = "";
				int KolSimbolPoslZapat = 0;
				int KolSimbol = 0;
				bool Drob = false;
				bool MenhDvyhDrob = false;
				StrEdit = Str.ToString();
				for(int i = 0; i < StrEdit.Length; i++)
				{
					if(StrEdit[i].ToString() == "," || StrEdit[i].ToString() == "."){
						StrResult = StrResult + ",";
						Drob = true;
						
					}else StrResult = StrResult + StrEdit[i].ToString();
				}
			
				KolSimbol = StrResult.Length;
				if(Drob == true){
					for(int j = 0; j < StrResult.Length; j++){
						if(StrResult[j].ToString() == ","){
							KolSimbolPoslZapat = KolSimbolPoslZapat + 1;
							KolSimbolPoslZapat = KolSimbol - KolSimbolPoslZapat;
							if(KolSimbolPoslZapat < 2) MenhDvyhDrob = true;
						}KolSimbolPoslZapat++;
					}
					if(MenhDvyhDrob == true){
						StrResult = StrResult + "0";
						return StrResult;
					} else return StrResult;
				}else{
					StrResult = StrResult + ",00";
					return StrResult;
				}
			}else return Str;
		}
		
		/* Перевод строки в дробное число */
		public static double StringToDouble(String Str)
		{
			String StrResult = "";
			double DResult;
			for(int i = 0; i < Str.Length; i++){
				if(Str[i].ToString() == ".")
					StrResult = StrResult + ",";
				else StrResult = StrResult + Str[i].ToString();
			}
			DResult = Convert.ToDouble(StrResult);
			return DResult;
		}
		
		public static String DoubleToString(Double value)
		{
			String Str = value.ToString();
			String StrResult = "";
			for(int i = 0; i < Str.Length; i++){
				if(Str[i].ToString() == ",")
					StrResult = StrResult + ".";
				else StrResult = StrResult + Str[i].ToString();
			}
			return StrResult;
		}
	}
}
