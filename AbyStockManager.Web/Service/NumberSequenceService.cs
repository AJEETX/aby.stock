using Microsoft.EntityFrameworkCore;
using System.Threading;
using System;
using Aby.StockManager.Data.Entity;
using Aby.StockManager.Data.Context;
using System.Linq;

namespace Aby.StockManager.Web.Service
{
    public interface INumberSequenceService
    {
        string GetNumberSequence(string module);

        string GetInvoiceNumberSequence(string module);
    }

    public class NumberSequenceService : INumberSequenceService
    {
        private readonly EasyStockManagerDbContext _context;

        public NumberSequenceService(EasyStockManagerDbContext context)
        {
            this._context = context;
        }

        public string GetNumberSequence(string module)
        {
            string result = "";
            try
            {
                int counter = 0;

                NumberSequence numberSequence = _context.NumberSequence
                    .Where(x => x.Module.Equals(module))
                    .FirstOrDefault();

                if (numberSequence is null)
                {
                    numberSequence = new NumberSequence();
                    numberSequence.Module = module;
                    Interlocked.Increment(ref counter);
                    numberSequence.LastNumber = counter;
                    numberSequence.NumberSequenceName = module;
                    numberSequence.Prefix = module;

                    _context.Add(numberSequence);
                    _context.SaveChanges();
                }
                else
                {
                    counter = numberSequence.LastNumber;

                    Interlocked.Increment(ref counter);
                    numberSequence.LastNumber = counter;

                    _context.Update(numberSequence);
                    _context.SaveChanges();
                }

                result = DateTime.Now.ToString("yyyyMMdd") + counter.ToString().PadLeft(5, '0') + "#" + numberSequence.Prefix;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public string GetInvoiceNumberSequence(string module)
        {
            string result = "";
            try
            {
                int counter = 0;

                NumberSequence numberSequence = _context.NumberSequence
                    .Where(x => x.Module.Equals(module))
                    .FirstOrDefault();

                if (numberSequence is null)
                {
                    numberSequence = new NumberSequence();
                    numberSequence.Module = module;
                    Interlocked.Increment(ref counter);
                    numberSequence.LastNumber = counter;
                    numberSequence.NumberSequenceName = module;
                    numberSequence.Prefix = module;

                    _context.Add(numberSequence);
                    _context.SaveChanges();
                }
                else
                {
                    counter = numberSequence.LastNumber;

                    Interlocked.Increment(ref counter);
                    numberSequence.LastNumber = counter;

                    _context.Update(numberSequence);
                    _context.SaveChanges();
                }

                result = DateTime.Now.ToString("yyyyMMdd") + counter.ToString().PadLeft(5, '0') + "#" + numberSequence.Prefix;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}