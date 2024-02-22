using FluentValidation;
using MyBlog.Entity.DTO.UserDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.ValidationRules
{
	public class UserValidator : AbstractValidator<UserCrudDTO>
	{
		public UserValidator()
		{
			RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Sifre boş olamaz.");
			RuleFor(x => x.Password).MinimumLength(7).WithMessage("Sifre 7 karakterden fazla olmalıdır.");

		}
	}
}
