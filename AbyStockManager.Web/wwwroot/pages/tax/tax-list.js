$(document).ready(function () {
    var datatable = $('#datatable').dataTable({
        "searching": true,
        "iDisplayLength": 10,
        "ordering": true,
        "lengthChange": true,
        "bServerSide": true,
        "processing": true,
        "paging": true,
        "sAjaxSource": "/Tax/List",
        "info": true,
        "search": {
            return: true
        },
        "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
            aoData.push(
                { "name": "returnformat", "value": "plain" },
                { "name": "Name", "value": $('input[name="Name"]').val() }
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
                    mDataProp: "Name"
                },
                {
                    mDataProp: "Rate"
                },
                {
                    "sDefaultContent": "",
                    "bSortable": false,
                    "mRender": function (data, type, row) {
                        var buttons = "";
                        buttons += '<a href="/Tax/Edit/' + row.Id + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> ' + setEditButton() + '</a>&nbsp;'
                        buttons += '<a onclick="deleteRow(this,' + row.Id + ')"  class="btn btn-xs btn-danger"><i class="fas fa-trash"></i> ' + setDeleteButton() + '</a>'
                        return buttons;
                    }
                }
            ],
        "fnDrawCallback": function (oSettings) {
            setCulture($('#requestCulture_RequestCulture_UICulture_Name').val());
        }
    });

    function setCulture(changedLangValue) {
        if (changedLangValue != 'hi') {
            datatable.fnDestroy();
            datatable = null;
            datatable = $('#datatable').dataTable({
                language: en
            });
        } else {
            datatable.fnDestroy();
            datatable = null;
            datatable = $('#datatable').dataTable({
                language: hi
            });
        }
    }
    $('#requestCulture_RequestCulture_UICulture_Name').change(function () {
        setCulture($('#requestCulture_RequestCulture_UICulture_Name').val());
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
        url: '/Tax/Delete/' + id,
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