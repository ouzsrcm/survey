$(document).ready(function () {

    $("#LoginButton").click(function () {
        if ($("#Username").val() != "") {
            if ($("#Password").val() != "") {
                $("#login-process").fadeIn();
                $.ajax({
                    type: 'POST',
                    url: 'Ajax/Login.asmx/Login',
                    data: "{Username:'" + $('#Username').val() + "',Password:'" + $('#Password').val() + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: 'json',
                    success: function (logResult) {
                        $("#login-process").fadeOut();
                        if (logResult.d != "USER_NOT_FOUND") {
                            $("#login-success").fadeIn();
                            location.reload();
                        } else {
                            $("#login-error").fadeIn();
                        }
                    }
                });
            } else {
                $("#Password").focus();
            }
        } else {
            $("#Username").focus();
        }
    });

    $("#LinkLogout").click(function () {
        var answer = confirm('Are You Sure?');
        if (answer) {
            location.href = "LogOut.aspx";
        }
    });

});