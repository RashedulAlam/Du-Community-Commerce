/**
 * Created by Rashedul on 11/4/2016.
 */

application.service("AuthenticationService", function ($http, $q, localStorageService) {

    var serviceBase = 'http://localhost:9751/';

    this.saveRegistration = function (registration) {
        logOut();
        return $http.post(serviceBase + 'Account/Register', registration).then(function (response) {
            return response;
        });

    };

    this.login = function (loginData) {

        var data = "grant_type=password&username=" + loginData.username + "&password=" + loginData.password;


        var deferred = $q.defer();

        $http.post(serviceBase + 'login', data, {headers: {'Content-Type': 'application/x-www-form-urlencoded'}}).success(function (response) {
            localStorageService.set('authorizationData', {token: response.access_token, userName: loginData.userName});

            deferred.resolve(response);

        }).error(function (err, status) {
            logOut();
            deferred.reject(err);
        });

        return deferred.promise;

    };

    this.logOut = function () {

        localStorageService.remove('authorizationData');


    };

    this.fillAuthData = function () {

        return localStorageService.get('authorizationData');

    }


});