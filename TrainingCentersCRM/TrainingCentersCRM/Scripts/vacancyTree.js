$(function () {
    $("#qualificationTree")
        .jstree({
            'core': {
                'data':
                    {
                        'url': function (node) {
                            var pathname = location.pathname;
                            var pathnameArray = pathname.split("/");
                            var trainingCenterName = pathnameArray[1];
                            return node.id === '#' ?
                              '/' + trainingCenterName + '/Qualification/ChildNodes/0' :
                              '/' + trainingCenterName + '/Qualification/ChildNodes/';
                        },
                        'data': function (n) {
                            return {
                                "id": n.id
                            };
                        }
                    }
            }, "checkbox": {
                "tie_selection": false
            },
            'plugins': ["checkbox"]
        }).bind("check_node.jstree uncheck_node.jstree", function (e, data) {
            var checkboxes = [];
            $("form input:checkbox").each(function () {
                checkboxes.push($(this));
            });
            var checkedQualifications = $("#qualificationTree").jstree("get_checked", null, true);
            checkboxes.forEach(function (cb) {
                cb.prop('checked', false);
                checkedQualifications.forEach(function (entry) {
                    if (cb.prop('value') == entry) {
                        cb.prop('checked', true);
                        return;
                    }
                });
            });
        }).bind('ready.jstree', function (e, data) {
            $.when($("#qualificationTree").jstree("open_all")).done(function (a1) {
                var interval_id = setInterval(function () {
                    if ($("#qualificationTree").find(".jstree-loading").length == 0) {
                        clearInterval(interval_id)
                        //alert('my ajax tree is done loading');
                        $("#qualificationTree").jstree("close_all")
                        var treeQualifications
                        var checkboxes = [];
                        $("form input:checkbox:checked").each(function () {
                            checkboxes.push($(this));
                        });
                        checkboxes.forEach(function (cb) {
                            var node = $('#qualificationTree').jstree(true).get_node(cb.prop('value'));
                            $("#qualificationTree").jstree().check_node(node);
                        });
                    }
                }, 50);
            });
        });
});