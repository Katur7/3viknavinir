﻿// Grímur
$(document).ready(function () {
    $(function () {
        $("#accordion").accordion();
    });

    var counter = $('#counter').val();

    $(".AddLine").click(function () {
        counter++;
        console.log(counter);

        var newTranslationLineDiv = $(document.createElement('div')).attr({ id: counter, class: 'translationLine' });
        newTranslationLineDiv.after().html(
            '<input data-val="true" data-val-number="The field ID must be a number." data-val-required="The ID field is required." id="item_ID" name="item.ID" type="hidden" value="' + counter + '">' +
            '<p class="chapterLabel"><label for="Kafli">Kafli</label></p>' +
            '<input class="chapterTextBox valid" data-val="true" data-val-number="The field chapterNumber must be a number." data-val-required="The chapterNumber field is required." id="item_chapterNumber" name="item.chapterNumber" type="text" value="' + counter + '">' +
            '<span class="field-validation-valid" data-valmsg-for="item.chapterNumber" data-valmsg-replace="true"></span>' +
            '<p class="startTimeLabel"><label for="Byrjunart_mi">Byrjunartími</label></p>' +
            '<input class="startTimeTextBox" id="item_startTime" name="item.startTime" type="text" placeholder="00:02:15,712" value="">' +
            '<span class="field-validation-valid" data-valmsg-for="item.startTime" data-valmsg-replace="true"></span>' +
            '<div>' +
                '<p class="timeLabels">-&gt;</p>' +
            '</div>' +
            '<p class="endTimeLabel"><label for="Endat_mi">Endatími</label></p>' +
            '<input class="endTimeTextBox" id="item_endTime" name="item.endTime" type="text" placeholder="00:02:18,712" value="">' +
            '<span class="field-validation-valid" data-valmsg-for="item.endTime" data-valmsg-replace="true"></span>' +
            '<p class="subtitleTextLabel"><label for="Texti">Texti</label></p>' +
            '<input class="subtitleTextBox" id="item_subtitle" name="item.subtitle" type="text" placeholder="Hér kemur textinn" value="">' +
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
    })

    $('#editTranslationForm').on('submit', function (event) {
        // Stop the default submission
        event.preventDefault();

        
        var divs = $('#TextToEdit form .translationLine');
        var divarr = [];

        for (var i = 0; i < counter; i++) {
            var elem = divs[i];
            var chapterNumber = $(elem).find('.chapterTextBox').val();
            var startTime = $(elem).find('.startTimeTextBox').val();
            var endTime = $(elem).find('.endTimeTextBox').val();
            var subtitle = $(elem).find('.subtitleTextBox').val();

            divarr.push({ "chapterNumber": chapterNumber, "startTime": startTime, "endTime": endTime, "subtitle": subtitle });
        }

        var json = { "textToTranslate": divarr, "isFinished": $('.fullyTranslateCheckbox').find('input').is(':checked'), "mediaID": $('#mediaID').val(), "counter": counter }
        console.log(json);
        
        $.ajax({
            url: "/Translation/EditTranslation",
            contentType: "application/x-www-form-urlencoded",
            type: "POST",
            datatype: "text",
            data: {
                json:JSON.stringify(json)},
            error: function (xmlHttpRequest, errorText, thrownError) {
                console.log(xmlHttpRequest + "|" + errorText + "|" + thrownError);
            },
            success: function (data) {
                // Todo: refresh counter in table
                // Could use ajax, call repo, replace html element
            }
        });
    });
});