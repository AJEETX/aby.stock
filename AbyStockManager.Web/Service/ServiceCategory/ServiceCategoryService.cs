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
    public class ServiceCategoryService : BaseService, IServiceCategoryService
    {
        public ServiceCategoryService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ServiceResult> AddAsync(ServiceCategoryDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ServiceCategory entity = _mapper.Map<Data.Entity.ServiceCategory>(model);
                    entity.CreateDate = DateTime.Now;
                    await _unitOfWork.ServiceCategoryRepository.AddAsync(entity);
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

        public async Task<ServiceResult<IEnumerable<ServiceCategoryDTO>>> Find(ServiceCategoryDTO criteria)
        {
            ServiceResult<IEnumerable<ServiceCategoryDTO>> result = new ServiceResult<IEnumerable<ServiceCategoryDTO>>();

            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.ServiceCategory> list = await _unitOfWork
                                                                .ServiceCategoryRepository
                                                                .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.ServiceCategoryName)
                                                                || x.ServiceCategoryName.ToLower().Contains(criteria.ServiceCategoryName.Trim().ToLower())),
                                                                           orderByDesc: x => x.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);

                    result.TransactionResult = _mapper.Map<IEnumerable<ServiceCategoryDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<int>> FindCount(ServiceCategoryDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();

            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.ServiceCategoryRepository.FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.ServiceCategoryName)
                                                                || x.ServiceCategoryName.ToLower().Contains(criteria.ServiceCategoryName.Trim().ToLower())));
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

        public async Task<ServiceResult<IEnumerable<ServiceCategoryDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<ServiceCategoryDTO>> result = new ServiceResult<IEnumerable<ServiceCategoryDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.ServiceCategory> list = await _unitOfWork.ServiceCategoryRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<ServiceCategoryDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<ServiceCategoryDTO>> GetById(int id)
        {
            ServiceResult<ServiceCategoryDTO> result = new ServiceResult<ServiceCategoryDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ServiceCategory entity = await _unitOfWork.ServiceCategoryRepository.GetByIdAsync(id);
                    result.TransactionResult = _mapper.Map<ServiceCategoryDTO>(entity);
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
                    await _unitOfWork.ServiceCategoryRepository.RemoveById(id);
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

        public async Task<ServiceResult> Update(ServiceCategoryDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ServiceCategory entity = await _unitOfWork.ServiceCategoryRepository.GetByIdAsync(model.Id.Value);
                    if (entity != null)
                    {
                        _mapper.Map(model, entity);
                        _unitOfWork.ServiceCategoryRepository.Update(entity);
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