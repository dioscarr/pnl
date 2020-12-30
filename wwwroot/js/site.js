// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.






$(document).ready(function () {

    //window.open('.../Report/GetPdf?taxFormId=25', '_blank');

    var viewTaxPanel = $(".view-my-taxes");
    $(viewTaxPanel).on("click", function () {
        
    });

    var s = $(".TaxYearsInProcess button div:nth-child(2)");
    s.hover(function () {
        var self = this;
        $(this).addClass("bounce-top");

    });

    s.mouseleave(function () {
        $(this).removeClass("bounce-top");
    });

    $("path, circle").hover(function (e) {
        s
        $('#info-box').css('display', 'block');
        $('#info-box').html($(this).data('info'));
    });

    $("path, circle").mouseleave(function (e) {
        $('#info-box').css('display', 'none');
    });

    $(document).mousemove(function (e) {
        $('#info-box').css('top', e.pageY - $('#info-box').height() - 30);
        $('#info-box').css('left', e.pageX - ($('#info-box').width()) / 2);
    }).mouseover();

    var ios = /iPad|iPhone|iPod/.test(navigator.userAgent) && !window.MSStream;
    if (ios) {
        $('a').on('click touchend', function () {
            var link = $(this).attr('href');
            window.open(link, '_blank');
            return false;
        });
    }

    $(".selectablemap path").hover(function () {
        console.log($(this).data("info"));

    });

  

});


window.GetState =  $(".selectablemap path").on("click", function () {
    
    console.log("State: " + $(this).attr("id"));
    return $(this).attr("id");

});



