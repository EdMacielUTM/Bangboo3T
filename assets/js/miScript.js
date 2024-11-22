$(document).ready(function(){

    $("#email").on("blur", validateEmail);

    //$("miBoton").on("click", submitFormData);

    //initMap();

});

function validateEmail(){
    var email = document.getElementById("email");
    
    const emailRegEx =  /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    
    if (emailRegEx.test(email)) {
        Swal.fire({
            title: "Oops...",
            text: "Please enter a valid email address.",
            icon: "error"
          });
    }
}

function submitFormData(){
    validateEmail();
}