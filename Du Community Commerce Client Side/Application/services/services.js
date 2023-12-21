/**
 * Created by Rashedul on 11/4/2016.
 */

application.service("UserInfoService",function () {
    var user=null;
    this.setUser=function (sub) {
        user=sub;
        console.log(user);
    };
    this.getUser=function () {
        console.log(user);
        return user;
    };
});


application.service("SubcategoryProvider",function () {
    var subcategory=null;
    this.setSubcategory=function (sub) {
        subcategory=sub;
    };
    this.getSubcategory=function () {
        return subcategory;
    };
});


application.service("SearchServiceProvider",function(){
    var SearchModel=null;
    this.setSearchModel=function (searchItem) {
        SearchModel=searchItem;
    };
    this.getSearchModel=function () {
        return SearchModel;
    }
});

application.service('ProductDetailsService',function(){
    var productDetailsObject=null;
    this.setProduct=function (object) {
        productDetailsObject=object;
    };
    this.getProduct=function(){
        return productDetailsObject;
    };
});


application.service('AddressProviderService',function () {
    var productAddress=null;
    this.setAddress=function (address) {
        productAddress=address;
    };
    this.getAddress=function () {
        return productAddress;
    }
});