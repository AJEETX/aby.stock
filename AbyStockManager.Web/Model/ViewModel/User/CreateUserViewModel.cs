using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Aby.StockManager.Model.ViewModel.Base;

namespace Aby.StockManager.Model.ViewModel.User
{
    public class CreateUserViewModel: BaseViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(18)]
        [Display]
        public string Password { get; set; }

        [Required]
        [MaxLength(30)]
        [Display]
        public string Name { get; set; }

        [Required]
        [MaxLength(30)]
        [Display]
        public string Surname { get; set; }
    }
}
