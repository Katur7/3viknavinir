﻿$(document).ready(function () {
    for (i = new Date().getFullYear() ; i > 1900; i--) {
        $('#yearpicker').append($('<option />').val(i).html(i));
    }
});
$(function () {
    $("#accordion").accordion({
        collapsible: true
    });
});