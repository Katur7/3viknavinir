$(document).ready(function () {
    $(function () {
        $("#accordion").accordion();
    });
});
// Steinunn
$('#myTab frontPage').click(function (e) {
    e.preventDefault()
    $(this).tab('show')
})
