using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;


public class BankController : Controller
{
    private static List<BankBranch> branches =
         [

         new BankBranch()
        { LocationName ="KFH Auto", LocationURL ="https://maps.app.goo.gl/cqEbKLSB8p88RLaP7", BranchManager = "Ali Mansor", EmployeeCount = 20 , Id =1 }
    ];


    public IActionResult Index()
    {
        return View(branches);
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Submit(IFormCollection from)
    {
        var LocationName = from["LocationName"];
        var LocationURL = from["LocationURL"];
        var BranchManager = from["BranchManager"];
        var EmployeeCount = from["EmployeeCount"];
        if (ModelState.IsValid)
        {
            branches.Add(new BankBranch()
            {
               
                LocationName = LocationName,
                LocationURL = LocationURL,
                BranchManager = BranchManager,
                EmployeeCount = int.Parse(EmployeeCount),
                Id = branches.Max(r => r.Id) + 1,


            });
        }
        else
        {
            return View("Create");
        }
        return RedirectToAction("Index");
    }

        public IActionResult Details(int id)
    {
        var branch = branches.FirstOrDefault(b => b.Id == id);
        if (branch == null)
        {
            return NotFound();
        }
        return View(branch);
    }
}
