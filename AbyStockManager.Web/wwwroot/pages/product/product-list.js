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
        "sAjaxSource": "/Product/List",
        "info": true,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"],
        "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
            aoData.push(
                { "name": "returnformat", "value": "plain" },
                { "name": "ProductName", "value": $('input[name="ProductName"]').val() },
                { "name": "Barcode", "value": $('input[name="Barcode"]').val() },
                { "name": "CategoryId", "value": $('select[name="CategoryId"]').val() },
                { "name": "UnitOfMeasureId", "value": $('select[name="UnitOfMeasureId"]').val() }
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
                    "sDefaultContent": "",
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        var img = '<img src="' + row.ImageDisplay + '" src height="60" width="60" />';
                        return img;
                    }, bVisible: false
                },
                {
                    mDataProp: "ProductName"
                },
                {
                    mDataProp: "PurchasePrice"
                },
                {
                    mDataProp: "SalePrice"
                },
                {
                    mDataProp: "Tax"
                },
                {
                    mDataProp: "CategoryName"
                },
                {
                    mDataProp: "UnitOfMeasureName"
                },
                {
                    mDataProp: "Barcode", bVisible: false
                },
                {
                    "sDefaultContent": "",
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        var stockedin = row['Stockedin'];
                        var qty = row['Qty'];

                        if (stockedin == false) {
                            $(row).find('td:eq(0)').append(
                                $("<span>", { "class": "required-indicator" }).text("* {" + qty + "}")
                            );
                            $(row).find('td:eq(0)').css({ 'color': 'red' });
                        }
                        else {
                            $(row).find('td:eq(0)').append(
                                $("<span>", { "class": "required-indicator" }).text("* {" + qty + "}")
                            );
                            $(row).find('td:eq(0)').css({ 'color': 'green' });
                        }
                        var buttons = "";
                        buttons += '<a href="/Product/Edit/' + row.Id + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> Edit</a>&nbsp;'
                        buttons += '<a onclick="deleteRow(this,' + row.Id + ')"  class="btn btn-xs btn-danger"><i class="fas fa-trash"></i> Delete</a>'
                        return buttons;
                    }
                }
            ],
        rowCallback: function (row, data, index) {
            if (data.Stockedin === false) {
                $(row).find('td:eq(0)').append(
                    $("<span>", { "class": "required-indicator" }).text("* {" + data.Qty + "}")
                );
                $(row).find('td:eq(0)').css({ 'color': 'red' });
            }
            else {
                $(row).find('td:eq(0)').append(
                    $("<span>", { "class": "required-indicator" }).text("* {" + data.Qty + "}")
                );
                $(row).find('td:eq(0)').css({ 'color': 'green' });
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
        url: '/Product/Delete/' + id,
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