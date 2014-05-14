$(document).ready(function () {
    $(function () {
        $("#accordion").accordion();
    });

    //var translationLine = $().load()

    $(".AddLine").click(function () {
        var newTranslationLineDiv = $(document.createElement('div')).attr("class", 'form-group translationLine');
        newTranslationLineDiv.after().html('<div class="col-md-10 newChapter">' +
            '<p><label for="Kafli">Kafli</label></p>' +
            '<input class="text-box single-line" type="number" value="">' +
            '</div>' + 
            '<div class="timeStamps">' +
                '<div class="col-md-10 newStartTime">' +
                    '<p><label for="Byrjunart_mi">Byrjunartími</label></p>' +
                    '<input class="text-box single-line" type="text" value="">' +
                '</div>' + 
                '<p>-&gt;</p>' +
                '<div class="col-md-10 newEndTime">' +
                    '<p><label for="Endat_mi">Endatími</label></p>' +
                    '<input class="text-box single-line" type="text" value="">' +
                '</div>' +
            '</div>' +
            '<div class="col-md-10 newSubtitle">' +
                '<p><label for="Texti">Texti</label></p>' +
                '<input class="text-box single-line" type="text" value="">' +
            '</div>' +
        '</div>' +
        '<a href="#" id="DeleteLine">Eyða línu</a>' +
        '<a href="#" id="AddLine">Bæta við línu</a>');
        newTranslationLineDiv.insertAfter(this);
    });

    $('.glyphicon-thumbs-up').click(function ( event ) {
        console.log(event.target.id)
        var id = event.target.id;

        var param = { mediaId: id }

        $.ajax({
            url: "/ListTranslations/UpvoteMedia",
            contentType: "application/x-www-form-urlencoded",
            type: "GET",
            datatype: "json",
            data: param,
            error: function (xmlHttpRequest, errorText, thrownError) {
                console.log(xmlHttpRequest + "|" + errorText + "|" + thrownError);
            },
            success: function (data) {
                // Todo: refresh counter in table
            }
        });
    });

    /*
    $('.glyphicon-thumbs-up').click(id = $(this).element.attr('id'), function(id) {
        console.log(id);
    } )

    $("a[id|='upvote-media']").click(function () {
        $.ajax({
            url: "/ListTranslations/UpvoteMedia",
            contentType: "application/x-www-form-urlencoded",
            type: "POST",
            datatype: "string",
            data: this,
            error: function (xmlHttpRequest, errorText, thrownError) {
                alert(xmlHttpRequest + "|" + errorText + "|" + thrownError);
            },
            success: function (data) {
                if (data != null) {
                    alert("success");
                }
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



