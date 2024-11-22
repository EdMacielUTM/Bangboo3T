//dragAndDrop

//JS events are actions or happenings that take place in a web document and can be detected and handled by the JS code. These events can be triggered by the user or genereated automatically by the web browser

//In more specific terms, an event is a happenstance that takes place on the system we're preparing. The sistem produces a signal of a certain kind when an even takes place and provides a mechanism for performing an action automatically in response to said event

//variables
var counter = 0
var draggableElement = ""
var counterA = 0

//HTML event functions
function start (e){
    //a function that triggers at "ondragstart" event, takes the very event as action
    console.log("start");
    e.dataTransfer.effectAllowed = "move";          //defines the element's move effect
    e.dataTransfer.setData("Data", e.target.id);    //stores the element's data on cache
    $("#" + e.target.id).css("opacity", "0.4");     //looks the element up and changes its CSS properties via JQuery
    console.log(e.target.id);
    draggableElement = e.target.id                  //stores the current element on a global variable
}

function end(e){
    //a function that triggers at "ondragend" event, takes the very event as action
    console.log("end");
    e.target.style.opacity = "";                    //resets the opacity to its default value
    e.dataTransfer.clearData("Data");               //clears cache data
    draggableElement = "";                          //clears global variable
    console.log(e.target.id);
}

//movement functions
function enter(e){
    //a function that triggers at "ondragenter" event, takes the very event as action
    console.log("enter");
    e.target.style.border = "12px dotted #555555";  //adds a dark dotted border to a square upon a littler square entering it
}

function leave(e){
    //a function that triggers at "ondragleave" event, takes the very event as action
    console.log("leave");
    $("#" + e.target.id).css("border", "");         //removes the dark dotted border to a square upon a littler square exiting it
}

function over(e){
    //a function that triggers at "ondragover" event, takes the very event as action
    console.log("over");
    var id = e.target.id;                           //stores the element's value
    if((id == "cuadro1") || (id == "cuadro3") || (id == "papelera")){
        return false;                               //false means "allowing" elements to be dropped upon it
    }else{
        return true;                                //true means "disallowing" elements to be dropped upon it
    }
}

//gameplay functions
function drop(e){
    //a function that triggers at "ondrop" event, takes the very event as action
    console.log("drop");
    var draggedElement = e.dataTransfer.getData("Data");              //stores ID through the cache-store data
    e.target.appendChild(document.getElementById(draggedElement));    //appends child to an element or node to the node in question
    e.target.style.border = "";                                         //erases border upon dropping something
}

function remove(e){
    //a function that triggers at "ondrop" event, takes the very event as action
    console.log("delete");
    var draggedElement = document.getElementById(e.dataTransfer.getData("Data"));       //fetches ID from cache-store data
    draggedElement.parentNode.removeChild(draggedElement);                              //removes child
    e.target.style.border = "";                                                         //erases border upon dropping something
    counterA--;
}

function clone(e){
    //a function that triggers at "ondrop" event, takes the very event as action
    console.log("clone");
    var draggedElement = document.getElementById(e.dataTransfer.getData("Data"));       //fetches ID from cache-store data
    draggedElement.style.opacity = "";                                                  //restores opacity
    if(counterA < 3){
        var clonedElement = draggedElement.cloneNode(true);                             //clones element in question
        clonedElement.id = "ClonedNode" + counter;
        counter++;
        counterA++;
        clonedElement.style.position = "static";
        e.target.appendChild(clonedElement);
    }
    e.target.style.border = "";
}




