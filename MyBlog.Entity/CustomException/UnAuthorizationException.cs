using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Entity.CustomException
{
    public class UnAuthorizationException:Exception
    {
        public UnAuthorizationException(string message)
        {
            this.Data["UnAuthorizationException"] = message;
        }
    }
}
