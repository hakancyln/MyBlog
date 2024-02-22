using MyBlog.Entity.DTO.AboutDTO;
using MyBlog.Entity.DTO.SocialDTO;
using MyBlog.Entity.Result;

namespace MyBlog.UI.Models
{
	public class IntroModel
	{
		public UIResponse<AboutGetDTO> About { get; set; }
		public UIResponse<IEnumerable<SocialGetDTO>> Social { get; set; }
	}
}
