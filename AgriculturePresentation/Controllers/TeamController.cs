using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AgriculturePresentation.Controllers
{
  public class TeamController : Controller
  {
    private readonly ITeamService _Teamservice;

    public TeamController(ITeamService service)
    {
      _Teamservice = service;
    }

    public IActionResult Index()
    {
      var values=_Teamservice.GetListAll();
      return View(values);
    }
    [HttpGet]
    public IActionResult AddTeam()
    {
      return View();
    }
    [HttpPost]
    public IActionResult AddTeam(Team team)
    {
      TeamValidator teamValidator = new TeamValidator();
      ValidationResult result = teamValidator.Validate(team);
      if (result.IsValid)
      {
        _Teamservice.Insert(team);
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
    public IActionResult DeleteTeam(int id)
    {
      var value = _Teamservice.GetById(id);
      _Teamservice.Delete(value);
      return RedirectToAction("Index");

    }
    [HttpGet]
    public IActionResult UpdateTeam(int id)
    {
      var value=_Teamservice.GetById(id);
      return View(value);
    }
    [HttpPost]
    public IActionResult UpdateTeam(Team team)
    {
      TeamValidator teamValidator = new TeamValidator();
      ValidationResult result = teamValidator.Validate(team);
      if (result.IsValid)
      {
        _Teamservice.Update(team);
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
