using AutoMapper;
using MyBlog.Business.Abstract;
using MyBlog.DataAccess.Abstract.DataManagement;
using MyBlog.Entity.DTO.ContactDTO;
using MyBlog.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Business.Concrete
{
	public class ContactManager : GenericManager<ContactCrudDTO, ContactGetDTO, Contact>, IContactService
	{
		public ContactManager(IMapper mapper, IUnitOfWork uow) : base(mapper, uow)
		{
		}
	}
}
