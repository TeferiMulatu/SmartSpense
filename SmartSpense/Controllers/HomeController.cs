using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SmartSpense.Models;

namespace SmartSpense.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SmartSpenseDbContext _context;
        public HomeController(ILogger<HomeController> logger,SmartSpenseDbContext context )
        {
            _logger = logger;
            _context = context;
           
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList();
            var TotalExpenses=allExpenses.Sum(expense => expense.Value);
            ViewBag.expenses = TotalExpenses;
            return View(allExpenses);
        }
        public IActionResult CreateEditExpense(int? Id)
        {
            if (Id != null)
            {
                var ExpenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == Id);
                return View(ExpenseInDb);
            }
            return View();
        }
        public IActionResult DeleteExpense(int Id)
        {
            var ExpenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == Id);
            _context.Expenses.Remove(ExpenseInDb);
            _context.SaveChanges();
            return RedirectToAction("Expenses");
        }
        public IActionResult CreateEditExpenseForm(Expense model)

        {
            if (model.Id == 0)
            {//create sth
 _context.Expenses.Add(model);
            }
            else
            {
                _context.Expenses.Update(model);
            }

                _context.SaveChanges();
            return RedirectToAction("Expenses");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
