// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function redirectToLogin() {
    window.location.href = "/Identity/Account/Login?returnUrl=" + encodeURIComponent(location.pathname + location.search);
}

function handleDataTables() {
    $('#data_table').dataTable({
        order: [],
        ordering: true,
        responsive: true,
        //autoWidth: false,
        processing: true,
        columnDefs: [
            { orderable: false, targets: -1 },
            { responsivePriority: 1, targets: 0 },
            { responsivePriority: 2, targets: -1 }
        ],
        language: {
            lengthMenu: "_MENU_ registros por página",
            zeroRecords: "Nenhum registro encontrado",
            info: "Página _PAGE_ de _PAGES_",
            infoEmpty: "Sem registros",
            search: "Pesquisar:",
            infoFiltered: "(filtrados de _MAX_ total de registros)",
            paginate: {
                next: "Próxima",
                previous: "Anterior"
            }
        },
        dom: 'Bfrtip',
        buttons: [
            'pdf'
        ],
    });
}
