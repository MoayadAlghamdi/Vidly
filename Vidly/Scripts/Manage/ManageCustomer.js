$(document).ready(function () {

    var table = $("#customers").DataTable({
        ajax: {
            url: "/api/customers",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, customer) {
                    return "<a href='/customers/edit/" + customer.id + "'>" + customer.name + "</a>";
                }
            },
            {
                data: "membershipType.name"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class= 'btn-link js-delete' data-customer-id=" + data + ">Delete</button>";
                }
            }
        ]
    });

    $(".js-delete").click(function () {
        var button = $(this);
        var id = button.attr("data-customer-id");
        bootbox.confirm("Are you sure you want to delete this custome?", function (result) {
            if (result) {
                table.row(button.parents("tr")).remove().draw();
                //$.ajax({
                //    method: "DELETE",
                //    url: "/api/customers/" + id,
                //    success: function () {
                table.row(button.parents("tr")).remove().draw();
                //    }
                //});
            }
        });
    });
});