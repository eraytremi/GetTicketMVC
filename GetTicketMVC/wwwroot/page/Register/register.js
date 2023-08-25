
    $(document).ready(function () {
        $("#btnSave").click(function () {
            var formData = new FormData();

           

            formData.append("PassengerName", $("#txtPassengerName").val());
            formData.append("PassengerLastName", $("#txtPassengerLastName").val());
            formData.append("Password", $("#txtPassword").val());
            formData.append("Phone", $("#txtPhone").val());
            formData.append("IDNumber", $("#txtIDNumber").val());
            formData.append("EMail", $("#txtEMail").val());
            formData.append("Gender", $("#txtGender").val());
           
            $.ajax({
                url: "/SignUp/Register",
                method: "post",
                datatype: "json",
                data: formData,
                contentType: false,
                processData: false,
                success: function (response) {
                    if (response.isSuccess) {
                        alert("İşlem Başarılı " + response.message);
                        window.location.href = "/SignIn/Login";
                    }
                    else {
                        alert("İşlem Başarısız " + response.message);
                    }
                }
            });

        });
   });

