﻿using AionHR.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionHR.Model.Company.Structure
{
    public class Department :ModelBase, IEntity
    {
        public string reference { get; set; }
        public string name { get; set; }
        public string parentName { get; set; }
        public int? parentId { get; set; }
        public int? supervisorId { get; set; }
        public string supervisorName { get; set; }
        public string segmentCode { get; set; }
        public bool isSegmentHead { get; set; }
    }
}
