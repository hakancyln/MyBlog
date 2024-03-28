
var baslik = "";
$("#ekle1").click(function (e) {
    $("#Id").val("");
    $("#Name").val("");
    $("#Mail").val("");
    $("#Subject").val("");
    $("#Message").val("");
    $("#Date").text("");
    
    var baslik = "Yetenek Ekle";

    $("#staticBackdropLabel1").text(baslik);

    $('#staticBackdropMessage1').modal("show");
});
function CUpdate(Id, Name, Mail,Subject,Message,Dates) {

    $("#Id").val(Id);
    $("#Name").val(Name);
    $("#Mail").val(Mail);
    $("#Subject").val(Subject);
    $("#Message").val(Message);
    $("#Date").text("Tarih: "+Dates);
    baslik = "Mesaj Detay";
    $("#staticBackdropLabel1").text(baslik);
    $("#staticBackdropMessage").modal("show");

    var formData = new FormData();

    // Form alanlarını FormData'ya ekle
    formData.append("Id", $("#Id").val());
    formData.append("Name", $("#Name").val());
    formData.append("Mail", $("#Mail").val());
    formData.append("Subject", $("#Subject").val());
    formData.append("Message", $("#Message").val());
    formData.append("Date", $("#Date").text());
    formData.append("IsRead", true);


    $.ajax({
        type: "POST",
        url: "/CrudContact",
        data: formData,
        processData: false,  // processData ve contentType false olmalı
        contentType: false

    });

}
$("#isRead").click(function (e) {
    location.reload();
});
$("#isRead1").click(function (e) {
    location.reload();
});
$("#update1").click(function (e) {
    e.preventDefault(); // Form submitini engelle

    var formValid = true; // Form geçerliliği kontrolü

    // Her form elemanını kontrol et
    $("form input[required], form textarea[required]").each(function () {
        // Eğer boşsa
        if (!$(this).val()) {
            formValid = false; // Form geçersiz
            $(this).addClass("is-invalid"); // Hata göstergesi ekle
            $(this).siblings(".invalid-feedback").remove(); // Var olan hata mesajını kaldır
            $(this).after('<div class="invalid-feedback" style="color:darkred;">Bu alan boş bırakılamaz.</div>'); // Yeni hata mesajı ekle
        } else {
            $(this).removeClass("is-invalid"); // Hata göstergesini kaldır
            $(this).siblings(".invalid-feedback").remove(); // Hata mesajını kaldır
        }
    });

    // Email alanını kontrol et
    var emailValue = $("#Mail").val();
    if (!emailValue || !validateEmail(emailValue)) {
        formValid = false; // Form geçersiz
        $("#Mail").addClass("is-invalid"); // Hata göstergesi ekle
        $("#Mail").siblings(".invalid-feedback").remove(); // Var olan hata mesajını kaldır
        $("#Mail").after('<div class="invalid-feedback" style="color:darkred;">Geçerli bir email adresi girin.</div>'); // Yeni hata mesajı ekle
    } else {
        $("#Mail").removeClass("is-invalid"); // Hata göstergesini kaldır
        $("#Mail").siblings(".invalid-feedback").remove(); // Hata mesajını kaldır
    }

    // Eğer form geçerliyse
    if (formValid) {
        var formData = new FormData();

        // Form alanlarını FormData'ya ekle
        formData.append("Id", $("#Id").val());
        formData.append("Name", $("#Name").val());
        formData.append("Mail", $("#Mail").val());
        formData.append("Subject", $("#Subject").val());
        formData.append("Message", $("#Message").val());
        formData.append("Date", $("#Date").text());
        formData.append("IsRead", false);

        $.ajax({
            type: "POST",
            url: "/CrudContact",
            data: formData,
            processData: false,  // processData ve contentType false olmalı
            contentType: false,
            success: function (response) {
                if (response.success) {
                    $("#form").hide();
                    $("#message-success").show();
                    $("#Id").val("");
                    $("#Name").val("");
                    $("#Mail").val("");
                    $("#Subject").val("");
                    $("#Message").val("");
                    $("#Date").text("");
                    setTimeout(function () {
                        $("#form").show();
                        $("#message-success").hide();
                    }, 5000);
                } else {
                    $("#form").hide();
                    $("#message-warning").show();
                    setTimeout(function () {
                        $("#form").show();
                        $("#message-warning").hide();
                    }, 5000);
                }
            },
        });
    }
});

// Email adresinin geçerliliğini kontrol eden fonksiyon
function validateEmail(email) {
    var re = /\S+@\S+\.\S+/;
    return re.test(email);
}

function confirmDelete1(id) {
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
                data: { id: id },
                url: "/DeleteContact",
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


