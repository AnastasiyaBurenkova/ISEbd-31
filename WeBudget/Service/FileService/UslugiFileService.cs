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
    public class UslugiFileService: IUslugi
    {
        BudgetContext db = new BudgetContext();
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Uslugi";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(Uslugi));

        public void Create(Uslugi Uslugi)
        {
            int max = 0;
            foreach (var path in Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly))
            {
                Match m = Regex.Match(path, @"Uslugi\d+");
                int currentId = Convert.ToInt32(m.Value.Replace("Uslugi", ""));
                if (currentId > max)
                {
                    max = currentId;
                }
            }
            int id = max + 1;
            Uslugi.Id = id;
            string newFilePath = currentPath + "/Uslugi" + id + ".txt";
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, Uslugi);
            File.WriteAllText(newFilePath, txtWriter.ToString());
            txtWriter.Close();
        }

        public void Delete(int id)
        {
            File.Delete(currentPath + "/Uslugi" + id + ".txt");
        }

        public void Edit(Uslugi Uslugi)
        {
            StringWriter txtWriter = new StringWriter();
            xsSubmit.Serialize(txtWriter, Uslugi);
            File.WriteAllText(currentPath + "/Uslugi" + Uslugi.Id + ".txt", txtWriter.ToString());
            txtWriter.Close();

        }

        public Uslugi findUslugiById(int? id)
        {
            Uslugi Uslugi;
            using (StreamReader stream = new StreamReader(currentPath + "/Uslugi" + id + ".txt", true))
            {
                Uslugi = (Uslugi)xsSubmit.Deserialize(stream);
                stream.Close();
            }
            return Uslugi;
        }

        public List<Uslugi> getList()
        {
            string[] filesPaths = Directory.GetFiles(currentPath, "*", SearchOption.TopDirectoryOnly);
            List<Uslugi> UslugiList = new List<Uslugi>();
            foreach (string item in filesPaths)
            {
                StreamReader stream = new StreamReader(item, true);
                Uslugi Uslugi = (Uslugi)xsSubmit.Deserialize(stream);
                UslugiList.Add(Uslugi);
                stream.Close();
            }
            return UslugiList;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}