// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var modal = document.getElementsByClassName('simpleModal');
var modalBtn = document.getElementsByClassName('modalBtn');
var closeBtn = document.getElementsByClassName('closeBtn');

modalBtn.addEventListener('click', openModal);
closeBtn.addEventListener('click', closeModal);
window.addEventListener('click', ClickOutside);

function openModal() {
    modal.style.display = 'block';
}

function closeModal() {
    modal.style.display = 'none';
}

function ClickOutside(e) {
    if (e.target == modal) {
        modal.style.display = 'none';
    }
}