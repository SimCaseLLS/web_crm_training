selectQualification = function (id) {
    $("#qualificationButtons").show();
    $('#qualificationTree').jstree('select_node', id);
    selectedId = id;
    if (id == 0) {
        $('#qualificationData').empty();
        $("#editQualification").hide();
        $("#deleteQualification").hide();
    } else {
        $.ajax('/empty/Qualification/Details/' + id).success(function (data) {
            $('#qualificationData').empty();
            $('#qualificationData').append(data);
        });
        $("#editQualification").show();
        $("#deleteQualification").show();
    }
}