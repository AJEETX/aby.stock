$(document).ready(function () {
    var datatable = $('#datatable').dataTable({
        "searching": false,
        "aLengthMenu": [
            [25, 50, 100, -1],
            [25, 50, 100, "All"]
        ],
        "iDisplayLength": 25,
        "ordering": false,
        "lengthChange": false,
        "bServerSide": true,
        "processing": true,
        "paging": true,
        "sAjaxSource": "/ServiceCategory/List",
        "info": true,
        "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
            aoData.push(
                { "name": "returnformat", "value": "plain" },
                { "name": "serviceCategoryName", "value": $('input[name="ServiceCategoryName"]').val() }
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
                    mDataProp: "ServiceCategoryName"
                },
                {
                    "sDefaultContent": "",
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        var buttons = "";
                        buttons += '<a href="/ServiceCategory/Edit/' + row.Id + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> Edit</a>&nbsp;'
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
        url: '/ServiceCategory/Delete/' + id,
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