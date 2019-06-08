$(document).ready(function () {
    $('#carouselModalControls').carousel({
        interval: false
    });
    $('#gallery-close').click(function () {
        $('#gallery').removeClass('fadeIn').addClass('fadeOut');
        setTimeout(function () {
            $('#gallery').css('display', 'none');
        }, 1000);
    });
});