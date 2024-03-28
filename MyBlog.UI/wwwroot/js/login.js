$("#update").click(function (e) {
    e.preventDefault();
    var formData = new FormData();
    formData.append("UserName", $("#UserName").val());
    formData.append("Password", $("#Password").val());
    $.ajax({
        type: "POST",
        url: "/Log",
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {

            if (!response.success) {
                Swal.fire({
                    title: "HATA!!!",
                    text: response.responseText,
                    icon: "error"
                });
            } else {
                window.location.href = response.redirectTo;
            }
        },
    });
});
