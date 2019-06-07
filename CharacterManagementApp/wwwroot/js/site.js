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

    var allMenuButtons = document.getElementsByClassName("menuitem");

    var allPages = document.getElementsByClassName("page");

    var pageClass = this.classList.item(1);

    for(var i = 0; i < allMenuButtons.length; i++) {
        allMenuButtons[i].style.backgroundColor = "#314977";
        allMenuButtons[i].style.boxShadow = "2px 3px 3px black"
    }
    
    for (var i = 0; i < allPages.length; i++) {
        allPages[i].style.display = "none";
    }

    var toggled = document.getElementsByClassName(pageClass)[1];

    toggled.style.display = "block";

    this.style.backgroundColor = "#1b2841";
    this.style.boxShadow = "none";

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

// BEGIN functionality for dynamically generating fields for the character update form with 'constrained' fields

var characterUpdateFormBuilder = document.getElementById("characterupdateformbuilder");

var characterUpdateSubmitForm = document.getElementById("characterupdatesubmitform");

var removableUpdateRows = document.getElementsByClassName("removeupdateformrow");

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

        if (characterUpdateSubmitForm.children.length === 1)
        {
            characterUpdateSubmitForm.style.display = "block";
        }

        var newUpdateFormRow = document.createElement("div");

        newUpdateFormRow.classList.add("updatecharacterrow");

        var matchingInputField = document.getElementsByName(characterAttributeString)[0];

        if (matchingInputField.type === "textarea") {

            newUpdateFormRow.innerHTML = (

                '<div class="updatecharactersubmitformcolumn">' +
                    `<label for="currentTextAreaValue">${characterNameString}'s ${characterAttributeString} (Click to Remove)</label>` +
                    `<p class="viewcharactertextarea removeupdateformrow" id="currentTextAreaValue">${currentValue}</p>` +
                '</div>' +
                '<div class="updatecharactersubmitformcolumn">' +
                    '<label for="newTextAreaValue">New Value</label>' +
                    `<textarea class="updatecharactertextarea" id="newTextAreaValue" name="${characterNameString}_${characterAttributeString}" maxlength="300" required>${currentValue}</textarea>` +
                '</div>'
            );
        }

        else {

            newUpdateFormRow.innerHTML = (
            
                '<div class="updatecharactersubmitformcolumn">' +
                    '<label for="charactertoupdate">Name (Click to remove)</label>' +
                    `<p class="updatecharacterinput characterdetailvaluedisplay removeupdateformrow" id="charactertoupdate">${characterNameString}</p>` +
                '</div>' +
                '<div class="updatecharactersubmitformcolumn">' +
                    '<label for="attributetoupdate">Attribute</label>' +
                    `<p class="updatecharacterinput characterdetailvaluedisplay" id="attributetoupdate">${characterAttributeString}</p>`  +
                '</div>' +
                '<div class="updatecharactersubmitformcolumn">' +
                    '<label for="currentvalueofattributetoupdate">Current Value</label>' +
                    `<p class="updatecharacterinput characterdetailvaluedisplay" id="currentvalueofattributetoupdate">${currentValue}</p>` +
                '</div>' +
                '<div class="updatecharactersubmitformcolumn">' +
                    `<label for="${characterNameString}${characterAttributeString}updatefield">New Value</label>` +
                '</div>'
            );

            var cloneInputField = matchingInputField.cloneNode(true);

            cloneInputField.classList.remove("newcharacterinput");

            cloneInputField.classList.add("updatecharacterinput");

            cloneInputField.name = `${characterNameString}_${characterAttributeString}`;

            cloneInputField.id = `${characterNameString}${characterAttributeString}updatefield`;

            if (cloneInputField.type === 'checkbox') {

                cloneInputField.type = 'text';

                cloneInputField.readOnly = true;

                if (currentValue === 'True') {

                    cloneInputField.value = 'false';
                }
                else
                {
                    cloneInputField.value = 'true';
                } 
            }

            newUpdateFormRow.children[3].appendChild(cloneInputField);
        }

        var lastChildIndex = characterUpdateSubmitForm.children.length - 1;
        
        characterUpdateSubmitForm.insertBefore(newUpdateFormRow, characterUpdateSubmitForm.children[lastChildIndex]);

        for (var i = 0; i < removableUpdateRows.length; i++) {

            removableUpdateRows[i].addEventListener('click', removeUpdateRow);
        }
    }

    xhr.send()

}

//Below: helper function to remove a row from the dynamic update form

function removeUpdateRow() { 

    this.parentNode.parentNode.parentNode.removeChild(this.parentNode.parentNode);

    if (characterUpdateSubmitForm.children.length === 1)
        {
            characterUpdateSubmitForm.style.display = "none";
        }
}

// END functionality for dynamically generating fields for the character update form

// BEGIN functionality for submitting dynamic character update form

characterUpdateSubmitForm.addEventListener("submit", updateCharacterInfo);

function updateCharacterInfo() {

    var xhr = new XMLHttpRequest();

    var updateFormData = JSON.parse(interceptFormSubmit(event, characterUpdateSubmitForm));

    var characterUpdateInfoWrapper = {

        "DynamicUpdateInfo":[]
    }

    for (var property in updateFormData) {

        characterUpdateInfoWrapper["DynamicUpdateInfo"].push(property + "_" + updateFormData[property]);
    }

    var characterUpdateInfoWrapperJSON = JSON.stringify(characterUpdateInfoWrapper);

    xhr.open( 'POST', 'https://localhost:5003/api/updateCharacterInfo');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function () {

        alert(this.response);

        resetCharacterUpdateSubmitForm();
        
    }

    xhr.send(characterUpdateInfoWrapperJSON);

}

// below: helper function to reset characterupdatesubmitform

function resetCharacterUpdateSubmitForm() {

    var allUpdateFormRows = characterUpdateSubmitForm.children;

    while (allUpdateFormRows.length > 1) {

        characterUpdateSubmitForm.removeChild(allUpdateFormRows[0]);
    }

    characterUpdateSubmitForm.style.display = "none";
}

// END: functionality for submitting dynamic character update form

// BEGIN: functionality for toggling inventory page form display

var updateInventoryButton = document.getElementById("updateinventorybutton");
var viewInventoryButton = document.getElementById("viewinventorybutton");

updateInventoryButton.addEventListener("click", toggleInventoryDisplay);
viewInventoryButton.addEventListener("click", toggleInventoryDisplay);

function toggleInventoryDisplay() {

    var inventoryToggleButtons = document.getElementsByClassName("inventorytoggle");

    var allInventoryForms = document.getElementsByClassName("inventoryform");

    var inventoryFormClass = this.classList.item(1);

    for(var i = 0; i < inventoryToggleButtons.length; i++) {
        inventoryToggleButtons[i].style.backgroundColor = "#314977";
        inventoryToggleButtons[i].style.boxShadow = "2px 3px 3px black"
    }
    
    for (var i = 0; i < allInventoryForms.length; i++) {
        allInventoryForms[i].style.display = "none";
    }

    document.getElementsByClassName(inventoryFormClass)[1].style.display = "block";

    this.style.backgroundColor = "#1b2841";
    this.style.boxShadow = "none";
};

// END: functionality for toggling inventory page form display

// BEGIN: functionality for submitting inventory update form to api

var updateInventoryForm = document.getElementById("updateinventoryform");

updateInventoryForm.addEventListener("submit", updateCharacterInventory);

function updateCharacterInventory() {

    var xhr = new XMLHttpRequest();

    var request = interceptFormSubmit(event, updateInventoryForm);

    xhr.open('POST', 'https://localhost:5003/api/updateinventory');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        alert(this.response); 
    }

    xhr.send(request);

}

// END: functionality for submitting inventory update for to api

// BEGIN: functionality for populating character inventory drop down based on charactername drop down changes

var inventoryViewNameDropdown = document.getElementById("characterinventorytoview");

var inventoryDropdown = document.getElementById("currentcharacterinventory");

inventoryViewNameDropdown.addEventListener("change", populateInventoryDropdown);

function populateInventoryDropdown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', `https://localhost:5003/api/populateinventorydropdown?characterName=${inventoryViewNameDropdown.value}`);

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var characterInventoryArray = JSON.parse(this.response);

        while(inventoryDropdown.children.length > 1) {

            inventoryDropdown.removeChild(inventoryDropdown.children[1]);
        }

        for (var item of characterInventoryArray){

                var newSelectInput = document.createElement("option");

                newSelectInput.value = item;

                newSelectInput.innerHTML = item;

                inventoryDropdown.appendChild(newSelectInput);
        }
    }

    xhr.send()



}

// END: functionality for populating character inventory drop down

// BEGIN: functionality for viewing selected item details from selected character's inventory

var itemDetailsView = document.getElementById("itemDetailsView");

var viewInventoryForm = document.getElementById("viewinventoryform");

viewInventoryForm.addEventListener("submit", getSelectedItemDetails);

function getSelectedItemDetails() {

    var xhr = new XMLHttpRequest();

    var viewInventoryFormJSON = interceptFormSubmit(event, viewInventoryForm);

    var viewInventoryFormData = JSON.parse(viewInventoryFormJSON);

    console.log(viewInventoryFormData);

    xhr.open('GET', `https://localhost:5003/api/getSelectedItemDetails?characterName=${viewInventoryFormData.CharacterName}&itemName=${viewInventoryFormData.ItemName}`);

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var itemDetails = JSON.parse(this.response);

        // itemDetailsView.innerHTML = ("");
        
    };

    xhr.send();


}

// END: functionality for viewing selected item details