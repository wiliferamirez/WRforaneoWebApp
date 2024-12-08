let dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblEvent").DataTable({
        ajax: {
            url: '/Admin/Events/GetAllEvents',
            type: 'GET',
            datatype: 'json',
            error: function(xhr, status, error) {
                console.error("Error loading categories:", error);
                alert("An error occurred while loading categories.");
            }
        },
        columns: [
            { data: 'eventId', width: '5%' },
            { data: 'categoryName', width: '5%' },
            { data: 'title', width: '10%' },
            { data: 'description', width: '10%' },
            { data: 'location', width: '10%' },
            { data: 'startDate', width: '10%' },
            { data: 'creationDate', width: '10%' },
            {
                data: 'eventId',
                width: '30%',
                render: function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Events/Edit/${data}" class="btn btn-primary mx-1">
                            <i class="fas fa-edit"></i> Edit
                        </a>
                        &nbsp;
                        <button onclick="deleteCategory(${data})" class="btn btn-danger mx-1">
                            <i class="fas fa-trash"></i> Delete
                        </button>
                    </div>`;
                }
            }
        ]
    });
}

function deleteCategory(id) {
    confirmDelete(`/Admin/Events/Delete/${id}`, dataTable);
}

$(document).on('submit', '#categoryForm', function (e) {
    e.preventDefault();
    submitForm(this, function (response) {
        window.location.href = '/Admin/Events/Index';
    });
});
