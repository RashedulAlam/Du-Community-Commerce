/**
 * Created by rashe on 10/20/2016.
 */
application.controller('PostProductController', function ($scope, $http, Upload, uuid2, toastr, AddressProviderService) {

    $scope.product = {};
    $scope.disableForm=true;
    $scope.initializeMap = function () {
        var map = L.map('map').setView([
            23.727673500689797,
            90.40197730064392], 18);
        L.tileLayer('http://{s}.tile.osm.org/{z}/{x}/{y}.png', {
            attribution: '&copy; <a href="http://osm.org/copyright">OpenStreetMap</a> contributors'
        }).addTo(map);
        var newMarker;
        map.on('click', function (e) {
            if (newMarker) {
                map.removeLayer(newMarker);
            }
            newMarker = new L.marker(e.latlng).addTo(map);
            $scope.product.ProductLatitude=e.latlng.lat;
            $scope.product.ProductLongitude=e.latlng.lng;
            $scope.disableForm=false;
            console.log($scope.product);
        });
    };

    $scope.loadingBar=false;
    $scope.postProduct = function (file) {
        $scope.disableForm=true;
        $scope.loadingBar=true;
        $scope.product.ProductId = uuid2.newguid();

        file.upload = Upload.upload({
            url: 'http://localhost:9751/product/post-product-image',
            data: {ProductId: $scope.product.ProductId, ProductImages: file}
        });
        console.log($scope.product);

        $http.post('http://localhost:9751/product/post-product', $scope.product).then(function success(response) {
            console.log(response.data);
            file.upload.then(function success(response) {
                toastr.success('Product Advertisement has been successfully posted.', 'Yahoo!!!!');
                $scope.disableForm=false;
                $scope.loadingBar=false;
                $scope.product={};
                $scope.productImages=null;
            }, function error(response) {
                $scope.product={};
                $scope.productImages=null;
                $scope.loadingBar=false;
                toastr.error('Something went wrong', 'Sorry!!!!');
            });
        }, function error(response) {
            $scope.product={};
            $scope.productImages=null;
            $scope.loadingBar=false;
            toastr.error('Something went wrong', 'Sorry!!!!');
        });

    };

    $scope.category = null;

    var groupByData = null;

    $http.get('mock-data/category.json').then(function (response) {
        $scope.categories = _.keyBy(response.data, 'category');
        groupByData = _.groupBy(response.data, 'category');

    });

    $scope.selectedItemChanged = function () {
        $scope.subcategories = _.map(groupByData[$scope.category.category], "subcategory");
        $scope.product.ProductCategory = $scope.category.category;
    };


});