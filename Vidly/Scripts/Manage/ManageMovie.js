$(document).ready(function () {

    var table = $("#movies").DataTable({
        ajax: {
            url: "/api/movies",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, movie) {
                    return "<a href='/movies/edit/" + movie.id + "'>" + movie.name + "</a>";
                }
            },
            {
                data: "genres"
            },
            {
                data: "id",
                render: function (data) {
                    return "<button class= 'btn-link js-delete' data-movie-id=" + data + ">Delete</button>";
                }
            }
        ]
    });

    $(".js-delete").click(function () {
        var button = $(this);
        var id = button.attr("data-movie-id");
        bootbox.confirm("Are you sure you want to delete this movie?", function (result) {
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