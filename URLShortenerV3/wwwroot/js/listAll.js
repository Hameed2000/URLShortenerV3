// Fetches and prints out all shortened links you've created in your browser
// Uses localStorage cache to store the id's of links you've created
 
// This isn't the best way to do it, but I decided to add this feature 
// after creating the database, the way I did it does not allow you to add more columns
// one it's created

// I would've prefered to generate an id to store in localStorage for first time users
// And attach that id to the link entry in the database

let ids = localStorage.getItem("id-cache");
fetch("https://localhost:44378/api/Links/GetAllLinks/" + ids, {
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
            document.getElementById("ez-text").innerHTML = "Something went wrong...";
            return;
        }

        document.getElementById("ez-text").innerHTML = "Loaded";

        for (let i = 0; i < data.length; i++) {
            let p = document.createElement("p");
            p.innerHTML = "Link ID: " + data[i].linkID + " ///  Long URL: " + data[i].longURL + " /// Amount Used: " + data[i].amountUsed + " /// Date Created: " + data[i].dateCreated
            document.getElementById("list").appendChild(p);
            console.log(data[i].linkID + " " + data[i].longURL + " " + data[i].amountUsed + " " + data[i].dateCreated);
        }

    })
