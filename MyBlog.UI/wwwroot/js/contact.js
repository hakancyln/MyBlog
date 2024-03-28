
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
        processData: false,
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
    e.preventDefault();

    var formValid = true;
    $("form input[required], form textarea[required]").each(function () {
        if (!$(this).val()) {
            formValid = false;
            $(this).addClass("is-invalid");
            $(this).siblings(".invalid-feedback").remove();
            $(this).after('<div class="invalid-feedback" style="color:darkred;">Bu alan boş bırakılamaz.</div>');
        } else {
            $(this).removeClass("is-invalid");
            $(this).siblings(".invalid-feedback").remove();
        }
    });
    var emailValue = $("#Mail").val();
    if (!emailValue || !validateEmail(emailValue)) {
        formValid = false;
        $("#Mail").addClass("is-invalid");
        $("#Mail").siblings(".invalid-feedback").remove();
        $("#Mail").after('<div class="invalid-feedback" style="color:darkred;">Geçerli bir email adresi girin.</div>');
    } else {
        $("#Mail").removeClass("is-invalid");
        $("#Mail").siblings(".invalid-feedback").remove();
    }
    if (formValid) {
        var formData = new FormData();
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
            processData: false,
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
function validateEmail(email) {
    var re = /\S+@\S+\.\S+/;
    return re.test(email);
}

function confirmDelete1(id) {
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
                url: "/DeleteContact",
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


