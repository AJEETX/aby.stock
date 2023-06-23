﻿$(document).ready(function () {
    var datatable = $('#datatable').dataTable({
        "searching": false,
        "iDisplayLength": 10,
        "ordering": false,
        "lengthChange": false,
        "bServerSide": true,
        "processing": true,
        "paging": true,
        "sAjaxSource": "/Transaction/List",
        "info": true,
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
                    mDataProp: "TransactionCode"
                },
                {
                    mDataProp: "InvoiceNumber"
                },
                {
                    mDataProp: "Description"
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
                        var columnValue = row['InvoiceNumber']; // Change the index (3) to the appropriate column index

                        if (columnValue.startsWith('Inv')) {
                            // Hide the button by finding it within the row and applying CSS display property
                            buttons += '<a id="print-invoice" onclick="detailShow(this,' + row.Id + ')"  class="btn btn-xs btn-default"><i class="fas fa-list"></i> Print</a>&nbsp;'
                        }
                        buttons += '<a href="/Transaction/Edit/' + row.Id + '?typeId=' + row.TransactionTypeId + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> Edit</a>&nbsp;'
                        //buttons += '<a href="/Transaction/Print/' + row.Id + '?typeId=' + row.TransactionTypeId + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> PRINT</a>&nbsp;'
                        buttons += '<a onclick="deleteRow(this,' + row.Id + ')"  class="btn btn-xs btn-danger"><i class="fas fa-trash"></i> Delete</a>'
                        return buttons;
                    }
                }
            ]
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
                $('#amount-total').text(data.SubTotal);
                $('#grand-total').text(data.GrandTotal);
                $('#grand-plain-total').text(data.GrandPlainTotal);
                $('#tax-total').text(data.TaxTotal);
                $('#sgst-total').text(data.SgstTotal);
                $('#cgst-total').text(data.CgstTotal);

                $.each(data.Data, function (i, item) {
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