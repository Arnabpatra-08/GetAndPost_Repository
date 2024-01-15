$(document).ready(function () {
    customerDetails();
//    alert("welcome");
});

//$('#loginBtn').click(function () {
//    debugger
//    var UserName = $('#UserName').val(); // Correct the id to match the input id
//    var Passward = $('#Passward').val();

//    $.ajax({
//        type: "GET",
//        url: "/Myproject/SellerDashBorad",
//        data: { UserName: UserName, Passward: Passward },
//        dataType: 'json',
//        context: document.body,
//        success: function (data) {

//            if (data.success) {
//                debugger
//                $('#loginForm').hide();
//                $('#dashboard').show();
//                $('#cuname').text(data.customerDetails[0].name);
//                $('#cname').text(data.customerDetails[0].name);

//                $('#BuyerTable').empty();
//                var row = "";

//                var rowcount = 1;
//                $.each(data.customerDetails, function (item, value) {
//                    debugger
//                    row += "<tr>";
//                    row += "<td>" + rowcount + "</td>";
//                    row += "<td>" + value.buyerName + "</td>";
//                    row += "<td>" + value.buyerMoblieno + "</td>";
//                    row += "<td>" + value.carModel + "</td>";
//                    row += "<td>" + value.carPrice + "</td>";
//                    row += "<td>" + value.companyName + "</td>";
//                    row += "<td>" + value.usageYears + "</td>";
//                    row += "<td>" + value.carColor + "</td>";
//                    row += "<td>" + value.carCondition + "</td>";
//                    row += "<td>" + value.mileage + "</td>";
//                    row += "<td>" + value.remarks + "</td>";
//                    
//              
//                    
//                    

//                    rowcount += 1;
//                });
//                debugger

//                $("#BuyerTable").append(row);
//                // mid = $("#hiddenId").val();
//            }
//            else {
//                $('#errorMessage').text(data.message);
//            }

//        }

//    });
//});



//******************************************************************************************* */

function customerDetails() {
    debugger
    var LoggedInName = $("#LoggedInName").val();
    $.ajax({
        type: "GET",
        url: "/Myproject/CustomerStatus",
        data: { LoggedInName: LoggedInName },
        dataType: 'json',
        context: document.body,
        success: function (data) {
            debugger


            var row = "";
            var rowcount = 1;
            $.each(data, function (item, value) {
                debugger
                row += '<tr>';
                row += '<td>' + rowcount + '</td>';
                row += "<td>" + value.buyerName + "</td>";
                row += "<td>" + value.buyerMoblieno + "</td>";
                row += "<td>" + value.carModel + "</td>";
                row += "<td>" + value.carPrice + "</td>";
                row += "<td>" + value.companyName + "</td>";
                row += "<td>" + value.usageYears + "</td>";
                row += "<td>" + value.carColor + "</td>";
                row += "<td>" + value.carCondition + "</td>";
                row += "<td>" + value.mileage + "</td>";
                row += "<td>" + value.remarks + "</td>";
                rowcount += 1;
                
            });
            debugger
            $('#BuyerTable').append(row);

        },
        error: function (error) {

            alert("error");
        }
    });
}


