using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeCrossroad.Service.Abstract;

namespace WeCrossroad.Models
{
    [Serializable]
    public class Car : BaseEntity
    {

        public int Day { get; set; }

        public int Month { get; set; }

        public double Sum { get; set; }

        public string Comment { get; set; }

        public int UserId { get; set; }

        //public User User { get; set; }

    }
}