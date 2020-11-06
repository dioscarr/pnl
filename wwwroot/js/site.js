// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



hidePanel();
function showPanel() {
    var taxPanel = document.getElementsByClassName("view-taxes-by-year");
    taxPanel.show();

}

function hidePanel() {
    var taxPanel = document.getElementsByClassName("view-taxes-by-year");
    taxPanel.hide();

}

document.getElementById("viewtaxesbtn").addEventListener("click", function () {
    taxPanel();
})

