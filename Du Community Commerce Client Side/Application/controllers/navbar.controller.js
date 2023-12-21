/**
 * Created by Rashedul on 10/8/2016.
 */
application.controller('NavbarController',
    function ($scope, $http, SubcategoryProvider, $state, SearchServiceProvider, AuthenticationService) {

    $scope.searchText = null;
    $scope.searchSubcategory = null;

    $http.get('mock-data/category.json').then(function (response) {
        console.log(response.data);
        $scope.navBarCategories = response.data;
    });

    $http.get('mock-data/category.json').then(function (response) {
        $scope.categories = _.groupBy(response.data, 'category');
    });

    $scope.goTOSubcategory = function (subcategory) {
        SubcategoryProvider.setSubcategory(subcategory);
        $state.go("home.subcategory", {}, {reload: "home.subcategory"});
    };

    $scope.search = function () {
        if ($scope.searchSubcategory == null) {
            var searchModel = {
                SearchText: $scope.searchText,
                Subcategory: null
            };
        } else {
            var searchModel = {
                SearchText: $scope.searchText,
                Subcategory: $scope.searchSubcategory["subcategory"]
            };
        }
        SearchServiceProvider.setSearchModel(searchModel);
        $state.go('home.search-view', {}, {reload: 'home.search-view'});
    };

    $scope.logOut = function () {
        AuthenticationService.logOut();
        $state.go('login');
    };

});