// functions that are called when the page loads (to dynamically populate certain dropdown menus)

window.onload = function() {

    populateExistingCharactersDropDown();
    populateAttributeToUpdateDropdown();
}

// END onload functions

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

};
// END functionality for allowing menu buttons to toggle between pages


// BEGIN functionality for new character form submission

var newCharacterForm = document.getElementById("newcharacterform");

newCharacterForm.addEventListener("submit", sendNewCharacterInfoToApi);

// The sendNewCharacterInfoToApi function below makes an AJAX call to the character
// management API to post the submitted new character form info for entry into the database.
// Upon successful entry into the database, the function notifies the client of success, or on failure
// gives the reason why.

function sendNewCharacterInfoToApi(event) {

    var xhr = new XMLHttpRequest();

    var request = interceptFormSubmit(event, newCharacterForm);

    xhr.open('POST', 'https://localhost:5003/api/newcharacter');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        alert(this.response); // ***change this once database connection and other backend code is finished***
        
        for (var dropdown of existingCharactersDropDown) {

            dropdown.innerHTML = ('<option value="" disabled selected>' +
                                                    'Existing Characters' +
                                                    '</option>');
        }
                                                   
        populateExistingCharactersDropDown();
    }

    xhr.send(request);
}

// The interceptFormSubmit function below disables the default behavior of 
// the new character form and captures its entries in a form-data object,
// which it converts to JSON and returns.  Prior to returning it resets the form
// fields to their default values.

function interceptFormSubmit(event, formName) {

    event.preventDefault();

    var formData = new FormData(formName);

    var entries = formData.entries();

    var entriesObject = Object.fromEntries(entries);

    var jsonEntries = JSON.stringify(entriesObject);

    formName.reset();

    return jsonEntries;
}


// END functionality for new character form submission

// BEGIN functionality for populating existing character dropdown menus on all pages

var existingCharactersDropDown = document.getElementsByClassName('characternamedropdown');

//window.onload = populateExistingCharactersDropDown, populateAttributeToUpdateDropdown;

function populateExistingCharactersDropDown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', 'https://localhost:5003/api/viewcharacterdropdown');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var characterNameArray = JSON.parse(this.response);

        for (var name of characterNameArray){

            for (var dropdown of existingCharactersDropDown) {

                var newSelectInput = document.createElement("option");

                newSelectInput.value = name;

                newSelectInput.innerHTML = name;

                dropdown.appendChild(newSelectInput);
            }
        }
    }

    xhr.send()
}
// END functionality for populating existing character dropdown on view page

// BEGIN functionality for displaying selected character information on view page

var viewCharacterForm = document.getElementById("viewcharacterform");

viewCharacterForm.addEventListener("submit", getSelectedCharacterInfo);

function getSelectedCharacterInfo(event) {

    var xhr = new XMLHttpRequest();

    var characterNameJSON = interceptFormSubmit(event, viewCharacterForm);

    var characterNameString = JSON.parse(characterNameJSON).characterName;

    xhr.open('GET', `https://localhost:5003/api/selectedcharacterinfo?characterName=${characterNameString}`);

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var characterInfoObject = JSON.parse(this.response);
    
        for (var property in characterInfoObject) {

            if (property !== "characterInventory" && property !== "characterSpells") {

                var targetElement = document.getElementById(`${property}View`);

                if (targetElement.className !== "viewcharactercheckbox") {

                    targetElement.innerHTML = characterInfoObject[property];
                }
                else if (characterInfoObject[property] === true) {

                    targetElement.checked = true;
                }
            }
        }
        
    }

    xhr.send();
}

// END functionality for displaying selected character information on view page

// BEGIN functionality for populating updatable attributes dropdown on update page

var characterAttributesDropdown = document.getElementById('attributetoupdatedropdown');

//window.onload = populateAttributeToUpdateDropdown;

function populateAttributeToUpdateDropdown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', 'https://localhost:5003/api/getUpdatableCharacterAttributes');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {
        console.log(this.response);
        var emptyCharacterDetailsObject = JSON.parse(this.response);

        for (var property in emptyCharacterDetailsObject){

            if (property !== "characterInventory" && property !== "characterSpells") {

                var newSelectInput = document.createElement("option");

                newSelectInput.value = property;

                newSelectInput.innerHTML = property;

                characterAttributesDropdown.appendChild(newSelectInput);
            }
        }
    }

    xhr.send()
}

// END functionality for populating updatable attributes dropdown on updates page