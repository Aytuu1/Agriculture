using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
  public class AddressController : Controller
  {
    private readonly IAddressService _Addressservice;

    public AddressController(IAddressService addressService)
    {
      _Addressservice = addressService;
    }

    public IActionResult Index()
    {
      var values = _Addressservice.GetListAll();
      return View(values);
    }
    [HttpGet]
    public IActionResult UpdateAddress(int id)
    {
      var value = _Addressservice.GetById(id);
      return View(value);
    }
    [HttpPost]
    public IActionResult UpdateAddress(Address address)
    {
      AddressValidator addressValidator = new AddressValidator();
      ValidationResult result = addressValidator.Validate(address);
      if (result.IsValid)
      {
        _Addressservice.Update(address);
        return RedirectToAction("Index");
      }
      else
      {
        foreach (var item in result.Errors)
        {
          ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        }
      }
      return View();
    }

























  }
}
