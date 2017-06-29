var columOneSorted = true;
var columnTwoSorted = true;
var columnThreeSorted = true;
var allIsChecked = false;

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

    console.log(checkedContact);
    //****LOOPA igenom våra checked contacts och kontaka SQL

    //***Utforska möjligheten att ge tablerowsID=SSN

    //if (myRow[1].children[0].attr('checked')) {
    //    alert('hejjjjja');
    //}

    //console.log(myRow[1]);

    //if (checkbox.check == 1) {
    //    alert("Hallooooo");
    //}
    

    //for (var i = 0; i < myRow.length; i++) {

    //    if (myRow[i].children[0]. checkbox == true;)
    //    {
    //        take row[i].td[4] ssn[i] --> SQL
    //    }

    //}
    $("#tableBody")

}

function UpdateMarsian() {

}

function Sort(index){
	
	var sortBackwords = HandleIndex(index);
    var switching = true;
    var shouldSwitch;
    var myTable = $("#myTable");
    var myTableBody = $("#tableBody");
    var rows;
    var i;
    var x;
    var y;
    while (switching) {

        switching = false;
        rows = myTableBody.$("tr");
        for (var i = 1; i < rows.length - 1; i++) {
            shouldSwitch = false;
            x = rows[i].getElementsByTagName("td")[index];
            y = rows[i + 1].getElementsByTagName("td")[index];


            if (sortBackwords == true) {
                if (x.innerHTML.toLocaleLowerCase() < y.innerHTML.toLocaleLowerCase()) {

                    shouldSwitch = true;
                    break;
                }
            }
            else {
                if (x.innerHTML.toLocaleLowerCase() > y.innerHTML.toLocaleLowerCase()) {

                    shouldSwitch = true;
                    break;
                }
            }
        }
        if (shouldSwitch) {

            rows[i].parentNode.insertBefore(rows[i + 1], rows[i]);
            switching = true;
        }
    }

}
function HandleIndex(index) {
    var bool = false;
    switch (index) {

        case 0:
            if (columOneSorted == true) {
                columOneSorted = false;
            }
            else {
                columOneSorted = true;
                bool = true;
            }
            break;
        case 1:
            if (columnTwoSorted == true) {
                columnTwoSorted = false;
            }
            else {
                columnTwoSorted = true;
                bool = true;
            }
            break;
        case 2:
            if (columnThreeSorted == true) {
                columnThreeSorted = false;
            }
            else {
                columnThreeSorted = true;
                bool = true;
            }
            break;
    }
    return bool;
}
function CheckALL(){
	
	if(allIsChecked = false)
	{
		alert("Check all boxes");
		allIsChecked = true;
	}
	else if(allIsChecked = true)
	{
		alert("Uncheck all boxes");
		allIsChecked = false;
	}
	
}


//$("#btn_submit").on("click", function (e) {
//    e.preventDefault();
//    //console.log("jaaaa");
//    alert("JAAAADÅÅ");

//});