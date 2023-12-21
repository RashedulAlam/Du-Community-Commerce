/**
 * Created by Rashedul on 11/3/2016.
 */

application.controller('HomeController', function ($scope,$state) {


    $scope
        .$on('$stateChangeStart',
            function (event, toState, toParams, fromState, fromParams) {
                $("#ui-view2").html("");
                $(".page-loading2").removeClass("hidden");

            });

    $scope
        .$on('$stateChangeSuccess',
            function (event, toState, toParams, fromState, fromParams) {
                $(".page-loading2").addClass("hidden");

            });
});