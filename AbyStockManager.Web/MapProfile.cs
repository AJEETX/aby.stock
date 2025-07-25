﻿using System;
using System.Globalization;
using System.Linq;

using Aby.StockManager.Data.Entity;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Model.ViewModel.Category;
using Aby.StockManager.Model.ViewModel.Expense;
using Aby.StockManager.Model.ViewModel.ExpenseCategory;
using Aby.StockManager.Model.ViewModel.JsonResult;
using Aby.StockManager.Model.ViewModel.Product;
using Aby.StockManager.Model.ViewModel.Report.StoreStock;
using Aby.StockManager.Model.ViewModel.Report.TransactionDetail;
using Aby.StockManager.Model.ViewModel.Service;
using Aby.StockManager.Model.ViewModel.ServiceCategory;
using Aby.StockManager.Model.ViewModel.Store;
using Aby.StockManager.Model.ViewModel.Transaction;
using Aby.StockManager.Model.ViewModel.UnitOfMeasure;
using Aby.StockManager.Model.ViewModel.User;

using AbyStockManager.Web.Model.ViewModel.Report.StoreStock;
using AbyStockManager.Web.Model.ViewModel.Tax;

using AutoMapper;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Aby.StockManager.Mapper
{
    public class MapProfile : Profile
    {
        private static CultureInfo hindi = new CultureInfo("hi-IN");
        private static NumberFormatInfo hindiNFO = (NumberFormatInfo)hindi.NumberFormat.Clone();
        public MapProfile()
        {
            hindiNFO.CurrencySymbol = string.Empty;

            #region DTO & ViewModel

            CreateMap<SearchServiceReportViewModel, ServiceReportDTO>()
    .ForMember(dm => dm.SearchStartDate, vm => vm.MapFrom(vmf =>
    !string.IsNullOrWhiteSpace(vmf.SearchStartDate) ?
    DateTime.ParseExact(vmf.SearchStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) :
    DateTime.MinValue
    ))
     .ForMember(dm => dm.SearchEndDate, vm => vm.MapFrom(vmf =>
    !string.IsNullOrWhiteSpace(vmf.SearchEndDate) ?
    DateTime.ParseExact(vmf.SearchEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) :
    DateTime.MaxValue
    ))
    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<CreateServiceCategoryViewModel, ServiceCategoryDTO>()
                 .ForMember(x => x.ServiceCategoryName, vm => vm.MapFrom(vmf => vmf.ServiceCategoryName));

            CreateMap<ServiceCategoryDTO, CreateServiceCategoryViewModel>()
            .ForMember(x => x.ServiceCategoryName, vm => vm.MapFrom(vmf => vmf.ServiceCategoryName));

            CreateMap<EditServiceCategoryViewModel, ServiceCategoryDTO>()
                 .ForMember(x => x.ServiceCategoryName, vm => vm.MapFrom(vmf => vmf.ServiceCategoryName));

            CreateMap<ServiceCategoryDTO, EditServiceCategoryViewModel>()
                 .ForMember(x => x.ServiceCategoryName, vm => vm.MapFrom(vmf => vmf.ServiceCategoryName));

            CreateMap<ListServiceCategoryViewModel, ServiceCategoryDTO>()
     .ForMember(x => x.ServiceCategoryName, vm => vm.MapFrom(vmf => vmf.ServiceCategoryName));

            CreateMap<ServiceCategoryDTO, ListServiceCategoryViewModel>()
     .ForMember(x => x.ServiceCategoryName, vm => vm.MapFrom(vmf => vmf.ServiceCategoryName));

            CreateMap<SearchServiceCategoryViewModel, ServiceCategoryDTO>()
    .ForMember(x => x.ServiceCategoryName, vm => vm.MapFrom(vmf => vmf.ServiceCategoryName));

            CreateMap<ServiceCategoryDTO, SearchServiceCategoryViewModel>()
    .ForMember(x => x.ServiceCategoryName, vm => vm.MapFrom(vmf => vmf.ServiceCategoryName));

            CreateMap<ServiceCategoryDTO, ServiceCategory>()
   .ForMember(x => x.ServiceCategoryName, vm => vm.MapFrom(vmf => vmf.ServiceCategoryName));

            CreateMap<ServiceCategory, ServiceCategoryDTO>()
  .ForMember(x => x.ServiceCategoryName, vm => vm.MapFrom(vmf => vmf.ServiceCategoryName));

            CreateMap<CreateExpenseCategoryViewModel, ExpenseCategoryDTO>()
                .ForMember(x => x.CategoryName, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<ExpenseCategoryDTO, CreateExpenseCategoryViewModel>()
              .ForMember(x => x.CategoryName, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<EditExpenseCategoryViewModel, ExpenseCategoryDTO>()
             .ForMember(x => x.CategoryName, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<ExpenseCategoryDTO, EditExpenseCategoryViewModel>()
              .ForMember(x => x.CategoryName, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<ListExpenseCategoryViewModel, ExpenseCategoryDTO>()
                .ForMember(x => x.CategoryName, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<ExpenseCategoryDTO, ListExpenseCategoryViewModel>()
              .ForMember(x => x.CategoryName, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<SearchExpenseCategoryViewModel, ExpenseCategoryDTO>()
                .ForMember(x => x.CategoryName, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<ExpenseCategoryDTO, SearchExpenseCategoryViewModel>()
              .ForMember(x => x.CategoryName, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<ExpenseCategory, ExpenseCategoryDTO>()
                .ForMember(x => x.CategoryName, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<ExpenseCategoryDTO, ExpenseCategory>()
              .ForMember(x => x.CategoryName, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<ServiceResult, JsonResultModel>();

            CreateMap<CreateCategoryViewModel, CategoryDTO>();

            CreateMap<SearchCategoryViewModel, CategoryDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<CreateTaxViewModel, TaxDTO>()
                .ForMember(dm => dm.Name, vm => vm.MapFrom(vmf => vmf.Name))
                .ForMember(dm => dm.Rate, vm => vm.MapFrom(vmf => double.Parse(vmf.Rate)))
                ;

            CreateMap<SearchTaxViewModel, TaxDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<TaxDTO, ListTaxViewModel>()
                .ForMember(dm => dm.Rate, vm => vm.MapFrom(vmf => string.Format("{0:P2}", vmf.Rate / 100)))
                ;
            CreateMap<TaxDTO, EditTaxViewModel>();
            CreateMap<EditTaxViewModel, TaxDTO>();

            CreateMap<TaxDTO, SelectListItem>()
                   .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
                   .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => vmf.Rate));

            CreateMap<CategoryDTO, ListCategoryViewModel>();
            CreateMap<CategoryDTO, EditCategoryViewModel>();
            CreateMap<EditCategoryViewModel, CategoryDTO>();
            CreateMap<CategoryDTO, SelectListItem>()
                   .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
                   .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<ExpenseCategoryDTO, SelectListItem>()
               .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
               .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => vmf.CategoryName));

            CreateMap<ServiceCategoryDTO, SelectListItem>()
               .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
               .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => vmf.ServiceCategoryName));
            CreateMap<CreateUnitOfMeasureViewModel, UnitOfMeasureDTO>();
            CreateMap<SearchUnitOfMeasureViewModel, UnitOfMeasureDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<UnitOfMeasureDTO, ListUnitOfMeasureViewModel>();
            CreateMap<UnitOfMeasureDTO, EditUnitOfMeasureViewModel>();
            CreateMap<EditUnitOfMeasureViewModel, UnitOfMeasureDTO>();
            CreateMap<UnitOfMeasureDTO, SelectListItem>()
                   .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
                   .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => vmf.UnitOfMeasureName + "-" + vmf.Isocode));

            CreateMap<CreateUserViewModel, UserDTO>();
            CreateMap<SearchUserViewModel, UserDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<UserDTO, ListUserViewModel>()
                 .ForMember(dm => dm.ImageDisplay, vm => vm.MapFrom(vmf => !string.IsNullOrEmpty(vmf.Image) ? "/user/" + vmf.Image : "/dist/img/no-user-image.png"));

            CreateMap<UserDTO, EditUserViewModel>();
            CreateMap<EditUserViewModel, UserDTO>();

            CreateMap<CreateStoreViewModel, StoreDTO>();
            CreateMap<SearchStoreViewModel, StoreDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<StoreDTO, ListStoreViewModel>()
                 .ForMember(dm => dm.ImageDisplay, vm => vm.MapFrom(vmf => !string.IsNullOrEmpty(vmf.Image) ? "/store/" + vmf.Image : "/dist/img/no-image.png"));
            ;
            CreateMap<StoreDTO, EditStoreViewModel>();
            CreateMap<EditStoreViewModel, StoreDTO>();
            CreateMap<StoreDTO, SelectListItem>()
                    .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
                    .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => vmf.StoreCode + "-" + vmf.StoreName));

            CreateMap<CreateProductViewModel, ProductDTO>();
            CreateMap<SearchProductViewModel, ProductDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<ProductDTO, ListProductViewModel>()
                 .ForMember(dm => dm.ImageDisplay, vm => vm.MapFrom(vmf => !string.IsNullOrEmpty(vmf.Image) ? "/upload/" + vmf.Image : "/dist/img/no-image.png"))
                 .ForMember(dm => dm.SalePrice, vm => vm.MapFrom(vmf => vmf.SalePrice.HasValue ? string.Format(hindiNFO, "{0:c}", vmf.SalePrice.Value) : "-"))
                 .ForMember(dm => dm.PurchasePrice, vm => vm.MapFrom(vmf => vmf.PurchasePrice.HasValue ? string.Format(hindiNFO, "{0:c}", vmf.PurchasePrice.Value) : "-"))
                 .ForMember(dm => dm.Tax, vm => vm.MapFrom(vmf => vmf.TaxRate != null ? string.Format("{0:P2}", vmf.TaxRate / 100) : "-"))
                 ;

            CreateMap<ProductDTO, CreateProductViewModel>();
            CreateMap<CreateProductViewModel, ProductDTO>();
            CreateMap<ProductDTO, EditProductViewModel>();
            CreateMap<EditProductViewModel, ProductDTO>();
            CreateMap<ProductDTO, SelectListItem>()
                    .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
                    .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => vmf.ProductName + " - " + string.Format(hindiNFO, "{0:c}", (vmf.PurchasePrice))));

            //CreateMap<CreateTransactionViewModel, TransactionDTO>()
            //    .ForMember(dm => dm.TransactionDate, vm => vm.MapFrom(vmf => vmf.TransactionDate));

            CreateMap<CreateTransactionViewModel, TransactionDTO>().ForMember(x => x.TransactionDate, y => y.MapFrom(z => DateTime.ParseExact(z.TransactionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)));

            CreateMap<TransactionDetailViewModel, TransactionDetailDTO>();
            CreateMap<TransactionDetailDTO, TransactionDetailViewModel>()
                .ForMember(x => x.Price, vm => vm.MapFrom(
                    vmf => vmf.InvoiceNumber != null && vmf.InvoiceNumber.Contains(Common.Enums.TransactionType.Invoice.ToString().Substring(0, 3)) ? vmf.FinalSalePrice : vmf.PurchasePrice));

            CreateMap<SearchExpenseReportViewModel, ExpenseReportDTO>()
                .ForMember(dm => dm.SearchStartDate, vm => vm.MapFrom(vmf =>
                !string.IsNullOrWhiteSpace(vmf.SearchStartDate) ?
                DateTime.ParseExact(vmf.SearchStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) :
                DateTime.MinValue
                ))
                 .ForMember(dm => dm.SearchEndDate, vm => vm.MapFrom(vmf =>
                !string.IsNullOrWhiteSpace(vmf.SearchEndDate) ?
                DateTime.ParseExact(vmf.SearchEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) :
                DateTime.MaxValue
                ))
                .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<SearchTransactionViewModel, TransactionDTO>()
                .ForMember(dm => dm.SearchStartDate, vm => vm.MapFrom(vmf =>
                !string.IsNullOrWhiteSpace(vmf.SearchStartDate) ?
                DateTime.ParseExact(vmf.SearchStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) :
                DateTime.MinValue
                ))
                 .ForMember(dm => dm.SearchEndDate, vm => vm.MapFrom(vmf =>
                !string.IsNullOrWhiteSpace(vmf.SearchEndDate) ?
                DateTime.ParseExact(vmf.SearchEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) :
                DateTime.MaxValue
                ))
                .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<TransactionDTO, ListTransactionViewModel>()
                 .ForMember(dm => dm.TransactionDate, vm => vm.MapFrom(vmf => string.Format("{0:D}", vmf.TransactionDate)))
                 .ForMember(dm => dm.Amount, vm => vm.MapFrom(vmf => string.Format(hindiNFO, "{0:c}",
                 (vmf.TransactionDetail.Sum(r => (r.InvoiceNumber.Contains("inv", StringComparison.OrdinalIgnoreCase) ? r.FinalSalePrice : r.PurchasePrice) * r.Amount)))))
                 .ForMember(dm => dm.AmountWithGst, vm => vm.MapFrom(vmf => string.Format(hindiNFO, "{0:c}",
                 (vmf.TransactionDetail.Sum(r => (r.InvoiceNumber.Contains("inv", StringComparison.OrdinalIgnoreCase) ? r.FinalSalePrice : r.PurchasePrice) * r.Amount)))))
                 .ForMember(dm => dm.AmountWithoutGst, vm => vm.MapFrom(vmf => string.Format(hindiNFO, "{0:c}",
                 vmf.TransactionDetail.Sum(t => t.Amount * (t.InvoiceNumber.Contains("inv", StringComparison.OrdinalIgnoreCase) ? t.FinalSalePrice : t.PurchasePrice) * ((double)100 / ((double)100 + t.TaxRate))))))
                 .ForMember(dm => dm.CGst, vm => vm.MapFrom(vmf =>
                 string.Format(hindiNFO, "{0:c}", !vmf.Igst ?
                 vmf.TransactionDetail.Sum(t => ((t.Amount * (t.InvoiceNumber.Contains("inv", StringComparison.OrdinalIgnoreCase) ?
                 t.FinalSalePrice : t.PurchasePrice)) - ((t.InvoiceNumber.Contains("inv", StringComparison.OrdinalIgnoreCase) ?
                 t.FinalSalePrice : t.PurchasePrice) * (100 / (100 + t.TaxRate)) * t.Amount)) / 2
                 ) : 0)))
                 .ForMember(dm => dm.SGst, vm => vm.MapFrom(vmf => string.Format(hindiNFO, "{0:c}", !vmf.Igst ?
                 (vmf.TransactionDetail.Sum(t =>
                 (
                 (t.Amount * (t.InvoiceNumber.Contains("inv", StringComparison.OrdinalIgnoreCase) ? t.FinalSalePrice : t.PurchasePrice))
                 - ((t.InvoiceNumber.Contains("inv", StringComparison.OrdinalIgnoreCase) ? t.FinalSalePrice : t.PurchasePrice) * (100 / (100 + t.TaxRate)) * t.Amount)) / 2
                 )) : 0)))
                 .ForMember(dm => dm.IGst, vm => vm.MapFrom(vmf => string.Format(hindiNFO, "{0:c}", vmf.Igst ?
                 (vmf.TransactionDetail.Sum(t =>
                 (
                 (t.Amount * (t.InvoiceNumber.Contains("inv", StringComparison.OrdinalIgnoreCase) ? t.FinalSalePrice : t.PurchasePrice))
                 - ((t.InvoiceNumber.Contains("inv", StringComparison.OrdinalIgnoreCase) ? t.FinalSalePrice : t.PurchasePrice) * (100 / (100 + t.TaxRate)) * t.Amount))
                 )) : 0)))
                 .ForMember(dest => dest.ProductNamesWithQuantities, opt => opt.MapFrom(src =>
        string.Join(", ", src.TransactionDetail
            .Where(td => !string.IsNullOrWhiteSpace(td.ProductName) && td.Amount.HasValue)
            .Select(td => $"{td.ProductName} ({td.Amount})"))))
                 .ForMember(dest => dest.ProductNamesWithQuantitiesMultiline, opt => opt.MapFrom(src =>
    string.Join("<br/>", src.TransactionDetail
        .Where(td => !string.IsNullOrWhiteSpace(td.ProductName) && td.Amount.HasValue)
        .Select(td => $"{td.ProductName} ({td.Barcode}) = {td.Amount}, "))));

            CreateMap<TransactionDTO, EditTransactionViewModel>()
                .ForMember(x => x.TransactionDate, y => y.MapFrom(z => z.TransactionDate.ToString("dd/MM/yyyy")))
                ;
            CreateMap<EditTransactionViewModel, TransactionDTO>()
                .ForMember(x => x.TransactionDate, y => y.MapFrom(
                    z => DateTime.ParseExact(z.TransactionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                ;

            CreateMap<SearchStoreStockReportViewModel, StoreStockDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<StoreStockDTO, ListStoreStockReportViewModel>()
                 .ForMember(dm => dm.ProductFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.Barcode, vmf.ProductName)))
                 .ForMember(dm => dm.StoreFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.StoreCode, vmf.StoreName)))
                 .ForMember(dm => dm.ProductPrice, vm => vm.MapFrom(vmf => string.Format(hindiNFO, "{0:c}", (vmf.PurchasePrice))))
                 .ForMember(dm => dm.ProductTotalPrice, vm => vm.MapFrom(vmf => (vmf.PurchasePrice * vmf.Stock).ToString()))
                 .ForMember(dm => dm.ProductTotalDisplayPrice, vm => vm.MapFrom(vmf => string.Format(hindiNFO, "{0:c}", (vmf.PurchasePrice * vmf.Stock))))
                 .ForMember(dm => dm.QTY, vm => vm.MapFrom(vmf => string.Format("{0} ({1})", vmf.Stock.ToString(), vmf.Isocode)))
                 .ForMember(dm => dm.Quantity, vm => vm.MapFrom(vmf => int.Parse(vmf.Stock.ToString())))
                 ;

            CreateMap<StoreStockDTO, EditStoreStockReportViewModel>();
            CreateMap<EditStoreStockReportViewModel, StoreStockDTO>()
                ;

            CreateMap<StoreStockDTO, StoreStock>();

            CreateMap<SearchTransactionDetailReportViewModel, TransactionDetailReportDTO>()
                        .ForMember(dm => dm.SearchStartDate, vm => vm.MapFrom(vmf =>
                !string.IsNullOrWhiteSpace(vmf.SearchStartDate) ?
                DateTime.ParseExact(vmf.SearchStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) :
                DateTime.MinValue
                ))
                 .ForMember(dm => dm.SearchEndDate, vm => vm.MapFrom(vmf =>
                !string.IsNullOrWhiteSpace(vmf.SearchEndDate) ?
                DateTime.ParseExact(vmf.SearchEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) :
                DateTime.MaxValue
                ))
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<TransactionDetailReportDTO, ListTransactionDetailReportViewModel>()
                 .ForMember(dm => dm.ProductFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.Barcode, vmf.ProductName)))
                 .ForMember(dm => dm.StoreFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.StoreCode, vmf.StoreName)))
                 .ForMember(dm => dm.ProductPrice, vm => vm.MapFrom(vmf =>
                 vmf.TransactionCode == Common.Enums.TransactionType.Invoice.ToString() ? string.Format(hindiNFO, "{0:c}", (vmf.Price)) :
                 string.Format(hindiNFO, "{0:c}", (vmf.PurchasePrice))))
                 .ForMember(dm => dm.ProductPurchasePrice, vm =>
                 vm.MapFrom(vmf => string.Format(hindiNFO, "{0:c}", (vmf.PurchasePrice))))
                 .ForMember(dm => dm.ProductTotalPrice,
                 vm => vm.MapFrom(vmf =>
                 vmf.TransactionCode == Common.Enums.TransactionType.Invoice.ToString() ? string.Format(hindiNFO, "{0:c}", (vmf.Price * vmf.Amount)) :
                 string.Format(hindiNFO, "{0:c}", (vmf.PurchasePrice * vmf.Amount))))
                 .ForMember(dm => dm.ToStoreFullName, vm =>
                 vm.MapFrom(vmf => !string.IsNullOrEmpty(vmf.ToStoreName) ? string.Format("{1} ({0})", vmf.ToStoreCode, vmf.ToStoreName) : ""))
                 .ForMember(dm => dm.Amount, vm =>
                 vm.MapFrom(vmf => string.Format("{0} ({1})", vmf.Amount.ToString(), vmf.UnitOfMeasureShortName)))
                 .ForMember(dm => dm.TransactionDate,
                 vm => vm.MapFrom(vmf => string.Format("{0:D}", vmf.TransactionDate))); ;

            #endregion DTO & ViewModel

            #region Entity & DTO-

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();

            CreateMap<TaxDTO, Tax>();
            CreateMap<Tax, TaxDTO>();
            CreateMap<UnitOfMeasure, UnitOfMeasureDTO>();
            CreateMap<UnitOfMeasureDTO, UnitOfMeasure>();

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<Store, StoreDTO>();
            CreateMap<StoreDTO, Store>();

            CreateMap<ServiceReport, ServiceReportDTO>()
                 .ForMember(dm => dm.ServiceDate, vm => vm.MapFrom(vmf => vmf.ServiceDate.ToString("dd/MM/yyyy")))
                 .ForMember(dm => dm.ServiceCategoryName, vm => vm.MapFrom(vmf => vmf.ServiceCategory != null ? vmf.ServiceCategory.ServiceCategoryName : "-"))
                ;

            CreateMap<ServiceReportDTO, ListServiceReportViewModel>()
                .ForMember(x => x.ServiceCategory, y => y.MapFrom(f => f.ServiceCategoryName))
                             .ForMember(dm => dm.Amount, vm => vm.MapFrom(vmf => string.Format(hindiNFO, "{0:c}", vmf.Amount)))
                 .ForMember(dm => dm.ServiceDate, vm => vm.MapFrom(vmf => string.Format("{0:D}", DateTime.ParseExact(vmf.ServiceDate, "dd/MM/yyyy", CultureInfo.InvariantCulture))));

            CreateMap<ListServiceReportViewModel, ServiceReportDTO>()
                .ForMember(x => x.ServiceCategoryName, y => y.MapFrom(f => f.ServiceCategory))
                ;

            CreateMap<ServiceReportDTO, EditServiceReportViewModel>();
            CreateMap<EditServiceReportViewModel, ServiceReportDTO>();
            CreateMap<ServiceReportDTO, ServiceReport>()
                 .ForMember(dm => dm.ServiceDate, vm => vm.MapFrom(vmf => DateTime.ParseExact(vmf.ServiceDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                ;
            CreateMap<CreateServiceReportViewModel, ServiceReportDTO>();

            CreateMap<ExpenseReport, ExpenseReportDTO>()
                 .ForMember(dm => dm.ExpenseDate, vm => vm.MapFrom(vmf => vmf.ExpenseDate.ToString("dd/MM/yyyy")))
                 .ForMember(dm => dm.CategoryName, vm => vm.MapFrom(vmf => vmf.Category != null ? vmf.Category.CategoryName : "-"))
                ;
            CreateMap<ExpenseReportDTO, ExpenseReport>();

            CreateMap<ExpenseReportDTO, ListExpenseReportViewModel>()
                .ForMember(x => x.Category, y => y.MapFrom(f => f.CategoryName))
                             .ForMember(dm => dm.Amount, vm => vm.MapFrom(vmf => string.Format(hindiNFO, "{0:c}", vmf.Amount)))
                 .ForMember(dm => dm.ExpenseDate, vm => vm.MapFrom(vmf => string.Format("{0:D}", DateTime.ParseExact(vmf.ExpenseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture))))
                             ;
            CreateMap<ListExpenseReportViewModel, ExpenseReportDTO>()
                .ForMember(x => x.CategoryName, y => y.MapFrom(f => f.Category))
                ;
            CreateMap<ExpenseReportDTO, EditExpenseReportViewModel>();
            CreateMap<EditExpenseReportViewModel, ExpenseReportDTO>();
            CreateMap<ExpenseReportDTO, ExpenseReport>()
                 .ForMember(dm => dm.ExpenseDate, vm => vm.MapFrom(vmf => DateTime.ParseExact(vmf.ExpenseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                ;
            CreateMap<CreateExpenseReportViewModel, ExpenseReportDTO>();

            CreateMap<Product, ProductDTO>()
                 .ForMember(dm => dm.CategoryName, vm => vm.MapFrom(vmf => vmf.Category != null ? vmf.Category.CategoryName : "-"))
                 .ForMember(dm => dm.Tax, vm => vm.MapFrom(vmf => vmf.Tax != null ? string.Format("{0:C}", vmf.Tax.Rate) : "-"))
                 .ForMember(dm => dm.TaxRate, vm => vm.MapFrom(vmf => vmf.Tax != null ? vmf.Tax.Rate : 0.0D))
                 .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.UnitOfMeasure != null ? vmf.UnitOfMeasure.Isocode : "-"));
            CreateMap<ProductDTO, Product>();

            CreateMap<Transaction, TransactionDTO>()
                .ForMember(dm => dm.StoreName, vm => vm.MapFrom(vmf => vmf.Store != null ? vmf.Store.StoreName + "-" + vmf.Store.StoreCode : "-"))
                .ForMember(dm => dm.ToStoreName, vm => vm.MapFrom(vmf => vmf.ToStore != null ? vmf.ToStore.StoreName + "-" + vmf.ToStore.StoreCode : "-"))
                .ForMember(dm => dm.TransactionTypeName, vm => vm.MapFrom(vmf => vmf.TransactionType != null ? vmf.TransactionType.TransactionTypeName : "-"));
            CreateMap<TransactionDTO, Transaction>();

            CreateMap<TransactionDetail, TransactionDetailDTO>()
                .ForMember(dm => dm.ProductName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.ProductName : ""))
                .ForMember(dm => dm.TaxRate, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.Tax.Rate : 0D))
                .ForMember(dm => dm.Price, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.SalePrice : 0D))
                .ForMember(dm => dm.PurchasePrice, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.PurchasePrice : 0D))
                .ForMember(dm => dm.Tax, vm => vm.MapFrom(vmf => vmf.Product != null ?
                string.Format("{0:P2}", vmf.Product.Tax.Rate / 100) : "--"))
                .ForMember(dm => dm.UnitPrice, vm => vm.MapFrom(vmf => (vmf.Transaction.InvoiceNumber != null &&
                vmf.Transaction.InvoiceNumber.Contains(Common.Enums.TransactionType.Invoice.ToString().Substring(0, 3)) ? string.Format(hindiNFO, "{0:c}", vmf.FinalSalePrice) :
                string.Format(hindiNFO, "{0:c}", vmf.Product.PurchasePrice))))
                .ForMember(dm => dm.SubTotalPrice, vm => vm.MapFrom(vmf =>
                (vmf.Transaction.InvoiceNumber != null && vmf.Transaction.InvoiceNumber.Contains(Common.Enums.TransactionType.Invoice.ToString().Substring(0, 3)) ?
                string.Format(hindiNFO, "{0:c}", (vmf.FinalSalePrice * (100 / (100 + vmf.Product.Tax.Rate)) * vmf.Amount)) :
                string.Format(hindiNFO, "{0:c}", (vmf.Product.PurchasePrice * (100 / (100 + vmf.Product.Tax.Rate)) * vmf.Amount)))))
                .ForMember(dm => dm.Description, vm => vm.MapFrom(vmf => vmf.Transaction != null ? vmf.Transaction.Description : ""))
                .ForMember(dm => dm.Contact, vm => vm.MapFrom(vmf => vmf.Transaction != null ? vmf.Transaction.Contact : ""))
                .ForMember(dm => dm.Gstin, vm => vm.MapFrom(vmf => vmf.Transaction != null ? vmf.Transaction.Gstin : ""))
                .ForMember(dm => dm.Remarks, vm => vm.MapFrom(vmf => vmf.Transaction != null ? vmf.Transaction.Remarks : ""))
                .ForMember(dm => dm.Barcode, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.Barcode : ""))
                .ForMember(dm => dm.InvoiceNumber, vm => vm.MapFrom(vmf => vmf.Transaction != null ? vmf.Transaction.InvoiceNumber : ""))
                .ForMember(dm => dm.TransactionDate, vm => vm.MapFrom(vmf => vmf.Transaction != null && vmf.Transaction.TransactionDate != null ? vmf.Transaction.TransactionDate.ToString("dd/MM/yyyy") : "--"))
                .ForMember(dm => dm.TransactionDueDate, vm => vm.MapFrom(vmf => vmf.Transaction != null && vmf.Transaction.TransactionDate != null ? vmf.Transaction.TransactionDate.AddDays(30).ToString("dd/MM/yyyy") : "--"))
                .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.Product != null && vmf.Product.UnitOfMeasure != null ? vmf.Product.UnitOfMeasure.UnitOfMeasureName : ""))
                .ForMember(dm => dm.UnitOfMeasureShortName, vm => vm.MapFrom(vmf => vmf.Product != null && vmf.Product.UnitOfMeasure != null ? vmf.Product.UnitOfMeasure.Isocode : ""));
            CreateMap<TransactionDetailDTO, TransactionDetail>();

            CreateMap<StoreStock, StoreStockDTO>()
                 .ForMember(dm => dm.StoreName, vm => vm.MapFrom(vmf => vmf.Store != null ? vmf.Store.StoreName : "-"))
                 .ForMember(dm => dm.StoreCode, vm => vm.MapFrom(vmf => vmf.Store != null ? vmf.Store.StoreCode : "-"))
                 .ForMember(dm => dm.ProductName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.ProductName : "-"))
                 .ForMember(dm => dm.Barcode, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.Barcode : "-"))
                 .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.UnitOfMeasure.UnitOfMeasureName : "-"))
                 .ForMember(dm => dm.Price, vm => vm.MapFrom(vmf => vmf.Product.SalePrice != null ? vmf.Product.SalePrice.ToString() : null))
                 .ForMember(dm => dm.PurchasePrice, vm => vm.MapFrom(vmf => vmf.Product.PurchasePrice != null ? vmf.Product.PurchasePrice.ToString() : null))
                 .ForMember(dm => dm.TotalPrice, vm => vm.MapFrom(vmf => vmf.Product.SalePrice != null ? (vmf.Product.SalePrice * vmf.Stock).ToString() : null))
                 .ForMember(dm => dm.Isocode, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.UnitOfMeasure.Isocode : "-"));

            CreateMap<TransactionDetail, TransactionDetailReportDTO>()
                 .ForMember(dm => dm.StoreName, vm => vm.MapFrom(vmf => vmf.Transaction.Store.StoreName))
                 .ForMember(dm => dm.StoreCode, vm => vm.MapFrom(vmf => vmf.Transaction.Store.StoreCode))
                 .ForMember(dm => dm.ToStoreCode, vm => vm.MapFrom(vmf => vmf.Transaction.ToStore != null ? vmf.Transaction.ToStore.StoreCode : ""))
                 .ForMember(dm => dm.ToStoreName, vm => vm.MapFrom(vmf => vmf.Transaction.ToStore != null ? vmf.Transaction.ToStore.StoreName : ""))
                 .ForMember(dm => dm.Price, vm =>
                 vm.MapFrom(vmf => vmf.Transaction.InvoiceNumber.Contains(Common.Enums.TransactionType.Invoice.ToString().Substring(0, 3)) ? vmf.FinalSalePrice : vmf.Product.PurchasePrice))
                 .ForMember(dm => dm.PurchasePrice, vm => vm.MapFrom(vmf => vmf.Product.PurchasePrice != null ? vmf.Product.PurchasePrice.ToString() : null))
                 .ForMember(dm => dm.TotalPrice, vm => vm.MapFrom(vmf => vmf.Product.SalePrice != null ? (vmf.Product.SalePrice * vmf.Amount).ToString() : null))
                 .ForMember(dm => dm.ProductName, vm => vm.MapFrom(vmf => vmf.Product.ProductName))
                 .ForMember(dm => dm.Barcode, vm => vm.MapFrom(vmf => vmf.Product.Barcode))
                 .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.Product.UnitOfMeasure.UnitOfMeasureName))
                 .ForMember(dm => dm.UnitOfMeasureShortName, vm => vm.MapFrom(vmf => vmf.Product.UnitOfMeasure.Isocode))
                 .ForMember(dm => dm.TransactionTypeName, vm => vm.MapFrom(vmf => vmf.Transaction.TransactionType.TransactionTypeName))
                 .ForMember(dm => dm.TransactionDate, vm => vm.MapFrom(vmf => vmf.Transaction.TransactionDate))
                 .ForMember(dm => dm.InvoiceNumber, vm => vm.MapFrom(vmf => vmf.Transaction.InvoiceNumber))
                 .ForMember(dm => dm.TransactionCode, vm => vm.MapFrom(vmf => vmf.Transaction.TransactionCode));

            #endregion Entity & DTO-
        }



    }
}