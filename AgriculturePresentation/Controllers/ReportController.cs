using AgriculturePresentation.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace AgriculturePresentation.Controllers
{

  public class ReportController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }

    public IActionResult StaticReport()
    {
      ExcelPackage excelPackage = new();
      var workbook = excelPackage.Workbook.Worksheets.Add("Dosya1");

      workbook.Cells[1, 1].Value = "Ürün Adı";
      workbook.Cells[1, 2].Value = "Ürün Kategorisi";
      workbook.Cells[1, 3].Value = "Ürün Stok";


      workbook.Cells[2, 1].Value = "Mercimek";
      workbook.Cells[2, 2].Value = "Bakliyat";
      workbook.Cells[2, 3].Value = "785 Kg";

      workbook.Cells[3, 1].Value = "Buğday";
      workbook.Cells[3, 2].Value = "Bakliyat";
      workbook.Cells[3, 3].Value = "1.785 Kg";

      workbook.Cells[4, 1].Value = "Havuç";
      workbook.Cells[4, 2].Value = "Sebze";
      workbook.Cells[4, 3].Value = "585 Kg";

      var bytes = excelPackage.GetAsByteArray();
      return File(bytes, "application/vbd.openxmlformats-officedocument.spreadsheetml.sheet", "BakliyatRaporu.xlsx");
    }
    public List<ContactModel> ContactList()
    {
      List<ContactModel> contactModels = new();
      using (var context = new AgricultureContext())
      {
        contactModels = context.Contacts.Select(x => new ContactModel
        {
          ContactID = x.ContactID,
          ContactName = x.Name,
          ContactDate = x.Date.ToString(),
          ContactMail = x.Mail,
          ContactMessage = x.Message
        }).ToList();
      }
      return contactModels;
    }
    public IActionResult ContactReport()
    {
      using (var workBook = new XLWorkbook())
      {
        var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
        workSheet.Cell(1, 1).Value = "Mesaj ID";
        workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
        workSheet.Cell(1, 3).Value = "Mail Adresi";
        workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
        workSheet.Cell(1, 5).Value = "Mesaj Tarihi";

        int contactRowCount = 2;
        foreach (var item in ContactList())
        {
          workSheet.Cell(contactRowCount, 1).Value = item.ContactID;
          workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
          workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
          workSheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
          workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;

          contactRowCount++;
        }
        using (var stream=new MemoryStream())
        {
          workBook.SaveAs(stream);
          var content=stream.ToArray();
          return File(content,"application/vbd.openxmlformats-officedocument.spreadsheetml.sheet","MesajRapor.xlsx");
        }
      }
     
    }
    public List<AnnouncementModel> AnnouncementList()
    {
      List<AnnouncementModel> announcementModels = new();
      using (var context = new AgricultureContext())
      {
        announcementModels = context.Announcements.Select(x => new AnnouncementModel
        {
          AnnouncementID = x.AnnouncementID,
          AnnouncementTitle=x.Title,
          Date = x.Date,
          Description = x.Description,
          Status=x.Status
        }).ToList();
      }
      return announcementModels;
    }
    public IActionResult AnnouncementReport()
    {
      using (var workBook = new XLWorkbook())
      {
        var workSheet = workBook.Worksheets.Add("Duyuru Listesi");
        workSheet.Cell(1, 1).Value = "Duyuru ID";
        workSheet.Cell(1, 2).Value = "Duyuru Başlığı";
        workSheet.Cell(1, 3).Value = "Duyuru İçeriği";
        workSheet.Cell(1, 4).Value = "Duyuru Tarihi";
        workSheet.Cell(1, 5).Value = "Durum";

        int announcementRowCount = 2;
        foreach (var item in AnnouncementList())
        {
          workSheet.Cell(announcementRowCount, 1).Value = item.AnnouncementID;
          workSheet.Cell(announcementRowCount, 2).Value = item.AnnouncementTitle;
          workSheet.Cell(announcementRowCount, 3).Value = item.Description;
          workSheet.Cell(announcementRowCount, 4).Value = item.Date;
          workSheet.Cell(announcementRowCount, 5).Value = item.Status;

          announcementRowCount++;
        }
        using (var stream = new MemoryStream())
        {
          workBook.SaveAs(stream);
          var content = stream.ToArray();
          return File(content, "application/vbd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRapor.xlsx");
        }
      }

    }
















  }
}
