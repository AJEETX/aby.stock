﻿$(document).ready(function () {
    var datatable = $('#datatable').dataTable({
        "dom": 'lBfrtip',
        "searching": false,
        "iDisplayLength": 100,
        "ordering": false,
        "bServerSide": true,
        "processing": true,
        "paging": false,
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

            ],
        rowCallback: function (row, data, index) {
            if (data.Quantity < 2) {
                $(row).find('td:eq(1)').append(
                    $("<span>", { "class": "required-indicator" }).text("*")
                );
                $(row).find('td:eq(1)').css({ 'color': 'red', 'font-weight': 'bold' });
            }
            else if (data.Quantity < 5) {
                $(row).find('td:eq(1)').append(
                    $("<span>", { "class": "required-indicator" }).text("*")
                );
                $(row).find('td:eq(1)').css({ 'color': '#FFBF00', 'font-weight': 'bold' });
            }
            else if (data.Quantity >= 5) {
                $(row).find('td:eq(1)').css({ 'color': 'green', 'font-weight': 'bold' });
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