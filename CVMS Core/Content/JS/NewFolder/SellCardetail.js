$(document).ready(function () {
    //alert("****Welcome****");
    getcountry();
    getstate();
    getcity();
});


//***************************************************** for save seller data***************************************
$("#submit-btn").click(function (event) {
    debugger

    var isValid = true;
    function isValidInput(input) {
        return /^[A-Z][a-z]*$/.test(input);
    }
    function isValidName(input) {
        return /^[A-Z][a-z]* [A-Z][a-z]*$/.test(input);
    }

    var country = $('#country').val();
    var state = $('#state').val();
    var city = $('#city').val();
    var carModel = $('#carModel').val().trim();
    var carPrice = $('#carPrice').val().trim();
    var companyName = $('#companyName').val().trim();
    var carColor = $('#carColor').val().trim();
    var usageYears = $('#usageYears').val().trim();
    var carCondition = $('#carCondition').val();
    var mileage = $('#mileage').val().trim();
    var remarks = $('#remarks').val().trim();
    var name = $('#name').val().trim();
    var mobile = $('#mobile').val();
    var phonePattern = /^[0-9]{10}$/;

    var fileInput1 = $("#filepath2")[0].files[0];
    $('.error-message').text('');

    //**************************************all condition for validation***************************************

    if (country == null) {
        isValid = false;
        $('#country').addClass('border-danger');
        $('#country-error').text('Please select a country.');

    } else {
        $('#country').removeClass('border-danger');
    }

    if (state =='Select') {
        isValid = false;
        $('#state').addClass('border-danger');
        $('#state-error').text('Please select a state.');

    } else {
        $('#state').removeClass('border-danger');
    }

    if (city == 'Select') {
        isValid = false;
        $('#city').addClass('border-danger');
        $('#city-error').text('Please select a city.');

    }
    else {
        $('#city').removeClass('border-danger');
    }

    //---------------------------------------------------------
   // var carModel = $('#carModel').val().trim();
    if (!isValidInput(carModel)) {
        isValid = false;
        $('#carModel').addClass('border-danger');
        $('#model-error').text('Modelname should start with a capital letter and only contain alphabets.');

    } else {
        $('#carModel').removeClass('border-danger');
    }

   // var carPrice = $('#carPrice').val().trim();
    if (carPrice === '' || isNaN(carPrice)) {
        $('#carPrice').addClass('border-danger');
        $('#price-error').text('Enter the price of the car only in digits.');
        isValid = false;
    } else {
        $('#carPrice').removeClass('border-danger');
    }

   // var companyName = $('#companyName').val().trim();
    if (!isValidInput(companyName)) {
        $('#companyName').addClass('border-danger');
        $('#companyname-error').text('Companyname should start with a capital letter and only contain alphabets.');
        isValid = false;
    } else {
        $('#companyName').removeClass('border-danger');
    }

   // var carColor = $('#carColor').val().trim();
    if (!isValidInput(carColor)) {
        $('#carColor').addClass('border-danger');
        $('#color-error').text('color should start with a capital letter and only contain alphabets.');

        isValid = false;
    } else {
        $('#carColor').removeClass('border-danger');
    }

   
    if (usageYears === '' || isNaN(usageYears)) {
        $('#usageYears').addClass('border-danger');
        $('#use-error').text('Please Enter the Usage of the car in year like-- 3,2,etc.');

        isValid = false;
    } else {
        $('#usageYears').removeClass('border-danger');
    }

    if (carCondition == null) {
        $('#carCondition').addClass('border-danger');
        $('#condition-error').text('Please select the condition of the car.');

        isValid = false;
    }
    else {
        $('#carCondition').removeClass('border-danger');
    }


    if (mileage === '' || isNaN(mileage)) {
        $('#mileage').addClass('border-danger');
        $('#mile-error').text('Please enter the mileage of the car.');

        isValid = false;
    } else {
        $('#mileage').removeClass('border-danger');
    }

    if (!isValidInput(remarks)) {
        $('#remarks').addClass('border-danger');
        $('#remarks-error').text('Remarks should start with a capital letter and only contain alphabets.');

        isValid = false;
    } else {
        $('#remarks').removeClass('border-danger');
    }


    if (!isValidName(name)) {
        $('#name').addClass('border-danger');
        $('#name-error').text('Name should start with a capital letter then Title  and only contain alphabets like--Name Title.');

        isValid = false;
    } else {
        $('#name').removeClass('border-danger');
    }


    if (!phonePattern.test(mobile) || (mobile == '')) {
        isValid = false;
        $('#mobile').addClass('border-danger');
        $('#mobile-error').text('Enter your 10 digits mobile no.');

    }
    else {
        $('#mobile').removeClass('border-danger');
    }

    if (fileInput1 == null) {
        $('#filepath2').addClass('border-danger');
        $('#file-error').text('Please upload the photo.');

        isValid = false;
    }
    else {
        $('#filepath2').removeClass('border-danger');
    }

    if (!isValid) {
        alert('Form is Not valid. Please fill out all Details!!!!');
        return;
    }

    var formData = new FormData();
    debugger
    formData.append('Country' ,country);
    formData.append('State',  state);
    formData.append('City', city);
    formData.append('CarModel' ,    carModel);
    formData.append('CarPrice' ,   carPrice);
    formData.append('CompanyName' , companyName);
    formData.append('CarColor'  ,  carColor);
    formData.append('UsageYears'   , usageYears);
    formData.append('CarCondition'   ,    carCondition);
    formData.append('Mileage'  ,   mileage);
    formData.append('Remarks'  ,   remarks);
    formData.append('Name', name);
    formData.append('Moblieno', mobile);


    if (fileInput1) {
        formData.append("filepath2", fileInput1);
        debugger
        $.ajax({
            type: "POST",
            url: "../Myproject/Savecustomerselldetails", 
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
    }
    else {
        $("#message").html("<div class='alert alert-danger'>Please select a file to upload.</div>");
    }
    // }
});

//********************************** for binding Country ********************************************************
function getcountry() {
    debugger
    $.ajax({
        type: "GET",
        url: "../Myproject/getcountryname",
        data: {},
        dataType: 'json',
        context: document.body,
        success: function (data) {
            debugger
            $.each(data.bcountry, function (item, value) {

                $("#country").append($("<option></option>").val(value.countryId).html(value.countryname));
            });

        },

        error: function (error) {

            alert("Not Found");
        }
    });
};

//************************************** for binding state according to country *****************************************


$("#country").change(function () {
    getstate();


});
function getstate() {

    $("#state").empty();
    $("#state").append($('<option>Select</option>'));
    var stateselector = $("#country").val();
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

                $("#state").append($("<option></option>").val(value.stateId).html(value.statename));
            });

        },

        error: function (error) {

            alert("Not Found");
        }
    });
};

//************************************* for binding city according to state ****************************************
$("#state").change(function () {
    getcity();


});
function getcity() {

    $("#city").empty();
    $("#city").append($('<option>Select</option>'));
    var cityselector = $("#state").val();
    debugger
    $.ajax({
        type: "GET",
        url: "../Myproject/getcityname",
        data: {stateId: cityselector },
        dataType: 'json',
        context: document.body,
        success: function (data) {
            debugger
           
            $.each(data.bcity, function (item, value) {

                $("#city").append($("<option></option>").val(value.cityId).html(value.cityname));
            });

        },

        error: function (error) {

            alert("Not Found");
        }
    });
};