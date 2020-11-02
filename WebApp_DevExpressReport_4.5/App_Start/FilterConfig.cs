using System.Web;
using System.Web.Mvc;

namespace WebApp_DevExpressReport_4._5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
