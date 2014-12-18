function setupSpecializationsSelect() {
    $('#specialization').empty().append($('#areas').find('option:selected').data('specializations'));
}

function setSpecializationsSelect(areaId, specializationId) {
    $("#areas").val(areaId).change();
    $('#specialization').val(specializationId);
}

$(function () {
    setupSpecializationsSelect();

    $('#areas').on('change', function () {
        setupSpecializationsSelect();
    });
});