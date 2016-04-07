
showRelated = function (courseId) {
    $.ajax({
        url: '/' + curTCUrl + '/TrainingCours/GetAll/' + courseId,
        type: 'get',
        success: function (data) {
            var res = "<form method='post' name='formRelated' id='formRelated'>";
            var courseIdc = 0;
            $.map(data, function(c){
                courseIdc++;
                res += "<p>";
                if (c.Checked)
                    res += "<input type='checkbox'  class='filled-in' checked='checked' name='checkedRelated' id='checkedRelated" + courseIdc + "' value='" + c.Id + "' /><label for='checkedRelated" + courseIdc + "' class='control-label'>" + c.Title + "</label>";
                else
                    res += "<input type='checkbox' class='filled-in' name='checkedRelated' id='checkedRelated" + courseIdc + "' value='" + c.Id + "' /><label for='checkedRelated" + courseIdc + "' class='control-label'>" + c.Title + "</label>";
                res += "</p>";
            });
            res += "<button id='chooseRelButton' class='button'>Сохранить</button><br /><hr />";
            res += "</form>";
            $("#dropDownRelated").html(res);
            $("#dropDownRelated").toggle();
            $("#chooseRelButton").click(function(event){
                event.preventDefault();
                chooseRelated(courseId);
            });
        }
    });
    return false;
}

chooseRelated = function (courseId) {
    $.ajax({
        url: '/' + curTCUrl + '/TrainingCours/AddRelated/' + courseId,
        type: 'post',
        data: $("#formRelated").serialize(),
        success: function(data) {
            location.reload();
        }
    });
}

showRelatedTeachers = function (courseId) {
    $.ajax({
        url: '/' + curTCUrl + '/TrainingCours/GetAllTeachers/' + courseId,
        type: 'get',
        success: function (data) {
            var res = "<form method='post' name='formRelatedTeachers' id='formRelatedTeachers'>";
            var teacherId = 0;
            $.map(data, function(c){
                teacherId++;
                res += "<p>";
                if (c.Checked)
                    res += "<input type='checkbox' checked='checked' name='checkedRelatedTeacher' id='checkedRelatedTeacher" + teacherId + "' class='filled-in'  value='" + c.Id + "' /><label for='checkedRelatedTeacher" + teacherId + "' class='control-label'>" + c.Title + "</label>";
                else
                    res += "<input type='checkbox' name='checkedRelatedTeacher' id='checkedRelatedTeacher" + teacherId + "' class='filled-in' value='" + c.Id + "' /><label for='checkedRelatedTeacher" + teacherId + "' class='control-label'>" + c.Title + "</label>";
                res += "</p>";
            });
            res += "<button id='chooseRelTeacherButton' class='button waves-effect waves-light'>Сохранить</button><br /><hr />";
            res += "</form>";
            $("#dropDownRelatedTeachers").html(res);
            $("#dropDownRelatedTeachers").toggle();
            $("#chooseRelTeacherButton").click(function(event){
                event.preventDefault();
                chooseRelatedTeacher(courseId);
            });
        }
    });
    return false;
}
chooseRelatedTeacher = function (courseId) {
    $.ajax({
        url: '/' + curTCUrl + '/TrainingCours/AddRelatedTeacher/' + courseId,
        type: 'post',
        data: $("#formRelatedTeachers").serialize(),
        success: function(data) {
            location.reload();
        }
    });
}

clickQualifLink = function() {
    $("#qualificationTCFormDiv").toggle();
    return 0;
}

reloadQualificationsTC = function (courseId) {
    $.ajax({
        url: '/empty/TrainingCours/Qualifications/' + courseId,
        success: function (data) {
            var res = "<section class='block-list'>";
            res += "<h4>Квалификации</h4>";
            res += "<ul class='qualificationList'>";
            $.map(data, function (item) {
                if (item.id > 0)
                    res += "<li><a href='/empty/Articles/Details/" + item.id + "'>" + item.text + "</a></li>";
                else
                    res += "<li><a href='#'>" + item.text + "</a></li>";
            });
            res += "</ul></section>";
            $("#qualificationList").html(res);
            $("#qualificationTCFormDiv").hide();
        }
    });
}

showAddCourseTime = function (courseId) {
    $('#addCourseTimeContainer').toggle();
    $('.button-center').hide();
    $('#AddCourseDateButton').click(function(event) {
        event.preventDefault();
        $.ajax({
            url: '/empty/TrainingCours/AddTime/',
            type: 'post',
            data: $( "#AddTimeForm" ).serialize(),
            success: function(data){
                $("#addCourseTimeContainer").toggle();
                window.location.reload();
            }
        });
    });
}
