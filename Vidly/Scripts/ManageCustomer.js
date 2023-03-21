$(document).ready(function () {
    $("#customers").on("click", ".js-delete", function () {
        var button = $(this);
        var id = button.attr("data-user-id");
        bootbox.confirm("Are you sure you want to delete this custome?", function (result) {
            if (result) {
                console.log("test");
                $.ajax({
                    method: "DELETE",
                    url: "/api/customers/" + id,
                    success: function () {
                        button.parents("tr").remove();
                    }
                });
            }
        });
    });
});