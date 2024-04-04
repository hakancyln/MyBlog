
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
    e.preventDefault();

    var formValid = true;
    $("form input[portfoliorequired], form textarea[portfoliorequired]").each(function () {
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
        formData.append("Id", $("#PId").val());
        formData.append("Name", $("#PName").val());
        formData.append("Description", $("#PDescription").val());
        formData.append("Url", $("#PUrl").val());
        formData.append("Image", $("#PImage").val());
        var file = $("#PImage2")[0].files[0];
        formData.append("ImageFile", file);

        $.ajax({
            type: "POST",
            url: "/CrudPortfolio",
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
                data: {id:id},
                url: "/DeletePortfolio",
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

function girilenVeriyiGoster() {
    var textareaIcerigi = document.getElementById("veriGirisi").value;
    document.getElementById("gosterilenVeri").innerHTML = textareaIcerigi;
}