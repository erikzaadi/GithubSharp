$(document).ready(function(){
	$("#logindisplay a").click(LoginPopup);
});

function LoginPopup()
{
	if (!$("#overlay").length){
		$("body").append($('<div id="overlay" />'));
	}
	
	$("#overlay").load("
	
	return false;
}