using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;

namespace WeBudget.Service
{
	public class CarService
	{
		BudgetContext db = new BudgetContext();
		public void Delete(int id) {
            Car b = db.Dohods.Find(id);
            if (b != null)
            {
                db.Dohods.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(Car dohod) {
            db.Entry(dohod).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(Car dohod) {
            db.Dohods.Add(dohod);
            db.SaveChanges();
        }

        public Car findDohodById(int? id)
        {
            Car dohod = db.Dohods.Find(id);
            return dohod;
        }

        public List<Car> getList()
        {
            return db.Dohods.ToList();
        }

        public void Dispose() {
            db.Dispose();
        }


    }
}