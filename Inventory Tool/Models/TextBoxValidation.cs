using System.Globalization;
using System.Windows.Controls;

namespace Inventory_Tool
{
	/// <summary>
	/// Validate that a textbox has text in it, this just verifies there is some sort of text 
	/// not the type of text
	/// </summary>
	public class TextBoxValidation : ValidationRule
	{
		public string ErrMessage { get; set; }
		
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			string input = (string)value;
			if (input != null)
			{
				if (input.Length > 0)
				{
					return ValidationResult.ValidResult;
				}
			}
			
			return new ValidationResult(false, ErrMessage);
		}
	}
}
