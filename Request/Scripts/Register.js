document.getElementById("registerBtn").addEventListener("click", function (event) {
    const role = document.getElementById("Role").value;
    const email = document.getElementById("Email").value;


    if (role === "Select Role") {
        event.preventDefault();
        alert("Please select a valid role before proceeding.");
    }


    if (!email.includes("@")) {
        event.preventDefault();
        alert("Please enter a valid email address with '@'.");
    }
});

$(document).ready(function () {
    $('#ContactNumber').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });
});


document.getElementById("registerBtn").addEventListener("click", function (event) {
    const role = document.getElementById("Role").value;
    if (role === "Select Role") {
        event.preventDefault();
        alert("Please select a valid role before proceeding.");
    }
});


$(document).ready(function () {
    $('#ContactNumber').on('input', function () {
        this.value = this.value.replace(/[^0-9]/g, '');
    });