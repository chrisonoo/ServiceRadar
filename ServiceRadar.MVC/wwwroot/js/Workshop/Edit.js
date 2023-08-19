$(document).ready(function () {
    const myModal = new bootstrap.Modal(document.getElementById('createWorkshopServiceModal'));
    const addWorkshopServicesButton = document.querySelector("#add-workshop-services-button");

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
                myModal.hide(); // Closes the modal after successfully adding the service
            },
            error: function () {
                toastr["error"]("Something went wrong");
            }
        });
    });

    addWorkshopServicesButton.addEventListener('click', function () {
        const serviceDescription = document.querySelector("#ServiceDescription");
        const serviceCost = document.querySelector("#Cost");

        serviceDescription.value = '';
        serviceCost.value = '';
    });
});