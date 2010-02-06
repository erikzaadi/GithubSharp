/// <reference path="jquery-1.4.1.min-vsdoc.js" />
/// <reference path="urlMock.js" />
/// <reference path="jquery.blockUI.js" />

function InitMaster() {
    $("#logindisplay a").live('click', LoginPopup);
}

function LoginPopup() {
    $.blockUI({ message: $('<div id="blocker">Loading...</div>'), css: { width: '370px', padding: '5px'} });
    $.get(UrlHelper.LoginURL, {}, function(data) {
        $("#blocker").html(data);
        $('<input type="button" id="CancelButton" value="Cancel" />').insertAfter("#blocker button");
        $("#blocker #CancelButton").click(function() {
            $.unblockUI();
            $("#blocker").unblock();
            return false;
        });

        $("#blocker form").submit(function() {
            $("#blocker").block();
            $.post(UrlHelper.LoginURL, $("#blocker form").serialize(), function(data) {
                if (data) {
                    if (data.success) {
                        $.unblockUI();
                        $("#logindisplay").html(data.Name + ' <a href="' + UrlHelper.LoginURL + '">Change</a>');
                    }
                    else {
                        $("#blocker #errormessage").html(data.message);
                    }
                }
                $("#blocker").unblock();
            }, "json");

            return false;
        });
    });

    return false;
}