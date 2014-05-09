$(document).ready(function () {
    $(function () {
        $("#accordion").accordion();
    });
});
// Steinunn
$('#frontPage').click(function (e) {
    e.preventDefault()
    $(this).tab('show')
})