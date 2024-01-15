$(document).ready(function () {
    debugger
    alert("!!!Wellcome!!!");
    getemployee();

});

function getemployee() {
    debugger
    $.ajax({
        type: 'GET',
        url: "/Arnab/GetEmployeeList",
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
            $("#employeeTable").append(row);
            
        },
        error: function (error) {
            debugger
            // Handle errors here
            alert("Not Found");
        }
    });
}