$(document).ajaxError(function (evt, xhr, set, ex) {
    try {
        var json = $.parseJSON(xhr.responseText);
        //alert(json.errorMessage);
        $(".error-message").html("Yikes we had an error: " + json.errorMessage);
        $(".error-message").show();
        console.log(evt);
        console.log(xhr);
        console.log(set);
        console.log(ex);
    } catch (e) {
        alert('something out of the ordinary happened. please contact support.');
    }
});