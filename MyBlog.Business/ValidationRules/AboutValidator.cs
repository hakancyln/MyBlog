using FluentValidation;
using MyBlog.Entity.DTO.AboutDTO;

namespace MyBlog.Business.ValidationRules
{
	public class AboutValidator : AbstractValidator<AboutCrudDTO>
	{
		public AboutValidator()
		{
			RuleFor(x => x.NameSurname).MinimumLength(25).WithMessage("Kullanıcı adı 25 karakterden büyük olmalıdır.");
			RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
			RuleFor(x => x.Job).NotEmpty().WithMessage("Meslek boş olamaz.");
			RuleFor(x => x.Resume).NotEmpty().WithMessage("Özgeçmiş boş olamaz.");
			RuleFor(x => x.Mail).Matches("[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$").WithMessage("E-Posta Formatı Doğru Değil!!");
			RuleFor(x => x.Photo).NotEmpty().WithMessage("Resim boş olamaz.");
			RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Doğum tarihi boş olamaz.");
		}
	}
}
