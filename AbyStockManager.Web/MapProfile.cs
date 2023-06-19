using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using Aby.StockManager.Data.Entity;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Model.ViewModel.Category;
using Aby.StockManager.Model.ViewModel.JsonResult;
using Aby.StockManager.Model.ViewModel.Product;
using Aby.StockManager.Model.ViewModel.Report.StoreStock;
using Aby.StockManager.Model.ViewModel.Report.TransactionDetail;
using Aby.StockManager.Model.ViewModel.Store;
using Aby.StockManager.Model.ViewModel.Transaction;
using Aby.StockManager.Model.ViewModel.UnitOfMeasure;
using Aby.StockManager.Model.ViewModel.User;
using Elfie.Serialization;
using System.Globalization;
using AbyStockManager.Web.Model.ViewModel.Tax;

namespace Aby.StockManager.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region DTO & ViewModel

            CreateMap<ServiceResult, JsonResultModel>();

            CreateMap<CreateCategoryViewModel, CategoryDTO>();

            CreateMap<SearchCategoryViewModel, CategoryDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<CreateTaxViewModel, TaxDTO>()
                .ForMember(dm => dm.Name, vm => vm.MapFrom(vmf => vmf.Name))
                .ForMember(dm => dm.Rate, vm => vm.MapFrom(vmf => vmf.Rate))
                ;

            CreateMap<SearchTaxViewModel, TaxDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<TaxDTO, ListTaxViewModel>();
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
            CreateMap<UserDTO, ListUserViewModel>();
            CreateMap<UserDTO, EditUserViewModel>();
            CreateMap<EditUserViewModel, UserDTO>();

            CreateMap<CreateStoreViewModel, StoreDTO>();
            CreateMap<SearchStoreViewModel, StoreDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<StoreDTO, ListStoreViewModel>();
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
                 .ForMember(dm => dm.Price, vm => vm.MapFrom(vmf => vmf.Price.HasValue ? string.Format("{0:c}", vmf.Price.Value) : "-"));
            CreateMap<ProductDTO, CreateProductViewModel>();
            CreateMap<CreateProductViewModel, ProductDTO>();
            CreateMap<ProductDTO, EditProductViewModel>();
            CreateMap<EditProductViewModel, ProductDTO>();
            CreateMap<ProductDTO, SelectListItem>()
                    .ForMember(dm => dm.Value, vm => vm.MapFrom(vmf => vmf.Id.ToString()))
                    .ForMember(dm => dm.Text, vm => vm.MapFrom(vmf => !string.IsNullOrEmpty(vmf.Barcode) ? vmf.Barcode + "-" + vmf.ProductName : vmf.ProductName));

            //CreateMap<CreateTransactionViewModel, TransactionDTO>()
            //    .ForMember(dm => dm.TransactionDate, vm => vm.MapFrom(vmf => vmf.TransactionDate));

            CreateMap<CreateTransactionViewModel, TransactionDTO>().ForMember(x => x.TransactionDate, y => y.MapFrom(z => DateTime.ParseExact(z.TransactionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)));

            CreateMap<TransactionDetailViewModel, TransactionDetailDTO>();
            CreateMap<TransactionDetailDTO, TransactionDetailViewModel>();
            CreateMap<SearchTransactionViewModel, TransactionDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));
            CreateMap<TransactionDTO, ListTransactionViewModel>()
                 .ForMember(dm => dm.TransactionDate, vm => vm.MapFrom(vmf => string.Format("{0:D}", vmf.TransactionDate)));
            CreateMap<TransactionDTO, EditTransactionViewModel>();
            CreateMap<EditTransactionViewModel, TransactionDTO>();

            CreateMap<SearchStoreStockReportViewModel, StoreStockDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<StoreStockDTO, ListStoreStockReportViewModel>()
                 .ForMember(dm => dm.ProductFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.Barcode, vmf.ProductName)))
                 .ForMember(dm => dm.StoreFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.StoreCode, vmf.StoreName)))
                 .ForMember(dm => dm.ProductPrice, vm => vm.MapFrom(vmf => vmf.Price.ToString()))
                 .ForMember(dm => dm.ProductTotalPrice, vm => vm.MapFrom(vmf => (vmf.Price * vmf.Stock).ToString()))
                 .ForMember(dm => dm.QTY, vm => vm.MapFrom(vmf => string.Format("{0} ({1})", vmf.Stock.ToString(), vmf.Isocode)));

            CreateMap<SearchTransactionDetailReportViewModel, TransactionDetailReportDTO>()
                    .ForMember(dm => dm.PageNumber, vm => vm.MapFrom(vmf => vmf.iDisplayStart))
                    .ForMember(dm => dm.RecordCount, vm => vm.MapFrom(vmf => vmf.iDisplayLength));

            CreateMap<TransactionDetailReportDTO, ListTransactionDetailReportViewModel>()
                 .ForMember(dm => dm.ProductFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.Barcode, vmf.ProductName)))
                 .ForMember(dm => dm.StoreFullName, vm => vm.MapFrom(vmf => string.Format("{1} ({0})", vmf.StoreCode, vmf.StoreName)))
                 .ForMember(dm => dm.ProductPrice, vm => vm.MapFrom(vmf => vmf.Price.ToString()))
                 .ForMember(dm => dm.ProductTotalPrice, vm => vm.MapFrom(vmf => (vmf.Price * vmf.Amount).ToString()))
                 .ForMember(dm => dm.ToStoreFullName, vm => vm.MapFrom(vmf => !string.IsNullOrEmpty(vmf.ToStoreName) ? string.Format("{1} ({0})", vmf.ToStoreCode, vmf.ToStoreName) : ""))
                 .ForMember(dm => dm.Amount, vm => vm.MapFrom(vmf => string.Format("{0} ({1})", vmf.Amount.ToString(), vmf.UnitOfMeasureShortName)))
                 .ForMember(dm => dm.TransactionDate, vm => vm.MapFrom(vmf => string.Format("{0:D}", vmf.TransactionDate))); ;

            #endregion DTO & ViewModel

            #region Entity & DTO

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

            CreateMap<Product, ProductDTO>()
                 .ForMember(dm => dm.CategoryName, vm => vm.MapFrom(vmf => vmf.Category != null ? vmf.Category.CategoryName : "-"))
                 .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.UnitOfMeasure != null ? vmf.UnitOfMeasure.Isocode : "-"));
            CreateMap<ProductDTO, Product>();

            CreateMap<Transaction, TransactionDTO>()
                .ForMember(dm => dm.StoreName, vm => vm.MapFrom(vmf => vmf.Store != null ? vmf.Store.StoreName + "-" + vmf.Store.StoreCode : "-"))
                .ForMember(dm => dm.ToStoreName, vm => vm.MapFrom(vmf => vmf.ToStore != null ? vmf.ToStore.StoreName + "-" + vmf.ToStore.StoreCode : "-"))
                .ForMember(dm => dm.TransactionTypeName, vm => vm.MapFrom(vmf => vmf.TransactionType != null ? vmf.TransactionType.TransactionTypeName : "-"));
            CreateMap<TransactionDTO, Transaction>();

            CreateMap<TransactionDetail, TransactionDetailDTO>()
                .ForMember(dm => dm.ProductName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.ProductName : ""))
                .ForMember(dm => dm.Tax, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.Tax.Rate : 0))
                .ForMember(dm => dm.Price, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.Price : 0))
                .ForMember(dm => dm.Description, vm => vm.MapFrom(vmf => vmf.Transaction != null ? vmf.Transaction.Description : ""))
                .ForMember(dm => dm.Barcode, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.Barcode : ""))
                .ForMember(dm => dm.InvoiceNumber, vm => vm.MapFrom(vmf => vmf.Transaction != null ? vmf.Transaction.InvoiceNumber : ""))
                .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.UnitOfMeasure.UnitOfMeasureName : ""))
                .ForMember(dm => dm.UnitOfMeasureShortName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.UnitOfMeasure.Isocode : ""));
            CreateMap<TransactionDetailDTO, TransactionDetail>();

            CreateMap<StoreStock, StoreStockDTO>()
                 .ForMember(dm => dm.StoreName, vm => vm.MapFrom(vmf => vmf.Store != null ? vmf.Store.StoreName : "-"))
                 .ForMember(dm => dm.StoreCode, vm => vm.MapFrom(vmf => vmf.Store != null ? vmf.Store.StoreCode : "-"))
                 .ForMember(dm => dm.ProductName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.ProductName : "-"))
                 .ForMember(dm => dm.Barcode, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.Barcode : "-"))
                 .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.UnitOfMeasure.UnitOfMeasureName : "-"))
                 .ForMember(dm => dm.Price, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.Price.ToString() : "-"))
                 .ForMember(dm => dm.TotalPrice, vm => vm.MapFrom(vmf => vmf.Product != null ? (vmf.Product.Price * vmf.Stock).ToString() : "-"))
                 .ForMember(dm => dm.Isocode, vm => vm.MapFrom(vmf => vmf.Product != null ? vmf.Product.UnitOfMeasure.Isocode : "-"));

            CreateMap<TransactionDetail, TransactionDetailReportDTO>()
                 .ForMember(dm => dm.StoreName, vm => vm.MapFrom(vmf => vmf.Transaction.Store.StoreName))
                 .ForMember(dm => dm.StoreCode, vm => vm.MapFrom(vmf => vmf.Transaction.Store.StoreCode))
                 .ForMember(dm => dm.ToStoreCode, vm => vm.MapFrom(vmf => vmf.Transaction.ToStore != null ? vmf.Transaction.ToStore.StoreCode : ""))
                 .ForMember(dm => dm.ToStoreName, vm => vm.MapFrom(vmf => vmf.Transaction.ToStore != null ? vmf.Transaction.ToStore.StoreName : ""))
                 .ForMember(dm => dm.Price, vm => vm.MapFrom(vmf => vmf.Product.Price.ToString()))
                 .ForMember(dm => dm.TotalPrice, vm => vm.MapFrom(vmf => (vmf.Product.Price * vmf.Amount).ToString()))
                 .ForMember(dm => dm.ProductName, vm => vm.MapFrom(vmf => vmf.Product.ProductName))
                 .ForMember(dm => dm.Barcode, vm => vm.MapFrom(vmf => vmf.Product.Barcode))
                 .ForMember(dm => dm.UnitOfMeasureName, vm => vm.MapFrom(vmf => vmf.Product.UnitOfMeasure.UnitOfMeasureName))
                 .ForMember(dm => dm.UnitOfMeasureShortName, vm => vm.MapFrom(vmf => vmf.Product.UnitOfMeasure.Isocode))
                 .ForMember(dm => dm.TransactionTypeName, vm => vm.MapFrom(vmf => vmf.Transaction.TransactionType.TransactionTypeName))
                 .ForMember(dm => dm.TransactionDate, vm => vm.MapFrom(vmf => vmf.Transaction.TransactionDate))
                 .ForMember(dm => dm.InvoiceNumber, vm => vm.MapFrom(vmf => vmf.Transaction.InvoiceNumber))
                 .ForMember(dm => dm.TransactionCode, vm => vm.MapFrom(vmf => vmf.Transaction.TransactionCode));

            #endregion Entity & DTO
        }
    }
}