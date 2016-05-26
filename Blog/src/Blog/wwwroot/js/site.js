$(document).ready(function() {
    layout();
});

$(window).resize(function () {
    layout();
});

function layout() {
    if ($(window).height() < 640) {
        $('.logo').hide();
    } else {
        $('.logo').show();
    }
}