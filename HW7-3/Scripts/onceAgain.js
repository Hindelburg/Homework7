
var httpRequest;
//document.getElementById("getter").addEventListener('click', requesting);

function requesting() {
    httpRequest = new XMLHttpRequest();

    if (!httpRequest) {
        console.log("Oops, something went wrong and I couldn't make the http instance. Sorry.");
        return false;
    }
    httpRequest.onreadystatechange = woop;
    httpRequest.open('GET', 'https://api.giphy.com/v1/gifs/search?api_key=
       // I cut out the key before I committed. &q=cats&limit=25&offset=0&rating=G&lang=en');
    httpRequest.send();
}

function woop() {
    if (httpRequest.readyState == XMLHttpRequest.DONE) {
        if (httpRequest.status === 200) {
            console.log("I did it! Here it is!");
            console.log(httpRequest.responseText);
        }
        else {
            console.long("I failed again, sorry. I just can't do anything write anymore.");
        }
    }
}

