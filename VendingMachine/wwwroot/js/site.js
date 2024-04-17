// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

if (localStorage.getItem('total') == null) {
    localStorage.setItem('coin1', 0);
    localStorage.setItem('coin2', 0);
    localStorage.setItem('coin3', 0);
    localStorage.setItem('coin4', 0);
    localStorage.setItem('total', 0);
}
else {
    var total = localStorage.getItem("total");
    const totalElement = document.getElementById('total');
    totalElement.innerText = total;
}

setOnClickOnCoinInsertButtons();

function setOnClickOnCoinInsertButtons() {
    const coinButtons = document.querySelectorAll('.coin-button');

    coinButtons.forEach(button => {
        button.addEventListener('click', () => {
            var clicks = localStorage.getItem(button.id);
            var total = localStorage.getItem("total");
            var newTotal = Number(total) + Number(button.getAttribute("value"));
            localStorage.setItem(button.id, Number(clicks) + 1);
            localStorage.setItem("total", newTotal);
            console.log(`${button.id} clicked`);

            const totalElement = document.getElementById('total');
            totalElement.innerText = newTotal;
        })
    })
}