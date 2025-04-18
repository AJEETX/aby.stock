﻿$(document).ready(function () {
    var datatable = $('#datatable').dataTable({
        "aLengthMenu": [
            [25, 50, 100, -1],
            [25, 50, 100, "All"]
        ],
        "iDisplayLength": 25,
        "dom": 'lBfrtip',
        "searching": false,
        "ordering": false,
        "bServerSide": true,
        "processing": true,
        "sAjaxSource": "/Report/StoreStockList",
        "info": true,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"],
        "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
            aoData.push(
                { "name": "returnformat", "value": "plain" },
                { "name": "StoreId", "value": $('select[name="StoreId"]').val() },
                { "name": "ProductId", "value": $('select[name="ProductId"]').val() }
            );
            $.ajax({
                "dataType": 'json',
                "type": "GET",
                "url": sSource,
                "data": aoData,
                "success": function (data) {
                    if (data.IsSucceeded == true) {
                        $('#total-price').html(data.iAllProductTotalPrice);
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
                    mDataProp: "ProductFullName"
                },
                {
                    mDataProp: "QTY"
                },
                {
                    mDataProp: "StoreFullName", bVisible: false
                },

                {
                    mDataProp: "ProductPrice"
                },
                {
                    mDataProp: "ProductTotalDisplayPrice"
                },
                {
                    "sDefaultContent": "",
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        var buttons = "";
                        buttons += '<a href="/Report/Edit/' + row.ProductId + '" class="btn btn-xs btn-info"><i class="fas fa-pen"></i> Detail</a>&nbsp;'
                        //buttons += '<a onclick="deleteRow(this,' + row.Id + ')"  class="btn btn-xs btn-danger"><i class="fas fa-trash"></i> Delete</a>'
                        return buttons;
                    },
                }

            ],
        rowCallback: function (row, data, index) {
            if (data.Quantity == 0) {
                $(row).find('td:eq(1)').append(
                    $("<span>", { "class": "required-indicator" }).text("*")
                );
                $(row).css({ 'color': 'red', 'font-weight': 'bold' });
            }
            else if (data.Quantity == 1 || data.Quantity == 2) {
                $(row).find('td:eq(1)').append(
                    $("<span>", { "class": "required-indicator" }).text("*")
                );
                $(row).css({ 'color': '#CE760B', 'font-weight': 'bold' });
            }
            else if (data.Quantity >= 3) {
                $(row).css({ 'color': 'green', 'font-weight': 'bold' });
            }
        },
    });

    $("#btnFilter").click(function () {
        datatable.fnFilter();
    });

    $("#btnClear").click(function () {
        $('div.dataTable-search-form').clearForm();
        $("#ProductId").val(null).trigger('change');
        datatable.fnFilter();
    });

    $('.enter-keyup').keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            datatable.fnFilter();
        }
    });

    $("#ProductId").select2({
        minimumInputLength: 1,
        ajax: {
            url: '/Report/GetProduct',
            dataType: 'json',
            type: "GET",
            delay: 500,
            data: function (params) {
                return {
                    search: params.term
                };
            },
            processResults: function (data) {
                return {
                    results: $.map(data, function (item) {
                        return {
                            text: item.Text,
                            id: item.Value
                        }
                    })
                };
            }
        }
    });

    $('.select2').on("click", function () {
        console.log('clicked')
        $(".select2-search__field")[0].focus();
    });
});