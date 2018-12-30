using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeCrossroad.Models;
using WeCrossroad.Service.Abstract;

namespace WeCrossroad.Service
{
	public class UslugiService : ICrossroad
	{
        CrossroadContext db = new CrossroadContext();
        public  void Delete(int id)
        {
            Uslugi b = db.Uslugis.Find(id);
            if (b != null)
            {
                db.Uslugis.Remove(b);
                db.SaveChanges();
            }
        }

        public  void Edit (BaseEntity baseEntity)
        {
            db.Entry((Uslugi)baseEntity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public  void Create(BaseEntity baseEntity)
        {
            db.Uslugis.Add((Uslugi)baseEntity);
            db.SaveChanges();
        }

        public  BaseEntity findById(int? id)
        {
            Uslugi Uslugi = db.Uslugis.Find(id);
            return Uslugi;
        }

        public  List<BaseEntity> getList()
        {
            List<BaseEntity> baseentity = new List<BaseEntity>();
            List<Uslugi> Uslugi = db.Uslugis.ToList();
            for (int i = 0; i < Uslugi.Count; i++)
            {
                baseentity.Add(Uslugi[i]);
            }
            return baseentity;

        }

       
    }
}
