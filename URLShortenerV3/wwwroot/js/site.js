console.log("Welcome Hameed");

// When the user clicks the "Shorten URL" button, this function is called
// Makes a post request to the server to create the entry
// Also adds id to localStorage cache

function URLShorten() {
    console.log("URLShorten() Called");
    console.log(document.getElementById("url-input").value);
    fetch("https://localhost:44378/api/Links", {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            LongURL: document.getElementById("url-input").value
        })
    })
    .then(res => {

        if (!res.ok) {
            return false;
        }

        return res.json();
    })
    .then(data => {

        console.log(data);

        if (!data) {
            document.getElementById("shortened-url").innerHTML = "Invalid Entry";
        }
        else {

            document.getElementById("shortened-url").innerHTML = "Your shortened URL: localhost:44378/" + data.linkID;

            addToCache(data.linkID);

        }

    })

}

function addToCache(linkID){

    if ("caches" in window) {

        if (localStorage["id-cache"] == "") {
            localStorage["id-cache"] = localStorage.getItem("id-cache") + linkID;
        }
        else {
            localStorage["id-cache"] = localStorage.getItem("id-cache") + "_" + linkID;
        }
        

        console.log(localStorage["id-cache"]);

    }

}