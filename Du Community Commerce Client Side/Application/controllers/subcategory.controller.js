/**
 * Created by rashe on 10/25/2016.
 */
application.controller('SubcategoryController',
    function ($scope, $http, SubcategoryProvider, $state, toastr, ProductDetailsService, RemoteService) {
        $scope.message = "Subcategory Controller";
        $scope.showSpinner = true;
        var sub = SubcategoryProvider.getSubcategory();
        RemoteService.getProductsBySubcategory(sub).then(function success(response) {
            $scope.products = response.data;
            $scope.imageData = {};
            angular.forEach($scope.products, function (value) {
                RemoteService.getOneImageForProduct(value.ProductId).then(function success(response) {
                    $scope.imageData[value.ProductId] = response.data;
                }, function error(response) {
                    toastr.error(response.message, "Sorry");
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