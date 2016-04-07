selectQualification = function (id) {
    $("#qualificationButtons").show();
    $('#qualificationTree').jstree('select_node', id);
    selectedId = id;
    if (id == 0) {
        $('#qualificationData').empty();
        $("#editQualification").hide();
        $("#deleteQualification").hide();
    } else {
<<<<<<< HEAD
        $.ajax('Qualification/Details/' + id).success(function (data) {
=======
        $.ajax('/empty/Qualification/Details/' + id).success(function (data) {
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
            $('#qualificationData').empty();
            $('#qualificationData').append(data);
        });
        $("#editQualification").show();
        $("#deleteQualification").show();
    }
}