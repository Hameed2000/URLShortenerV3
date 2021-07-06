// When user enters their shortened URL this will make a get request
// to the server, requesting the long URL, then it will redirect the client
// to the new URL

let URL = window.location.href;
let split = URL.split("/");
let id = split[split.length - 1];

fetch("https://localhost:44378/api/Links/" + id, {
    method: 'Get',
})
    .then(res => {
        console.log(res);
        if (!res.ok) {
            return false;
        }
        return res.json();
    })
    .then(data => {
        console.log(data);
        if (!data) {
            document.getElementById("ez-text").innerHTML = "Your URL was not found";
            return;
        }
        let longURL = data.longURL;
        console.log(longURL);
        window.location.assign(longURL);
    })