using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.App.Attributes
{
	public class DateValidation : ValidationAttribute
	{

		public override bool IsValid( object value )
		{
			if (!value.GetType().IsAssignableFrom(typeof(DateTime)))
			{
				this.ErrorMessage = "Invalid Date";
				return false;
			}
			var date = (DateTime)value;
			if (date)
			{

			}

			return base.IsValid(value);
		}
	}
}
