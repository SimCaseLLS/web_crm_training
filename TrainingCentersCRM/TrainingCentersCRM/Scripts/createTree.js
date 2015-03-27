selectedId = 0;

createQualification = function () {
    $.ajax('/empty/Qualification/Create/' + selectedId).success(function (data) {
        $('#qualificationData').empty();
        $('#qualificationData').append(data);
    });
}
deleteQualification = function () {
    $.ajax('/empty/Qualification/Delete/' + selectedId).success(function (data) {
        $('#qualificationData').empty();
        $('#qualificationData').append(data);
    });
    //var element = $('#qualificationTree').jstree(true).get_node(selectedId)
    //$('#qualificationTree').jstree('select_node', element.parent);
    //$('#qualificationTree').jstree('remove', element.id);
}
editQualification = function () {
    $.ajax('/empty/Qualification/Edit/' + selectedId).success(function (data) {
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
                          '/empty/Qualification/ChildNodes/0' :
                          '/empty/Qualification/ChildNodes/';
                    },
                    'data': function (n) {
                        return {
                            "id": n.id === '#' ? 0 : n.id
                        };
                    }
                }
            }
        }).bind("select_node.jstree", function (event, data) {
            selectQualification(data.node.id);
        });
});