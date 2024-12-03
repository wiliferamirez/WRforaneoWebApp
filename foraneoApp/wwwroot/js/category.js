let dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblCategory").DataTable({
        ajax: {
            url: '/Admin/Categories/GetAllCategories',
            type: 'GET',
            datatype: 'json'
        },
        columns: [
            { data: 'id', width: '5%' },
            { data: 'name', width: '40%' },
            { data: 'order', width: '10%' },
            {
                data: 'id',
                width: '40%',
                render: function(data) {
                    return `<div class="text-center">
                        <a href="/Admin/Categories/Edit/${data}" class="btn btn-primary mx-1">
                            <i class="fas fa-edit"></i> Edit
                        </a>
                        &nbsp
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
    confirmDelete(`/Admin/Categories/Delete/${id}`, dataTable);
}


$(document).on('submit', '#categoryForm', function(e) {
    e.preventDefault();
    submitForm(this, function(response) {
        window.location.href = '/Admin/Categories/Index';
    });
});