﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MissionPlanningWebApp.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        [Display(Name="Equipment")]
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Firepower { get; set; }
        public string Category { get; set; }
    }
}