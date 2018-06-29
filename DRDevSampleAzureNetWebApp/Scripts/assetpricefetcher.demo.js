$(document).ready(function () {
    setInterval(function () {
        $.ajax({
            type: "POST",
            url: "/Home/GetAssetPrices",
            data: '',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                $('#assetContainer tbody').empty();
                $.each(response, function (i, item) {
                    var row = "<tr>"
                        + "<td class='tblItem'>" + item.Name + "</td>"
                        + "<td class='tblItem'>" + item.Value + "</td>"
                        + "<td class='tblItem'>" + item.LastUpdate + "</td>"
                        + "</tr>";
                    $('#assetContainer tbody').append(row);
                });
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
                var r = jQuery.parseJSON(response.responseText);
                alert("Message: " + r.Message);
                alert("StackTrace: " + r.StackTrace);
                alert("ExceptionType: " + r.ExceptionType);
            }
        });
    }, 5000);
});