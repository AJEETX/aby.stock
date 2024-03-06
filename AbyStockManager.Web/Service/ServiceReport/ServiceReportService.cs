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

using Aby.StockManager.Data.Entity;

using Microsoft.EntityFrameworkCore;
using System.Linq;
using Aby.StockManager.Data.Context;

namespace Aby.StockManager.Service
{
    public interface IServiceReportService : IService<ServiceReportDTO>
    {
        IEnumerable<ServiceReport> GetAllServices();

        IEnumerable<ServiceReport> GetSearchResult(string searchString);

        void AddService(ServiceReport expense);

        int UpdateService(ServiceReport expense);

        ServiceReport GetServiceData(int id);

        void DeleteService(int id);

        Dictionary<string, double> CalculateMonthlyService();

        Dictionary<string, double> CalculateWeeklyService();
    }

    public class ServiceReportService : BaseService, IServiceReportService
    {
        private EasyStockManagerDbContext db;

        public ServiceReportService(EasyStockManagerDbContext _db, IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            db = _db;
        }

        public IEnumerable<ServiceReport> GetAllServices()
        {
            try
            {
                return db.ServiceReport.ToList();
            }
            catch
            {
                throw;
            }
        }

        // To filter out the records based on the search string
        public IEnumerable<ServiceReport> GetSearchResult(string searchString)
        {
            List<ServiceReport> exp = new List<ServiceReport>();
            try
            {
                exp = GetAllServices().ToList();
                return exp.Where(x => x.ItemName.ToLower().Trim().IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }

        //To Add new Expense record
        public void AddService(ServiceReport expense)
        {
            try
            {
                db.ServiceReport.Add(expense);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar expense
        public int UpdateService(ServiceReport expense)
        {
            try
            {
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the data for a particular expense
        public ServiceReport GetServiceData(int id)
        {
            try
            {
                ServiceReport expense = db.ServiceReport.Find(id);
                return expense;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular expense
        public void DeleteService(int id)
        {
            try
            {
                ServiceReport emp = db.ServiceReport.Find(id);
                db.ServiceReport.Remove(emp);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        // To calculate last six months expense
        public Dictionary<string, double> CalculateMonthlyService()
        {
            Dictionary<string, double> dictMonthlySum = new Dictionary<string, double>();

            var expenseCategories = db.ServiceCategory;

            foreach (var expenseCategory in expenseCategories)
            {
                double catum = db.ServiceReport.Include(i => i.ServiceCategory).Where
                                (cat => cat.ServiceCategory.Id == expenseCategory.Id && (cat.ServiceDate > DateTime.Now.AddMonths(-7)))
                                .Select(cat => cat.Amount)
                                .Sum();
                dictMonthlySum.Add(expenseCategory.ServiceCategoryName, catum);
            }

            return dictMonthlySum;
        }

        // To calculate last four weeks expense
        public Dictionary<string, double> CalculateWeeklyService()
        {
            Dictionary<string, double> dictWeeklySum = new Dictionary<string, double>();

            var expenseCategories = db.ServiceCategory;

            foreach (var expenseCategory in expenseCategories)
            {
                double catum = db.ServiceReport.Include(i => i.ServiceCategory).Where
                (cat => cat.ServiceCategory.Id == expenseCategory.Id && (cat.ServiceDate > DateTime.Now.AddDays(-28)))
                .Select(cat => cat.Amount)
                .Sum();
                dictWeeklySum.Add(expenseCategory.ServiceCategoryName, catum);
            }

            return dictWeeklySum;
        }

        public async Task<ServiceResult> AddAsync(ServiceReportDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ServiceReport entity = _mapper.Map<Data.Entity.ServiceReport>(model);
                    entity.CreateDate = DateTime.Now;
                    await _unitOfWork.ServiceReportRepository.AddAsync(entity);
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

        public async Task<ServiceResult<IEnumerable<ServiceReportDTO>>> Find(ServiceReportDTO criteria)
        {
            ServiceResult<IEnumerable<ServiceReportDTO>> result = new ServiceResult<IEnumerable<ServiceReportDTO>>();

            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.ServiceReport> list = await _unitOfWork
                                                                .ServiceReportRepository
                                                                .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.ItemName) || x.ItemName.ToLower().Contains(criteria.ItemName.Trim().ToLower())) &&
                                                                 (criteria.SearchStartDate == null || x.ServiceDate >= criteria.SearchStartDate) &&
                                                                                        (criteria.SearchEndDate == null || x.ServiceDate <= criteria.SearchEndDate) &&
                                                                                        (criteria.ServiceCategoryId == null || x.ServiceCategoryId == criteria.ServiceCategoryId),
                                                                           includes: new List<string>() { "ServiceCategory" },
                                                                           orderByDesc: x => x.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);

                    result.TransactionResult = _mapper.Map<IEnumerable<ServiceReportDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<int>> FindCount(ServiceReportDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.ServiceReportRepository
                                                 .FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.ItemName) || x.ItemName.Contains(criteria.ItemName)) &&
                                                                 (criteria.SearchStartDate == null || x.ServiceDate >= criteria.SearchStartDate) &&
                                                                                        (criteria.SearchEndDate == null || x.ServiceDate <= criteria.SearchEndDate) &&
                                                                                        (criteria.ServiceCategoryId == null || x.ServiceCategoryId == criteria.ServiceCategoryId));
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

        public async Task<ServiceResult<IEnumerable<ServiceReportDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<ServiceReportDTO>> result = new ServiceResult<IEnumerable<ServiceReportDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.ServiceReport> list = await _unitOfWork.ServiceReportRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<ServiceReportDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResult<ServiceReportDTO>> GetById(int id)
        {
            ServiceResult<ServiceReportDTO> result = new ServiceResult<ServiceReportDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ServiceReport entity = await _unitOfWork.ServiceReportRepository.GetByIdAsync(id);
                    var servicetype = await _unitOfWork.ServiceCategoryRepository.GetByIdAsync(entity.ServiceCategoryId.Value);

                    entity.ServiceCategory = servicetype;
                    result.TransactionResult = _mapper.Map<ServiceReportDTO>(entity);
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
                    await _unitOfWork.ServiceReportRepository.RemoveById(id);
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

        public async Task<ServiceResult> Update(ServiceReportDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ServiceReport entity = await _unitOfWork.ServiceReportRepository.GetByIdAsync(model.Id.Value);
                    if (entity != null)
                    {
                        _mapper.Map(model, entity);
                        _unitOfWork.ServiceReportRepository.Update(entity);
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