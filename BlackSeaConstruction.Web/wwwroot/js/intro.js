var hI_maxLayerHouse = 11;

function homeIntroShowLayesr() {
    $('#intro-house').animate({ opacity: 0, "left": "50px", "top": "-310px" }, 500);
    $('#intro-helmet').animate({ opacity: 0, "left": "210px", "top": "-200px" }, 500);
    $('#intro-logo-3d').animate({ opacity: 0, "left": "-20px", "top": "-180px" }, 500, function () {
        $('#intro').removeClass('fadeIn').addClass('animated fadeOut');
        $('#intro-bg').removeClass('fadeIn').addClass('animated fadeOut');
        setTimeout(function () {
            $('#intro').hide();
            $('#intro-bg').hide();
        }, 800);
    });
}

function homeIntroHouse(cNumLayer) {
    if (cNumLayer < hI_maxLayerHouse) {
        $('#intro-house-' + cNumLayer).animate({ opacity: 1 }, 300, function () { homeIntroHouse(cNumLayer + 1); });
    } else {
        $('#intro-house-sh').animate({ opacity: 1 }, 300);
        $('#intro-pages-0').animate({ "rotate": "360deg", opacity: 0 }, 1000, function () {
            $('#intro-helmet').animate({ "left": "260px", "top": "260px", "width": "100px", "height": "92px" }, 500, function () {
                $('#intro-logo-3d').animate({ opacity: 1, "left": "240px", "top": "210px", "width": "472px", "height": "333px" }, 500);
                $('#intro-house').animate({ "left": "310px", "top": "70px" }, 500);
                $('#intro-helmet').animate({ "left": "470px", "top": "180px" }, 500, function () {
                    $('#intro-house').animate({ "left": "310px", "top": "70px" }, 700, function () {
                        homeIntroShowLayesr();
                    });
                });
            });
        });
    }
}

function homeIntro() {
    $('#intro').removeClass('d-none').addClass('animated fadeIn');
    $('#intro-pages-0').animate({ opacity: 1, "left": "300px", "top": "200px" }, 700, function () {
        $('#intro-pages-1').animate({ opacity: 1 }, 500, function () {
            $('#intro-helmet').animate({ opacity: 1 }, 500);
            homeIntroHouse(1);
        });
    });

}