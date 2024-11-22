using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ContractMonthlyClaimSystem.Web.Data;
using ContractMonthlyClaimSystem.Web.Models;

namespace ContractMonthlyClaimSystem.Web.Controllers
{
    [Authorize(Roles = "ProgrammeCoordinator,AcademicManager")]
    public class ClaimController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClaimController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "ProgrammeCoordinator")]
        public IActionResult PendingClaims()
        {
            var claims = _context.Claims.Where(c => c.Status == "Pending").ToList();
            return View(claims);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Approve(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim == null)
            {
                return NotFound();
            }

            if (claim.HoursWorked > 40)
            {
                ModelState.AddModelError("", "Cannot approve claims with hours exceeding 40.");
                return View("PendingClaims", _context.Claims.Where(c => c.Status == "Pending").ToList());
            }

            claim.Status = "Approved";
            _context.SaveChanges();
            return RedirectToAction("PendingClaims");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Reject(int id)
        {
            var claim = _context.Claims.Find(id);
            if (claim == null)
            {
                return NotFound();
            }

            claim.Status = "Rejected";
            _context.SaveChanges();
            return RedirectToAction("PendingClaims");
        }
    }
}

