$(document).ready(function () {
    //alert("wellcome");
    getcountry();
    getstate();
    getcity();
    getsellerdtl();

})


//********************************************************************************************************************************** */

function getcountry() {

    $.ajax({
        type: "GET",
        url: "../Myproject/getcountryname",
        data: {},
        dataType: 'json',
        context: document.body,
        success: function (data) {

            //var row = "";
            //var rowcount = 1;
            $.each(data.bcountry, function (item, value) {

                $("#Country").append($("<option></option>").val(value.countryId).html(value.countryname));
            });

        },

        error: function (error) {

            alert("Not Found");
        }
    });
};

//******************************************************************************* */

$("#Country").change(function () {
    getstate();


});
function getstate() {
    debugger
    $("#State").empty();
    $("#State").append($('<option>Select</option>'));
    var stateselector = $("#Country").val();
    debugger
    $.ajax({
        type: "GET",
        url: "../Myproject/getstatename",
        data: { countryId: stateselector },
        dataType: 'json',
        context: document.body,
        success: function (data) {
            debugger;
            //var row = "";
            //var rowcount = 1;
            $.each(data.bstate, function (item, value) {

                $("#State").append($("<option></option>").val(value.stateId).html(value.statename));
            });

        },

        error: function (error) {

            alert("Not Found");
        }
    });
};

//******************************************************************************* */

$("#State").change(function () {
    getcity();


});
function getcity() {
    debugger
    $("#City").empty();
    $("#City").append($('<option>Select</option>'));
    var cityselector = $("#State").val();
    debugger
    $.ajax({
        type: "GET",
        url: "../Myproject/getcityname",
        data: { stateId: cityselector },
        dataType: 'json',
        context: document.body,
        success: function (data) {
            debugger;
            //var row = "";
            //var rowcount = 1;
            $.each(data.bcity, function (item, value) {

                $("#City").append($("<option></option>").val(value.cityId).html(value.cityname));
            });

        },

        error: function (error) {

            alert("Not Found");
        }
    });
};

function getsellerdtl() {
    debugger
    $.ajax({
        type: "GET",
        url: "/Myproject/getallbuylist",
        data: {},
        dataType: "JSON",
        context: document.body,
        success: function (data) {

            var row = "";
            var rowcount = 1;
            $.each(data.buy, function (item, value) {
                debugger
                row += "<tr>";
                row += "<td>" + rowcount + "</td>";
                row += "<td>" + value.buyerName + "</td>";
                row += "<td>" + value.buyerMoblieno + "</td>";
                row += "<td>" + value.countryname + "</td>";
                row += "<td>" + value.statename + "</td>";
                row += "<td>" + value.cityname + "</td>";
                row += "<td>" + value.carModel + "</td>";
                row += "<td>" + value.carPrice + "</td>";
                row += "<td>" + value.companyName + "</td>";
                row += "<td>" + value.usageYears + "</td>";
                row += "<td>" + value.carColor + "</td>";
                row += "<td>" + value.carCondition + "</td>";
                row += "<td>" + value.mileage + "</td>";
                row += "<td>" + value.remarks + "</td>";
                //row += "<td>" +
                //    "<button type='button' class='btn btn-sm btn-info' data-id=''onclick='viewsellerMaster(" + value.url + ",event)'><i class='fa fa-eye' aria-hidden='true'></i></button>" +
                //    "</td>";
                row += "</tr>";

                rowcount += 1;
            });
            debugger
            $("#buyertabledtl").append(row);
        },
        error: function (error) {
            alert("Not Found");
        }
    });
}




// function for seaching........
$('#search').on('keyup', function () {
    var searchTerm = $(this).val().toLowerCase();
    $('#usertbl tbody tr').each(function () {
        var lineStr = $(this).text().toLowerCase();
        if (lineStr.indexOf(searchTerm) === -1) {
            $(this).hide();
        } else {
            $(this).show();
        }
    });
});


$("#Country").change(function () {
    debugger
    var filterCountry = $("#Country option:selected").html().toLowerCase();

    $('#usertbl tbody tr').each(function () {
        debugger
        var lineStr = $(this).text().toLowerCase();
        if (lineStr.indexOf(filterCountry) === -1) {
            $(this).hide();
        } else {
            $(this).show();
        }
    });
});


$("#State").change(function () {
    debugger
    var filterState = $("#State option:selected").html().toLowerCase();
    $('#usertbl tbody tr').each(function () {
        debugger
        var lineStr = $(this).text().toLowerCase();
        if (lineStr.indexOf(filterState) === -1) {
            $(this).hide();
        } else {
            $(this).show();
        }
    });
});

$("#City").change(function () {
    debugger
    var filterCity = $("#City option:selected").html().toLowerCase();
    $('#usertbl tbody tr').each(function () {
        debugger
        var lineStr = $(this).text().toLowerCase();
        if (lineStr.indexOf(filterCity) === -1) {
            $(this).hide();
        } else {
            $(this).show();
        }
    });
});



       