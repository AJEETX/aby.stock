$(document).ready(function () {
    var datatable = $('#datatable').dataTable({
        "dom": 'lBfrtip',
        "searching": false,
        "iDisplayLength": 100,
        "ordering": false,
        "bServerSide": true,
        "processing": true,
        "paging": true,
        "sAjaxSource": "/Expense/List",
        "info": true,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"],
        "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
            aoData.push(
                { "name": "returnformat", "value": "plain" },
                { "name": "ItemName", "value": $('input[name="ItemName"]').val() },
                { "name": "Category", "value": $('select[name="Category"]').val() },
                { "name": "SearchStartDate", "value": $('input[name="SearchStartDate"]').val() },
                { "name": "SearchEndDate", "value": $('input[name="SearchEndDate"]').val() }
            );
            $.ajax({
                "dataType": 'json',
                "type": "GET",
                "url": sSource,
                "data": aoData,
                "success": function (data) {
                    if (data.IsSucceeded == true) {
                        $('#total-expense').html(data.iAllProductTotalPrice);
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
                    mDataProp: "ItemName"
                },
                {
                    mDataProp: "Category"
                },
                {
                    mDataProp: "Amount"
                },
                {
                    mDataProp: "ExpenseDate"
                },
                {
                    "sDefaultContent": "",
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        var buttons = "";
                        var invoiceNumber = row['InvoiceNumber'];
                        var description = row['Description'];
                        //buttons += '<a id="print-invoice" onclick="detailShow(this,' + row.Id + ')"  class="btn btn-xs btn-default"><i class="fas fa-print"></i> Print</a>&nbsp;'

                        //if (invoiceNumber != null && invoiceNumber != '' && invoiceNumber.startsWith('Inv')) {
                        //    buttons += '<a id="print-invoice" onclick="detailShow(this,' + row.Id + ')"  class="btn btn-xs btn-default"><i class="fas fa-print"></i> Print</a>&nbsp;'
                        //}
                        //else
                        //if (invoiceNumber == null) {
                        //    row['Description'] = 'Good Received';
                        //}
                        buttons += '<a href="/Expense/Edit/' + row.Id + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> Edit</a>&nbsp;'
                        //buttons += '<a href="/Transaction/Print/' + row.Id + '?typeId=' + row.TransactionTypeId + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> PRINT</a>&nbsp;'
                        buttons += '<a onclick="deleteRow(this,' + row.Id + ')"  class="btn btn-xs btn-danger"><i class="fas fa-trash"></i> Delete</a>'
                        return buttons;
                    }
                }
            ],
        rowCallback: function (row, data, index) {
            if (data.Description == 'Good Received') {
                $(row).find('td:eq(1)').append(
                    $("<span>", { "class": "required-indicator" }).text(" *")
                );
                $(row).find('td:eq(1)').css({ 'font-style': 'italic' });
            }
            if (data.InvoiceNumber == null) {
                $(row).find('td:eq(0)').append(
                    $("<span>", { "class": "required-indicator" }).text(" *")
                );
                $(row).find('td:eq(1)').css({ 'font-style': 'italic' });
            }
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
        url: '/Expense/Delete/' + id,
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
        url: '/Expense/GetTransactionDetail/' + id,
        type: "GET",
        success: function (data) {
            if (data.IsSucceeded) {
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

                $.each(data.Data, function (i, item) {
                    $('#invoice-contact').text(item.Contact);
                    $('#invoice-gstin').text(item.Gstin);
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