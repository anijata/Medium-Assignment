function getRequest(url) {

    return $.ajax({
        type: "GET",
        url: url,
        datatype: "json",
        traditional: "true",
        headers: { "Authorization": "Bearer " + getCookieValue('token') },
        error: errorHandler
    });
}

function postRequest(verb, data, url) {

    return $.ajax({
        type: verb,
        url: url,
        data: data,
        datatype: "json",
        traditional: "true",
        headers: { "Authorization": "Bearer " + getCookieValue('token') },
        error: errorHandler
    });
}

function getCookieValue(key) {
    let kvps = document.cookie.split(';');

    for (let i = 0; i < kvps.length; i++) {
        let k = kvps[i].split('=')[0];
        let v = kvps[i].split('=')[1];

        if (k == key) {
            return v;
        }

    }


}

function errorHandler(jqXHR, status, err) {
    switch (jqXHR.status) {
        case 401:
            window.location.href = "https://localhost:44335/error/NotAuthorized";
            break;
        case 404:
            window.location.href = "https://localhost:44335/error/NotFound";
            break;
        case 500:
            window.location.href = "https://localhost:44335/error/InternalServerError";
            break;
        default:
            alert(jqXHR.responseJSON.Message);
            break;
    }

}

function populateCountriesHandler(data) {
    $("#Countries").empty();
    $("#Countries").append("<option value=0> Select Country </option>");

    $("#States").empty();
    $("#States").append("<option value=0> Select State </option>");

    $("#Cities").empty();
    $("#Cities").append("<option value=0> Select City </option>");


    for (var i = 0; i < data.length; i++) {
        $("#Countries").append("<option value=" + data[i].Id + ">" + data[i].Name + "</option>");

    }

}

function populateCountries() {
    let url = "https://localhost:44357/api/resources/countries/";

    return getRequest(url).done(populateCountriesHandler);
}

function populateCitiesHandler(data) {
    $("#Cities").empty();
    $("#Cities").append("<option value=0> Select City </option>");

    for (var i = 0; i < data.length; i++) {
        $("#Cities").append("<option value=" + data[i].Id + ">" + data[i].Name + "</option>");

    }
}

function populateStates(countryId) {
    let url = "https://localhost:44357/api/resources/states/" + countryId;
    return getRequest(url).done(populateStatesHandler);
}

function populateStatesHandler(data) {

    $("#States").empty();
    $("#States").append("<option value=0> Select State </option>");

    $("#Cities").empty();
    $("#Cities").append("<option value=0> Select City </option>");


    for (var i = 0; i < data.length; i++) {
        $("#States").append("<option value=" + data[i].Id + ">" + data[i].Name + "</option>");

    }
}

function populateCities(stateId) {
    let url = "https://localhost:44357/api/resources/cities/" + stateId;
    return getRequest(url).done(populateCitiesHandler);
}



