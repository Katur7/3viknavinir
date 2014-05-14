// Grímur
$(document).ready(function () {
    $(function () {
        $("#accordion").accordion();
    });

    $(".AddLine").click(function () {
        var newTranslationLineDiv = $(document.createElement('div'));
        newTranslationLineDiv.after().html(
            '<input data-val="true" data-val-number="The field ID must be a number." data-val-required="The ID field is required." id="item_ID" name="item.ID" type="hidden" value="1">' +  //Breyta í countID
            '<p class="chapterLabel"><label for="Kafli">Kafli</label></p>' +
            '<input class="chapterTextBox valid" data-val="true" data-val-number="The field chapterNumber must be a number." data-val-required="The chapterNumber field is required." id="item_chapterNumber" name="item.chapterNumber" type="text" value="">' +
            '<span class="field-validation-valid" data-valmsg-for="item.chapterNumber" data-valmsg-replace="true"></span>' +
            '<p class="startTimeLabel"><label for="Byrjunart_mi">Byrjunartími</label></p>' +
            '<input class="startTimeTextBox" id="item_startTime" name="item.startTime" type="text" value="">' +
            '<span class="field-validation-valid" data-valmsg-for="item.startTime" data-valmsg-replace="true"></span>' +
            '<div>' +
                '<p class="timeLabels">-&gt;</p>' +
            '</div>' +
            '<p class="endTimeLabel"><label for="Endat_mi">Endatími</label></p>' +
            '<input class="endTimeTextBox" id="item_endTime" name="item.endTime" type="text" value="">' +
            '<span class="field-validation-valid" data-valmsg-for="item.endTime" data-valmsg-replace="true"></span>' +
            '<p class="subtitleTextLabel"><label for="Texti">Texti</label></p>' +
            '<input class="subtitleTextBox" id="item_subtitle" name="item.subtitle" type="text" value="">' +
            '<span class="field-validation-valid" data-valmsg-for="item.subtitle" data-valmsg-replace="true"></span>' +
            '</div>');

        var editLinesDiv = $(".editLines")

        newTranslationLineDiv.insertBefore(editLinesDiv);
    });

    $('.upvoteTranslation').click(function ( event ) {
        var id = event.target.id;

        var param = { mediaId: id }

        $.ajax({
            url: "/ListTranslations/UpvoteMedia",
            contentType: "application/x-www-form-urlencoded",
            type: "POST",
            datatype: "json",
            data: param,
            error: function (xmlHttpRequest, errorText, thrownError) {
                console.log(xmlHttpRequest + "|" + errorText + "|" + thrownError);
            },
            success: function (data) {
                // Todo: refresh counter in table
                // Could use ajax, call repo, replace html element
            }
        });
    });

    $('.upvoteRequest').click(function (event) {
        var id = event.target.id;

        var param = { requestId: id }
   
    $('.glyphicon-thumbs-up').click(id = $(this).element.attr('id'), function(id) {
        console.log(id);
    } )

        $.ajax({
            url: "/ListRequest/UpvoteRequest",
            contentType: "application/x-www-form-urlencoded",
            type: "POST",
            datatype: "json",
            data: param,
            error: function (xmlHttpRequest, errorText, thrownError) {
                console.log(xmlHttpRequest + "|" + errorText + "|" + thrownError);
            },
            success: function (data) {
                // Todo: refresh counter in table
                // Could use ajax, call repo, replace html element
            }
        });
    })*/
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



