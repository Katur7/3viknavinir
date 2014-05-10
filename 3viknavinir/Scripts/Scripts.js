$(document).ready(function () {
    $(function () {
        $("#accordion").accordion();
    });
});
// Steinunn
$(document).ready(function () {
    $('#frontPage').click(function (e) {
        e.preventDefault()
        $(this).tab('show');
    });
});


