var tokenUrl = '/api/auth/token'; // Replace with your token endpoint

//$('#input_apiKey').hide();
//$('#input_apiKey').after('<button id="btn_authorize" class="btn btn-outline-secondary" onclick="authorize()">Authorize</button>');

window.authorize = function () {
    alert('Authorizing...');
    $.ajax({
        url: tokenUrl,
        method: 'POST',
        contentType: 'application/json',
        data: JSON.stringify({ /* your request payload if needed */ }),
        success: function (response) {
            var token = response.token;
            if (token) {
                // Set the token in Swagger UI
                ui.preauthorizeApiKey('Bearer ' + token);
                $('#input_apiKey')[0].value = 'Bearer ' + token;
                $('#input_apiKey').show();
            }
        }
    });
};