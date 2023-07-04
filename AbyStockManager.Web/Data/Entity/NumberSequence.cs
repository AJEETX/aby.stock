using System.ComponentModel.DataAnnotations;

using Aby.StockManager.Data.Entity;

namespace Aby.StockManager.Data.Entity
{
    public class NumberSequence : BaseEntity
    {
        public int NumberSequenceId { get; set; }

        [Required]
        public string NumberSequenceName { get; set; }

        [Required]
        public string Module { get; set; }

        [Required]
        public string Prefix { get; set; }

        public int LastNumber { get; set; }
    }

    public class InvoiceNumberSequence : BaseEntity
    {
        public int NumberSequenceId { get; set; }

        [Required]
        public string NumberSequenceName { get; set; }

        [Required]
        public string Module { get; set; }

        [Required]
        public string Prefix { get; set; }

        public int LastNumber { get; set; }
    }
}