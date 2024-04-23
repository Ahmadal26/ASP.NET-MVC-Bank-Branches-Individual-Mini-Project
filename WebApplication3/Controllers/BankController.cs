using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;


public class BankController : Controller
{



    public IActionResult Index()
    {
        var context = new BankContext();
        return View(context.BankBranches.ToList());
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(IFormCollection from)

    {

        using (var context = new BankContext())
        {

            var LocationName = from["LocationName"];
            var LocationURL = from["LocationURL"];
            var BranchManager = from["BranchManager"];
            var EmployeeCount = from["EmployeeCount"];
            if (ModelState.IsValid)
            {
                context.BankBranches.Add(new BankBranch()
                {

                    LocationName = LocationName,
                    LocationURL = LocationURL,
                    BranchManager = BranchManager,
                    EmployeeCount = int.Parse(EmployeeCount),


                });
                context.SaveChanges();
            }
            else
            {
                return View("Create");
            }
        }
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        using (var context = new BankContext())
        {

            var branch = context.BankBranches.Include(e => e.Employees).FirstOrDefault(b => b.BankId == id);
            if (branch == null)
            {
                return NotFound();
            }
            return View(branch);
        }

    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var form = new EditBankBranch();
        var context = new BankContext();
        var banks = context.BankBranches.SingleOrDefault(a => a.BankId == id);
        if (banks == null)
        {
            return RedirectToAction("Index");
        }
        form.BankId = banks.BankId;
        form.LocationURL = banks.LocationURL;
        form.LocationName = banks.LocationName;
        form.BranchManager = banks.BranchManager;
        form.EmployeeCount = banks.EmployeeCount;
        return View(form);
    }


    [HttpPost]
    public IActionResult Edit(EditBankBranch form, int id)

    {

        using (var context = new BankContext())
        {
            var bankId = form.BankId;
            var LocationName = form.LocationName;
            var LocationURL = form.LocationURL;
            var BranchManager = form.BranchManager;
            var EmployeeCount = form.EmployeeCount;
            if (ModelState.IsValid)
            {
                {
                    var bank = context.BankBranches.Find(id);
                    if (bank != null)
                    {

                        bank.LocationName = LocationName;
                        bank.LocationURL = LocationURL;
                        bank.BranchManager = BranchManager;
                        bank.EmployeeCount = EmployeeCount;
                        bank.BankId = bankId;
                        context.SaveChanges();

                    };
                    context.SaveChanges();
                }
            }
            else
            {
                return View(form);
            }
        }
        return RedirectToAction("Index");


    }
    public IActionResult Search(string searchTerm)
    {
        using (var context = new BankContext())
        {
            var branches = context.BankBranches.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                branches = branches.Where(m => m.LocationName.StartsWith(searchTerm));
            }

            var data = branches.ToList();
            return View("Index", data);
        }
    }

    [HttpGet]
    public IActionResult AddEmployee()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddEmployee(int id, AddEmployee form)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var context = new BankContext();

                var name = form.Name;
                var civilId = form.CivilId;
                var position = form.Position;

                var bank = context.BankBranches.Find(id);

                bank.Employees.Add(new Employee
                {
                    Name = name,
                    CivilId = civilId,
                    Position = position, Phone = ""
                });
                context.SaveChanges();
                //return View();
            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("CivilId", "Duplicate Civil ID");
                return View(form);
            }
        }
        else
        {
            return View(form);
        }
        return RedirectToAction("Details", new { id = id });

    }


}

