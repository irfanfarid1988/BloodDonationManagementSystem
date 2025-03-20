// Initialize DataTables for tables
$(document).ready(function () {
    // Initialize all DataTables on the page
    $('table.table').each(function () {
        new DataTable(this, {
            responsive: true,
            pageLength: 10,
            lengthMenu: [[5, 10, 25, 50, -1], [5, 10, 25, 50, "All"]]
        });
    });
});
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
