//BEGIN functionality for allowing menu buttons to toggle between pages

var mainButton = document.getElementById("mainbutton");
var newButton = document.getElementById("newbutton");
var viewButton = document.getElementById("viewbutton");
var updateButton = document.getElementById("updatebutton");
var inventoryButton = document.getElementById("inventorybutton");
var spellsButton = document.getElementById("spellsbutton");

var mainPage = document.getElementById("mainpage");
var newPage = document.getElementById("newpage");
var viewPage = document.getElementById("viewpage");
var updatePage = document.getElementById("updatepage");
var inventoryPage = document.getElementById("inventorypage");
var spellsPage = document.getElementById("spellspage");

mainButton.addEventListener("click", togglePageDisplay);
newButton.addEventListener("click", togglePageDisplay);
viewButton.addEventListener("click", togglePageDisplay);
updateButton.addEventListener("click", togglePageDisplay);
inventoryButton.addEventListener("click", togglePageDisplay);
spellsButton.addEventListener("click", togglePageDisplay);

//the togglePageDisplay function below sets the display of all pages to "none", then 
//sets the display of the page whose corresponding button was clicked
//to "block", allowing one to quickly view each page by clicking the menu buttons

function togglePageDisplay() {

    var allPages = document.getElementsByClassName("page");

    var pageClass = this.classList.item(1);
    
    for (var i = 0; i < allPages.length; i++) {
        allPages[i].style.display = "none";
    }

    document.getElementsByClassName(pageClass)[1].style.display = "block";

    //console.log("togglePageDisplay called");

};
// END functionality for allowing menu buttons to toggle between pages


// BEGIN functionality for new character form submission/validation

var newCharacterForm = document.getElementById("newcharacterform");

newCharacterForm.addEventListener("submit", sendNewCharacterInfoToApi);

function sendNewCharacterInfoToApi(event) {

    interceptFormSubmit(event);
    // var xhr = new XMLHttpRequest();

    // xhr.open('POST', 'https://localhost:5003/api/values');

    // xhr.setRequestHeader("Content-Type", "application/JSON");
}

function interceptFormSubmit(event) {

    event.preventDefault();

    var formData = new FormData(newCharacterForm);

    var entries = formData.entries();

    var entriesObject = Object.fromEntries(entries);

    var jsonEntries = JSON.stringify(entriesObject);

    return jsonEntries;

    newCharacterForm.reset();
}


// END functionality for new character form submission/validation