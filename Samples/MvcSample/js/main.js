/// <reference path="jquery-1.4.1.min-vsdoc.js" />


var UrlHelper =
{
    Base: '',
    LoginURL: function() { return this.Base + 'Home/Login'; }
};

function InitMaster(BaseURL) {
    UrlHelper.Base = BaseURL;
    $("#logindisplay a").live('click', LoginPopup);
    RemoveNotification();
    InitPopup();
}

function InitPopup() {
    var $blocker = $("#blocker");
    $('<input type="button" id="CancelButton" value="Cancel" />').insertAfter("#blocker input[type='submit']");
    $("#CancelButton", $blocker).click(function() {
        $blocker.slideUp('fast');
        $(".overlayed").remove();
        return false;
    });
}

function RemoveNotification() {
    setTimeout(function() { $("#notification").fadeOut('slow'); }, 3500);
}

function LoginPopup() {
    var $blocker = $("#blocker");
    $("form", $blocker).submit(function() {
        $.post(UrlHelper.LoginURL(), $(this).serialize(), function(data) {
            if (data) {
                if (data.success) {
                    $blocker.slideUp('fast');
                    $(".overlayed").remove();
                    $("#logindisplay").html(data.Name + ' <a href="' + UrlHelper.LoginURL() + '">Change</a>');
                    $("#notificationwrapper").html('<span class="notice" id="notification">Login succeeded</span>');
                    RemoveNotification();
                }
                else {
                    $("#errormessage", $blocker).html('<span class="error">' + data.message + '</span>');
                }
            }
        }, "json");
        return false;
    });
    $('<div class="overlayed" />').appendTo("body").fadeTo('slow', 0.4, function() {
        $(this).toggleClass('overlayedReady', true);
        $blocker.slideDown('fast');
    });

    return false;
}