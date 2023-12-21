/**
 * Created by Rashedul on 11/3/2016.
 */
application.controller('SearchController',
    function ($scope,SearchServiceProvider,$http,toastr,ProductDetailsService,$state,RemoteService) {
    $scope.searchIteamModel=SearchServiceProvider.getSearchModel();
    console.log($scope.searchIteamModel);
    $scope.showSpinner = true;
    console.log($scope.searchIteamModel);

    RemoteService.getSearchResults($scope.searchIteamModel).then(function success(response) {
        console.log(response.data);
        $scope.products = response.data;
        $scope.imageData={};
        angular.forEach($scope.products,function(value){
            $http.post('http://localhost:9751/product/get-product-image-one', '"' + value.ProductId + '"').then(function success(response) {
                $scope.imageData[value.ProductId]=response.data;
            }, function error(response) {
                toastr.error(response.message,"Sorry");
            })
        });
        $scope.showSpinner = false;
    }, function error(error) {
        console.log(error.message);
        toastr.error('Internal server error. Please try again later', 'Sorry');
    });

    $scope.gotoProductDetails = function (object) {
        ProductDetailsService.setProduct(object);
        $state.go("home.product-details");
    };

});