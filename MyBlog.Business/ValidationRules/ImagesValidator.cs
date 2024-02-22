using FluentValidation;
using MyBlog.Entity.DTO.ImageDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.ValidationRules
{
	namespace PersonalWebsite.Business.ValidationRules
	{
		public class ImageValidator : AbstractValidator<ImageCrudDTO>
		{
			public ImageValidator()
			{
				RuleFor(x => x.Url).NotEmpty().WithMessage("Fotoğraf boş olamaz.");
			}
		}
	}
