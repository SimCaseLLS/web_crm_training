selectedId = 0;

createQualification = function () {
<<<<<<< HEAD
    $.ajax('Qualification/Create/' + selectedId).success(function (data) {
=======
    $.ajax('/empty/Qualification/Create/' + selectedId).success(function (data) {
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        $('#qualificationData').empty();
        $('#qualificationData').append(data);
    });
}
deleteQualification = function () {
<<<<<<< HEAD
    $.ajax('Qualification/Delete/' + selectedId).success(function (data) {
=======
    $.ajax('/empty/Qualification/Delete/' + selectedId).success(function (data) {
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        $('#qualificationData').empty();
        $('#qualificationData').append(data);
    });
    //var element = $('#qualificationTree').jstree(true).get_node(selectedId)
    //$('#qualificationTree').jstree('select_node', element.parent);
    //$('#qualificationTree').jstree('remove', element.id);
}
editQualification = function () {
<<<<<<< HEAD
    $.ajax('Qualification/Edit/' + selectedId).success(function (data) {
=======
    $.ajax('/empty/Qualification/Edit/' + selectedId).success(function (data) {
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
        $('#qualificationData').empty();
        $('#qualificationData').append(data);
    });
}
refreshTree = function () {
    $('#qualificationTree').jstree().refresh();
}
    
$('#editQualification').click(function () { editQualification(); });
$('#deleteQualification').click(function () { deleteQualification(); });
$('#createQualification').click(function () { createQualification(); });
$(function () {
    $("#qualificationTree")
        .jstree({
            'core': {
                'data':
                    {
                    'url': function (node) {
                        return node.id === '#' ?
<<<<<<< HEAD
                          'Qualification/ChildNodes/0' :
                          'Qualification/ChildNodes/';
                    },
                    'data': function (n) {
                        return {
                            "id": n.id
=======
                          '/empty/Qualification/ChildNodes/0' :
                          '/empty/Qualification/ChildNodes/';
                    },
                    'data': function (n) {
                        return {
                            "id": n.id === '#' ? 0 : n.id
>>>>>>> 77e7434ea7678d938336fcb397236ab4ac0ef878
                        };
                    }
                }
            }
        }).bind("select_node.jstree", function (event, data) {
            selectQualification(data.node.id);
        });
});