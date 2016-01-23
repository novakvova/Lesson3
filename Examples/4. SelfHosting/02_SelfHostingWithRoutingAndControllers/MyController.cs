using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace _02_SelfHostingWithRoutingAndControllers
{
    public class MyController : ApiController
    {
        public string Get()
        {
            return "Ответ от SelfHost Web API приложения";
        }
    }
}
