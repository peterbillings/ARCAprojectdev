// functions that are called when the page loads (to dynamically populate certain dropdown menus)

window.onload = function() {

    populateRaceDropDown();
    populateCharacterClassDropDown();
    populateBackgroundDropDown();
    populateAlignmentDropDown();
    populateHitDiceDropDown();
    populateSchoolOfMagicDropDown();
    populateExistingCharactersDropDown();
    populateAttributeToUpdateDropDown();
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

        var buttonId = allMenuButtons[i].id;

        if (buttonId !== "updateinventorybutton" && buttonId !== "updatespellsbutton" &&
            buttonId !== "viewinventorybutton" && buttonId !== "viewspellsbutton") {
                
            allMenuButtons[i].style.backgroundColor = "#314977";
            allMenuButtons[i].style.boxShadow = "2px 3px 3px black";
            allMenuButtons[i].style.border = "none";
        }
    }
    
    for (var i = 0; i < allPages.length; i++) {
        allPages[i].style.display = "none";
    }

    var toggled = document.getElementsByClassName(pageClass)[1];

    toggled.style.display = "block";

    this.style.backgroundColor = "#1b2841";
    this.style.boxShadow = "none";
    this.style.border = "1px solid #f0e6d6";
};
// END functionality for allowing menu buttons to toggle between pages

// BEGIN functionality for populating race dropdown menu
var raceDropDown = document.getElementById('racefield');

function populateRaceDropDown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', 'https://localhost:5003/api/populateracedropdown');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var raceArray = JSON.parse(this.response);

        for (var race of raceArray){

            var newSelectInput = document.createElement("option");

            newSelectInput.value = race;

            newSelectInput.innerHTML = race;

            raceDropDown.appendChild(newSelectInput);
        }
    }

    xhr.send()
}
// END functionality for populating race dropdown menu

// BEGIN functionality for populating character class dropdown menu
var characterClassDropDown = document.getElementById('characterclassfield');

function populateCharacterClassDropDown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', 'https://localhost:5003/api/populatecharacterclassdropdown');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var characterClassArray = JSON.parse(this.response);

        for (var characterClass of characterClassArray){

            var newSelectInput = document.createElement("option");

            newSelectInput.value = characterClass;

            newSelectInput.innerHTML = characterClass;

            characterClassDropDown.appendChild(newSelectInput);
        }
    }

    xhr.send()
}
// END functionality for populating characterclass dropdown menu

// BEGIN functionality for populating background dropdown menu

var backgroundDropDown = document.getElementById('backgroundfield');

function populateBackgroundDropDown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', 'https://localhost:5003/api/populatebackgrounddropdown');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var backgroundArray = JSON.parse(this.response);

        for (var background of backgroundArray){

            var newSelectInput = document.createElement("option");

            newSelectInput.value = background;

            newSelectInput.innerHTML = background;

            backgroundDropDown.appendChild(newSelectInput);
        }
    }

    xhr.send()
}
// END functionality for populating background dropdown menu

// BEGIN functionality for populating alignment dropdown menu
var alignmentDropDown = document.getElementById('alignmentfield');

function populateAlignmentDropDown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', 'https://localhost:5003/api/populatealignmentdropdown');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var alignmentArray = JSON.parse(this.response);

        for (var alignment of alignmentArray){

            var newSelectInput = document.createElement("option");

            newSelectInput.value = alignment;

            newSelectInput.innerHTML = alignment;

            alignmentDropDown.appendChild(newSelectInput);
        }
    }

    xhr.send()
}
// END functionality for populating alignment dropdown menu

// BEGIN functionality for populating hitdice dropdown menu
var hitDiceDropDown = document.getElementById('hitdicefield');

function populateHitDiceDropDown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', 'https://localhost:5003/api/populatehitdicedropdown');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var hitDiceArray = JSON.parse(this.response);

        for (var hitdice of hitDiceArray){

            var newSelectInput = document.createElement("option");

            newSelectInput.value = hitdice;

            newSelectInput.innerHTML = hitdice;

            hitDiceDropDown.appendChild(newSelectInput);
        }
    }

    xhr.send()
}
// END functionality for populating hitdice dropdown menu

// BEGIN functionality for populating schoolofmagic dropdown menu
var schoolOfMagicDropDown = document.getElementById('schoolofmagicfield');

function populateSchoolOfMagicDropDown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', 'https://localhost:5003/api/populateschoolofmagicdropdown');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var schoolOfMagicArray = JSON.parse(this.response);

        for (var schoolofmagic of schoolOfMagicArray){

            var newSelectInput = document.createElement("option");

            newSelectInput.value = schoolofmagic;

            newSelectInput.innerHTML = schoolofmagic;

            schoolOfMagicDropDown.appendChild(newSelectInput);
        }
    }

    xhr.send()
}
// END functionality for populating schoolofmagic dropdown menu

// BEGIN functionality for new character form submission

var newCharacterForm = document.getElementById("newcharacterform");

newCharacterForm.addEventListener("submit", sendNewCharacterInfoToApi);

// The sendNewCharacterInfoToApi function below makes an AJAX call to the character
// management API to post the submitted new character form info for entry into the database.
// Upon successful entry into the database, or not, the function notifies the client of success or failure

function sendNewCharacterInfoToApi(event) {

    var xhr = new XMLHttpRequest();

    var request = interceptFormSubmit(event, newCharacterForm);

    xhr.open('POST', 'https://localhost:5003/api/newcharacter');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        alert(this.response);  // maybe determine a better way than alert to notify client
        
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
// which it converts to JSON and returns. Prior to returning it resets the form
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

        var viewCharacterDisplay = document.getElementsByClassName("viewcharacterdisplay")

        for (var row of viewCharacterDisplay)
        {
            row.style.display = "flex";
        }

        resetViewCharacterCheckBoxes();
    
        for (var property in characterInfoObject) {

            var targetElement = document.getElementById(`${property}View`);

            if (targetElement.className !== "viewcharactercheckbox") {

                targetElement.innerHTML = characterInfoObject[property];
            }
            else if (characterInfoObject[property] === true) {

                targetElement.checked = true;
            }

            if (property === 'charismaSave')
            {
                break;
            }
        }
        
    }

    xhr.send();
}

// Below: helper function for resetting the character skill checkboxes each time a new character is viewed

function resetViewCharacterCheckBoxes() {

    var allViewCheckBoxes = document.getElementsByClassName("viewcharactercheckbox");

    for (var checkbox of allViewCheckBoxes) {

        checkbox.checked = false;
    }
}

// END functionality for displaying selected character information on view page

// BEGIN functionality for refreshing selected character information on view page

    var viewCharacterRefresh = document.getElementById("viewcharacterrefresh");

    viewCharacterRefresh.addEventListener("click", refreshCurrentCharacter);

    function refreshCurrentCharacter(event) {

        var existingCharacterDropDown = document.getElementById("viewexistingcharacters");

        var characterNameView = document.getElementById("characterNameView");

        existingCharacterDropDown.value = characterNameView.innerHTML;

        getSelectedCharacterInfo(event);
    }
    

// END functionality for refreshing selected character information on view page

// BEGIN functionality for resetting all fields on the character view page to default with the 'reset' button

var resetButton = document.getElementById("viewcharacterreset");

resetButton.addEventListener("click", resetCharacterViewPage)

function resetCharacterViewPage() {

    resetViewCharacterCheckBoxes();

    var detailAndTextAreaViewFields = document.getElementsByClassName("viewfieldreset");

    var detailAndTextAreaViewLabels = document.getElementsByClassName("viewcharacterlabel");

    var viewCharacterDisplay = document.getElementsByClassName("viewcharacterdisplay")

    for (var i = 0; i < detailAndTextAreaViewFields.length; i++)
    {
        var defaultInnerHTML = detailAndTextAreaViewLabels[i].innerHTML;

        detailAndTextAreaViewFields[i].innerHTML = defaultInnerHTML;
    }

    for (var row of viewCharacterDisplay)
    {
        row.style.display = "none";
    }
}

// END functionality for resetting all fields on the character view page

// BEGIN functionality for populating updatable attributes dropdown on update page

var characterAttributesDropdown = document.getElementById('attributetoupdatedropdown');

function populateAttributeToUpdateDropDown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', 'https://localhost:5003/api/getUpdatableCharacterAttributes');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var emptyCharacterDetailsObject = JSON.parse(this.response);

        for (var property in emptyCharacterDetailsObject){

            if (property !== "characterInventory" && property !== "characterSpells" && property !== "characterName") {

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
                    `<p class="viewcharactertextarea removeupdateformrow buttonhover" id="currentTextAreaValue">${currentValue}</p>` +
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
                    `<p class="updatecharacterinput characterdetailvaluedisplay removeupdateformrow buttonhover" id="charactertoupdate">${characterNameString}</p>` +
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

    if (this.id === "updateinventorybutton") {
        itemDetailsView.style.display = "none";
    }
    else
    {
        itemDetailsView.style.display = "block";
    }

    var inventoryToggleButtons = document.getElementsByClassName("inventorytoggle");

    var allInventoryForms = document.getElementsByClassName("inventoryform");

    var inventoryFormClass = this.classList.item(1);

    for(var i = 0; i < inventoryToggleButtons.length; i++) {
        inventoryToggleButtons[i].style.backgroundColor = "#314977";
        inventoryToggleButtons[i].style.boxShadow = "2px 3px 3px black"
        inventoryToggleButtons[i].style.border = "none";
    }
    
    for (var i = 0; i < allInventoryForms.length; i++) {
        allInventoryForms[i].style.display = "none";
    }

    document.getElementsByClassName(inventoryFormClass)[1].style.display = "block";

    this.style.backgroundColor = "#1b2841";
    this.style.boxShadow = "none";
    this.style.border = "1px solid #f0e6d6";
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

var itemDetailsView = document.getElementById("itemdetailsview");

var viewInventoryForm = document.getElementById("viewinventoryform");

viewInventoryForm.addEventListener("submit", getSelectedItemDetails);

function getSelectedItemDetails() {

    var xhr = new XMLHttpRequest();

    var viewInventoryFormJSON = interceptFormSubmit(event, viewInventoryForm);

    var viewInventoryFormData = JSON.parse(viewInventoryFormJSON);

    xhr.open('GET', `https://localhost:5003/api/getSelectedItemDetails?characterName=${viewInventoryFormData.CharacterName}&itemName=${viewInventoryFormData.ItemName}`);

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        itemDetailsView.style.display = "block";

        var itemDetails = JSON.parse(this.response);

        itemDetailsView.innerHTML = (
                    '<div class="inventoryformrow">' +
                        '<div class="inventoryviewcolumn">' +
                            '<label for="inventoryNameView">Character Name</label>' +
                            `<p class="itemdetailvaluedisplay" id="inventoryNameView">${viewInventoryFormData.CharacterName}</p>` +
                        '</div>' +
                        '<div class="inventoryviewcolumn">' +
                            '<label for="itemNameView">Item Name</label>' +
                            `<p class="itemdetailvaluedisplay" id="itemNameView">${itemDetails.itemName}</p>` +
                        '</div>' +
                        '<div class="inventoryviewcolumn">' +
                            '<label for="itemValueView">Value (GP)</label>' +
                            `<p class="itemdetailvaluedisplay" id="itemValueView">${itemDetails.itemValue}</p>` +
                        '</div>' +
                        '<div class="inventoryviewcolumn">' +
                            '<label for="itemQuantityView">Quantity</label>' +
                            `<p class="itemdetailvaluedisplay" id="itemQuantityView">${itemDetails.itemQuantity}</p>` +
                        '</div>' +
                    '</div>' +
                    '<div class="inventoryformrow">' +
                        '<div class="inventoryviewcolumn">' +
                            '<label for="itemDescriptionView">Description</label>' +
                            `<p class="viewitemdetailtextarea" id="itemDescriptionView">${itemDetails.itemDescription}</p>` +
                        '</div>' +
                        '<div class="inventoryviewcolumn">' +
                             '<p class="itemdetailvaluedisplay buttonhover" id="incrementquantitybutton">Increment (+1)</p>' +
                             '<p class="itemdetailvaluedisplay buttonhover" id="decrementquantitybutton">Decrement (-1)</p>' +
                             '<p class="itemdetailvaluedisplay buttonhover" id="itemviewresetbutton">Reset</p>' +
                        '</div>' +
                    '</div>'
        );

        var incrementButton = document.getElementById("incrementquantitybutton");

        var decrementButton = document.getElementById("decrementquantitybutton");

        var itemViewResetButton = document.getElementById("itemviewresetbutton");

        incrementButton.addEventListener("click", updateItemQuantity);

        decrementButton.addEventListener("click", updateItemQuantity);

        itemViewResetButton.addEventListener("click", resetItemView);
        
    };

    xhr.send();
}

// END: functionality for viewing selected item details

// BEGIN: functionality for updating item quantity (function references in above section for viewing item details)

function updateItemQuantity() {

    var xhr = new XMLHttpRequest();

    var itemQuantity = document.getElementById("itemQuantityView")

    var characterName = document.getElementById("inventoryNameView").innerHTML;

    var itemName = document.getElementById("itemNameView").innerHTML;

    var changeInQuantity;

    if (this.id === "incrementquantitybutton") {
        
        changeInQuantity = 1;
    }
    else if (this.id === "decrementquantitybutton" && itemQuantity.innerHTML !== "0") {

        changeInQuantity = (-1);
    }
    else {
        changeInQuantity = 0;
    }

    xhr.open('GET', `https://localhost:5003/api/incrementInventory?characterName=${characterName}&itemName=${itemName}&changeInQuantity=${changeInQuantity}`)

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        console.log(this.response);

        if (this.response === -1) {

            alert("Quantity update failed, please try again");
        }
        else {

            itemQuantity.innerHTML = this.response; 
        }
    }

    xhr.send();

}

// END: functionality for updating item quantity

// BEGIN: functionality for resetting item view
    
    function resetItemView() {

        itemDetailsView.style.display = "none";
    }

// END: functionality for resetting item view

// BEGIN: functionality for toggling spells page form display

var updateSpellsButton = document.getElementById("updatespellsbutton");
var viewSpellsButton = document.getElementById("viewspellsbutton");

updateSpellsButton.addEventListener("click", toggleSpellsDisplay);
viewSpellsButton.addEventListener("click", toggleSpellsDisplay);

function toggleSpellsDisplay() {

    if (this.id === "updatespellsbutton") {
        spellDetailsView.style.display = "none";
    }
    else
    {
        spellDetailsView.style.display = "block";
    }

    var spellsToggleButtons = document.getElementsByClassName("spellstoggle");

    var allSpellsForms = document.getElementsByClassName("spellsform");

    var spellsFormClass = this.classList.item(1);

    for(var i = 0; i < spellsToggleButtons.length; i++) {
        spellsToggleButtons[i].style.backgroundColor = "#314977";
        spellsToggleButtons[i].style.boxShadow = "2px 3px 3px black"
        spellsToggleButtons[i].style.border = "none";
    }
    
    for (var i = 0; i < allSpellsForms.length; i++) {
        allSpellsForms[i].style.display = "none";
    }

    document.getElementsByClassName(spellsFormClass)[1].style.display = "block";

    this.style.backgroundColor = "#1b2841";
    this.style.boxShadow = "none";
    this.style.border = "1px solid #f0e6d6";
};

// END: functionality for toggling spells page form display

// BEGIN: functionality for adding a spell to a character's spell list

var updateSpellsForm = document.getElementById("updatespellsform");

updateSpellsForm.addEventListener("submit", updateCharacterSpells);

function updateCharacterSpells() {

    var xhr = new XMLHttpRequest();

    var request = interceptFormSubmit(event, updateSpellsForm);

    console.log(request);

    xhr.open('POST', 'https://localhost:5003/api/updatespells');

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        alert(this.response); 
    }

    xhr.send(request);

}

// END: functionality for adding a spell to a character's spell list

// BEGIN: functionality for populating character spell drop down based on charactername drop down changes

var spellsViewNameDropdown = document.getElementById("characterspellstoview");

var spellsDropdown = document.getElementById("currentcharacterspells");

spellsViewNameDropdown.addEventListener("change", populateSpellsDropdown);

function populateSpellsDropdown() {

    var xhr = new XMLHttpRequest();

    xhr.open('GET', `https://localhost:5003/api/populatespellsdropdown?characterName=${spellsViewNameDropdown.value}`);

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {
        var characterSpellsArray = JSON.parse(this.response);

        while(spellsDropdown.children.length > 1) {

            spellsDropdown.removeChild(spellsDropdown.children[1]);
        }

        for (var spell of characterSpellsArray){

                var newSelectInput = document.createElement("option");

                newSelectInput.value = spell;

                newSelectInput.innerHTML = spell;

                spellsDropdown.appendChild(newSelectInput);
        }
    }

    xhr.send()
}

// END: functionality for populating character spells drop down

// BEGIN: functionality for viewing selected spell details

var spellDetailsView = document.getElementById("spelldetailsview");

var viewSpellsForm = document.getElementById("viewspellsform");

viewSpellsForm.addEventListener("submit", getSelectedSpellDetails);

function getSelectedSpellDetails() {

    var xhr = new XMLHttpRequest();

    var viewSpellsFormJSON = interceptFormSubmit(event, viewSpellsForm);

    var viewSpellsFormData = JSON.parse(viewSpellsFormJSON);

    xhr.open('GET', `https://localhost:5003/api/getSelectedSpellDetails?spellName=${viewSpellsFormData.SpellName}`);

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var spellDetails = JSON.parse(this.response);

        spellDetailsView.style.display = "block";

        spellDetailsView.innerHTML = (
            '<div class="spellsformrow">' +
                '<div class="spellsviewcolumn">' +
                    '<label for="spellListNameView">Character Name</label>' +
                    `<p class="spelldetailvaluedisplay" id="inventoryNameView">${viewSpellsFormData.CharacterName}</p>` +
                '</div>' +
                '<div class="spellsviewcolumn">' +
                    '<label for="spellNameView">Spell Name</label>' +
                    `<p class="spelldetailvaluedisplay" id="spellNameView">${spellDetails.spellName}</p>` +
                '</div>' +
                '<div class="spellsviewcolumn">' +
                    '<label for="spellLevelView">Spell Level</label>' +
                    `<p class="spelldetailvaluedisplay" id="spellLevelView">${spellDetails.spellLevel}</p>` +
                '</div>' +
            '</div>' +
            '<div class="spellsformrow">' +
                '<div class="spellsviewcolumn">' +
                    '<label for="schoolOfMagicView">School Of Magic</label>' +
                    `<p class="spelldetailvaluedisplay" id="schoolOfMagicView">${spellDetails.schoolOfMagic}</p>` +
                '</div>' +
                '<div class="spellsviewcolumn">' +
                    '<label for="spellCastingTimeView">Casting Time</label>' +
                    `<p class="spelldetailvaluedisplay" id="spellCastingTimeView">${spellDetails.spellCastingTime}</p>` +
                '</div>' +
                '<div class="spellsviewcolumn">' +
                    '<label for="ritualView">Ritual</label>' +
                    `<p class="spelldetailvaluedisplay" id="ritualView">${spellDetails.ritual}</p>` +
                '</div>' +
            '</div>' +
            '<div class="spellsformrow">' +
                '<div class="spellsviewcolumn">' +
                    '<label for="spellRangeView">Range</label>' +
                    `<p class="spelldetailvaluedisplay" id="spellRangeView">${spellDetails.spellRange}</p>` +
                '</div>' +
                '<div class="spellsviewcolumn">' +
                    '<label for="spellComponentsView">Components</label>' +
                    `<p class="spelldetailvaluedisplay" id="spellComponentsView">${spellDetails.spellComponents}</p>` +
                '</div>' +
                '<div class="spellsviewcolumn">' +
                    '<label for="spellDurationView">Duration</label>' +
                    `<p class="spelldetailvaluedisplay" id="spellDurationView">${spellDetails.spellDuration}</p>` +
                '</div>' +
            '</div>' +
            '<div class="spellsformrow">' +
                '<div class="spellsviewcolumn">' +
                    '<label for="spellDescriptionView">Description</label>' +
                    `<p class="viewspelldetailtextarea" id="spellDescriptionView">${spellDetails.spellDescription}</p>` +
                '</div>' +
                '<div class="spellsviewcolumn">' +
                    '<p class="spelldetailvaluedisplay buttonhover" id="spellviewresetbutton">Reset</p>' +
                '</div>' +
            '</div>'
        );
    
        var spellViewResetButton = document.getElementById("spellviewresetbutton");

        spellViewResetButton.addEventListener("click", resetSpellView);
    }

    xhr.send();
}

// END functionality for viewing selected spell details

// BEGIN functionality for resetting spell details view subpage

function resetSpellView() {

    spellDetailsView.style.display = "none";
}

// END functionality for resetting spell details view subpage

// BEGIN functionality for toggling utility subpage display
var instructionsButton = document.getElementById("instructionsbutton");
var diceButton = document.getElementById("dicebutton");
var combatButton = document.getElementById("combatbutton");
var statusButton = document.getElementById("statusbutton");
var objectivesButton = document.getElementById("objectivesbutton");

var instructionsDisplay = document.getElementById("instructionsdisplay");
var diceDisplay = document.getElementById("dicedisplay");
var combatDisplay = document.getElementById("combatdisplay");
var statusDisplay = document.getElementById("statusdisplay");
var objectivesDisplay = document.getElementById("objectivesdisplay");

instructionsButton.addEventListener("click", toggleUtilityDisplay);
diceButton.addEventListener("click", toggleUtilityDisplay);
combatButton.addEventListener("click", toggleUtilityDisplay);
statusButton.addEventListener("click", toggleUtilityDisplay);
objectivesButton.addEventListener("click", toggleUtilityDisplay);

function toggleUtilityDisplay() {

    var allUtilityButtons = document.getElementsByClassName("mainutilitytogglebutton");

    var allUtilityDisplays = document.getElementsByClassName("mainutilitysubpagedisplay");

    var displayClass = this.classList.item(1);

    for(var i = 0; i < allUtilityButtons.length; i++) {
                
            allUtilityButtons[i].style.backgroundColor = "#314977";
            allUtilityButtons[i].style.boxShadow = "2px 3px 3px black";
            allUtilityButtons[i].style.border = "none";
    }
    
    for (var i = 0; i < allUtilityDisplays.length; i++) {

        allUtilityDisplays[i].style.display = "none";
    }

    var toggled = document.getElementsByClassName(displayClass)[1];

    toggled.style.display = "block";

    this.style.backgroundColor = "#1b2841";
    this.style.boxShadow = "none";
    this.style.border = "1px solid #f0e6d6";
}
// END functionality for toggling utility subpage display

// BEGIN functionality for generating dice roll results

var diceRollForm = document.getElementById("dicerollform")

diceRollForm.addEventListener("submit", rollTheDice);

function rollTheDice() {

    var xhr = new XMLHttpRequest();

    var diceRollFormJSON = interceptFormSubmit(event, diceRollForm);

    var diceRollFormData = JSON.parse(diceRollFormJSON);

    xhr.open('GET', `https://localhost:5003/api/rollthedice?totalDice=${diceRollFormData.totalDice}&numberOfSides=${diceRollFormData.numberOfSides}&modifier=${diceRollFormData.modifier}`);

    xhr.setRequestHeader("Content-Type", "application/JSON");

    xhr.onload = function() {

        var rollDisplay = document.getElementById("dicerolldisplay");

        var resultDisplay = document.getElementById("diceresultdisplay");

        rollDisplay.innerHTML = `Roll: ${diceRollFormData.totalDice}d${diceRollFormData.numberOfSides} + ${diceRollFormData.modifier}`;
        resultDisplay.innerHTML =  `Result: ${this.response}`;

        document.getElementById("diceresultdisplayrow").style.display = "flex";
    }

    xhr.send();
}

// END functionality for generating dice roll results

// BEGIN functionality for resetting dice roll result display

var diceResultDisplay = document.getElementById("diceresultdisplay");

diceResultDisplay.addEventListener("click", resetDiceResultDisplay);

function resetDiceResultDisplay() {
    
    document.getElementById("diceresultdisplayrow").style.display = "none";
}
// END functionality for resetting dice roll result display

// BEGIN functionality for adding a character or enemy row to the initiative display table

    var characterInitiativeForm = document.getElementById("characterinitiativeform");

    var enemyInitiativeForm = document.getElementById("enemyinitiativeform");

    characterInitiativeForm.addEventListener("submit", addRowToInitiativeDisplayTable);

    enemyInitiativeForm.addEventListener("submit", addRowToInitiativeDisplayTable);

    function addRowToInitiativeDisplayTable() {

        var initiativeFormJSON = interceptFormSubmit(event, this);

        var initiativeFormData = JSON.parse(initiativeFormJSON);

        var name = initiativeFormData.name;

        var initiativeRoll = initiativeFormData.initiativeRoll;

        var combatHp = initiativeFormData.combatHp;

        var initiativeDisplayTable = document.getElementById("initiativedisplaytable");

        var newInitiativeRow = document.createElement("tr");

        document.getElementById("initiativedisplaytablewrapper").style.display = "block";

        newInitiativeRow.innerHTML = (
            `<td class="initiativeorderdisplay">Order</td>` +
            `<td class="initiativenamedisplay">${name}</td>` +
            `<td class="initiativerolldisplay">${initiativeRoll}</td>` +
            `<td class="initiativehpdisplay" contenteditable=true>${combatHp}`
        )

        var tableRows = initiativeDisplayTable.children;

        var arrayOfInitiatives = [];

        for (var i = 1; i < tableRows.length; i++)
        {
            arrayOfInitiatives.push(tableRows[i].children[2].innerHTML);
        }

        arrayOfInitiatives.push(initiativeRoll);

        arrayOfInitiatives.sort(function(a, b){return b - a});

        var newIndex = arrayOfInitiatives.indexOf(initiativeRoll);

        if (tableRows.length === 1 || tableRows.length === newIndex) {

            initiativeDisplayTable.appendChild(newInitiativeRow);
        }
        else {

            initiativeDisplayTable.insertBefore(newInitiativeRow, tableRows[newIndex + 1]);
        }

        for (var i = 1; i < tableRows.length; i++)
        {
            tableRows[i].children[0].innerHTML = i;
        }
        

        // tableRows[tableRows.length - 1].children[0].innerHTML = Array.prototype.indexOf.call(tableRows, tableRows[tableRows.length - 1]);

        //Array.prototype.indexOf.call(parent.children, child);
    }

// END functionality for adding a character or enemy row to the initiative display table