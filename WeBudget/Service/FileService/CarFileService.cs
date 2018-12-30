﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Serialization;
using WeCrossroad.Models;
using WeCrossroad.Service.Abstract;

namespace WeCrossroad.Service.FileService
{
    public class CarFileService: AbstractClass
    {
        string Name = "Car";
        string currentPath = HttpContext.Current.Server.MapPath("~") + "/Files/Car";
        XmlSerializer xsSubmit = new XmlSerializer(typeof(Car));

        public CarFileService()
        {
            base.Name = Name;
            base.xsSubmit = xsSubmit;
            base.currentPath = currentPath;
        }
}
}