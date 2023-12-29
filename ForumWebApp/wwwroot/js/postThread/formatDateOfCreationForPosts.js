export function formatDateOfCreation(milliseconds) {
    millisecondsInt = parseInt(milliseconds);

    let date = new Date(millisecondsInt);

    let years = date.getFullYear() - 1970;

    if (years > 0) {
        let result = years.toString() + " year";
        if (years > 1) result = result + "s";
        return result;
    }

    let totalSeconds = parseInt(millisecondsInt / 1000, 10);
    let minutes = parseInt(totalSeconds / 60, 10);
    let hours = parseInt(minutes / 60, 10);
    let days = parseInt(hours / 24, 10);
    let weeks = parseInt(days / 7, 10);
    let months = parseInt(days / 30, 10);

    if (months > 0) {
        let result = months.toString() + " month";
        if (months > 1) result = result + "s";
        return result;
    }
    if (weeks > 0) {
        let result = weeks.toString() + " week";
        if (weeks > 1) result = result + "s";
        return result;
    }
    if (days > 0) {
        let result = days.toString() + " day";
        if (days > 1) result = result + "s";
        return result;
    }
    if (hours > 0) {
        let result = hours.toString() + " hour";
        if (hours > 1) result = result + "s";
        return result;
    }
    if (minutes > 0) {
        let result = minutes.toString() + " minute";
        if (minutes > 1) result = result + "s";
        return result;
    }

    let result = totalSeconds.toString() + " second";
    if (totalSeconds > 1) result = result + "s";
    return result;
}
var dateTimeElements = document.getElementsByClassName("dateTimeLabel");
for (let i = 0; i < dateTimeElements.length; ++i) {
    dateTimeElements[i].textContent = formatDateOfCreation(dateTimeElements[i].getAttribute("data-date-diff"));
}