var hi = {
    "processing": "प्रगति पे हैं ...",
    "lengthMenu": " _MENU_ प्रविष्टियां दिखाएं ",
    "zeroRecords": "रिकॉर्ड्स का मेल नहीं मिला",
    "info": "_START_ से _END_ of _TOTAL_ प्रविष्टियां दिखा रहे हैं",
    "infoEmpty": "0 में से 0 से 0 प्रविष्टियां दिखा रहे हैं",
    "infoFiltered": "(_MAX_ कुल प्रविष्टियों में से छठा हुआ)",
    "paginate": {
        "first": "प्रथम",
        "previous": "पिछला",
        "next": "अगला",
        "last": "अंतिम"
    },
    "emptyTable": "तालिका में आंकड़े उपलब्ध नहीं है",
    "aria": {
        "sortAscending": "आरोही क्रम",
        "sortDescending": "अवरोही क्रम"
    },
    "autoFill": {
        "cancel": "रद्द करें",
        "fill": "भरें",
        "fillHorizontal": "क्षैतिज भरें",
        "fillVertical": "लंबवत भरें",
        "info": "जानकारी"
    },
    "buttons": {
        "collection": "संग्रह",
        "colvis": "स्तंभ दृश्यता",
        "colvisRestore": "दृश्यता बहाल करें",
        "copy": "प्रतिलिपि",
        "copyTitle": "शीर्षक प्रतिलिपि",
        "csv": "सीएसवी",
        "excel": "एक्सेल",
        "pdf": "पीडीएफ",
        "print": "छपाई"
    },
    "thousands": "हज़ार",
    "decimal": "दशमलव",
    "searchBuilder": {
        "add": "जोड़ना",
        "clearAll": "सभी साफ करें",
        "condition": "शर्त",
        "data": "जानकारी",
        "leftTitle": "बायां शीर्षक",
        "rightTitle": "सही शीर्षक",
        "value": "कीमत"
    },
    "searchPanes": {
        "count": "गिनती करना",
        "title": "शीर्षक",
        "showMessage": "संदेश दिखाओ"
    },
    "datetime": {
        "previous": "पहले का",
        "next": "अगला",
        "hours": "घंटे",
        "minutes": "मिनट",
        "seconds": "सेकंड"
    },
    "editor": {
        "error": {
            "system": "त्रुटि प्रणाली"
        },
        "multi": {
            "title": "बहु शीर्षक"
        }
    },
    "loadingRecords": "प्रगति पे हैं ..."
};

$(document).ready(function () {
    var datatable = $('#datatable').dataTable({
        "searching": false,
        "iDisplayLength": 10,
        "ordering": false,
        "lengthChange": false,
        "bServerSide": true,
        "processing": true,
        "paging": true,
        "sAjaxSource": "/Tax/List",
        "info": true,
        language: {
            url: '//cdn.datatables.net/plug-ins/1.13.5/i18n/hi.json',
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
                        buttons += '<a href="/Tax/Edit/' + row.Id + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> Edit</a>&nbsp;'
                        buttons += '<a onclick="deleteRow(this,' + row.Id + ')"  class="btn btn-xs btn-danger"><i class="fas fa-trash"></i> Delete</a>'
                        return buttons;
                    }
                }
            ]
    });
    var currentLang = null;
    function setCulture(changedLangValue) {
        datatable.fnDestroy();
        datatable = null;
        if (changedLangValue == 'hi') {
            datatable = $('#datatable').dataTable({
                language: {
                    url: '//cdn.datatables.net/plug-ins/1.13.5/i18n/hi.json',
                },
            });
        } else {
            datatable = $('#datatable').dataTable({
                language: {
                    url: '//cdn.datatables.net/plug-ins/1.13.5/i18n/en-GB.json',
                },
            });
        }
    }
    $('#requestCulture_RequestCulture_UICulture_Name').change(function () {
        setCulture($('#requestCulture_RequestCulture_UICulture_Name').val());
    });
    //setCulture($('#requestCulture_RequestCulture_UICulture_Name').val());

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