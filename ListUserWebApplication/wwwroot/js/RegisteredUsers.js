function NewClick() {
    $("#showAllUsers").hide();
    $("#newUserRegister").show();
    $("#newUserRegister").removeClass('hidediv');
}

function AddNewUser() {
    var checkedDays = "";
    $.each($("input[name='Day']:checked"), function () {
        checkedDays = checkedDays + ',' + $(this).val();
    });

    var userData = {
        Name: $("#name").val(),
        Email: $("#email").val(),
        Gender: $("input[name='gender']:checked").val(),
        DateRegistered: $("#dateofreg").val(),
        AdditionalRequest: $("#addReq").val(),
        selectedDays: checkedDays
    }

    $.ajax({
        url: "/Home/AddUsers",
        type: "POST",
        data: { userModel: userData },
        dataType: "json",
        success: function (data) {
            $("#showAllUsers").show();
            $("#newUserRegister").hide();
            location.reload();
        },
        error: function (data) {
            $("#showAllUsers").show();
            $("#newUserRegister").hide();

        }
    });

    
}

