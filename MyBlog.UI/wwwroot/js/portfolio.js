
var baslik = "";
$("#ekle").click(function (e) {
    $("#PId").val("");
    $("#PName").val(""); 
    $("#PDescription").val("");
    $("#PUrl").val(""); 
    $("#PImage2").val("");
    $("#PImage1").attr("src", "");
    $("#PImage").val("");

    var baslik = "Çalışma Ekle";

    $("#staticBackdropLabel").text(baslik);

    $('#staticBackdropUpdate').modal("show");
});
function Update(Id, Name, Description, Url, Image) {

    $("#PId").val(Id);
    $("#PName").val(Name);
    $("#PDescription").val(Description);
    $("#PUrl").val(Url);
    $("#PImage").val(Image);
    var fullImagePath = '/images/portfolio/' + Image;
    $("#PImage1").attr("src", fullImagePath);
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
        formData.append("Id", $("#PId").val());
        formData.append("Name", $("#PName").val());
        formData.append("Description", $("#PDescription").val());
        formData.append("Url", $("#PUrl").val());
        formData.append("Image", $("#PImage").val());

        // Dosyayı da FormData'ya ekle
        var file = $("#PImage2")[0].files[0];
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

function girilenVeriyiGoster() {
    // Textarea içine girilen veriyi al
    var textareaIcerigi = document.getElementById("veriGirisi").value;
    // Alınan veriyi uygun bir div içine yerleştirerek HTML olarak işle
    document.getElementById("gosterilenVeri").innerHTML = textareaIcerigi;
}