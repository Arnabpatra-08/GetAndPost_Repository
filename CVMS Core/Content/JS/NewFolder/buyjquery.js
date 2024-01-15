$(document).ready(function () {
    //alert("wellcome");
    getcountry();
    getstate();
    getcity();
    getsellerdtl();
})

//******************************************************************************* */

function getcountry() {
    debugger
    $.ajax({
        type: "GET",
        url: "../Myproject/getcountryname",
        data: {},
        dataType: 'json',
        context: document.body,
        success: function (data) {
            debugger;
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

var mid = null;
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
                    "<button type='button' class='btn btn-sm btn-info' data-id=''onclick='viewsellerMaster(" + value.id + ",event)'><i class='fa fa-eye' aria-hidden='true'></i></button>" +
                    "<button type='button' class='btn btn-sm btn-success' data-id=''onclick='BuyerDtlMaster(" + value.id + ",event)'><i aria-hidden='true'>Buynow</i></button>" +
                    //<button type="button" id="customer-btn" class="btn btn-success btn-lg">Customer</button>
                    "</td>";
                row += "</tr>";       

                rowcount += 1;
            });
            debugger
            $("#mtable").append(row);
            mid = $("#hiddenId").val();   

        },
        error: function (error) {

            alert("Not Found");
        }
    });
}
//*********************************************************************************** */

function viewsellerMaster(control, e) {
    debugger
    // ClearSubmitForm()
    e.preventDefault();
    //Id = cid;

    var id = control;
    // $('#btnupdate').prop('disabled', false);
    debugger
    if (id > 0) {
        $.ajax({
            type: "GET",
            url: "../Myproject/viewdetails/" + id,
            dataType: "jSON",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                debugger
                $("#imgPreviewModal1").modal('show');
                var imgurl = data.company[0].filepath2;
                $("#imgshow").attr("src", imgurl);
                $("#imgshow").show();
               
            },
            error: function (xhr) {

                debugger;
                alert('Some error occured.');
            }
        });
    }
    else {
        alert('Some error occured. Please try again.');
    }
};

//****************************************************************************


//$("#viewclick").change(function () {
//    var fileInput1 = this.files[0];

//    if (fileInput1) {
//        var reader = new FileReader();

//        reader.onload = function (e) {
//            // Set the 'src' attribute of the <img> element to display the selected image
//            $("#imagePreview1").attr("src", e.target.result);
//        };

//        reader.readAsDataURL(fileInput1);
//    } else {
//        // Clear the 'src' attribute if no file is selected
//        $("#imagePreview1").attr("src", "");
//    }
//});

function openImagePreview1() {
    // Display the modal
    $("#imgPreviewModal1").modal("show");

    // Set the 'src' attribute of the <img> element in the modal to display the selected image
    var originalSrc = $("#imagePreview1").attr("src");
    $("#imgPreviewModal1 img.img-fluid").attr("src", originalSrc);
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


//********************************************** Location wise searching filter ************************************************** */
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



function BuyerDtlMaster(control, e) {
    debugger
    // ClearSubmitForm()
    e.preventDefault();
    //Id = cid;

    var id = control;
    // $('#btnupdate').prop('disabled', false);
    debugger
    if (id > 0) {
        $.ajax({
            type: "GET",
            url: "../Myproject/buyerdetails/" + id,
            dataType: "jSON",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                debugger
                $("#popupform").modal('show');
                $("#name").val(data.bdetail[0].name);
                $("#mobile").val(data.bdetail[0].moblieno);

                $("#country").val(data.bdetail[0].countryname);
                $("#state").val(data.bdetail[0].statename);
                $("#city").val(data.bdetail[0].cityname);
                $("#carModel").val(data.bdetail[0].carModel);
                $("#carPrice").val(data.bdetail[0].carPrice);
                $("#companyName").val(data.bdetail[0].companyName);
                $("#usageYears").val(data.bdetail[0].usageYears);
                $("#carColor").val(data.bdetail[0].carColor);
                $("#carCondition").val(data.bdetail[0].carCondition);
                $("#mileage").val(data.bdetail[0].mileage);
                $("#remarks").val(data.bdetail[0].remarks);
                //$("#filepath2").val(data.bdetail[0].filepath2);
                $("#hiddenId").val(data.bdetail[0].id);   //--------
            },
            error: function (xhr) {

                debugger;
                alert('Some error occured.');
            }
        });
    }
    else {
        alert('Some error occured. Please try again......');
    }
};
//******************************************** for save buyer data **************************************************************/

$("#Buy-submit-btn").click(function (event) {
    debugger

    var isValid = true;
    var name = $('#name').val();
    var mobile = $('#mobile').val();
    var country = $('#country').val();
    var state = $('#state').val();
    var city = $('#city').val();
    var carModel = $('#carModel').val();
    var carPrice = $('#carPrice').val();
    var companyName = $('#companyName').val();
    var carColor = $('#carColor').val();
    var usageYears = $('#usageYears').val();
    var carCondition = $('#carCondition').val();
    var mileage = $('#mileage').val();
    var remarks = $('#remarks').val();
    var buyname = $('#buyername').val().trim();
    var mobileno = $('#buyermobile').val();
    var phonePattern = /^[0-9]{10}$/;
    function isValidName(input) {
        return /^[A-Z][a-z]* [A-Z][a-z]*$/.test(input);
    }
    $('.error-message').text('');
    //**************************************all condition for validation***************************************

    if (country == null) {
        isValid = false;
        $('#country').addClass('border-danger');
    } else {
        $('#country').removeClass('border-danger');
    }

    if (state == 'Select') {
        isValid = false;
        $('#state').addClass('border-danger');
    } else {
        $('#state').removeClass('border-danger');
    }

    if (city == 'Select') {
        $('#city').addClass('border-danger');
        isValid = false;
    }
    else {
        $('#city').removeClass('border-danger');
    }

    if (carModel == '') {
        isValid = false;
        $('#carModel').addClass('border-danger');
    }
    else {
        $('#carModel').removeClass('border-danger');
    }


    if (carPrice == '') {
        $('#carPrice').addClass('border-danger');
        isValid = false;
    }
    else {
        $('#carPrice').removeClass('border-danger');
    }


    if (companyName == '') {
        $('#companyName').addClass('border-danger');
        isValid = false;
    }
    else {
        $('#companyName').removeClass('border-danger');
    }

    if (carColor == '') {
        $('#carColor').addClass('border-danger');
        isValid = false;
    }
    else {
        $('#carColor').removeClass('border-danger');
    }

    if (usageYears == '') {
        $('#usageYears').addClass('border-danger');
        isValid = false;
    }
    else {
        $('#usageYears').removeClass('border-danger');
    }

    if (carCondition == null) {
        $('#carCondition').addClass('border-danger');
        isValid = false;
    }
    else {
        $('#carCondition').removeClass('border-danger');
    }

    if (mileage == '') {
        $('#mileage').addClass('border-danger');
        isValid = false;
    }
    else {
        $('#mileage').removeClass('border-danger');
    }

    if (remarks == '') {
        $('#remarks').addClass('border-danger');
        isValid = false;
    }
    else {
        $('#remarks').removeClass('border-danger');
    }

    if (name == '') {
        $('#name').addClass('border-danger');
        isValid = false;
    }
    else {
        $('#name').removeClass('border-danger');
    }

    if (!phonePattern.test(mobile) || (mobile == '')) {
        isValid = false;
        $('#mobile').addClass('border-danger');
    }
    else {
        $('#mobile').removeClass('border-danger');
    }

    //-----------------------------------------------
    if (!isValidName(buyname)) {
        $('#buyername').addClass('border-danger');
        $('#buyname-error').text('Name should start with a capital letter then Title  and only contain alphabets like--Name Title.');

        isValid = false;
    } else {
        $('#buyername').removeClass('border-danger');
    }

    //if (buyname == '') {
    //    $('#buyername').addClass('border-danger');
    //    isValid = false;
    //}
    //else {
    //    $('#buyername').removeClass('border-danger');
    //}

    if (!phonePattern.test(mobileno) || (mobileno == '')) {
        isValid = false;
        $('#buyermobile').addClass('border-danger');
        $('#buymobile-error').text('Enter your 10 digits mobile no.');

    }
    else {
        $('#buyermobile').removeClass('border-danger');
    }


    if (!isValid) {
        alert('Form is Not valid. Please fill out all Details!!!!');
        return;
    }

    var formData = new FormData();
    debugger
    formData.append('Name', name);
    formData.append('Moblieno', mobile);
    formData.append('Country', country);
    formData.append('State', state);
    formData.append('City', city);
    formData.append('CarModel', carModel);
    formData.append('CarPrice', carPrice);
    formData.append('CompanyName', companyName);
    formData.append('CarColor', carColor);
    formData.append('UsageYears', usageYears);
    formData.append('CarCondition', carCondition);
    formData.append('Mileage', mileage);
    formData.append('Remarks', remarks);
    formData.append('BuyerName', buyname);
    formData.append('BuyerMoblieno', mobileno);

        debugger
    $.ajax({
        type: "POST",
        url: "../Myproject/Savebuyerdtl", 
        data: formData,
        dataType: "json",
        processData: false,
        contentType: false,
        context: document.body,
        success: function (data) {
            debugger
            alert("Successfully saved");
            window.location.reload();
        },
        error: function (error) {
            debugger
            alert("Error: " + error.statusText);
        }
    });
    
});
