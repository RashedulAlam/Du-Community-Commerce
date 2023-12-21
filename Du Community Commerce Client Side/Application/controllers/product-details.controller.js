/**
 * Created by rashe on 10/26/2016.
 */
application.controller('ProductDetailsController',
    function ($scope, ProductDetailsService, $http, toastr, $state,RemoteService) {

    $scope.product = ProductDetailsService.getProduct();
    if($scope.product==null){
        $state.go('home.map-view');
    }else{
        var map;
        $scope.initializeProductDetailsMap = function () {
            map = L.map('productMap').setView([$scope.product.ProductLatitude, $scope.product.ProductLongitude], 15);
            L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
                attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
            }).addTo(map);
            var newMarker = new L.marker([$scope.product.ProductLatitude, $scope.product.ProductLongitude]);
            newMarker.addTo(map);
        };
        $scope.showZoomImage = false;
        $scope.showLocation = true;
        $scope.showComments = true;
        $scope.showImageLoadingBar = true;
        RemoteService.getAllImagesOfProduct($scope.product.ProductId)
            .then(function success(response) {
                $scope.selectedItem = response.data[0];
                $scope.productImages = _.without(response.data, $scope.selectedItem);
                $scope.showImageLoadingBar = false;
            }, function error(error) {
                toastr.error(error.message, "Sorry");
            });
        RemoteService.getAllCommentsOfProduct($scope.product.ProductId)
            .then(function (response) {
                console.log(response.data);
            }, function (error) {
                console.log(error.message);
            });
    }


    $('#content').hover(function () {
        $("#content").addClass('transition');

    }, function () {
        $("#content").removeClass('transition');
    });

    $scope.swap = function (path) {
        $scope.productImages.push($scope.selectedItem);
        $scope.selectedItem = path;
        $scope.productImages = _.without($scope.productImages, path);
    };

    $scope.postComment = function () {
        $scope.comment = {
            CommmentDescription: $scope.CommmentDescription,
            ProductId: $scope.product.ProductId,
            UserId: "12312312-123123-123123123"
        };
        console.log($scope.comment);
        $http.post('http://localhost:9751/Product/post-comment', $scope.comment).then(function (response) {
            console.log(response.data);
        }, function (response) {
            toastr.error(response.message, "Sorry");
        });
    };

});