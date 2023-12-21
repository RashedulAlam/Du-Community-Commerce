/**
 * Created by Rashedul on 10/7/2016.
 */
var application = angular.module('application',
    ['ui.router', 'ngAnimate', 'toastr', 'localytics.directives', 'ngFileUpload', 'angularUUID2', 'LocalStorageModule']);


application.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});


application.run(function (AuthenticationService, UserInfoService, $http, $state,$rootScope) {
    console.log(AuthenticationService.fillAuthData());
    $http.get("http://localhost:9751/Account/validate-user").then(function (response) {
        console.log(response.data);
        UserInfoService.setUser(response.data);
        $state.go('home.map-view');
    });
    $rootScope
        .$on('$stateChangeStart',
            function (event, toState, toParams, fromState, fromParams) {
                $("#ui-view").html("");
                $(".page-loading").removeClass("hidden");
            });
    $rootScope
        .$on('$stateChangeSuccess',
            function (event, toState, toParams, fromState, fromParams) {
                $(".page-loading").addClass("hidden");
            });
});


application.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise("login");
    $stateProvider
        .state(
            'login', {
                url: '/login',
                controller: 'loginRegistrationController',
                templateUrl: 'Application/views/login-registration.view.html',
                authenticate : true
            }
        )
        .state(
            'home', {
                url: '/home',
                abstract: true,
                controller: 'HomeController',
                templateUrl: 'Application/views/home.view.html'

            }
        )
        .state(
            'home.message', {
                url: '/message',
                controller: 'MessageController',
                templateUrl: 'Application/views/message.view.html'
            }
        )
        .state(
            'home.post-product', {
                url: '/post-product',
                controller: 'PostProductController',
                templateUrl: 'Application/views/post-product.view.html'
            }
        )

        .state(
            'home.subcategory', {
                url: '/subcategory',
                controller: 'SubcategoryController',
                templateUrl: 'Application/views/subcategory.view.html'
            }
        )
        .state(
            'home.product-details', {
                url: '/product-details',
                controller: 'ProductDetailsController',
                templateUrl: 'Application/views/product-details.view.html'
            }
        ).state(
        'home.map-view', {
            url: '/map-view',
            controller: 'MapController',
            templateUrl: 'Application/views/map.view.html'
        }
    ).state('home.search-view', {
        url: '/search-view',
        controller: 'SearchController',
        templateUrl: 'Application/views/search.view.html'
    })

});




application.run(function () {
    console.log("ok run");
});

application.controller('sampleController', function ($scope, $state, SubcategoryProvider) {
    $scope.message = "sample controller";
    $scope.redirectTOSubcategory = function () {
        SubcategoryProvider.setSubcategory("Pets");
        $state.go("subcategory");
    };

    // RemoteService.logIn("asdas").then(function(response){
    //     console.log(response.data);
    // })

});