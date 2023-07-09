var hindi = {
    "processing": "प्रगति पे हैं ...",
    "lengthMenu": " _MENU_ प्रविष्टियां दिखाएं ",
    "zeroRecords": "रिकॉर्ड्स का मेल नहीं मिला",
    "info": "_START_ से _END_ of _TOTAL_ प्रविष्टियां दिखा रहे हैं",
    "infoEmpty": "0 में से 0 से 0 प्रविष्टियां दिखा रहे हैं",
    "infoFiltered": "(_MAX_ कुल प्रविष्टियों में से छठा हुआ)",
    "search": "खोजें:",
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
    "loadingRecords": "प्रगति पे हैं ...",
    "searchPlaceholder": "खोजें ..."
};
var english = {
    "sLengthMenu": "Display _MENU_ records per page",
    "sZeroRecords": "Nothing found - sorry",
    "sInfo": "Showing _START_ to _END_ of _TOTAL_ records",
    "sInfoEmpty": "Showing 0 to 0 of 0 records",
    "sInfoFiltered": "(filtered from _MAX_ total records)"
};

var currentLang = english;

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
        language: {},
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
                                $("<span>", { "class": "required-indicator" }).text("*")
                            );
                            $(row).css({ 'color': 'red' });
                        }
                        else {
                            $(row).css({ 'color': 'green' });
                        }
                        var buttons = "";
                        buttons += '<a href="/Product/Edit/' + row.Id + '" class="btn btn-xs btn-warning"><i class="fas fa-pen"></i> ' + setEditButton() + '</a>&nbsp;'
                        buttons += '<a onclick="deleteRow(this,' + row.Id + ')"  class="btn btn-xs btn-danger"><i class="fas fa-trash"></i> ' + setDeleteButton() + '</a>'
                        return buttons;
                    }
                }
            ],
        rowCallback: function (row, data, index) {
            if (data.Stockedin === false) {
                $(row).find('td:eq(0)').append(
                    $("<span>", { "class": "required-indicator" }).text("*")
                );
                $(row).css({ 'color': 'red' });
            }
            else {
                $(row).css({ 'color': 'green' });
            }
        }
    });

    $('#requestCulture_RequestCulture_UICulture_Name').click(function () {
        dtable.fnDestroy();
        dtable = null;
        currentLang = (currentLang == english) ? hindi : english;
        dtable = $('#table_id').dataTable({ "oLanguage": currentLang });
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