export const ValidateClinic = {
    validatePhone,
    validatePostCode,
    validateEmail
    
};

function validatePhone(phone) {
    const phoneRegex = new RegExp(/^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/);
    const phoneFormat = { formatPhoneNumber: "", hasError: false, message: "" };
    if (phoneRegex.test(phone)) {
        phoneFormat.formatPhoneNumber = phone.replace(phoneRegex, "($1)-$2-$3");
    } else {
        phoneFormat.hasError = true;
        phoneFormat.message = "Invvalid phone number";
    }

    return phoneFormat;
}

function validatePostCode(postCode) {
    const postCodeRegex = new RegExp(/^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$/);
    const postCodeFormat = { formatPostCode: "", hasError: false, message: "" };
    if (postCodeRegex.test(postCode)) {
        postCodeFormat.formatPostCode = postCode.substring(0, 3) + " " + postCode.substring(3, 6);
    } else {
        postCodeFormat.hasError = true;
        postCodeFormat.message = "post code format not correct";
    }
    return postCodeFormat;
}

function validateEmail(email) {
    const emailRegex = new RegExp(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/);
    const emailError = { hasError: false, message: "" };
    if (emailRegex.test(email) === false) {
        emailError.hasError = true;
        emailError.message = "email format not correct";
    }

    return emailError;
}