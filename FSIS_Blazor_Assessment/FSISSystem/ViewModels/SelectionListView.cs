﻿
#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSISSystem.ViewModels
{
   
    public class SelectionListView
    {
        //common class used to hold 2 values for use in a select list scenario
        //  such as a drop down list
        public int ValueID { get; set; }
        public string DisplayText { get; set; }
    }
   
}
