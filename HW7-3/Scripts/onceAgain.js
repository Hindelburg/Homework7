
var httpRequest;
//document.getElementById("getter").addEventListener('click', requesting);

function requesting() {

    var rating;
    if (document.getElementById('g').checked == true) {
        rating = "G";
    }
    else if (document.getElementById('pg').checked == true) {
        rating = "PG";
    }
    else if (document.getElementById('pg13').checked == true) {
        rating = "PG-13";
    }
    else if (document.getElementById('r').checked == true) {
        rating = "R";
    }
    else {
        rating = "G";
    }

    $.ajax({
        url: "Home/Find",
        type: "Get",
        data: {
            search: (document.getElementById('searchFor').value),
            rating: rating,
            userAgent: navigator.userAgent
        },
        success: function (data) { 
            $('img').remove();

            data.data.forEach(function (item) {
                if (document.getElementById('animated').checked == true){
                    $('#test').append(`<img style="background-color: black; padding: 5px 5px 5px 5px; margin: 10px 10px 10px 10px;" src="${item.images.fixed_height.url}" id="tmp">`);

                }
                else {
                    $('#test').append(`<img style="background-color: black; padding: 5px 5px 5px 5px; margin: 10px 10px 10px 10px;" src="${item.images.fixed_height_still.url}" id="tmp">`);
                }
            })
        }
    });
}


