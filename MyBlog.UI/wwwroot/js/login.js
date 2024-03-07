$("#update").click(function (e) {
    e.preventDefault(); // Form submitini engelle
    var formData = new FormData();

    // Form alanlarını FormData'ya ekle
    formData.append("UserName", $("#UserName").val());
    formData.append("Password", $("#Password").val());
    $.ajax({
        type: "POST",
        url: "/Log",
        data: formData,
        processData: false,  // processData ve contentType false olmalı
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
