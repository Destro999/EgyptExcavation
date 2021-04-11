// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var slideIndex = 1;
showDivs(slideIndex);

function plusDivs(n) {
    showDivs(slideIndex += n);
}

function showDivs(n) {
    var i;
    var x = document.getElementsByClassName("mySlides");
    if (n > x.length) { slideIndex = 1 }
    if (n < 1) { slideIndex = x.length }
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    x[slideIndex - 1].style.display = "block";
}


//function highlight {
//    var header = document.getElementById("myDIV");
//    var btns = header.getElementsByClassName("btna");
//    for (var i = 0; i < btns.length; i++) {
//        btns[i].addEventListener("click", function () {
//            var current = document.getElementsByClassName("Current");
//            current[0].className = current[0].className.replace(" Current", "");
//            this.className += " Current";
//        });
//    }
//}
