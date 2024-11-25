console.log("Hello from google.js!");

$(document).ready(function(){
    getLocation();
});

//geolocate device
function getLocation(){
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showLocation, showError);
    }else{
        alert("Geolocation is not supported by this browser.");
    }
}

//show location of device if possible
function showLocation(position) {
    const lat = position.coords.latitude;
    const lon = position.coords.longitude;

    console.log("Latitude: " + lat);
    console.log("Longitude: " + lon);

    getAddress(lat, lon);
    initMapComponents(lat, lon);
}

//warns in the event of a failed geolocalisation
function showError(error){
    switch (error.code){
        case error.PERMISSION_DENIED:
            alert("User permission denied.");
        break;
        case error.POSITION_UNAVAILABLE:
            alert("Current location is unavailable.");
        break;
        case error.TIMEOUT:
            alert("Request timeout.");
        break;
        default:
            alert("Error found: " + error.message);
        break;
    }
}

function getAddress(lat, lon){
    const latLng = {lat: lat, lng: lon};
    const geocoder = new google.maps.Geocoder();

    geocoder.geocode({location: latLng}, function (results, status){
        if (status == "OK"){
            console.log(results);
            if (results[0]){
                const address = results[0].formatted_address;

                document.getElementById("address").innerText = "Direccion: " + address;
            }else{
                alert("Address not found.");
            }
        }else{
            alert("Geocoding failed: "+ status);
        }
    });
}

function initMapComponents (lat, lon){
    const location = {lat: lat, lng: lon};

    const map = new google.maps.Map(document.getElementById("map"),{
        zoom: 15,
        center: location
    });
    
    new google.maps.Marker({
        position: location,
        map: map,
        title: "Current location"
    });
    
    const panorama = new google.maps.StreetViewPanorama(
        document.getElementById("street"),{
            position: location,
            pov: {heading: 90, pitch: 3}
        }
    );

    map.setStreetView(panorama);
}