using FluentValidation;
using MyBlog.Entity.DTO.PortfolioDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.ValidationRules
{
	public class PortfolioValidator : AbstractValidator<PortfolioCrudDTO>
	{
		public PortfolioValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("İsim boş olamaz.");
			RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.");
		}
	}
}
