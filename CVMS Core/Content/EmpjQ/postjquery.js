//$(document).ready(function () {
//    alert("Please Enter Correct Data");
//});

//$('#submitbtn').click(function () {
//    var name = $('#name').val();
//    var lastname = $('#lastname').val();
//    var address = $("#address").val();

//    var iserror = false;
//    if (name == '') {
//        $('#name').addClass('border-danger');
//        iserror = true;
//    } else {
//        $('#name').removeClass('border-danger');
//    }

//    if (lastname == '') {
//        $('#lastname').addClass('border-danger');
//        iserror = true;
//    } else {
//        $('#lastname').removeClass('border-danger');
//    }

//    if (address == '') {
//        $('#address').addClass('border-danger');
//        iserror = true;
//    } else {
//        $('#address').removeClass('border-danger');
//    }

//    if (iserror) {
//        alert(' Data Has Not Been Saved In DataBase');
//        return;
//    }


//    saveemp(name, lastname, address);
//   /* getemployee();*/
//});

//function saveemp(name, lastname, address) {
//    debugger;

//    var formData = new FormData();
//    formData.append('Name', name);
//    formData.append('Lastname', lastname);
//    formData.append('Address', address);

//    $.ajax({
//        type: "POST",
//        url: "../Arnabpost/Savemployee",
//        data: formData,
//        contentType: false,
//        processData: false,
//        context: document.body,
//        success: function (data) {
//            debugger;
//            alert('Data has been stored in the database');
//            window.location.reload();
//            getemployee();
//        }
//    });
//}


//function getemployee() {
//    debugger
//    $.ajax({
//        type: 'GET',
//        url: "/Arnabpost/getemployeelist",
//        data: {},
//        dataType: 'json',
//        context: document.body,
//        success: function (data) {
//            debugger
//            var row = "";
//            var rowcount = 1;
//            //console.log(employees);
//            $.each(data.employees, function (item, value) {
//                debugger
//                row += "<tr>";
//                row += "<td>" + rowcount + "</td>";
//                row += "<td>" + value.name + "</td>";

//                row += "<td>" + value.lastname + "</td>";
//                row += "<td>" + value.address + "</td>";
//                row += "</tr>";
//                rowcount += 1;
//            });
//            $("#employeeTable").append(row);

//        },
//        error: function (error) {
//            debugger
//            // Handle errors here
//            alert("Not Found");
//        }
//    });
//}


$(document).ready(function () {
    alert("Please Enter Correct Data");

    getemployee();

});

$('#submitbtn').click(function () {
    var name = $('#name').val();
    var lastname = $('#lastname').val();
    var address = $("#address").val();

    var iserror = false;
    if (name == '') {
        $('#name').addClass('border-danger');
        iserror = true;
    } else {
        $('#name').removeClass('border-danger');
    }

    if (lastname == '') {
        $('#lastname').addClass('border-danger');
        iserror = true;
    } else {
        $('#lastname').removeClass('border-danger');
    }

    if (address == '') {
        $('#address').addClass('border-danger');
        iserror = true;
    } else {
        $('#address').removeClass('border-danger');
    }

    if (iserror) {
        alert(' Data Has Not Been Saved In DataBase');
        return;
    }
    else {
        var formData = new FormData();
        formData.append('Name', name);
        formData.append('Lastname', lastname);
        formData.append('Address', address);

        $.ajax({
            type: "POST",
            url: "../Arnabpost/Savemployee",
            data: formData,
            contentType: false,
            processData: false,
            context: document.body,
            success: function (data) {
                debugger;
                alert('Data has been stored in the database');
                
                //getemployee();
                window.location.reload();
            }
        })
    }


    
});



function getemployee() {
    debugger
    $.ajax({
        type: 'GET',
        url: "../Arnabpost/getemployeelist",
        data: {},
        dataType: 'json',
        context: document.body,
        success: function (data) {
            debugger
            var row = "";
            var rowcount = 1;
            //console.log(employees);
            $.each(data.employees, function (item, value) {
                debugger
                row += "<tr>";
                row += "<td>" + rowcount + "</td>";
                row += "<td>" + value.name + "</td>";

                row += "<td>" + value.lastname + "</td>";
                row += "<td>" + value.address + "</td>";
                row += "</tr>";
                rowcount += 1;
            });
            $("#submittedData").append(row);

        },
        error: function (error) {
            debugger
            // Handle errors here
            alert("Not Found");
        }
    });
}