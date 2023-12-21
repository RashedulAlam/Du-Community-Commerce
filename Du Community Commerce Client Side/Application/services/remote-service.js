/**
 * Created by Rashedul on 11/4/2016.
 */

application.service("RemoteService", function ($http) {

    this.getProductsBySubcategory=function (sub) {
        return $http.post('http://localhost:9751/product/subcategory', '"' + sub + '"');
    };

    this.getOneImageForProduct=function (productId) {
        return $http.post('http://localhost:9751/product/get-product-image-one', '"' + productId + '"');
    };

    this.getCategory=function(){
        return $http.get('mock-data/category.json');
    };

    this.getSearchResults=function(searchModel){
        return $http.post('http://localhost:9751/product/search-product', searchModel);
    };
    this.getAllImagesOfProduct=function (productId) {
        return $http.post('http://localhost:9751/product/get-product-image-all', '"' + productId + '"');
    };

    this.getAllCommentsOfProduct=function(productId){
        return $http.post('http://localhost:9751/Product/get-comment', '"' + productId + '"');
    }


});