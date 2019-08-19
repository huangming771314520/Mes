using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spring.Net
{
    class UserInfoService : IUserInfoService
    {
        public string Name { get; set; }
        public Person Person_One{ get;set;}
        public string GetMsg()
        {
            return "Hello ! " + Name + " Age:" + Person_One.Age.ToString();
        }
    }
}
