using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _TopAddressPartial : ViewComponent
	{
		private readonly IAddressService _addressService;

		public _TopAddressPartial(IAddressService address)
		{
			_addressService = address;
		}

		public IViewComponentResult Invoke()
		{
			var values = _addressService.GetListAll();
			return View(values);
		}








	}
}
