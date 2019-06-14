//$(document).ready(function () {
//    var lesson = $("#LessonID").val();

//    $('.form-control').prop('selectedIndex', 0);

//    if (lesson != 0) {
//        $("button[name=1]").prop('disabled', false);
//    }
//    else {
//        $("button[name=1]").prop('disabled', true);
//    }
//});
//$("#textarea").on("change keyup paste", function () {
//    var textarea = $("#textarea").val();
//    if (textarea != 0) {
//        $("button[name=2]").prop('disabled', false);
//    }
//    else {
//        $("button[name=2]").prop('disabled', true);
//    }
//});
$("#LessonID").change(function () {
    var lesson = $("#LessonID").val();

    var j = 0;
    var i = 0;
    var lessons;
    var subjects;
    $('#Subject')[0].options.length = 0;

    $.ajax({
        url: '/Exam/GetLesson',
        type: "GET",
        dataType: "json",
        data: { LessonID: lesson },
        success: function (data) {
            $.each(data, function () {
                subjects = data[i].SubjectID;
                i++;
                Subject();
            });
        }
    });
    function Subject() {
        $.ajax({
            url: '/Exam/GetSubject',
            type: "GET",
            dataType: "json",
            data: { SubjectID: subjects },
            success: function (data) {
                $.each(data, function () {
                    if (data != null) {
                        $.each(data, function () {
                            $('#Subject').append('<option value=' + this.SubjectID + '>' + this.SubjectText + '</option>');
                        });
                    } else {
                        $('#Subject').append('<option value="0">Seçiniz</option>');
                    }
                });

            }
        });
    }
    //var lesson = $("#LessonID").val();
    //if (lesson != 0) {
    //    $("button[name=1]").prop('disabled', false);
    //}
    //else {
    //    $("button[name=1]").prop('disabled', true);
    //}

});