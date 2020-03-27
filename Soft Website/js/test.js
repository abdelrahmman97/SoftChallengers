$(".minuBar").click(function () {
    $(".navbar ul").slideToggle()
});


function myFunction(x) {
    if (x.matches) {
        $('.ourTeam_slidr').slick({
            slidesToShow: 2,
            slidesToScroll: 1,
            autoplay: true,
            autoplaySpeed: 2000,
        });

    } else {
        $('.ourTeam_slidr').slick({
            slidesToShow: 5,
            slidesToScroll: 1,
            autoplay: true,
            autoplaySpeed: 1000,
        });
    }
}
var x = window.matchMedia("(max-width: 600px)")
myFunction(x) // Call listener function at run time
x.addListener(myFunction) // Attach listener function on state changes

$(".ourTeam .ourTeam_slidr .slidr_feat").height($(".ourTeam .ourTeam_slidr .slidr_feat").width());

$('.img_slider').slick({
    slidesToShow: 1,
    slidesToScroll: 1,
    autoplay: true,
    autoplaySpeed: 1000,
});























