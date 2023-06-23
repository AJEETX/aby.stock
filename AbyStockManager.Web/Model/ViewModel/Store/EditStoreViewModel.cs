﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using Aby.StockManager.Model.ViewModel.Base;

using Microsoft.AspNetCore.Http;

namespace Aby.StockManager.Model.ViewModel.Store
{
    public class EditStoreViewModel : BaseViewModel
    {
        [Required]
        [MaxLength(30)]
        [Display(Name = "Name")]
        public string StoreName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Details")]
        public string StoreCode { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        [Display(Name = "Image")]
        [RegularExpression(@"^.*\.(jpg|JPG|png|PNG|jpeg|JPEG)$")]
        public IFormFile ImageFile { get; set; }

        public string ImageDisplayURL { get; set; }
    }
}