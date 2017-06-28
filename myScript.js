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


//$("#btn_submit").on("click", function (e) {
//    e.preventDefault();
//    //console.log("jaaaa");
//    alert("JAAAADÅÅ");

//});