using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;
using WeBudget.Service.Interface;

namespace WeBudget.Service
{
	public class UslugiService: IUslugi
	{
        BudgetContext db = new BudgetContext();
        public void Delete(int id)
        {
            Uslugi b = db.Uslugis.Find(id);
            if (b != null)
            {
                db.Uslugis.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(Uslugi Uslugi)
        {
            db.Entry(Uslugi).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(Uslugi Uslugi)
        {
            db.Uslugis.Add(Uslugi);
            db.SaveChanges();
        }

        public Uslugi findUslugiById(int? id)
        {
            Uslugi Uslugi = db.Uslugis.Find(id);
            return Uslugi;
        }

        public List<Uslugi> getList()
        {
            return db.Uslugis.ToList();
 
        }

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
