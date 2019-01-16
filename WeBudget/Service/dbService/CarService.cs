using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeBudget.Models;
using WeBudget.Service.Abstract;

namespace WeBudget.Service
{
	public class CarService : ICrossroad
	{
		CrossroadContext db = new CrossroadContext();
		public  void Delete(int id) {
            Car b = db.Cars.Find(id);
            if (b != null)
            {
                db.Cars.Remove(b);
                db.SaveChanges();
            }
        }

        public void Edit(BaseEntity baseEntity) {
            db.Entry((Car)baseEntity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public  void Create(BaseEntity baseEntity) {
            db.Cars.Add((Car)baseEntity);
            db.SaveChanges();
        }

        public BaseEntity findById(int? id)
        {
            Car Car = db.Cars.Find(id);
            return Car;
        }

        public  List<BaseEntity> getList()
        {
            List < BaseEntity > baseentity = new List <BaseEntity>();
            List<Car> Car = db.Cars.ToList();
            for (int i = 0; i < Car.Count; i++) {
                baseentity.Add(Car[i]);
            }
            return baseentity;
        }

    }
}