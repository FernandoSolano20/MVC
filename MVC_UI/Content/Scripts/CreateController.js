let txt_name = document.querySelector("#txt_name");
let txt_last_name = document.querySelector("#txt_last_name");
let txt_email = document.querySelector("#txt_email");
let btn_action = document.querySelector("#btn_action");



const gatherData = () => {
    let name = txt_name.value;
    let last_name = txt_last_name.value;
    let email = txt_email.value;

    sendRequest(name, last_name, email);
};

const sendRequest = (pName, pLastName, pEmail) => {
    var person = { code: pName, name: pLastName, icon: pEmail };
    let request = $.ajax({
        url: 'https://localhost:44346/api/currency/',
        type: 'POST',
        dataType: 'json',
        beforeSend: function (request) {
            request.setRequestHeader("Authorization", "Negotiate");
        },
        contentType: 'application/json',
        success: function (data) {
            Console.log('done');
        },
        data: JSON.stringify(person)
    });

    request.done(function (msg) {

        Console.log('COMPLETED');
    });
};

btn_action.addEventListener("click", gatherData);
