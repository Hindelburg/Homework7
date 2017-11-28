
var httpRequest;
//document.getElementById("getter").addEventListener('click', requesting);

function requesting() {

    $.ajax({
        url: "Home/Find",
        type: "Get",
        data: { search: "cats" },
        success: function (data) { //On Success, Return Images into a grid 
            data.data.forEach(function (item) {
                $('#test').append(`<img src="${item.images.fixed_height.url}">`);
            })
        }
    });
}


