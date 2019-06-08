$(document).ready(function () {
    $('#gallery-close').click(function () {
        $('#gallery').removeClass('fadeIn').addClass('fadeOut');
        setTimeout(function () {
            $('#gallery').css('display', 'none');
        }, 1000);
    });
});