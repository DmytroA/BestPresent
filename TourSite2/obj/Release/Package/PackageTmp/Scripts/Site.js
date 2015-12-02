$("#OrderTour_children_num").change(function () {
    setChildrenNum($(this).val());
});

$("#OrderTour_children_num").keyup(function () {
    setChildrenNum($(this).val());
});

setChildrenNum($("#OrderTour_children_num").val());

function setChildrenNum(num) {
    if (num == "" || num == 0) {
        $("#OrderTour_children_age").hide();
    } else {
        $("#OrderTour_children_age").show();

        var element = '<select name="children_age[]">';
        for (var i = 1; i <= 18; i++) {
            element += '<option>' + i + '</option>';
        }
        element += '</select>';

        $("#OrderTour_children_age_ph").html("");

        for (var i = 0; i < num; i++) {
            $("#OrderTour_children_age_ph").append(element);
        }
    }
}