using FluentValidation;
using MyBlog.Entity.CustomException;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Aspect
{
	public static class ValidationHelper
	{
		public static void Validate(Type type, object[] items)
		{
			if (!typeof(IValidator).IsAssignableFrom(type))
			{
				throw new Exception("Validator Geçerli Bir Tip Değildir.");
			}
			var validator = (IValidator)Activator.CreateInstance(type);

			foreach (var item in items)
			{
				if (validator.CanValidateInstancesOfType(item.GetType()))
				{
					var result = validator.Validate(new ValidationContext<object>(item));

					List<string> ValidatonMessages = new List<string>();

					foreach (var error in result.Errors)
					{
						ValidatonMessages.Add(error.ErrorMessage);
					}

					if (!result.IsValid)
					{
						throw new FieldValidationException(ValidatonMessages);
					}
				}
			}
		}
	}
}
