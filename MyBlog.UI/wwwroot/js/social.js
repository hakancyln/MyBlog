
var baslik = "";
$("#ekle").click(function (e) {
    $("#Id").val("");
    $("#Name18").val("");
    $("#Url").val("");
    $("#Image1").attr("src", "");
    
    var baslik = "Sosyal Medya Ekle";

    $("#staticBackdropLabel").text(baslik);

    $('#staticBackdropUpdate').modal("show");
});
function Update(Id, Name, Image,Url) {

    $("#Id").val(Id);
    $("#Name18").val(Name);
    var fullImagePath = '/images/' + Image;
    $("#Image1").attr("src", fullImagePath);
    $("#Image").val(Image);
    $("#Url").val(Url);
    baslik = "Sosyal Medya Güncelle";
    $("#staticBackdropLabel").text(baslik);
    $("#staticBackdropUpdate").modal("show");
}
$("#update").click(function (e) {
    e.preventDefault();

    var formValid = true;
    $("form input[socialrequired], form textarea[socialrequired]").each(function () {
        if (!$(this).val()) {
            formValid = false;
            $(this).addClass("is-invalid");
            $(this).siblings(".invalid-feedback").remove();
            $(this).after('<div class="invalid-feedback">Bu alan boş bırakılamaz.</div>');
        } else {
            $(this).removeClass("is-invalid");
            $(this).siblings(".invalid-feedback").remove();
        }
    });
    if (formValid) {
        var formData = new FormData();
        formData.append("Id", $("#Id").val());
        formData.append("Name", $("#Name18").val());
        formData.append("Url", $("#Url").val());
        formData.append("Image", $("#Image").val());
        var file = $("#Image2")[0].files[0];
        formData.append("ImageFile", file);

        $.ajax({
            type: "POST",
            url: "/CrudSocial",
            data: formData,
            processData: false,
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
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                data: { id: id },
                url: "/DeleteSocial",
                success: function (response) {
                    if (response.success) {
                        Swal.fire({
                            title: "Başarılı!",
                            text: "Öğe başarıyla silindi.",
                            icon: "success"
                        }).then(function () {
                            location.reload();

                        });
                    } else {
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


