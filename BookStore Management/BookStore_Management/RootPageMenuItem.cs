﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore_Management
{

    public class RootPageMenuItem
    {
        //public RootPageMenuItem()
        //{
        //    TargetType = typeof(RootPageDetail);
        //}
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}