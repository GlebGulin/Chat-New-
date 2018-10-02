$(document).ready(function () {
    $('.chatField').scrollTop(100000);
    $('.MessagePost').keydown(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $(".pushmess").click();
        }
    });
    $('#an').keydown(function (e) {
        if (e.keyCode == 13) {
            e.preventDefault();
            $(".btn-answer").click();
        }
    });

    

    //setTimeout("$('.chatField'), reload()", 10000);
    setInterval(function () {
        $(".chatField").load("MessagePost.cshtml .chatField");
    }, 10000);
});