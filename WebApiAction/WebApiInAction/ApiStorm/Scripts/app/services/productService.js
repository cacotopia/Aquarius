define(["require", "exports"], function (require, exports) {
    "use strict";
    var ProductService = (function () {
        function ProductService($http) {
            this.$http = $http;
            return this;
        }
        return ProductService;
    })();
    exports.ProductService = ProductService;
    var ProductServiceHandler = (function () {
        function ProductServiceHandler() {
        }
        ProductServiceHandler.prototype.assign = function (service) {
            this.service = service;
        };
        ProductServiceHandler.prototype.validateUser = function (userName) {
            return this.service.$http({
                method: 'GET',
                url: '/api/Students?userName=' + userName
            });
        };
        ;
        ProductServiceHandler.prototype.registerUser = function (user) {
            return this.service.$http({
                method: 'POST',
                url: '/api/Students',
                data: user
            });
        };
        ;
        ProductServiceHandler.prototype.saveProduct = function (product) {
            return this.service.$http({
                method: 'POST',
                url: '/api/Product',
                data: product
            });
        };
        ProductServiceHandler.prototype.getProduct = function (productId) {
            return this.service.$http({
                method: 'GET',
                url: '/api/Product/' + productId
            });
        };
        ProductServiceHandler.prototype.getAllProduct = function () {
            return this.service.$http({
                method: 'GET',
                url: '/api/Product'
            });
        };
        ProductServiceHandler.prototype.deleteProduct = function (productId) {
            return this.service.$http({
                method: 'GET',
                url: '/api/Product/Delete/' + productId
            });
        };
        return ProductServiceHandler;
    })();
    exports.ProductServiceHandler = ProductServiceHandler;
});
//# sourceMappingURL=productService.js.map