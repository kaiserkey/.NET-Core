// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function markCompleted(value) {
    let check = document.getElementById('task-finish');

    if (value == 'False') {
        check.closest('form').submit();
    }
}