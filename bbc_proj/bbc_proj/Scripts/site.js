// Creating a Sortable Table
$(document).ready(function () {
    $('#mp_dataTable').DataTable();
});

// Appending data to Div on page to display the following data:
// Committees, Constituencies, Staff and profile image.
// IMPORTANT TO BBC

// Please see the information below. I have not been able to get the data required from the API for the Committees, Constituencies and Staff. To show the functionality still works, I have used a static API (Located in HomeController) to show I can complete the functionality.
function returnMPFurtherData() {
    var mpId = arguments[0];
    // The following method calls are for the data within the lists. I would have prefered to do them differently but have been struggling with the Parliment API to get the information needed.
    returnStaff();
    returnConstituencies();
    returnCommittees();
    $('#info_body').empty();
    $('#info_body').append("<div class=\"row\">" +
        "<div class=\"container\">" +
        "<div class=\"col-xs-12 col-sm-4\">" +
        "<img src=\"https://data.parliament.uk/membersdataplatform/services/images/MemberPhoto/" + arguments[0] + "//" + " class=\"img-responsive\" />" +
        "</div>" +
        "<div class=\"col-sm-8\">" +
        "<h3>Committees</h3>" +
        "<ul id=\"mp_committees\">" +
        "</ul>" +
        "<h3>Constituencies</h3>" +
        "<ul id=\"mp_constituencies\">" +
        "</ul>" +
        "<h3>Staff</h3>" +
        "<ul id=\"mp_staff\">" +
        "</ul>" +
        "</div>" +
        "</div>" +
        "</div>");
}

function returnStaff() {
    $.ajax({
        url: "/Home/returnStaff",
        success: function (html) {
            $('#mp_staff').append(html);
        }
    });
}

function returnConstituencies() {
    $.ajax({
        url: "/Home/returnConstituencies",
        success: function (html) {
            $('#mp_constituencies').append(html);
        }
    });
}

function returnCommittees() {
    $.ajax({
        url: "/Home/returnCommittees",
        success: function (html) {
            $('#mp_committees').append(html);
        }
    });
}


// For the JSON Formatted Data Payload, I was unable to get any clarification as it's currently 12:00AM and I had unfortunately had issues when receiving the coding test. I have included how I would of used JSON below to send the data to an API.

function dataPayload() {
    $.ajax({
        url: "/Home/PayloadAPI",
        // Provide data here
        data: { "data_example" : "MP NAME HERE" },
        success: function (html) {
            alert("Successful API post");
        }
    });
}