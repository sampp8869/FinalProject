using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using FinalProject.ViewModels;

namespace FinalProject.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult List(CKeywordViewModel vm)
        {
            IEnumerable<TCustomer> datas = null;
            FinalProjectContext db = new FinalProjectContext();
            if (string.IsNullOrEmpty(vm.txtKeyword))
                datas = from t in db.TCustomers
                    select t;
            else
                datas = db.TCustomers.Where(t => t.FLastName.Contains(vm.txtKeyword) ||
                  t.FFirstName.Contains(vm.txtKeyword) ||
                  t.FTel.Contains(vm.txtKeyword) ||
                  t.FEmail.Contains(vm.txtKeyword) ||
                  t.FMobile.Contains(vm.txtKeyword) ||
                  t.FPassword.Contains(vm.txtKeyword));
            return View(datas);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TCustomer p)
        {
            FinalProjectContext db = new FinalProjectContext();
            db.TCustomers.Add(p);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                FinalProjectContext db = new FinalProjectContext();
                TCustomer delCustomer = db.TCustomers.FirstOrDefault(t => t.FId == id);
                if (delCustomer != null)
                {
                    db.TCustomers.Remove(delCustomer);
                    db.SaveChangesAsync();
                }
            }
            return RedirectToAction("List");
        }
        public ActionResult Edit(int? id)
        {
            if (id != null)
            {
                FinalProjectContext db = new FinalProjectContext();
                TCustomer x = db.TCustomers.FirstOrDefault(t => t.FId == id);
                if (x != null)
                    return View(x);
            }
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Edit(TCustomer p)
        {
            FinalProjectContext db = new FinalProjectContext();
            TCustomer x = db.TCustomers.FirstOrDefault(t => t.FId == p.FId);
            if (x != null)
            {
                x.FFirstName = p.FLastName;
                x.FLastName = p.FFirstName;
                x.FGender = p.FGender;
                x.FTel = p.FTel;
                x.FMobile = p.FMobile;
                x.FEmail = p.FEmail;
                x.FPassword = p.FPassword;
                x.FBirthDate= p.FBirthDate;
                x.FPoint = p.FPoint;
                x.FRemark= p.FRemark;
                x.FBlackList= p.FBlackList;
                x.FCreationDate= p.FCreationDate;
                x.FLastUpdateDate= p.FLastUpdateDate;

                db.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
        public ActionResult Detail(int? id)
        {
            if (id != null)
            {
                FinalProjectContext db = new FinalProjectContext();
                TCustomer x = db.TCustomers.FirstOrDefault(t => t.FId == id);
                if (x != null)
                    return View(x);
            }
            return RedirectToAction("List");
        }
    }
}
