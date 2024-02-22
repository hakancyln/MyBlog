using FluentValidation;
using MyBlog.Entity.DTO.SkillsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.ValidationRules
{
	public class SkillsValidator : AbstractValidator<SkillsCrudDTO>
	{
		public SkillsValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Yetenek ismi boş olamaz.");
			RuleFor(x => x.Percentile).NotEmpty().WithMessage("Yetenek yüzdesi boş olamaz");
			RuleFor(x => x.Percentile).LessThanOrEqualTo(100).WithMessage("Yetenek yüzdesi 100 den büyük olamaz.");
			RuleFor(x => x.Percentile).GreaterThan(0).WithMessage("Yetenek yüzdesi 0 dan büyük olmalıdır.");
		}
	}
}
