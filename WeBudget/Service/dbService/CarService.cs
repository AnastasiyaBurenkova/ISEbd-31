using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;
using WeBudget.Service.Interface;

namespace WeBudget.Service
{
	public class CarService : ICar
	{
		BudgetContext db = new BudgetContext();
		public void Delete(int id) {
            Car b = db.Cars.Find(id);
            if (b != null)
            {
                db.Cars.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(Car Car) {
            db.Entry(Car).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Create(Car Car) {
            db.Cars.Add(Car);
            db.SaveChanges();
        }

        public Car findCarById(int? id)
        {
            Car Car = db.Cars.Find(id);
            return Car;
        }

        public List<Car> getList()
        {
            return db.Cars.ToList();
        }

        public void Dispose() {
            db.Dispose();
        }


    }
}