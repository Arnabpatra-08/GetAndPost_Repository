$(document).ready(function () {
    getcountry();
    getstate();
    getcity()
    getsellerdtl();

})



//********************************************************* for binding country *****************************************

function getcountry() {
    
    $.ajax({
        type: "GET",
        url: "../Myproject/getcountryname",
        data: {},
        dataType: 'json',
        context: document.body,
        success: function (data) {
            
            $.each(data.bcountry, function (item, value) {

                $("#Country").append($("<option></option>").val(value.countryId).html(value.countryname));
            });

        },

        error: function (error) {

            alert("Not Found");
        }
    });
};

//************************************ for binding state according to country *******************************************

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
            debugger
            $.each(data.bstate, function (item, value) {

                $("#State").append($("<option></option>").val(value.stateId).html(value.statename));
            });

        },

        error: function (error) {

            alert("Not Found");
        }
    });
};

//******************************** for binding city according to state ***********************************************

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
            debugger
           
            $.each(data.bcity, function (item, value) {

                $("#City").append($("<option></option>").val(value.cityId).html(value.cityname));
            });

        },

        error: function (error) {

            alert("Not Found");
        }
    });
};


//************************************* for get seller details to admindashboard page **************************
function getsellerdtl() {
    debugger
    $.ajax({
        type: "GET",
        url: "/Myproject/getallselllist",
        data: {},
        dataType: "JSON",
        context: document.body,
        success: function (data) {

            var row = "";
            var rowcount = 1;
            $.each(data.sell, function (item, value) {
                debugger
                row += "<tr>";
                row += "<td>" + rowcount + "</td>";
                row += "<td>" + value.name + "</td>";
                row += "<td>" + value.moblieno + "</td>";
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
                row += "<td>" +
                    "<button type='button' class='btn btn-sm btn-danger' onclick='DeletesellerdtlMaster(" + value.id + ",event)'><i class='fa fa-trash' aria-hidden='true'></i></button>" +
                    "<button type='button' class='btn btn-sm btn-info' onclick='ViewMaster(" + value.filepath2 + ",event)'><i class='fa fa-eye' aria-hidden='true'></i></button>" +
                    "</td>";
                row += "</tr>";       

                rowcount += 1;
            });
            debugger
            $("#admintable").append(row);
        },
        error: function (error) {
            alert("Not Found");
        }
    });
}

//****************************************** for delete *******************************************************

function DeletesellerdtlMaster(control, e) {
    debugger
    // ClearSubmitForm()
    e.preventDefault();
    //Id = cid;

    var id = control;
    $.ajax({
        type: "POST",
        url: "../Myproject/Deletesellerdata/" + id,
        dataType: "JSON",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            debugger

            window.location.reload();
            alert("Details has been deleted...");
        },
        error: function (error) {

            debugger;
            alert('Some error occured.');
        }
    });

}

//******************************************* for view button ************************************************************
debugger
function ViewMaster(filepath2, event) {

    console.log("file Path2:", filepath2);
   
    $("#imageModal").find("img").attr("src", filepath2);
    $("#imageModal").modal("show");
}





//************************************************** function for seaching.*************************************************
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

//********************************************for location wise filter searching*********************************************
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

