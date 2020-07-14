export const ValidateClinicHour = {
    validateDay,
    compareTime,
    isEmpty
};



function validateDay(day , ...currentDays) {
    const error = { hasError: false, message: "" };
    let activeDay = currentDays.find(x => parseInt(x.day) === parseInt(day));

    if (activeDay !== undefined) {
        error.hasError = true;
        error.message = "Conflict with existing clinic hour days, please select another day";
    } 
    return error; 
}

function validateTime(time) {
    const error = { hasError: false, message: "" };
    let pattern = new RegExp(/^$|^(([01][0-9])|(2[0-3])):[0-5][0-9]$/);
    if (pattern.test(time) === false) {
        error.hasError = true;
        error.message = "Time format wrong ,it should be 00:00 or 11:00 format";
    }
    return error;
}

function compareTime(startTime, endTime) {
    const error = { hasError: false, message: "" };
    const startTimeError = validateTime(startTime);
    const endTimeError = validateTime(endTime);
    if (startTimeError.hasError === false && endTimeError.hasError === false) {
        const startTimeDate = new Date('1/1/1999 ' + startTime);
        const endTimeDate = new Date('1/1/1999 ' + endTime);
        if (startTimeDate >= endTimeDate) {
            error.hasError = true;
            error.message = "Start Time must be less than End Time";
        }
    } else {
        error.hasError = true;
        error.message = startTimeError.message + " " + endTimeError.message;
    }

    return error;
}

function isEmpty(time) {
    const error = { hasError: false, message: "" };
    alert(time);
    if (time === undefined || time === null || time==="") {
        error.hasError = true;
        error.message = "Time value can not be empty";
    }

    return error;
}