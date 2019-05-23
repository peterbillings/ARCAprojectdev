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

        resetViewCharacterCheckBoxes();
    
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

// Below: helper function for resetting the character skill checkboxes each time a new character if viewed

function resetViewCharacterCheckBoxes() {

    var allViewCheckBoxes = document.getElementsByClassName("viewcharactercheckbox");

    for (var checkbox of allViewCheckBoxes) {

        checkbox.checked = false;
    }
}

// END functionality for displaying selected character information on view page

// BEGIN functionality for populating updatable attributes dropdown on update page

var characterAttributesDropdown = document.getElementById('attributetoupdatedropdown');

function populateAttributeToUpdateDropdown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', 'https://localhost:5003/api/getUpdatableCharacterAttributes');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var emptyCharacterDetailsObject = JSON.parse(this.response);

        for (var property in emptyCharacterDetailsObject){

            if (property !== "characterInventory" && property !== "characterSpells") {

                var newSelectInput = document.createElement("option");

                property = convertFirstLetterToUpper(property);

                newSelectInput.value = property;

                newSelectInput.innerHTML = property;

                characterAttributesDropdown.appendChild(newSelectInput);
            }
        }
    }

    xhr.send()
}

// below: helper function for capitalizing the first letter of each property for C# object property formatting

function convertFirstLetterToUpper(string) {

    return string.charAt(0).toUpperCase() + string.slice(1)
}

// END functionality for populating updatable attributes dropdown on updates page

// BEGIN functionality for dynamically generating fields for the character update form

var characterUpdateFormBuilder = document.getElementById("characterupdateformbuilder");

var characterUpdateForm = document.getElementById("characterupdatesubmitform");

characterUpdateFormBuilder.addEventListener("submit", generateUpdateFormField);

function generateUpdateFormField(event) {

    var xhr = new XMLHttpRequest();

    var characterNameAndAttributeJSON = interceptFormSubmit(event, characterUpdateFormBuilder);

    var characterNameString = JSON.parse(characterNameAndAttributeJSON).characterName;

    var characterAttributeString = JSON.parse(characterNameAndAttributeJSON).characterAttribute;

    xhr.open('GET', `https://localhost:5003/api/getCurrentValueOfSelectedAttribute?characterName=${characterNameString}&characterAttribute=${characterAttributeString}`);

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var currentValue = this.response;

        if (characterUpdateForm.children.length === 1)
        {
            characterUpdateForm.style.display = "block";
        }

        var newUpdateFormRow = document.createElement("div");

        var removableUpdateRows = document.getElementsByClassName("removeupdateformrow");

        newUpdateFormRow.classList.add("updatecharacterrow");

        newUpdateFormRow.innerHTML = ('<div class="updatecharactersubmitformcolumn">' +
                                          '<label for="charactertoupdate">Character Name</label>' +
                                          `<p class="updatecharacterinput characterdetailvaluedisplay" id="charactertoupdate">${characterNameString}</p>` +
                                      '</div>' +
                                      '<div class="updatecharactersubmitformcolumn">' +
                                          '<label for="attributetoupdate">Attribute</label>' +
                                          `<p class="updatecharacterinput characterdetailvaluedisplay" id="attributetoupdate">${characterAttributeString}</p>`  +
                                      '</div>' +
                                      '<div class="updatecharactersubmitformcolumn">' +
                                          '<label for="currentvalueofattributetoupdate">Current Value</label>' +
                                          `<p class="updatecharacterinput characterdetailvaluedisplay" id="">${currentValue}</p>` +
                                      '</div>' +
                                      '<div class="updatecharactersubmitformcolumn">' +
                                          '<label for="newcharacterupdatevalue">New Value</label>' +
                                          '<input class="updatecharacterinput" id="newcharacterupdatevalue" type="text">' +
                                      '</div>' +
                                      '<p class="removeupdateformrow" style="border: solid 1px black; background-color: white; height: 30px; width: 30px;">X</p>'
                                      );

        var lastChildIndex = characterUpdateForm.children.length - 1;
        
        characterUpdateForm.insertBefore(newUpdateFormRow, characterUpdateForm.children[lastChildIndex]);

        for (var i = 0; i < removableUpdateRows.length; i++) {

            removableUpdateRows[i].addEventListener('click', removeUpdateRow);
        }

        //console.log(currentValueOfSelectedAttribute);
    }

    xhr.send()

}

//Below: helper function to remove a row from the dynamic update form

function removeUpdateRow() { 

    this.parentNode.parentNode.removeChild(this.parentNode);

    if (characterUpdateForm.children.length === 1)
        {
            characterUpdateForm.style.display = "none";
        }
}

// END functionality for dynamically generating fields for the character update form