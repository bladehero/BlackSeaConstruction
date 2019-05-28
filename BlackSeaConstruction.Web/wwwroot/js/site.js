var hI_maxLayerHouse = 11;

function homeIntroShowLayesr() {

    $('#intro-house').animate({ opacity: 0, "left": "50px", "top": "-310px" }, 500);
    $('#intro-helmet').animate({ opacity: 0, "left": "210px", "top": "-200px" }, 500);
    $('#intro-logo-3d').animate({ opacity: 0, "left": "-20px", "top": "-180px" }, 500, function () {

        document.getElementById("intro").style.display = "none";

        document.querySelector(".topmenu-bg").style.display = "block";
        $('.topmenu-bg').animate({ opacity: 0.7 }, 500);

        document.querySelector(".logo").style.display = "block";
        $('.logo').animate({ opacity: 1 }, 500);

        document.querySelector(".helmet").style.display = "block";
        $('.helmet').animate({ opacity: 1 }, 500);

        document.getElementById("cont-bg-intro").style.display = "block";
        $('#contbgintro').animate({ "width": "100%", "height": "400px", "margin-left": "0%" }, 500,
            function () {
                $('#cont-bg-intro').animate({ opacity: 0 }, 300,
                    function () {
                        document.getElementById("cont-bg-intro").style.display = 'none';
                        document.getElementById("cont-bg").style.boxShadow = '0px 0px 15px 0px rgba(0, 0, 0, 1)';
                        document.getElementById("cont-bg").style.backgroundImage = 'url(/images/site/cont-bg.png)';
                        $('#bg-obj-cont').animate({ opacity: 1 }, 300, function () {
                            $('#cont').animate({ opacity: 1 }, 300);
                            $('#short-news').animate({ opacity: 1 }, 300);
                            $('#roulette').animate({ opacity: 1 }, 300, function () {
                                $('#hammer').animate({ opacity: 1 }, 300);
                                responsiveDesign();
                            });
                        });
                    });
            });
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

    $('#cont').animate({ opacity: 0 }, 1);
    $('#short-news').animate({ opacity: 0 }, 1);
    document.getElementById("cont-bg-intro").style.display = "none";

    $('#bg-obj-cont').animate({ opacity: 0 }, 1);

    $('#hammer').animate({ opacity: 0 }, 1);

    document.querySelector(".logo").style.display = "none"; $('.logo').animate({ opacity: 0 }, 1);
    document.querySelector(".topmenu-bg").style.display = "none"; $('.topmenu-bg').animate({ opacity: 0 }, 1);

    document.querySelector(".helmet").style.display = "none"; $('.helmet').animate({ opacity: 0 }, 1);

    $('#roulette').animate({ opacity: 0 }, 1);

    document.getElementById("topmenu-short-tit").style.display = "none";
    document.querySelector(".topmenu").style.display = "none";

    document.getElementById("cont-bg").style.display = "table";
    document.getElementById("cont-bg").style.boxShadow = "none";
    document.getElementById("cont-bg").style.backgroundImage = "none";

    $('#cont-bg').animate({ opacity: 1 }, 300);

    $('#intro-pages-0').animate({ opacity: 1, "left": "300px", "top": "200px" }, 700, function () {
        $('#intro-pages-1').animate({ opacity: 1 }, 500, function () {
            $('#intro-helmet').animate({ opacity: 1 }, 500);
            homeIntroHouse(1);
        });
    });

}