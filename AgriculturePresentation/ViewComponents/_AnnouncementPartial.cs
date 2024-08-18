using DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _AnnouncementPartial : ViewComponent
	{
		private readonly IAnnouncementDal _announcementDal;

		public _AnnouncementPartial(IAnnouncementDal announcementDal)
		{
			_announcementDal = announcementDal;
		}

		public IViewComponentResult Invoke()
		{
			var values = _announcementDal.GetListAll();
			return View(values);

		}
	}
}
