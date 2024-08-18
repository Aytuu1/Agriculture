using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
  public class ContactController : Controller
  {
    private readonly IContactService _Contactservice;

    public ContactController(IContactService contactService)
    {
      _Contactservice = contactService;
    }

    public IActionResult Index()
    {
      var values = _Contactservice.GetListAll();
      return View(values);
    }
    [HttpGet]
    public IActionResult DetailsContact(int id)
    {
      var value = _Contactservice.GetById(id);
      return View(value);
    }
    [HttpPost]
    
    public IActionResult ContactDelete(int id)
    {
      var values= _Contactservice.GetById(id);
      _Contactservice.Delete(values);
      return RedirectToAction("Index");
    }


















  }
}
