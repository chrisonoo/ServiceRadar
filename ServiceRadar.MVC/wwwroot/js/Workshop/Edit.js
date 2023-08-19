$(document).ready(function () {
    const RenderWorkshopServices = (services, container) => {
        container.empty();

        let servicesTable = '';
        let iteration = 1;

        for (const service of services) {
            servicesTable +=
                `<tr><th scope="row">${iteration}</th>
                 <td>${service.description}</td>
                 <td>${service.cost}</td></tr>`
            iteration++;
        }

        container.append(
            `<table class="table">
                 <thead>
                     <tr>
                         <th scope="col">#</th>
                         <th scope="col">Service</th>
                         <th scope="col">Price</th>
                     </tr>
                 </thead>
                 <tbody>
                     ${servicesTable}
                 </tbody>
             </table>`
        )
    }

    const LoadWorkshopServices = () => {
        const container = $("#services");
        const workshopEncodedName = container.data("encodedName");

        $.ajax({
            url: `/Workshop/${workshopEncodedName}/WorkshopService`,
            type: 'get',
            success: function (data) {
                if (!data.length) {
                    container.html("There are no services for this workshop");
                } else {
                    RenderWorkshopServices(data, container);
                }
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        });
    }

    LoadWorkshopServices();

    $("#createWorkshopServiceModal form").submit(function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Created workshop service")
            },
            error: function () {
                toastr["error"]("Something went wrong")
            }
        });
    });
});