/**
 * Created by rashe on 10/25/2016.
 */

application.controller('loginRegistrationController',function ($scope,AuthenticationService,UserInfoService,$http,$state) {

    $scope.user={};
    $scope.loginModel={};

    $scope.showRegistrationForm=false;
    $scope.showLoginForm=true;

    $scope.registerUser=function () {
      console.log($scope.user);
    };

    $scope.loginUser=function () {
      console.log($scope.loginModel);
        AuthenticationService.login($scope.loginModel).then(function (response) {
            console.log(response);
            $http.get("http://localhost:9751/Account/validate-user").then(function (response) {
                console.log(response.data);
                UserInfoService.setUser(response.data);
                $state.go('home.map-view');
            });
        },function (err) {
            console.log(err.description);
        });
    };
    $scope.showLoginFormFunction=function () {
        if($scope.showLoginForm==false){
            $scope.showLoginForm=true;
            $scope.showRegistrationForm=false;
        }

    };
    $scope.showRegistrationFormFunction=function () {
        if($scope.showRegistrationForm==false){
            $scope.showRegistrationForm=true;
            $scope.showLoginForm=false;
        }
    };



});