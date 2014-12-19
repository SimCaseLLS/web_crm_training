function setupSpecializationsSelect() {
    $('#HeadHunterId').empty().append($('#HeadHunterAreas').find('option:selected').data('specializations'));
    setSpecializationName();
}

function setSpecializationsSelect(areaId, specializationId) {
    $("#HeadHunterAreas").val(areaId).change();
    $('#HeadHunterId').val(specializationId).change();
}

function setSpecializationName() {
    $("#HeadHunterName").val($('#HeadHunterId').find('option:selected').text());
}

$(function () {
    $(document).on('change', '#HeadHunterId', function () {
        setSpecializationName();
    });

    setupSpecializationsSelect();

    $(document).on('change', '#HeadHunterAreas', function () {
        setupSpecializationsSelect();
    });
});