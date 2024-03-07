
var baslik = "";
$("#ekle").click(function (e) {
    $("#Id").val("");
    $("#Name1").val(""); 
    $("#Description1").val("");
    $("#Url1").val(""); 
    $("#Image2").val("");
    $("#Image1").attr("src", "");
    $("#Image").val("");

    var baslik = "Çalışma Ekle";

    $("#staticBackdropLabel").text(baslik);

    $('#staticBackdropUpdate').modal("show");
});
function Update(Id, Name, Description, Url, Image) {

    $("#Id").val(Id);
    $("#Name1").val(Name);
    $("#Description1").val(Description);
    $("#Url1").val(Url);
    $("#Image").val(Image);
    var fullImagePath = '/images/portfolio/' + Image;
    $("#Image1").attr("src", fullImagePath);
    baslik = "Çalışma Güncelle";
    $("#staticBackdropLabel").text(baslik);
    $("#staticBackdropUpdate").modal("show");
}
$("#update").click(function (e) {
    e.preventDefault(); // Form submitini engelle

    var formValid = true; // Form geçerliliği kontrolü

    // Her form elemanını kontrol et
    $("form input[required], form textarea[required]").each(function () {
        // Eğer boşsa
        if (!$(this).val()) {
            formValid = false; // Form geçersiz
            $(this).addClass("is-invalid"); // Hata göstergesi ekle
            $(this).siblings(".invalid-feedback").remove(); // Var olan hata mesajını kaldır
            $(this).after('<div class="invalid-feedback">Bu alan boş bırakılamaz.</div>'); // Yeni hata mesajı ekle
        } else {
            $(this).removeClass("is-invalid"); // Hata göstergesini kaldır
            $(this).siblings(".invalid-feedback").remove(); // Hata mesajını kaldır
        }
    });

    // Eğer form geçerliyse
    if (formValid) {
        var formData = new FormData();

        // Form alanlarını FormData'ya ekle
        formData.append("Id", $("#Id").val());
        formData.append("Name", $("#Name1").val());
        formData.append("Description", $("#Description1").val());
        formData.append("Url", $("#Url1").val());
        formData.append("Image", $("#Image").val());

        // Dosyayı da FormData'ya ekle
        var file = $("#Image2")[0].files[0];
        formData.append("ImageFile", file);

        $.ajax({
            type: "POST",
            url: "/CrudPortfolio",
            data: formData,
            processData: false,  // processData ve contentType false olmalı
            contentType: false,
            success: function (response) {
                if (response.success) {
                    Swal.fire({
                        title: "Başarılı!",
                        text: response.responseText,
                        icon: "success"
                        
                    }).then(function () {
                        location.reload();
                    });;
                    $("#staticBackdropUpdate").modal("hide");
                } else {
                    Swal.fire({
                        title: "HATA!!!",
                        text: response.responseText,
                        icon: "error"
                    });
                    $("#staticBackdropUpdate").modal("hide");
                }
            },
        });
    }
});
function confirmDelete(id) {
    // Swal onay iletişim kutusu gösterme
    Swal.fire({
        title: "Emin misiniz?",
        text: "Bu öğeyi silmek istediğinizden emin misiniz?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Evet, sil",
        cancelButtonText: "İptal"
    }).then((result) => {
        // Kullanıcı onaylarsa silme işlemini gerçekleştirme
        if (result.isConfirmed) {
            // AJAX kullanarak silme işlemini gerçekleştirme
            $.ajax({
                type: "POST",
                data: {id:id},
                url: "/DeletePortfolio",
                success: function (response) {
                    // Başarılı bir şekilde silindiyse
                    if (response.success) {
                        // Swal ile başarılı iletişim kutusu gösterme
                        Swal.fire({
                            title: "Başarılı!",
                            text: "Öğe başarıyla silindi.",
                            icon: "success"
                        }).then(function () {
                            // Sayfayı yenileme
                            location.reload();

                        });
                    } else {
                        // Swal ile hata iletişim kutusu gösterme
                        Swal.fire({
                            title: "Hata!",
                            text: response.message,
                            icon: "error"
                        });
                    }
                }
            });
        }
    });
}


