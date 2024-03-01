using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.Service
{
    public class ListServiceReportViewModel : BaseViewModel
    {
        public string ItemName { get; set; }

        [Display(Name = "Service Type Name")]
        public string ServiceCategory { get; set; }

        public string Amount { get; set; }
        public string ServiceDate { get; set; }
    }
}