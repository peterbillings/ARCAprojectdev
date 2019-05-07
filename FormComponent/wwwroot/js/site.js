
var formShell = document.getElementById("formshell");

var addToForm = document.getElementById("addtoform");

var removeFormField = document.getElementsByClassName("removeformfield");

addToForm.addEventListener("click", addComponent);

//addComponent: adds specified form field to the form when clicked

function addComponent() { 
    console.log("the addComponent function was called");
    var formDiv = document.createElement("div");
    formDiv.classList.add("component");
    formDiv.innerHTML = ('<input type="text" name="charactername">' +
                         '<button type="button" class="removeformfield">Remove</button>');
    formShell.insertBefore(formDiv, formShell.children[0]);

    for (var i = 0; i < removeFormField.length; i++) {
        removeFormField[i].addEventListener('click', removeField);
    }
};

//removeField: removes the form field if you click the remove button

function removeField() { 
    console.log("the removeField function was called")
    this.parentNode.parentNode.removeChild(this.parentNode);
};