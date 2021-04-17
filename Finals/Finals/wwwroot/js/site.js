document.addEventListener('DOMContentLoaded', function () {

    const serv = document.querySelector('#services');
    const searchBar = document.forms['searchservices'].querySelector('#filter');
    if (searchBar) {
        searchBar.addEventListener('keyup', function (e) {
            const term = e.target.value.toLowerCase();
            const services = serv.getElementsByClassName('servrow');
            Array.from(services).forEach(function (service) {
                const servname = service.textContent;
                if (servname.toLowerCase().indexOf(term) != -1) {
                    service.style.display = 'block';
                } else {
                    service.style.display = 'none';
                }
            })
        })
    }
});

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


