$(document).ajaxError(function (evt, xhr, set, ex) {
    try {
        var json = $.parseJSON(xhr.responseText);
        
        if (typeof json !== "undefined") {
            
            if (json.erroMessage) {
                //alert(json.errorMessage);
                $(".error-message").html("Yikes we had an error: " + json.errorMessage);
                $(".error-message").show();
            } else if (json.errors) {
                var message = "Errors:\n";
                $.each(e.errors, function (key, value) {
                    if ('errors' in value) {
                        $.each(value.errors, function () {
                            message += this + "\n";
                        });
                    }
                });
                alert(message);
            } else {
                alert(json);
            }
        }
    } catch (e) {
        console.log(e);
        alert('something out of the ordinary happened. please contact support.');
        $(".error-message").html(xhr.responseText);
        $(".error-message").show();
    }
    

    console.log(evt);
    console.log(xhr);
    console.log(set);
    console.log(ex);
});