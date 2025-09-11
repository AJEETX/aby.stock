namespace Aby.StockManager.Model.ViewModel.JsonResult
{
    public class JsonResultModel
    {
        public JsonResultModel()
        {
            IsSucceeded = true;
            IsRedirect = false;
        }

        public bool IsSucceeded { get; set; }
        public bool IsRedirect { get; set; }
        public string UserMessage { get; set; }
        public string RedirectUrl { get; set; }
        public object Data { get; set; }
        public string SubTotal { get; set; }
        public string GrandTotal { get; set; }
        public string GrandPlainTotal { get; set; }
        public string SgstTotal { get; set; }
        public string CgstTotal { get; set; }
        public string IgstTotal { get; set; }
        public string TaxTotal { get; set; }

        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StoreContact { get; set; }
        public string StoreGstin { get; set; }
        public string BankAccountNumber { get; set; }
        public string StoreIfsc { get; set; }
        public string StoreImage { get; set; }
        public string PrintHeader { get; set; } = "Tax Invoice";
        public string PrintBillType { get; set; } = "Invoice";
        public string PrintBilled { get; set; } = "Thanks!";
        public string PrintBillTo { get; set; } = "Bill to:";
        public string PrintBillNotice { get; set; } = "note: A finance charge of 1.5% be made on unpaid balance after 30 days.";
    }
}