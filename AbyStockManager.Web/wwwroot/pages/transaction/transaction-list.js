$(document).ready(function () {
    var datatable = $('#datatable').dataTable({
        "dom": 'lBfrtip',
        "searching": false,
        "aLengthMenu": [
            [25, 50, 100, -1],
            [25, 50, 100, "All"]
        ],
        "iDisplayLength": 25,
        "ordering": false,
        "bServerSide": true,
        "processing": true,
        "paging": true,
        "sAjaxSource": "/Transaction/List",
        "info": true,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"],
        "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
            aoData.push(
                { "name": "returnformat", "value": "plain" },
                { "name": "TransactionCode", "value": $('input[name="TransactionCode"]').val() },
                { "name": "SearchStartDate", "value": $('input[name="SearchStartDate"]').val() },
                { "name": "SearchEndDate", "value": $('input[name="SearchEndDate"]').val() },
                { "name": "TransactionTypeId", "value": $('select[name="TransactionTypeId"]').val() },
                { "name": "StoreId", "value": $('select[name="StoreId"]').val() },
                { "name": "ToStoreId", "value": $('select[name="ToStoreId"]').val() }
            );
            $.ajax({
                "dataType": 'json',
                "type": "GET",
                "url": sSource,
                "data": aoData,
                "success": function (data) {
                    if (data.IsSucceeded == true) {
                        fnCallback(data);
                    }
                    else {
                        toastr.error(data.UserMessage);
                    }
                }
            });
        },
        aoColumns:
            [
                {
                    mDataProp: "TransactionCode", bVisible: false
                },
                {
                    mDataProp: "InvoiceNumber"
                },
                {
                    mDataProp: "Description"
                },
                {
                    mDataProp: "AmountWithGst"
                },
                {
                    mDataProp: "AmountWithoutGst"
                },
                {
                    mDataProp: "SGst"
                },
                {
                    mDataProp: "CGst"
                },
                {
                    mDataProp: "IGst"
                },
                {
                    mDataProp: "Amount"
                },
                {
                    mDataProp: "Gstin"
                },
                {
                    mDataProp: "TransactionTypeName", bVisible: false
                },
                {
                    mDataProp: "TransactionDate"
                },
                {
                    mDataProp: "StoreName", bVisible: false
                },
                {
                    mDataProp: "ToStoreName", bVisible: false
                },
                {
                    "sDefaultContent": "",
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        var buttons = "";
                        var invoiceNumber = row['InvoiceNumber'];
                        var description = row['Description'];
                        buttons += '<a id="print-invoice" onclick="detailShow(this,' + row.Id + ')"  class="btn btn-xs btn-default"><i class="fas fa-print"></i> Print</a>&nbsp;'

                        //if (invoiceNumber != null && invoiceNumber != '' && invoiceNumber.startsWith('Inv')) {
                        //    buttons += '<a id="print-invoice" onclick="detailShow(this,' + row.Id + ')"  class="btn btn-xs btn-default"><i class="fas fa-print"></i> Print</a>&nbsp;'
                        //}
                        //else

                        //if (invoiceNumber == null) {
                        //    row['Description'] = 'Good Received';
                        //}
                        //if (invoiceNumber != null && invoiceNumber.endsWith('StockIn')) {
                        //    row['Description'] = 'Good Received';
                        //}
                        buttons += '<a href="/Transaction/Edit/' + row.Id + '?typeId=' + row.TransactionTypeId + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> Edit</a>&nbsp;'
                        //buttons += '<a href="/Transaction/Print/' + row.Id + '?typeId=' + row.TransactionTypeId + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> PRINT</a>&nbsp;'
                        buttons += '<a onclick="deleteRow(this,' + row.Id + ')"  class="btn btn-xs btn-danger"><i class="fas fa-trash"></i> Delete</a>'
                        return buttons;
                    }
                }
            ],
        rowCallback: function (row, data, index) {
            //if (data.InvoiceNumber == null) {
            //    $(row).find('td:eq(1)').append(
            //        $("<span>", { "class": "required-indicator" }).text("Goods Received *")
            //    );
            //    $(row).find('td:eq(0)').append(
            //        $("<span>", { "class": "required-indicator" }).text("stock-in *")
            //    );
            //    $(row).find('td:eq(1)').css({ 'font-style': 'italic' });
            //}
            //else if (data.InvoiceNumber != null && data.InvoiceNumber.endsWith('StockIn')) {
            //    $(row).find('td:eq(1)').append(
            //        $("<span>", { "class": "required-indicator" }).text("Goods Received *")
            //    );
            //    $(row).find('td:eq(1)').css({ 'font-style': 'italic' });
            //    //$(row).find('td:eq(0)').css({ 'color': 'red', 'font-style': 'italic' });
            //}
        }
    });

    $("#btnFilter").click(function () {
        datatable.fnFilter();
    });

    $("#btnClear").click(function () {
        $('div.dataTable-search-form').clearForm();
        datatable.fnFilter();
    });

    $('.enter-keyup').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            datatable.fnFilter();
        }
    });
});

function deleteRow(row, id) {
    $.ajax({
        url: '/Transaction/Delete/' + id,
        type: "POST",
        async: false,
        success: function (data) {
            if (data.IsSucceeded) {
                var aPos = $('#datatable').dataTable().fnGetPosition(row);
                $('#datatable').dataTable().fnDeleteRow(aPos);
                toastr.success(data.UserMessage);
            }
            else {
                toastr.error(data.UserMessage);
            }
        }
    });
}

function detailShow(row, id) {
    $("#invoice-table tbody").empty();
    var str = '';
    $.ajax({
        url: '/Transaction/GetTransactionDetail/' + id,
        type: "GET",
        success: function (data) {
            if (data.IsSucceeded) {
                $('#print-header').text(data.PrintHeader);
                $('#print-bill-type').text(data.PrintBillType);
                $('#print-bill-disclaimer').text(data.PrintBillType);
                $('#print-bill-date').text(data.PrintBillType);
                $('#print-bill-due-date').text(data.PrintBillType);
                $('#thanks').text(data.PrintBilled);
                $('#bill-to').text(data.PrintBillTo);
                $('#bill-notice').text(data.PrintBillNotice);
                $('#print-header').text(data.PrintHeader);
                $('#store-image').attr('src', data.StoreImage);
                $('#store-name').text(data.StoreName);
                $('#store-address').text(data.StoreAddress);
                $('#store-contact').text(data.StoreContact);
                $('#store-gstin').text(data.StoreGstin);

                $('#amount-total').text(data.SubTotal);
                $('#grand-total').text(data.GrandTotal);
                $('#grand-plain-total').text(data.GrandPlainTotal);
                $('#tax-total').text(data.TaxTotal);
                $('#sgst-total').text(data.SgstTotal);
                $('#cgst-total').text(data.CgstTotal);
                $('#igst-total').text(data.IgstTotal);

                $.each(data.Data, function (i, item) {
                    $('#invoice-contact').text(item.Contact);
                    $('#invoice-gstin').text(item.Gstin);
                    $('#invoice-remarks').text(item.Remarks);
                    $('#invoice-description').text(item.Description);
                    $('#invoice-number').text(item.InvoiceNumber);
                    $('#invoice-date').text(item.TransactionDate);
                    $('#invoice-due-date').text(item.TransactionDueDate);
                    var count = i + 1;
                    str += '<tr>';
                    str += '<td class="no"> ' + count + ' </td>';
                    str += '<td class="desc">' + item.ProductName + ' </td>';
                    str += '<td class="unit">' + item.UnitPrice + ' </td>';
                    str += '<td  class="qty">' + item.Amount + ' </td>';
                    str += '<td  class="tax">' + item.Tax + ' </td>';
                    str += '<td  class="total">' + item.SubTotalPrice + ' </td>';
                    str += '</tr>';
                });
                $("#invoice-table tbody").append(str);
                //$('#print-invoice').attr('href', 'Transaction/Print?id=' + id);
            }
            else {
                toastr.error(data.UserMessage);
            }
        }
    });

    $('#modal-detail').modal('show');
}