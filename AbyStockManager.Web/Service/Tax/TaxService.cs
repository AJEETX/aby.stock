using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Aby.StockManager.Core.Service;
using Aby.StockManager.Core.UnitOfWorks;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Service.Base;

using AbyStockManager.Web.Common.Message;

using AutoMapper;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AbyStockManager.Web.Service.Tax
{
    public class TaxService : BaseService, ITaxService
    {
        public TaxService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ServiceResult> AddAsync(TaxDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Aby.StockManager.Data.Entity.Tax entity = _mapper.Map<Aby.StockManager.Data.Entity.Tax>(model);
                    entity.CreateDate = DateTime.Now;
                    await _unitOfWork.TaxRepository.AddAsync(entity);
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

        public async Task<ServiceResult<IEnumerable<TaxDTO>>> Find(TaxDTO criteria)
        {
            ServiceResult<IEnumerable<TaxDTO>> result = new ServiceResult<IEnumerable<TaxDTO>>();

            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Aby.StockManager.Data.Entity.Tax> list = await _unitOfWork
                                                                .TaxRepository
                                                                .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.Name) || x.Rate.ToString().Contains(criteria.Rate.ToString())),
                                                                           orderByDesc: x => x.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);

                    result.TransactionResult = _mapper.Map<IEnumerable<TaxDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<int>> FindCount(TaxDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();

            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.TaxRepository.FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.Name) || x.Rate.ToString().Contains(criteria.Rate.ToString())));
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

        public async Task<ServiceResult<IEnumerable<TaxDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<TaxDTO>> result = new ServiceResult<IEnumerable<TaxDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Aby.StockManager.Data.Entity.Tax> list = await _unitOfWork.TaxRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<TaxDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<TaxDTO>> GetById(int id)
        {
            ServiceResult<TaxDTO> result = new ServiceResult<TaxDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Aby.StockManager.Data.Entity.Tax entity = await _unitOfWork.TaxRepository.GetByIdAsync(id);
                    result.TransactionResult = _mapper.Map<TaxDTO>(entity);
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
                    await _unitOfWork.TaxRepository.RemoveById(id);
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

        public async Task<ServiceResult> Update(TaxDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Aby.StockManager.Data.Entity.Tax entity = await _unitOfWork.TaxRepository.GetByIdAsync(model.Id.Value);
                    if (entity != null)
                    {
                        _mapper.Map(model, entity);
                        _unitOfWork.TaxRepository.Update(entity);
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