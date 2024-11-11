function updateDateTime() {
    const now = new Date();
    const options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric', second: 'numeric' };
    if (document.getElementById('dateTime') !== undefined && document.getElementById('dateTime') !== null)
        document.getElementById('dateTime').textContent = now.toLocaleString('da-DK', options);
}

// Opdater dato og tid hvert sekund
setInterval(updateDateTime, 1000);
updateDateTime(); // Initial opdatering

let users = localStorage.getItem('users') ? JSON.parse(localStorage.getItem('users')) : [];

console.dir(users);

function createUser() {
    let user = users.find(u => u.username === username && u.password === password);
    if (user) {
        // alert('User already exists');
        return;
    }
    
    user = {
        username: document.getElementById('username').value,
        password: document.getElementById('password').value,
        birthdate: document.getElementById('birthdate').value,
        city: document.getElementById('city').value,
        municipality: document.getElementById('municipality').value
    };

    console.dir('users', users);
    users.push(user);
    localStorage.setItem('users', JSON.stringify(users));
}

const loggedInUser = localStorage.getItem('loggedInUser') ? JSON.parse(localStorage.getItem('loggedInUser')) : null;

function login() {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    const user = users.find(u => u.username === username && u.password === password);
    
    if (user) {
        localStorage.setItem('loggedInUser', JSON.stringify(user));
        console.log('Login successful');
    } else {
        alert('Login failed');
    }
}