using FluentValidation;
using MyBlog.Entity.DTO.ContactDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.ValidationRules
{
	public class ContactValidator : AbstractValidator<ContactCrudDTO>
	{
		public ContactValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz");
			RuleFor(x => x.Mail).Matches("[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$").WithMessage("E-Posta Formatı Doğru Değil!!");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu başlığı boş olamaz");
			RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj boş olamaz");
		}
	}
}
