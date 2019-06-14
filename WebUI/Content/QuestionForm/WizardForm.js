var currentTab = 0; // Current tab is set to be the first tab (0)
showTab(currentTab); // Display the current tab

function showTab(n) {
    // This function will display the specified tab of the form...
    var x = document.getElementsByClassName("tab");
    x[n].style.display = "block";
    //... and fix the Previous/Next buttons:
    if (n == 0) {
        document.getElementById("prevBtn").style.display = "none";
    } else {
        document.getElementById("prevBtn").style.display = "inline";
    }
    if (n == (x.length - 1)) {
        document.getElementById("nextBtn").innerHTML = "Son";
    } else {
        document.getElementById("nextBtn").innerHTML = "İleri";
    }
    //... and run a function that will display the correct step indicator:
    fixStepIndicator(n)
}

function nextPrev(n) {
    // This function will figure out which tab to display
    var x = document.getElementsByClassName("tab");
    // Exit the function if any field in the current tab is invalid:
    if (n == 1 && !validateForm()) return false;
    // Hide the current tab:
    x[currentTab].style.display = "none";
    // Increase or decrease the current tab by 1:
    currentTab = currentTab + n;
    // if you have reached the end of the form...
    if (currentTab >= x.length) {
        // ... the form gets submitted:
        document.getElementById("regForm").submit();
        return false;
    }
    // Otherwise, display the correct tab:
    showTab(currentTab);
}

function validateForm() {
    // This function deals with validation of the form fields
    var x, y, i, valid = true;
    x = document.getElementsByClassName("tab");
    y = x[currentTab].getElementsByTagName("input");
    // A loop that checks every input field in the current tab:
    for (i = 0; i < y.length; i++) {
        // If a field is empty...
        if (y[i].value == "") {
            // add an "invalid" class to the field:
            y[i].className += " invalid";
            // and set the current valid status to false
            valid = false;
        }
    }
    // If the valid status is true, mark the step as finished and valid:
    if (valid) {
        document.getElementsByClassName("step")[currentTab].className += " finish";
    }
    return valid; // return the valid status
}

function fixStepIndicator(n) {
    // This function removes the "active" class of all steps...
    var i, x = document.getElementsByClassName("step");
    for (i = 0; i < x.length; i++) {
        x[i].className = x[i].className.replace(" active", "");
    }
    //... and adds the "active" class on the current step:
    x[n].className += " active";
}


(function () {
    'use strict';
    function elasticArea() {
        $('.js-elasticArea').each(function (index, element) {
            var elasticElement = element,
                $elasticElement = $(element),
                initialHeight = initialHeight || $elasticElement.height(),
                delta = parseInt($elasticElement.css('paddingBottom')) + parseInt($elasticElement.css('paddingTop')) || 0,
                resize = function () {
                    $elasticElement.height(initialHeight);
                    $elasticElement.height(elasticElement.scrollHeight - delta);
                };
            $elasticElement.on('input change keyup', resize);
            resize();
        });
    };
    elasticArea();
})();

$(document).ready(function () {
    var lesson = $("#LessonID").val();

    $('.form-control').prop('selectedIndex', 0);

    if (lesson != 0) {
        $("button[name=1]").prop('disabled', false);
    }
    else {
        $("button[name=1]").prop('disabled', true);
    }
});
$(document).ready(function () {
    var textarea = $("#textarea").val();
    if (textarea != 0) {
        $("button[name=2]").prop('disabled', false);
    }
    else {
        $("button[name=2]").prop('disabled', true);
    }
});
$("#textarea").on("change keyup paste", function () {
    var textarea = $("#textarea").val();
    if (textarea != 0) {
        $("button[name=2]").prop('disabled', false);
    }
    else {
        $("button[name=2]").prop('disabled', true);
    }
});
$("#LessonID").change(function () {
    var lesson = $("#LessonID").val();

    var j = 0;
    var i = 0;
    var lessons;
    var subjects;
    $('#Subject')[0].options.length = 0;

    $.ajax({
        url: '/Question/GetLesson',
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
            url: '/Question/GetSubject',
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
    var lesson = $("#LessonID").val();
    if (lesson != 0) {
        $("button[name=1]").prop('disabled', false);
    }
    else {
        $("button[name=1]").prop('disabled', true);
    }

});


console.log('before', $("input:radio[id=option1]").prop('checked'));

// $("input:radio[id=option1]").prop('checked', true);

$("input:radio[id=option1]").click();
$("input:radio[id=dif1]").click();
console.log('after', $("input:radio[id=option1]").prop('checked'));

$('.has-clear input[type="text"]').on('input propertychange', function () {
    var $this = $(this);
    var visible = Boolean($this.val());
    $this.siblings('.form-control-clear').toggleClass('hidden', !visible);
}).trigger('propertychange');

$('.form-control-clear').click(function () {
    $(this).siblings('input[type="text"]').val('')
        .trigger('propertychange').focus();
});

var radio;
$(document).ready(function () {
    radio = $("input[name='options']:checked").val();
    $('input:radio[name=options]').change(function () {
        radio = $("input[name='options']:checked").val();
    });
});
var dif;
$(document).ready(function () {
    dif = $("input[name='dif']:checked").val();
    $('input:radio[name=dif]').change(function () {
        dif = $("input[name='dif']:checked").val();
    });
});
var text;
var text1;
var Input1;
var Input2;
var Input3;
var Input4;
var Input5;
var sub;
var les;
var questionID;
$("#nextBtn4").click(function () {
    text = $("#textarea").val();
    text1 = $("#textarea1").val();
    Input1 = document.getElementById("exampleInput1").value;
    Input2 = document.getElementById("exampleInput2").value;
    Input3 = document.getElementById("exampleInput3").value;
    Input4 = document.getElementById("exampleInput4").value;
    Input5 = document.getElementById("exampleInput5").value;
    sub = $("#Subject").val();
    les = $("#LessonID").val();
    radio;
    dif;
    var optionID;
    $.ajax({
        url: '/Question/AddOption',
        type: "Post",
        dataType: "json",
        data: { OptionA: Input1, OptionB: Input2, OptionC: Input3, OptionD: Input4, OptionE: Input5 },
        success: function (result) {
            optionID = result.ResultSet;
            question();
        }
    });
    function question() {
        $.ajax({
            url: '/Question/AddQuestion',
            type: "POST",
            dataType: "json",
            data: { Text: text, SubText: text1, subject: sub, radio: radio, difficult: dif, lesson: les, OptionID: optionID },
            success: function (result) {
                questionID = result.ResultSet;
                userquestion();
            }
        });
    }
    function userquestion() {
        $.ajax({
            url: '/Question/AddUserQuestion',
            type: "POST",
            dataType: "json",
            data: { QuestionID: questionID },
            success: function (result) {
                if (result.Result) {
                    alert("İşlem Başarılı");
                    location.reload();
                } else {
                    alert(result.ResultDescription);
                }
            }
        });
    }

});
