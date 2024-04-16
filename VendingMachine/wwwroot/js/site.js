// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

localStorage.setItem('coin1', 0);
localStorage.setItem('coin2', 0);
localStorage.setItem('coin3', 0);
localStorage.setItem('coin4', 0);

const coinButtons = document.querySelectorAll('.coin-button');

var iterator = 1;
coinButtons.forEach(button => {
    button.addEventListener('click', () => {
        var clicks = localStorage.getItem(button.id);
        localStorage.setItem(button.id, Number(clicks) + 1);
        console.log(`${button.id} clicked`);
    })
})