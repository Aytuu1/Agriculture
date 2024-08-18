using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repository;
using DataAccessLayer.Contexts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFrameWork
{
  public class EfAnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
  {
    
    public void AnnouncementStatus(int id)
    {
      var context = new AgricultureContext();
      Announcement announcement = context.Announcements.Find(id);
      if (announcement.Status ==true ) 
      {
        announcement.Status = false;
      }
      else
      {
        announcement.Status = true;
      }
      context.SaveChanges();
    }










  }
}
