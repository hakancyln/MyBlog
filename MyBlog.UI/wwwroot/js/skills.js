
var baslik = "";
$("#ekle").click(function (e) {
    $("#Id19").val("");
    $("#Name19").val("");
    $("#Percentile").val("");
    
    var baslik = "Yetenek Ekle";

    $("#staticBackdropLabel").text(baslik);

    $('#staticBackdropUpdate').modal("show");
});
function Update(Id, Name, Percentile) {
    $("#Id19").val(Id);
    $("#Name19").val(Name);
    $("#Percentile").val(Percentile);
    baslik = "Yetenek Güncelle";
    $("#staticBackdropLabel").text(baslik);
    $("#staticBackdropUpdate").modal("show");
}
$("#update").click(function (e) {
    e.preventDefault();

    var formValid = true;
    $("form input[skillsrequired], form textarea[skillsrequired]").each(function () {
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
        formData.append("Id", $("#Id19").val());
        formData.append("Name", $("#Name19").val());
        formData.append("Percentile", $("#Percentile").val());
        

        $.ajax({
            type: "POST",
            url: "/CrudSkills",
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
                url: "/DeleteSkills",
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


