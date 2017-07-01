var sortFirst = false;
var sortLast = false;
var sortSSN = false;
var sortEmail = false;

$(document).ready(function () {
    ReadMars();
});


function ReadMars() {
    $.getJSON("contactlist.aspx").done(function (data) {
        $('#tableBody').children().remove();

        var tr = "";

        for (var i = 0; i < data.length; i++) {
            
            tr += "<tr>";
            tr += "<td><input id='checkbox" + i + "' name='checkbox' type='checkbox'></td>";
            tr += "<td>" + data[i].FirstName + "</td>";
            tr += "<td>" + data[i].LastName + "</td>";
            tr += "<td>" + data[i].SSN + "</td>";
            tr += "<td>" + data[i].Email + "</td>";
            
            if (data[i].addressList) {

                tr += "<td>";
                for (var j = 0; j < data[i].addressList.length; j++) {
                    tr +="Type: " + data[i].addressList[j].Type;
                    tr +=" Street: " + data[i].addressList[j].Street;
                    tr +=" Zip: " + data[i].addressList[j].Zip;
                    tr += " City: " + data[i].addressList[j].City;
                    tr += "<br />";
                    
                }
                tr += "</td>";
            }
            if (data[i].phoneList) {

                tr += "<td>";
                for (var k = 0; k < data[i].phoneList.length; k++) {
                    tr += "Type: " + data[i].phoneList[k].Type;
                    tr += " Number: " + data[i].phoneList[k].Number;
                    tr += "<br />";
                }
                tr += "</td>";
            }

            tr += "</tr>";
        }
        $('#tableBody').append(tr);

    });



}

function CreateMarsian() {
   // $.getJSON("createMarsian.aspx").done(function (data) {

        //alert("createMars.aspx");
    //}


}

function DeleteMarsian() {

    var myTable = $("#tableBody");
    var myRow = myTable.children();

    var checkedContact = [];
    var count = 0;

    //console.log(check);
    for (var i = 0; i < myRow.length; i++) {
        var check = $('#checkbox'+i).is(":checked");
        if (check) {
            checkedContact[count] = (myRow[i].children[3].innerHTML);
            count++;
        }
    }

    //console.log(checkedContact);
    //****LOOPA igenom våra checked contacts och kontaka SQL

    //***Utforska möjligheten att ge tablerowsID=SSN

    
    //$("#tableBody")


    SendToController(checkedContact);


}


function SendToController(checkCon) {

    var data = {};
    data.idToDelete = checkCon;
    var adam="&ids=";

    for (var i = 0; i < checkCon.length; i++) {
        adam += checkCon[i] + ";";
    }

    $.ajax({
        type: "POST",
        url: "contactlist.aspx?action=delete" + adam,
        dataType: "json",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        success: ReadMars,
        error: function (error) {
            alert("failed in opening XML file !!!");
        }
    });
}


function UpdateMarsian() {


    var myTable = $("#tableBody");
    var myRow = myTable.children();
    var temp;


        for (var i = 0; i < myRow.length; i++) {
            var check = $('#checkbox' + i).is(":checked");
            if (check) {
                temp = myRow[i];
            }
        }
        $('#tableBody').children().remove();
        $("#tableBody").append(temp);
        var inputRow = "<tr><td></td><td><input type='textbox' id='inputFirst'></td>";
        inputRow += "<td><input type='textbox' id='inputLast'></td>";
        inputRow += "<td><input type='textbox' id='inputSSN'></td>";
        inputRow += "<td><input type='textbox' id='inputEmail'></td>";
        inputRow += "<td><input type='button' onclick='UpdateContact();' value='Update Contact' class='btn-info' id='btnInput'></td>";
        inputRow += "</tr>";
        
        $("#tableBody").append(inputRow);
        //$("#inputFirst") = "test";

        

        
        //console.log(UpdatedContactInfo);

}
function UpdateContact() {
    var myTable = $("#tableBody");
    var myRow = myTable.children();
    var updatedContactInfo = [];

    if ($("#inputFirst").val() != "")
    {
        updatedContactInfo[0] = $("#inputFirst").val();
    }
    else
    {
        updatedContactInfo[0] = myRow[0].children[1].innerHTML;
    }

    if ($("#inputLast").val() != "") {
        updatedContactInfo[1] = $("#inputLast").val();
    }
    else {
        updatedContactInfo[1] = myRow[0].children[2].innerHTML;
    }

    if ($("#inputSSN").val() != "") {
        updatedContactInfo[2] = $("#inputSSN").val();
    }
    else {
        updatedContactInfo[2] = myRow[0].children[3].innerHTML;
    }

    if ($("#inputEmail").val() != "") {
        updatedContactInfo[3] = $("#inputEmail").val();
    }
    else {
        updatedContactInfo[3] = myRow[0].children[4].innerHTML;
    }

    updatedContactInfo[4] = myRow[0].children[3].innerHTML;

    console.log(updatedContactInfo);

    var data = {};
    data.idToUpdate = updatedContactInfo;
    var adam = "&ids=";

    for (var i = 0; i < updatedContactInfo.length; i++) {
        adam += updatedContactInfo[i] + ";";
    }

    $.ajax({
        type: "POST",
        url: "contactlist.aspx?action=edit" + adam,
        dataType: "json",
        data: JSON.stringify(data),
        contentType: "application/json; charset=utf-8",
        success: ReadMars,
        error: function (error) {
            alert("Do some changes!");
        }
    });
    
    //console.log(updatedContactInfo);


}


function SortContact(sortBy) {
    
    var sortBackwords = HandleIndex(sortBy);
    
    var myTableBody = document.getElementById("tableBody");

    var myRows = myTableBody.children;
    

    for (var i = 0; i < myRows.length; i++) {

        for (var j = i + 1; j < myRows.length; j++) {

            var iName = myRows[i].children[sortBy].innerHTML;

            var jName = myRows[j].children[sortBy].innerHTML;

            if (sortBackwords) {

                if (iName.localeCompare(jName) < 0) {
                    myTableBody.insertBefore(myRows[j], myRows[i]);
                }
            }
            else
            {
                if (iName.localeCompare(jName) > 0) {
                    myTableBody.insertBefore(myRows[j], myRows[i]);
                }
            }
            
        }

    }
    
}
function HandleIndex(index) {

    var sortBackword = false;

    switch (index) {

        case 1:
            if (sortFirst) {
                sortBackword = true;
                sortFirst = false;
            }
            else {
                sortBackword = false;
                sortFirst = true;
            }
            break;
        case 2:
            if (sortLast) {
                sortBackword = true;
                sortLast = false;
            }
            else {
                sortBackword = false;
                sortLast = true;
            }
            break;
        case 3:
            if (sortSSN) {
                sortBackword = true;
                sortSSN = false;
            }
            else {
                sortBackword = false;
                sortSSN = true;
            }
            break;
        case 4:
            if (sortEmail) {
                sortBackword = true;
                sortEmail = false;
            }
            else {
                sortBackword = false;
                sortEmail = true;
            }
            break;

    }

    return sortBackword;
}

