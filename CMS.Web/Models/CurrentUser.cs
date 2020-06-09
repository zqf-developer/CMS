using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Web.Models
{
    public class CurrentUser
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime ModifyDate { get; set; }
    }
}
