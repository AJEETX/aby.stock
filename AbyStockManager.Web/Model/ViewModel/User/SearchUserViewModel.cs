using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.User
{
    public class SearchUserViewModel : BaseViewModel
    {

        [Display]
        public string Email { get; set; }

        [Display]
        public string Name { get; set; }

        [Display]
        public string Surname { get; set; }
    }
}
