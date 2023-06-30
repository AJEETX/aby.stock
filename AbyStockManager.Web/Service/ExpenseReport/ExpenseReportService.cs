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
    public interface IExpenseReportService : IService<ExpenseReportDTO>
    {
        IEnumerable<ExpenseReport> GetAllExpenses();

        IEnumerable<ExpenseReport> GetSearchResult(string searchString);

        void AddExpense(ExpenseReport expense);

        int UpdateExpense(ExpenseReport expense);

        ExpenseReport GetExpenseData(int id);

        void DeleteExpense(int id);

        Dictionary<string, double> CalculateMonthlyExpense();

        Dictionary<string, double> CalculateWeeklyExpense();
    }

    public class ExpenseReportService : BaseService, IExpenseReportService
    {
        private EasyStockManagerDbContext db;

        public ExpenseReportService(EasyStockManagerDbContext _db, IUnitOfWorks unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
            db = _db;
        }

        public IEnumerable<ExpenseReport> GetAllExpenses()
        {
            try
            {
                return db.ExpenseReport.ToList();
            }
            catch
            {
                throw;
            }
        }

        // To filter out the records based on the search string
        public IEnumerable<ExpenseReport> GetSearchResult(string searchString)
        {
            List<ExpenseReport> exp = new List<ExpenseReport>();
            try
            {
                exp = GetAllExpenses().ToList();
                return exp.Where(x => x.ItemName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) != -1);
            }
            catch
            {
                throw;
            }
        }

        //To Add new Expense record
        public void AddExpense(ExpenseReport expense)
        {
            try
            {
                db.ExpenseReport.Add(expense);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar expense
        public int UpdateExpense(ExpenseReport expense)
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
        public ExpenseReport GetExpenseData(int id)
        {
            try
            {
                ExpenseReport expense = db.ExpenseReport.Find(id);
                return expense;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular expense
        public void DeleteExpense(int id)
        {
            try
            {
                ExpenseReport emp = db.ExpenseReport.Find(id);
                db.ExpenseReport.Remove(emp);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        // To calculate last six months expense
        public Dictionary<string, double> CalculateMonthlyExpense()
        {
            List<ExpenseReport> lstEmployee = new List<ExpenseReport>();

            Dictionary<string, double> dictMonthlySum = new Dictionary<string, double>();

            double foodSum = db.ExpenseReport.Where
                (cat => cat.Category == "Food" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
                .Select(cat => cat.Amount)
                .Sum();

            double shoppingSum = db.ExpenseReport.Where
               (cat => cat.Category == "Shopping" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.Amount)
               .Sum();

            double travelSum = db.ExpenseReport.Where
               (cat => cat.Category == "Travel" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.Amount)
               .Sum();

            double healthSum = db.ExpenseReport.Where
               (cat => cat.Category == "Health" && (cat.ExpenseDate > DateTime.Now.AddMonths(-7)))
               .Select(cat => cat.Amount)
               .Sum();

            dictMonthlySum.Add("Food", foodSum);
            dictMonthlySum.Add("Shopping", shoppingSum);
            dictMonthlySum.Add("Travel", travelSum);
            dictMonthlySum.Add("Health", healthSum);

            return dictMonthlySum;
        }

        // To calculate last four weeks expense
        public Dictionary<string, double> CalculateWeeklyExpense()
        {
            List<ExpenseReport> lstEmployee = new List<ExpenseReport>();

            Dictionary<string, double> dictWeeklySum = new Dictionary<string, double>();

            double foodSum = db.ExpenseReport.Where
                (cat => cat.Category == "Food" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
                .Select(cat => cat.Amount)
                .Sum();

            double shoppingSum = db.ExpenseReport.Where
               (cat => cat.Category == "Shopping" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.Amount)
               .Sum();

            double travelSum = db.ExpenseReport.Where
               (cat => cat.Category == "Travel" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.Amount)
               .Sum();

            double healthSum = db.ExpenseReport.Where
               (cat => cat.Category == "Health" && (cat.ExpenseDate > DateTime.Now.AddDays(-28)))
               .Select(cat => cat.Amount)
               .Sum();

            dictWeeklySum.Add("Food", foodSum);
            dictWeeklySum.Add("Shopping", shoppingSum);
            dictWeeklySum.Add("Travel", travelSum);
            dictWeeklySum.Add("Health", healthSum);

            return dictWeeklySum;
        }

        public async Task<ServiceResult> AddAsync(ExpenseReportDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ExpenseReport entity = _mapper.Map<Data.Entity.ExpenseReport>(model);
                    entity.CreateDate = DateTime.Now;
                    await _unitOfWork.ExpenseReportRepository.AddAsync(entity);
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

        public async Task<ServiceResult<IEnumerable<ExpenseReportDTO>>> Find(ExpenseReportDTO criteria)
        {
            ServiceResult<IEnumerable<ExpenseReportDTO>> result = new ServiceResult<IEnumerable<ExpenseReportDTO>>();

            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.ExpenseReport> list = await _unitOfWork
                                                                .ExpenseReportRepository
                                                                .FindAsync(filter: x => (string.IsNullOrEmpty(criteria.ItemName) || x.ItemName.ToLower().Contains(criteria.ItemName.Trim().ToLower())) &&
                                                                 (criteria.SearchStartDate == null || x.ExpenseDate >= criteria.SearchStartDate) &&
                                                                                        (criteria.SearchEndDate == null || x.ExpenseDate <= criteria.SearchEndDate) &&
                                                                                        (criteria.Category == null || x.Category == criteria.Category),
                                                                           orderByDesc: x => x.Id,
                                                                           skip: criteria.PageNumber,
                                                                           take: criteria.RecordCount);

                    result.TransactionResult = _mapper.Map<IEnumerable<ExpenseReportDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = string.Format(CommonMessages.MSG0002, ex.Message);
            }

            return result;
        }

        public async Task<ServiceResult<int>> FindCount(ExpenseReportDTO criteria)
        {
            ServiceResult<int> result = new ServiceResult<int>();
            try
            {
                using (_unitOfWork)
                {
                    int count = await _unitOfWork.ExpenseReportRepository
                                                 .FindCountAsync(filter: x => (string.IsNullOrEmpty(criteria.ItemName) || x.ItemName.Contains(criteria.ItemName)) &&
                                                                 (criteria.SearchStartDate == null || x.ExpenseDate >= criteria.SearchStartDate) &&
                                                                                        (criteria.SearchEndDate == null || x.ExpenseDate <= criteria.SearchEndDate) &&
                                                                                        (criteria.Category == null || x.Category == criteria.Category));
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

        public async Task<ServiceResult<IEnumerable<ExpenseReportDTO>>> GetAll()
        {
            ServiceResult<IEnumerable<ExpenseReportDTO>> result = new ServiceResult<IEnumerable<ExpenseReportDTO>>();
            try
            {
                using (_unitOfWork)
                {
                    IEnumerable<Entity.ExpenseReport> list = await _unitOfWork.ExpenseReportRepository.GetAllAsync();
                    result.TransactionResult = _mapper.Map<IEnumerable<ExpenseReportDTO>>(list);
                }
            }
            catch (Exception ex)
            {
                result.IsSucceeded = false;
                result.UserMessage = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResult<ExpenseReportDTO>> GetById(int id)
        {
            ServiceResult<ExpenseReportDTO> result = new ServiceResult<ExpenseReportDTO>();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ExpenseReport entity = await _unitOfWork.ExpenseReportRepository.GetByIdAsync(id);
                    result.TransactionResult = _mapper.Map<ExpenseReportDTO>(entity);
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
                    await _unitOfWork.ExpenseReportRepository.RemoveById(id);
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

        public async Task<ServiceResult> Update(ExpenseReportDTO model)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                using (_unitOfWork)
                {
                    Entity.ExpenseReport entity = await _unitOfWork.ExpenseReportRepository.GetByIdAsync(model.Id.Value);
                    if (entity != null)
                    {
                        _mapper.Map(model, entity);
                        _unitOfWork.ExpenseReportRepository.Update(entity);
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