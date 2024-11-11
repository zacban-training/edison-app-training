const minAge = 13;

function calculateAge() {
    const birthDate = new Date(document.getElementById("birthdate").value);
    const today = new Date();

    // Beregn alder
    let age = today.getFullYear() - birthDate.getFullYear();
    const monthDiff = today.getMonth() - birthDate.getMonth();
    const dayDiff = today.getDate() - birthDate.getDate();

    // Justér for måned og dag
    if (monthDiff < 0 || (monthDiff === 0 && dayDiff < 0)) {
        age--;
    }

    return age;
}

function isOldEnough() {
    const myAge = calculateAge();
    return myAge >= minAge;
}

function updateDateTime() {
    const now = new Date();
    const options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric', second: 'numeric' };
    document.getElementById('dateTime').textContent = now.toLocaleString('da-DK', options);
}

// Opdater dato og tid hvert sekund
setInterval(updateDateTime, 1000);
updateDateTime(); // Initial opdatering