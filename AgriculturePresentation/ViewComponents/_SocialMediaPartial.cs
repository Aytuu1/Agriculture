using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _SocialMediaPartial : ViewComponent
	{
		private readonly ISocialMediaService _socialMedia;

		public _SocialMediaPartial(ISocialMediaService socialMedia)
		{
			_socialMedia = socialMedia;
		}

		public IViewComponentResult Invoke()
		{
			var values = _socialMedia.GetListAll();
			return View(values);

		}



	}
}
