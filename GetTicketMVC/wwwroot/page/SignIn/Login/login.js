$(document).ready(function () {
	$("#btnLogIn").click(function () {
		let formDataObject =
		{
			Email: $("#txtEmail").val(),
			Password: $("#txtPassword").val()
		};
		$.ajax({
			url: "/SignIn/Login",
			method: "post",
			datatype: "json",
			data: { dto: formDataObject },
			success: function (response) {
				if (response.isSuccess) {
					window.location.href = "/Home/Index";
				}
				else {
					var errMessages = "<div class='alert alert-danger'>";

					for (var i = 0; i < response.messages.length; i++) {
						errMessages += response.messages[i] + "<br />";
					}

					errMessages += "</div>";

					$("#divMessages").html(errMessages);
				}
			}
		});
	});
});