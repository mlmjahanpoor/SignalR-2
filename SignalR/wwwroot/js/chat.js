﻿"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/ChatHub").build();

//Disable the send button until connection is established.
/*document.getElementById("sendButton").disabled = true;*/

connection.on("ReceiveMessage", function (user, message,g) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});
connection.on("ShowMessage", function (name) {
    alert("your name is :" + name);
});

//connection.start().then(function () {
//    document.getElementById("sendButton").disabled = false;
//}).catch(function (err) {
//    return console.error(err.toString());
//});


connection.start().then(function () {

    document.getElementById("sendButton").disabled = false;

}).catch(function (err) {

    return console.error(err.toString())
});


//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;

//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});



document.getElementById("sendButton").addEventListener("click", function (event) {

    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    connection.invoke("SendMessage", user, message,"g1").catch(function (err) {
        return console.error(err.toString());
    });

    document.getElementById("messageInput").value = "";
    event.preventDefault();


});

document.getElementById("showButton").addEventListener("click", function (event) {

    var name = document.getElementById("userInput").value;

    connection.invoke("ShowMessage", name).catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();


});