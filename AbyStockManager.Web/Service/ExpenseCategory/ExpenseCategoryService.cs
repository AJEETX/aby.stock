using AutoMapper;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Aby.StockManager.Core.Service;
using Aby.StockManager.Core.UnitOfWorks;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Service.Base;

using Entity = Aby.StockManager.Data.Entity;
using AbyStockManager.Web.Common.Message;

namespace Aby.StockManager.Service.Category
{
    public class ExpenseCategoryService : BaseService, IExpenseCategoryService
    {
        public ExpenseCategoryService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ServiceResult> AddAsync(ExpenseCategoryDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ExpenseCategory entity = _mapper.Map<Data.Entity.ExpenseCategory>(model);
                    entity.CreateDate = DateTime.Now;
                    await _unitOfWork.ExpenseCategoryRepository.AddAsync(entity);
                    await _unitOfWork.SaveAsync();
                    result.Id = entity.Id;
                    result.UserMessage = CommonMessages.MSG0001;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<IEnumerable<ExpenseCategoryDTO>>> Find(ExpenseCategoryDTO criteria)
        {
            ServiceResult<IEnumerable<ExpenseCategoryDTO>> result = new ServiceResult<IEnumerable<ExpenseCategoryDTO>>();

            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.ExpenseCategory> list = await _unitOfWork
                                                                .ExpenseCategoryRepository
                                                                .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.CategoryName)
                                                                || x.CategoryName.ToLower().Contains(criteria.CategoryName.Trim().ToLower())),
                                                                           orderByDesc: x => x.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);

                    result.TransactionResult = _mapper.Map<IEnumerable<ExpenseCategoryDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<int>> FindCount(ExpenseCategoryDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();

            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.ExpenseCategoryRepository.FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.CategoryName)
                                                                || x.CategoryName.ToLower().Contains(criteria.CategoryName.Trim().ToLower())));
                    result.TransactionResult = count;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<IEnumerable<ExpenseCategoryDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<ExpenseCategoryDTO>> result = new ServiceResult<IEnumerable<ExpenseCategoryDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.ExpenseCategory> list = await _unitOfWork.ExpenseCategoryRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<ExpenseCategoryDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<ExpenseCategoryDTO>> GetById(int id)
        {
            ServiceResult<ExpenseCategoryDTO> result = new ServiceResult<ExpenseCategoryDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ExpenseCategory entity = await _unitOfWork.ExpenseCategoryRepository.GetByIdAsync(id);
                    result.TransactionResult = _mapper.Map<ExpenseCategoryDTO>(entity);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
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
                    await _unitOfWork.ExpenseCategoryRepository.RemoveById(id);
                    await _unitOfWork.SaveAsync();
                    result.UserMessage = CommonMessages.MSG0001;
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult> Update(ExpenseCategoryDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ExpenseCategory entity = await _unitOfWork.ExpenseCategoryRepository.GetByIdAsync(model.Id.Value);
                    if (entity != null)
                    {
                        _mapper.Map(model, entity);
                        _unitOfWork.ExpenseCategoryRepository.Update(entity);
                        await _unitOfWork.SaveAsync();
                        result.UserMessage = CommonMessages.MSG0001;
                    }
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }
    }
}