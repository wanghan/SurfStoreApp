var request = new XMLHttpRequest();
request.open('POST', '/statistics/update', false);
request.send(null);

if (request.status == 200) {
    // return a message to the calling script
    postMessage(request.responseText);
}