



$(".loginButton").on('click', login)

function login(event){
    var usernameField = $('#username')
    var passwordField = $('#password')
    sendLoginRequest(usernameField.valueOf().val(), passwordField.valueOf().val())
}

function sendLoginRequest(username, password){
    data = {
            Username:username, 
            Password:password
    }
    $.ajax('/Login/login', {
        method: 'post',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data)
    });
}