// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



    $(document).ready(function()
    {
        var viewTaxPanel = $(".view-my-taxes");
        $(viewTaxPanel).on("click", function(){
            alert();            
        });

        var s = $(".TaxYearsInProcess button div:nth-child(2)");
        s.hover(function () {
            var self = this;
            $(this).addClass("bounce-top");
         
        });

        s.mouseleave(function () {
            $(this).removeClass("bounce-top");
        });


    })

