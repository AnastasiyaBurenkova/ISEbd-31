using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;

namespace WeBudget.Service
{
	public class UslugService
	{
        BudgetContext db = new BudgetContext();
        public void Delete(int id)
        {
            Uslug b = db.Rashods.Find(id);
            if (b != null)
            {
                db.Rashods.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(Uslug rashod)
        {
            db.Entry(rashod).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(Uslug rashod)
        {
            db.Rashods.Add(rashod);
            db.SaveChanges();
        }

        public Uslug findRashodById(int? id)
        {
            Uslug rashod = db.Rashods.Find(id);
            return rashod;
        }

       /* public List<Rashod> getList()
        {
            return db.Rashods.ToList();
 
        }*/

        public void Dispose()
        {
            db.Dispose();
        }

    }
}
