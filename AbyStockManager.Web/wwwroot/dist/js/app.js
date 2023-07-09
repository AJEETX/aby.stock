function setEditButton() {
    if ($('#requestCulture_RequestCulture_UICulture_Name').val() != 'hi') {
        return 'Edit'
    } else {
        return 'संपादन'
    }
}
function setDeleteButton() {
    if ($('#requestCulture_RequestCulture_UICulture_Name').val() != 'hi') {
        return 'Delete'
    } else {
        return 'हटाएं'
    }
}
var en =
{
    "sEmptyTable": "No data available in table",
    "sInfo": "Showing _START_ to _END_ of _TOTAL_ entries",
    "sInfoEmpty": "Showing 0 to 0 of 0 entries",
    "sInfoFiltered": "(filtered from _MAX_ total entries)",
    "sInfoPostFix": "",
    "sInfoThousands": ",",
    "sLengthMenu": "Show _MENU_ entries",
    "sLoadingRecords": "Loading...",
    "sProcessing": "Processing...",
    "sSearch": "Search below:",
    "sZeroRecords": "No matching records found",
    "oPaginate": {
        "sFirst": "First",
        "sLast": "Last",
        "sNext": "Next",
        "sPrevious": "Previous"
    },
    "oAria": {
        "sSortAscending": ": activate to sort column ascending",
        "sSortDescending": ": activate to sort column descending"
    }
};
var hi = {
    "processing": "प्रगति पे हैं ...",
    "lengthMenu": " _MENU_ प्रविष्टियां दिखाएं ",
    "zeroRecords": "रिकॉर्ड्स का मेल नहीं मिला",
    "info": "_START_ से _END_ कुल _TOTAL_ प्रविष्टियां दिखा रहे हैं",
    "infoEmpty": "0 में से 0 से 0 प्रविष्टियां दिखा रहे हैं",
    "infoFiltered": "(_MAX_ कुल प्रविष्टियों में से छठा हुआ)",
    "sSearch": "नीचे ढूँढ़ें:",
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

var hi2 =
{
    "sProcessing": "प्रगति पे हैं ...",
    "sLengthMenu": " _MENU_ प्रविष्टियां दिखाएं ",
    "sZeroRecords": "रिकॉर्ड्स का मेल नहीं मिला",
    "sInfo": "_START_ से _END_ कुल _TOTAL_ प्रविष्टियां दिखा रहे हैं",
    "sInfoEmpty": "0 में से 0 से 0 प्रविष्टियां दिखा रहे हैं",
    "sInfoFiltered": "(_MAX_ कुल प्रविष्टियों में से छठा हुआ)",
    "sInfoPostFix": "",
    "sSearch": "नीचे ढूँढ़ें:",
    "sUrl": "",
    "oPaginate": {
        "sFirst": "प्रथम",
        "sPrevious": "पिछला",
        "sNext": "अगला",
        "sLast": "अंतिम"
    }
};
$("#datatable_filter").on('enter-keyup', function () {
    datatable.fnFilter();
});
