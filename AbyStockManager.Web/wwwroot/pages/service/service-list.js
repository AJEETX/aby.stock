﻿$(document).ready(function () {
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
        "sAjaxSource": "/Service/List",
        "info": true,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"],
        "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
            aoData.push(
                { "name": "returnformat", "value": "plain" },
                { "name": "ItemName", "value": $('input[name="ItemName"]').val() },
                { "name": "ServiceCategoryId", "value": $('select[name="ServiceCategoryId"]').val() },
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
                    mDataProp: "ServiceCategory"
                },
                {
                    mDataProp: "Amount"
                },
                {
                    mDataProp: "ServiceDate"
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
                        buttons += '<a href="/Service/Edit/' + row.Id + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> Edit</a>&nbsp;'
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
        url: '/Service/Delete/' + id,
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
