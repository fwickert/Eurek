// Write your Javascript code.

$(document).ready(function (e) {

    $("#sun").click(function () {
        //Active the cloud
        $("#cloud").css("left", "5px");
        //Send data with Lux update
        $(".d").each(function () {
            var dID = $(this).attr("id").split("_")[1];

            SendMessage(dID, false, 10000, 10);
        });
    });

    $("#cloud").click(function () {
        $(".on").each(function () { $(this).show(); });
        $(".off").each(function () { $(this).hide(); });        
        $("#cloud").css("left", "-30%");
        //Send data with night update
        $(".d").each(function () {
            var dID = $(this).attr("id").split("_")[1];

            SendMessage(dID, true, 0, 10);
        });
    });


    $("#moon").click(function () {
        //Car
        $("#car").show();        
       
    });

    $("#car").one("animationend", function (e) {
        $("#lampOn3").css("left", "840px");
        $("#lampOn3").css("top", "270px");
        $("#lampOn3").css("transform", "rotate(70deg)");
        //Send data with angle update
        $("#_100172").each(function () {
            var dID = $(this).attr("id").split("_")[1];

            SendMessage(dID, true, 0, 180);
        });
    });



});

function SendMessage(deviceID, onOff, lux, angle)
{
    var msg = JSON.stringify({ DeviceID: deviceID, OnOff: onOff, Lux: lux, Angle: angle });
   
    $.ajax({
        url: "https://<Your function>.azurewebsites.net/api/DeviceSimulatorAPI?code=<Your Function Code>",
        type:"POST",
        contentType: "application/json",
        dataType:"json",
        data: msg        
    });
}
