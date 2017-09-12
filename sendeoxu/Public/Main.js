$(document).ready(function () {

    $("#likebtn").click(function () {
        event.preventDefault();
        url = "/read/like/";
        $.ajax({
            url: url,
            type: "GET",
            error: function () {
                console.log("error");
            },
            success: function (result) {
                $("#likecount").html(result[1])
                $("#dislikecount").html(result[2])
                if (result[0] == 1) {
                    $("#likebtn").css('background-color', '#ccc')
                } else if (result[0] == 2) {
                    $("#likebtn").css('background-color', 'white')
                } else if (result[0] == 3) {
                    $("#likebtn").css('background-color', '#ccc')
                    $("#dislikebtn").css('background-color', 'white')
                }
            }
        })
    })

    $("#dislikebtn").click(function () {
        event.preventDefault();
        url = "/read/dislike/";
        $.ajax({
            url: url,
            type: "GET",
            error: function () {
                console.log("error");
            },
            success: function (result) {
                $("#likecount").html(result[1])
                $("#dislikecount").html(result[2])
                if (result[0] == 1) {
                    $("#dislikebtn").css('background-color', '#ccc')
                } else if (result[0] == 2) {
                    $("#dislikebtn").css('background-color', 'white')
                } else if (result[0] == 3) {
                    $("#dislikebtn").css('background-color', '#ccc')
                    $("#likebtn").css('background-color', 'white')
                }
            }
        })
    })

    $("#login").click(function () {
        event.preventDefault();

        email = $("#inputEmail3").val();
        password = $("#inputPassword3").val();
        console.log(email + " " + password);

        url = $(this).parent().parent().parent().attr('action');

        $.ajax({
            url: url,
            type: "POST",
            data: {
                email: email,
                password: password
            },
            error: function () {
                console.log("error");
            },
            success: function (result) {
                $(':input').val('');
                if (result == true) {
                    location.reload();
                }
                else {
                    $("#message-reg").html(
                        "Email və ya şifrə yanlışdır."
                    );
                }
            }
        });
    });

    $("#registr").click(function () {
        event.preventDefault();
        //console.log($("#fulname").val() + " " + $("#regist_email").val() + " " + $("#new_password").val() )
        if ($("#confirm").val() == $("#new_password").val()) {
            url = $(this).parent().parent().parent().attr('action');

            fullname = $("#fulname").val();
            email = $("#regist_email").val();
            password = $("#new_password").val();

            $.ajax({
                url: url,
                type: "POST",
                data: {
                    fullname: fullname,
                    email: email,
                    password: password
                },
                error: function (result) {
                    console.log("eroro");
                },
                success: function (result) {
                    if (result == true) {
                        $(':input').val('');
                        location.reload();
                    }
                    //console.log("sucees");
                    else {
                        $("#message_confirm").html("Yanlışlıq var")
                    }
                }
            });
            $("#message_confirm").html("")
        } else {
            $("#message_confirm").html("Şifrəni dəqiqləşdirin.")
        }
    })

    $.validate({
        modules: 'location, date, security, file'
    });

    $("#kateqoriya_id").val($("select option:first-child").val());

    $("#searchcategory").change(function () {
        $("#kateqoriya_id").val($("select option:selected").attr("value"));
        console.log($("#kateqoriya_id").val());
    })

    var d = new Date;
    var month = 0;
    month = d.getMonth() + 1;
    if (month > 12) {
        month == 1;
    }
    var time = d.getFullYear() + "-" + month + "-" + d.getDate() + " " + d.getHours() + ":" + d.getMinutes() + ":" + d.getSeconds();
    $("#date_now").val(time);

    
})
