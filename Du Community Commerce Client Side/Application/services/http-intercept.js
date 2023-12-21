/**
 * Created by Rashedul on 11/4/2016.
 */

'use strict';
application.factory('authInterceptorService', ['$q', '$location', 'localStorageService', 'UserInfoService',
    function ($q, $location, localStorageService, UserInfoService) {

    var authInterceptorServiceFactory = {};

    var _request = function (config) {

        config.headers = config.headers || {};

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }
        return config;
    };

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            UserInfoService.setUser(null);
            $location.path('/login');
        }
        return $q.reject(rejection);
    };

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);