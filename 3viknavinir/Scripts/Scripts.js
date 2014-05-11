$(document).ready(function () {
    $(function () {
        $("#accordion").accordion();
    });
});
// Steinunn
/*$(document).ready(function () {
    $('#frontPage').click(function (e) {
        e.preventDefault()
        $(this).tab('show');
    });
});*/

//fanney
var hash = {
    'srt': 1,
};

function check_extension(filename, submitId) {
    var re = /\..+$/;
    var ext = value.slice(value.lastIndexOf(".")).toLowerCase();;
    var submitEl = document.getElementById(submitId);
    if (hash[ext]) {
        submitEl.disabled = false;
        return true;
    } else {
        alert("Vinsamlegast veldu .srt skrá");
        submitEl.disabled = true;

        return false;
    }
}



