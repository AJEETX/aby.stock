﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aby.StockManager.Common.Enums;
using Aby.StockManager.Core.Service;
using Aby.StockManager.Core.UnitOfWorks;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Service.Base;
using Entity = Aby.StockManager.Data.Entity;
using AbyStockManager.Web.Common.Message;

namespace Aby.StockManager.Service.Transaction
{
    public class TransactionService : BaseService, ITransactionService
    {
        public TransactionService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ServiceResult> AddAsync(TransactionDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (model.ToStoreId == model.StoreId)
                {
                    result.IsSucceeded = false;
                    result.UserMessage = CommonMessages.MSG0004;
                    return result;
                }

                model.TransactionDetail = model.TransactionDetail.GroupBy(x => x.ProductId)
                                                                  .Select(g => new TransactionDetailDTO
                                                                  {
                                                                      Amount = g.Sum(s => s.Amount),
                                                                      ProductId = g.Key,
                                                                      FinalSalePrice = g.Sum(g => g.FinalSalePrice),
                                                                      PurchasePrice = g.Sum(g => g.PurchasePrice),
                                                                      Price = g.Sum(g => g.Price),
                                                                  }).ToList();

                using (_unitOfWork)
                {
                    Entity.Transaction entity = _mapper.Map<Data.Entity.Transaction>(model);
                    entity.CreateDate = DateTime.Now;
                    await _unitOfWork.TransactionRepository.AddAsync(entity);

                    foreach (var transactionDetailItem in model.TransactionDetail)
                    {
                        bool storeStockIsUpdate = true;
                        Data.Entity.StoreStock storeStock = await _unitOfWork.StoreStockRepository.GetByStoreAndProductId(transactionDetailItem.ProductId.Value, model.StoreId.Value);

                        if (storeStock == null)
                        {
                            storeStockIsUpdate = false;
                            storeStock = new Entity.StoreStock();
                            storeStock.StoreId = model.StoreId.Value;
                            storeStock.ProductId = transactionDetailItem.ProductId.Value;
                        }

                        if (model.TransactionTypeId == (int)TransactionType.Inv)
                            storeStock.Stock -= transactionDetailItem.Amount.Value;
                        else
                            storeStock.Stock += transactionDetailItem.Amount.Value;

                        if (storeStockIsUpdate == false)
                            await _unitOfWork.StoreStockRepository.AddAsync(storeStock);
                    }
                    await _unitOfWork.SaveAsync();
                    result.Id = entity.Id;
                    result.UserMessage = CommonMessages.MSG0001;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult<IEnumerable<TransactionDTO>>> Find(TransactionDTO criteria)
        {
            ServiceResult<IEnumerable<TransactionDTO>> result = new ServiceResult<IEnumerable<TransactionDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.Transaction> list = await _unitOfWork
                                                                .TransactionRepository
                                                                .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.TransactionCode) || x.TransactionCode.ToLower().Contains(criteria.TransactionCode.Trim().ToLower())) &&
                                                                                        (criteria.TransactionTypeId == null || x.TransactionTypeId == criteria.TransactionTypeId) &&
                                                                                        (criteria.SearchStartDate == null || x.TransactionDate >= criteria.SearchStartDate) &&
                                                                                        (criteria.SearchEndDate == null || x.TransactionDate <= criteria.SearchEndDate) &&
                                                                                        (criteria.StoreId == null || x.StoreId == criteria.StoreId) &&
                                                                                        (criteria.ToStoreId == null || x.ToStoreId == criteria.ToStoreId),
                                                                           orderByDesc: x => x.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount,
                                                                           includes: new List<string>() { "TransactionType", "Store", "ToStore", "TransactionDetail", "TransactionDetail.Product", "TransactionDetail.Product.Tax" });

                    result.TransactionResult = _mapper.Map<IEnumerable<TransactionDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult<int>> FindCount(TransactionDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.TransactionRepository
                                                 .FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.TransactionCode) || x.TransactionCode.ToLower().Contains(criteria.TransactionCode.Trim().ToLower())) &&
                                                                              (criteria.TransactionTypeId == null || x.TransactionTypeId == criteria.TransactionTypeId) &&
                                                                              (criteria.SearchStartDate == null || x.TransactionDate >= criteria.SearchStartDate) &&
                                                                              (criteria.SearchEndDate == null || x.TransactionDate <= criteria.SearchEndDate) &&
                                                                              (criteria.StoreId == null || x.StoreId == criteria.StoreId) &&

                                                                              (criteria.ToStoreId == null || x.ToStoreId == criteria.ToStoreId));
                    result.TransactionResult = count;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult<IEnumerable<TransactionDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<TransactionDTO>> result = new ServiceResult<IEnumerable<TransactionDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.Transaction> list = await _unitOfWork.TransactionRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<TransactionDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResult<TransactionDTO>> GetById(int id)
        {
            ServiceResult<TransactionDTO> result = new ServiceResult<TransactionDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.Transaction entity = await _unitOfWork.TransactionRepository.GetByIdAsync(id);
                    result.TransactionResult = _mapper.Map<TransactionDTO>(entity);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult<IEnumerable<TransactionDetailDTO>>> GetTransactionDetailByTransactionId(int transactionId)
        {
            ServiceResult<IEnumerable<TransactionDetailDTO>> result = new ServiceResult<IEnumerable<TransactionDetailDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.TransactionDetail> list = await _unitOfWork.TransactionDetailRepository.GetByTransactionId(transactionId);
                    result.TransactionResult = _mapper.Map<IEnumerable<TransactionDetailDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult<TransactionDTO>> GetWithDetailAndProductById(int id)
        {
            ServiceResult<TransactionDTO> result = new ServiceResult<TransactionDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.Transaction entity = await _unitOfWork.TransactionRepository.GetWithDetailAndProductById(id);
                    result.TransactionResult = _mapper.Map<TransactionDTO>(entity);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> RemoveById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    //Stock Update
                    var transaction = await _unitOfWork.TransactionRepository.GetWithDetailById(id);
                    foreach (var transactionDetail in transaction.TransactionDetail)
                    {
                        var storeStock = await _unitOfWork.StoreStockRepository.GetByStoreAndProductId(transactionDetail.ProductId, transaction.StoreId);
                        if (storeStock != null)
                        {
                            if (transaction.TransactionTypeId == (int)TransactionType.Inv)
                                storeStock.Stock += transactionDetail.Amount;
                            else
                                storeStock.Stock -= transactionDetail.Amount;
                        }
                    }

                    //Transaction Delete
                    await _unitOfWork.TransactionRepository.RemoveById(id);
                    await _unitOfWork.SaveAsync();
                    result.UserMessage = CommonMessages.MSG0001;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> Update(TransactionDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                if (model.ToStoreId == model.StoreId)
                {
                    result.IsSucceeded = false;
                    result.UserMessage = CommonMessages.MSG0004;
                    return result;
                }

                model.TransactionDetail = model.TransactionDetail.GroupBy(x => x.ProductId)
                                                                  .Select(g => new TransactionDetailDTO
                                                                  {
                                                                      Amount = g.Sum(s => s.Amount),
                                                                      FinalSalePrice = g.Sum(g => g.FinalSalePrice),
                                                                      PurchasePrice = g.Sum(g => g.PurchasePrice),
                                                                      Price = g.Sum(g => g.Price),
                                                                      ProductId = g.Key
                                                                  }).ToList();

                using (_unitOfWork)
                {
                    Entity.Transaction entity = await _unitOfWork.TransactionRepository.GetWithDetailById(model.Id.Value);

                    if (entity != null)
                    {
                        //Revert Old Stock
                        foreach (var transactionDetailItem in entity.TransactionDetail)
                        {
                            Data.Entity.StoreStock storeStock = await _unitOfWork.StoreStockRepository.GetByStoreAndProductId(transactionDetailItem.ProductId, entity.StoreId);
                            if (storeStock != null)
                            {
                                if (model.TransactionTypeId == (int)TransactionType.Inv)
                                    storeStock.Stock += transactionDetailItem.Amount;
                                else
                                    storeStock.Stock -= transactionDetailItem.Amount;
                            }
                        }

                        //Delete Old Record
                        _unitOfWork.TransactionDetailRepository.DeleteAllRecordByTransaction(entity.TransactionDetail);

                        //Update Transactions
                        _mapper.Map(model, entity);

                        foreach (var transactionDetailItem in model.TransactionDetail)
                        {
                            bool storeStockIsUpdate = true;
                            Data.Entity.StoreStock storeStock = await _unitOfWork.StoreStockRepository.GetByStoreAndProductId(transactionDetailItem.ProductId.Value, model.StoreId.Value);

                            if (storeStock == null)
                            {
                                storeStockIsUpdate = false;
                                storeStock = new Entity.StoreStock();
                                storeStock.StoreId = model.StoreId.Value;
                                storeStock.ProductId = transactionDetailItem.ProductId.Value;
                            }

                            if (model.TransactionTypeId == (int)TransactionType.Inv)
                                storeStock.Stock -= transactionDetailItem.Amount.Value;
                            else
                                storeStock.Stock += transactionDetailItem.Amount.Value;

                            if (storeStockIsUpdate == false)
                                await _unitOfWork.StoreStockRepository.AddAsync(storeStock);
                        }

                        _unitOfWork.TransactionRepository.Update(entity);
                        await _unitOfWork.SaveAsync();
                        result.UserMessage = CommonMessages.MSG0001;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult<IEnumerable<TransactionDetailReportDTO>>> TransactionDetailReport(TransactionDetailReportDTO criteria)
        {
            ServiceResult<IEnumerable<TransactionDetailReportDTO>> result = new ServiceResult<IEnumerable<TransactionDetailReportDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.TransactionDetail> list = await _unitOfWork
                                                                .TransactionDetailRepository
                                                                .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.TransactionCode) || x.Transaction.TransactionCode.Contains(criteria.TransactionCode)) &&
                                                                                        (criteria.TransactionTypeId == null || x.Transaction.TransactionTypeId == criteria.TransactionTypeId) &&
                                                                                        (criteria.SearchStartDate == null || x.Transaction.TransactionDate >= criteria.SearchStartDate) &&
                                                                                        (criteria.SearchEndDate == null || x.Transaction.TransactionDate <= criteria.SearchEndDate) &&
                                                                                        (criteria.StoreId == null || x.Transaction.StoreId == criteria.StoreId) &&
                                                                                        (criteria.ToStoreId == null || x.Transaction.ToStoreId == criteria.ToStoreId) &&
                                                                                        (criteria.ProductId == null || x.ProductId == criteria.ProductId),
                                                                           orderByDesc: x => x.Transaction.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount,
                                                                           includes: new List<string>() { "Product", "Product.UnitOfMeasure", "Transaction", "Transaction.TransactionType", "Transaction.Store", "Transaction.ToStore" });

                    result.TransactionResult = _mapper.Map<IEnumerable<TransactionDetailReportDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult<int>> TransactionDetailReportCount(TransactionDetailReportDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.TransactionDetailRepository
                                               .FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.TransactionCode) || x.Transaction.TransactionCode.Contains(criteria.TransactionCode)) &&
                                                                            (criteria.TransactionTypeId == null || x.Transaction.TransactionTypeId == criteria.TransactionTypeId) &&
                                                                            (criteria.SearchStartDate == null || x.Transaction.TransactionDate >= criteria.SearchStartDate) &&
                                                                            (criteria.SearchEndDate == null || x.Transaction.TransactionDate <= criteria.SearchEndDate) &&
                                                                            (criteria.StoreId == null || x.Transaction.StoreId == criteria.StoreId) &&
                                                                            (criteria.ToStoreId == null || x.Transaction.ToStoreId == criteria.ToStoreId) &&
                                                                            (criteria.ProductId == null || x.ProductId == criteria.ProductId),
                                                                  includes: new List<string>() { "Product", "Product.UnitOfMeasure", "Transaction", "Transaction.TransactionType", "Transaction.Store", "Transaction.ToStore" });

                    result.TransactionResult = count;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }
            return result;
        }
    }
}