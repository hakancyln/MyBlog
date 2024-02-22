using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.SkillsDTO;
using MyBlog.Entity.DTO.SocialDTO;
using MyBlog.Entity.Entity;
using MyBlog.Entity.Result;

namespace MyBlog.UI.Models
{
	public class AboutModel
	{
		public UIResponse<AboutGetDTO> About { get; set; }
		public UIResponse<IEnumerable<SkillsGetDTO>> Skills { get; set; }
	}
}
