using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using WeBudget.Models;
using WeBudget.Service.Abstract;

namespace WeBudget.Service.FileService
{
    public class UslugiFileService : AbstractClass
    {
        string Name = "Uslugi";
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Uslugi";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(Uslugi));

        public UslugiFileService()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }

    }
}