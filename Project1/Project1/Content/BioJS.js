$("#question").click(function () {
    $.ajax({
        url: "FreeLanceController/Questions",
        type: "get",
        data: $("form").serialize(), //if you need to post Model data, use this
        success: function (result) {
            $("#partial").html(result);
        }
    });
};

carousel.js
$(document).ready(function () {
    $("#something").hide();
});