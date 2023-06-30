﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aby.StockManager.Common.Extensions;
using Aby.StockManager.Core.Service;
using Aby.StockManager.Core.UnitOfWorks;
using Aby.StockManager.Model.Domain;
using Aby.StockManager.Model.Service;
using Aby.StockManager.Service.Base;
using Entity = Aby.StockManager.Data.Entity;
using AbyStockManager.Web.Common.Message;

namespace Aby.StockManager.Service.User
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<ServiceResult> AddAsync(UserDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    bool emailValidation = await _unitOfWork.UserRepository.EmailValidationCreateUser(model.Email);

                    if (!emailValidation)
                    {
                        Entity.User entity = _mapper.Map<Data.Entity.User>(model);
                        entity.Password = model.Password.MD5Hash();
                        entity.CreateDate = DateTime.Now;
                        await _unitOfWork.UserRepository.AddAsync(entity);
                        await _unitOfWork.SaveAsync();
                        result.Id = entity.Id;
                        result.UserMessage = CommonMessages.MSG0001;
                    }
                    else
                    {
                        result.IsSucceeded = false;
                        result.UserMessage = CommonMessages.MSG0003;
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

        public async Task<ServiceResult<IEnumerable<UserDTO>>> Find(UserDTO criteria)
        {
            ServiceResult<IEnumerable<UserDTO>> result = new ServiceResult<IEnumerable<UserDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.User> list = await _unitOfWork
                                                                .UserRepository
                                                                .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.Email) || x.Email.ToLower().Contains(criteria.Email.Trim().ToLower())) &&
                                                                                        (string.IsNullOrEmpty(criteria.Name) || x.Name.ToLower().Contains(criteria.Name.Trim().ToLower())) &&
                                                                                        (string.IsNullOrEmpty(criteria.Surname) || x.Surname.ToLower().Contains(criteria.Surname.Trim().ToLower())),
                                                                           orderByDesc: x => x.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);

                    result.TransactionResult = _mapper.Map<IEnumerable<UserDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult<int>> FindCount(UserDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.UserRepository
                                                  .FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.Email) || x.Email.ToLower().Contains(criteria.Email.Trim().ToLower())) &&
                                                                               (string.IsNullOrEmpty(criteria.Name) || x.Name.ToLower().Contains(criteria.Name.Trim().ToLower())) &&
                                                                               (string.IsNullOrEmpty(criteria.Surname) || x.Surname.ToLower().Contains(criteria.Surname.Trim().ToLower())));

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

        public async Task<ServiceResult<IEnumerable<UserDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<UserDTO>> result = new ServiceResult<IEnumerable<UserDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.User> list = await _unitOfWork.UserRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<UserDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<UserDTO>> GetById(int id)
        {
            ServiceResult<UserDTO> result = new ServiceResult<UserDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.User entity = await _unitOfWork.UserRepository.GetByIdAsync(id);
                    result.TransactionResult = _mapper.Map<UserDTO>(entity);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }
            return result;
        }

        public async Task<ServiceResult> Login(string email, string password)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    var login = await _unitOfWork.UserRepository.Login(email, password.MD5Hash());
                    if (login != null)
                    {
                        result.Id = login.Id;
                        result.IsSucceeded = true;
                    }
                    else
                    {
                        result.IsSucceeded = false;
                        result.UserMessage = CommonMessages.MSG0005;
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

        public async Task<ServiceResult> RemoveById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    await _unitOfWork.UserRepository.RemoveById(id);
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

        public async Task<ServiceResult> Update(UserDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.User entity = await _unitOfWork.UserRepository.GetByIdAsync(model.Id.Value);
                    if (entity != null)
                    {
                        bool emailValidation = await _unitOfWork.UserRepository.EmailValidationUpdateUser(model.Email, model.Id.Value);

                        if (!emailValidation)
                        {
                            string oldPassword = entity.Password;
                            if (!string.IsNullOrEmpty(model.Password))
                                model.Password = model.Password.MD5Hash();
                            else
                                model.Password = oldPassword;

                            _mapper.Map(model, entity);
                            _unitOfWork.UserRepository.Update(entity);

                            await _unitOfWork.SaveAsync();
                            result.UserMessage = CommonMessages.MSG0001;
                        }
                        else
                        {
                            result.IsSucceeded = false;
                            result.UserMessage = CommonMessages.MSG0003;
                        }
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

        public async Task<ServiceResult> DeleteProductImage(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    await _unitOfWork.UserRepository.DeleteProductImage(id);
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
    }
}