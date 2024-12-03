let dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $("#tblCategory").DataTable({
        ajax: {
            url: '/Admin/Categories/GetAllCategories',
            type: 'GET',
            datatype: 'json',
            error: function(xhr, status, error) {
                console.error("Error loading categories:", error);
                alert("An error occurred while loading categories.");
            }
        },
        columns: [
            { data: 'categoryId', width: '5%' },    // Change 'id' to 'categoryId'
            { data: 'categoryName', width: '40%' },  // Change 'name' to 'categoryName'
            { data: 'order', width: '10%' },
            {
                data: 'categoryId',  // Use 'categoryId' here as well
                width: '40%',
                render: function (data) {
                    return `<div class="text-center">
                        <a href="/Admin/Categories/Edit/${data}" class="btn btn-primary mx-1">
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
    confirmDelete(`/Admin/Categories/Delete/${id}`, dataTable);
}

$(document).on('submit', '#categoryForm', function (e) {
    e.preventDefault();
    submitForm(this, function (response) {
        window.location.href = '/Admin/Categories/Index';
    });
});
