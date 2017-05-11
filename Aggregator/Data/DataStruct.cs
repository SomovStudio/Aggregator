/*
 * Создано в SharpDevelop.
 * Пользователь: Somov Studio
 * Дата: 30.04.2017
 * Время: 10:46
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;

namespace Aggregator.Data
{
	public struct Price {
			public String counteragentName;		// наименование контрагента
			public String priceName;			// идентификатор прайслиста
	}
	
	public struct Nomenclature {
			public String Name;					// наименование номенклатуры
			public String Code;					// код номенклатуры
			public String Series;				// серия номенклатуры
			public String Article;				// артикул номенклатуры
			public String Manufacturer;			// производитель номенклатуры
			public String Units;				// единицы измерения номенклатуры
			public Double Remainder;			// остаток номенклатуры
			public Double Price;				// цена номенклатуры
			public Double Discount1;			// скидка 1 номенклатуры
			public Double Discount2;			// скидка 2 номенклатуры
			public Double Discount3;			// скидка 3 номенклатуры
			public Double Discount4;			// скидка 4 номенклатуры
			public DateTime Term;				// срок годности номенклатуры
			public String CounteragentName;		// наименование контрагента
			public String CounteragentPrice;	// идентификатор прайслиста
	}
}
