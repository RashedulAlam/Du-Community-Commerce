/**
 * Created by Rashedul on 10/29/2016.
 */

application.controller('MapController', function ($scope,UserInfoService) {

    $scope.initializeTotalMap = function () {
        var map = L.map('mapView').setView([23.727673500689797, 90.40197730064392], 18);
        L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);
    };
    var a=UserInfoService.getUser();
    console.log(a);

});