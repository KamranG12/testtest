
$(document).ready(function () {

  


    //reting user slider
    $('.owl-carousel').owlCarousel({
        responsive: {
            0: {
                items: 1
            },
            600: {
                items:1
            },
            1000: {
                items: 1
            }
        }
    });

    $(".whitout_url").click(function () {
        $('#profil-Modal').css({ display: "block" });
        $('#message-reg').text('Zəhmət olmasa login və parolunuzu daxil edin və ya qeydiyyatdan keçin.');
    })

    //select picker
    $('#ex-search').picker({ search: true });


    //$(function () {
    //    $('#search').keyup(function () {
    //        var current_query = $('#search').val();
    //        if (current_query !== "") {
    //            $(".list-group li").hide();
    //            $(".list-group li").each(function () {
    //                var current_keyword = $(this).text();
    //                if (current_keyword.indexOf(current_query) >= 0) {
    //                    $(this).show();
    //                };
    //            });
    //        } else {
    //            $(".list-group li").show();
    //        };
    //    });
    //});
});

// scroll top start
    (function() {
        var link,
            toggleScrollToTop = function() {
                if ($('body').scrollTop() > 0 || $('html').scrollTop() > 0) {
                    link.fadeIn(400);
                } else {
                    link.fadeOut(400);
                }
            }
        $(document).ready(function() {
            link = $('.scroll-top');
            $(window).scroll(toggleScrollToTop);

            toggleScrollToTop();

            link.on("click", function () {
                $('body').animate({ scrollTop: 0 }, 1000);
                $('html').animate({ scrollTop: 0 }, 1000);
            });
        });
    })();
    // scroll top end


//profil sign-in start
// Get the modal
var modal = document.getElementById("profil-Modal");
// Get the button that opens the modal
//var btn = document.getElementsByClassName("btn-profil1");
// Get the <span> element that closes the modal
var span = document.getElementsByClassName("close")[0];
// When the user clicks the button, open the modal 
//btn.onclick = function() {
//    modal.style.display = "block";
//    console.log("test")
//}
$(".btn-profil1").click(function () {
    $("#profil-Modal").css({ display: "block" });
})
// When the user clicks on <span> (x), close the modal
span.onclick = function() {
    modal.style.display = "none";
    $('#message-reg').text('');
}
// When the user clicks anywhere outside of the modal, close it
window.onclick = function(event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}
//profil sign-in end