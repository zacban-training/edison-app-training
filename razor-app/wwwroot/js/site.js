// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function updateDateTime() {
    const now = new Date();
    const options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric', second: 'numeric' };
    document.getElementById('dateTime').textContent = now.toLocaleString('da-DK', options);
}

// Opdater dato og tid hvert sekund
setInterval(updateDateTime, 1000);
updateDateTime(); // Initial opdatering