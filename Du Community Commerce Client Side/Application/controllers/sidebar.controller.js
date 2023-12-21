/**
 * Created by Rashedul on 10/8/2016.
 */
application.controller('SidebarController',function($scope,$http,SubcategoryProvider,$state,RemoteService){
   RemoteService.getCategory.then(function (response) {
        $scope.categories=_.groupBy(response.data, 'category');
    });

    $scope.goTOSubcategory=function (subcategory) {
        SubcategoryProvider.setSubcategory(subcategory);
        $state.go("subcategory", {}, { reload: true });
    };
});