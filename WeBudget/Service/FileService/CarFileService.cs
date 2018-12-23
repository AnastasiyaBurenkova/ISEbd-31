using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using WeBudget.Models;
using WeBudget.Service.Interface;

namespace WeBudget.Service.FileService
{
    public class CarFileService: ICar
    {
        BudgetContext db = new BudgetContext();
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Car";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(Car));

        public void Create(Car Car)
        {
            int max = 0;
            foreach (var path in Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly))
            {
                Match m = Regex.Match(path, @"Car\d+");
                int currentId = Convert.ToInt32(m.Value.Replace("Car", ""));
                if (currentId > max)
                {
                    max = currentId;
                }
            }
            int id = max + 1;
            Car.Id = id;
            string newFilePath = currentPath + "/Car" + id + ".txt";
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, Car);
            File.WriteAllText(newFilePath, txtWriter.ToString());
            txtWriter.Close();
        }

        public void Delete(int id)
        {
            File.Delete(currentPath + "/Car" + id + ".txt");
        }

        public void Edit(Car Car)
        {
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, Car);
            File.WriteAllText(currentPath + "/Car" + Car.Id + ".txt", txtWriter.ToString());
            txtWriter.Close();

        }

        public Car findCarById(int? id)
        {
            Car Car;
            using (StreamReader stream = new StreamReader(currentPath + "/Car" + id + ".txt", true))
            {
                Car = (Car)xsSubmit.Deserialize(stream);
                stream.Close();
            }
            return Car;
        }

        public List<Car> getList()
        {
            string[] filesPaths = Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly);
            List<Car> CarList = new List<Car>();
            foreach (string item in filesPaths)
            {
                StreamReader stream = new StreamReader(item, true);
                Car Car = (Car)xsSubmit.Deserialize(stream);
                CarList.Add(Car);
                stream.Close();
            }
            return CarList;
        }

        public void Dispose()
        {
            db.Dispose();
        }
}
}