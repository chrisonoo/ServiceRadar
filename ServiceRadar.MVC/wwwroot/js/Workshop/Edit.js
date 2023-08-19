$(document).ready(function () {
    LoadWorkshopServices();

    $("#createWorkshopServiceModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Created workshop service");
                LoadWorkshopServices();
            },
            error: function () {
                toastr["error"]("Something went wrong");
            }
        });
    });
});