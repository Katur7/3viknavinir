﻿$(document).ready(function () {
    $(function () {
        $("#accordion").accordion();
    });

    $
});

//fanney
var hash = {
    'srt': 1,
};

function check_extension(filename, submitId) {
    var re = /\..+$/;
    var ext = value.slice(value.lastIndexOf(".")).toLowerCase();;
    var submitEl = document.getElementById(submitId);
    if (ext == "srt") {
        submitEl.disabled = false;
        return true;
    } else {
        alert("Vinsamlegast veldu .srt skrá");
        submitEl.disabled = true;

        return false;
    }
}



