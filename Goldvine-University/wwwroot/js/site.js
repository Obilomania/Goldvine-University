//SIGN IN FORM JS
const password = document.querySelector(".password");
const eye = document.querySelector(".reveal");

eye.addEventListener("click", () => {
    if (password.type === "password") {
        password.type = "text";
    } else {
        password.type = "password";
    }
});


//REGISTRATION FORM


previewBeforeUpload("file-1");

// REVEAL PASSWORD
const password2 = document.querySelector(".password2");
const eye2 = document.querySelector(".eye2");


eye2.addEventListener("click", () => {
    if (password2.type === "password") {
        password2.type = "text";
    } else {
        password2.type = "password";
    }
});
