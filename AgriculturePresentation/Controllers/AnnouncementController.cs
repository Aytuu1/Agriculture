using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
  public class AnnouncementController : Controller
  {
    private readonly IAnnouncementService _announcement;

    public AnnouncementController(IAnnouncementService announcement)
    {
      _announcement = announcement;
    }

    public IActionResult Index()
    {
      var values = _announcement.GetListAll();
      return View(values);
    }
    [HttpGet]
    public ActionResult AddAnnouncement()
    {
      return View();
    }
    [HttpPost]
    public ActionResult AddAnnouncement(Announcement announcement)
    {
      announcement.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
      announcement.Status = true;
      _announcement.Insert(announcement);
      return RedirectToAction("Index");
    }

    public IActionResult DeleteAnnouncement()
    {
      return View();
    }
    [HttpGet]
    public IActionResult UpdateAnnouncement(int id)
    {
      var value=_announcement.GetById(id);
      return View(value);
    }

    [HttpPost]
    public IActionResult UpdateAnnouncement(Announcement announcement)
    {
      _announcement.Update(announcement);
      return RedirectToAction("Index");
    }
    public IActionResult ChangeStatus(int id)
    {
      _announcement.AnnouncementStatus(id);
      return RedirectToAction("Index");
    }
    


  }
}
