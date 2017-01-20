
src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCzXEVbfnNpvBgKY9BONSKVOt6NjXyGdqs"
var map = new google.maps.Map(document.getElementById('map'), {
    scrollwheel: false,
    zoom: 15
});
navigator.geolocation.getCurrentPosition(function (position) {
    var pos = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
    };
    console.log(pos.lat.toString());
    map.setCenter(pos);
});

