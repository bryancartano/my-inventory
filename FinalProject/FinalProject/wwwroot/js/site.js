var modal = document.getElementsByClassName('.simpleModal');


document.querySelectorAll('.modalBtn').forEach(item => {
    item.addEventListener('click', event => {
        item.nextElementSibling.style.display = 'block';

    })
})


document.querySelectorAll('.closeBtn').forEach(item => {
    item.addEventListener('click', event => {
        item.parentElement.parentElement.parentElement.style.display = 'none';
    })
})