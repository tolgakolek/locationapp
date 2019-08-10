(function () {
    var slideContainer = $('.slide-container');
    slideContainer.slick();
    $('.clash-card__image img').hide();
    $('.slick-active').find('.clash-card img').fadeIn(200);
    slideContainer.on('afterChange', function (event, slick, currentSlide) {
        $('.slick-active').find('.clash-card img').fadeIn();
    });
})
    ();