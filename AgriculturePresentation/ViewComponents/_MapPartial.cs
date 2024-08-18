using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
  public class _MapPartial : ViewComponent
  {
    public IViewComponentResult Invoke()
    {
      AgricultureContext context = new();
      var values=context.Addresses.Select(x=>x.Mapinfo).FirstOrDefault();

      ViewBag.map = values;
      return View();
    }









  }
}
