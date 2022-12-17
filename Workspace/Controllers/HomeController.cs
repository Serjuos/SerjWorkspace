using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Workspace.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace Workspace.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;
            
           if (!db.Types.Any())
           {
                DocumentType z1 = new DocumentType { Name = "Приказ" };
                DocumentType g2 = new DocumentType { Name = "Договор" };
                DocumentType m3 = new DocumentType {Name = "Инструкция" };
                DocumentType f4 = new DocumentType {Name = "Протокол" };

                Status u1 = new Status { Name = "Утвержден" };
                Status u2 = new Status { Name = "Согласован" };
                Status u3 = new Status { Name = "Новый" };
                Status u4 = new Status { Name = "Обработан" };
                Status u5 = new Status { Name = "В бухгалтерии" };

                db.Types.AddRange(z1, g2, m3, f4);
                db.Status.AddRange(u1, u2, u3, u4, u5);
                db.SaveChanges();
           }
        }

        //public HomeController(ILogger<HomeController> logger)
        //  {
        //     _logger = logger;
        // }
        public async Task<IActionResult> Index()
        {
            return View(await db.Documents.ToListAsync());
        }
        public async Task<IActionResult> Create()
        {

            var statuses = await db.Status.ToListAsync();
            var types = await db.Types.ToListAsync();

            ViewBag.statuses = statuses; 
            ViewBag.types = types;

            return View();

        }
       // public IActionResult Index()
       // {
        //    return View();
       // }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> Create(Document document)
        {
            db.Documents.Add(document);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Document document = new Document { Id = id.Value };
                db.Entry(document).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Document document = await db.Documents.FirstOrDefaultAsync(p => p.Id == id);
                if (document != null) return View(document);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Document document)
        {
            db.Documents.Update(document);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}