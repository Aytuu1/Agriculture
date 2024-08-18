using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
  public class _DashboardOverviewPartial:ViewComponent
  {
    AgricultureContext context = new();
    public IViewComponentResult Invoke()
    {

      ViewBag.teamCount = context.Teams.Count();
      ViewBag.serviceCount=context.Services.Count();
      ViewBag.messageCount=context.Contacts.Count();
      var date = DateTime.Now.Month;
      ViewBag.currentMonthMessage = context.Contacts.Where(x => x.Date.Month == date).Count();

      ViewBag.announcementTrue=context.Announcements.Where(x=>x.Status==true).Count();
      ViewBag.announcementFalse=context.Announcements.Where(x=>x.Status==false).Count();

      ViewBag.productMarketing = context.Teams.Where(x => x.Title == "Ürün Pazarlama").Select(x=>x.PersonName).FirstOrDefault();
      ViewBag.pulseManagement = context.Teams.Where(x => x.Title == "Bakliyat Yönetimi").Select(x=>x.PersonName).FirstOrDefault();
      ViewBag.milkProducer = context.Teams.Where(x => x.Title == "Süt Üreticisi").Select(x=>x.PersonName).FirstOrDefault();
      ViewBag.fertilizerManagement = context.Teams.Where(x => x.Title == "Gübre Yönetimi").Select(x=>x.PersonName).FirstOrDefault();
      return View();
    }
  }
}
