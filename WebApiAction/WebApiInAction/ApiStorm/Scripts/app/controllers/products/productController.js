define(["require", "exports", "../models/ProductModel"], function (require, exports, productModule) {
    "user strict";
    var productController = (function () {
        function productController($scope, $exportService) {
            this.productService = $exportService;
            this.refreshProducts($scope);
            var controller = this;
            $scope.addNewProduct = function () {
                var newProduct = new productModule.Product();
                newProduct.Name = $scope.newProductName;
                newProduct.Price = $scope.newProductPrice;
                controller.addProduct(newProduct, function () {
                    controller.getAllProducts(function (data) {
                        $scope.products = data;
                    });
                });
            };
            $scope.deleteProduct = function (productId) {
                controller.deleteProduct(productId, function () {
                    controller.getAllProducts(function (data) {
                        $scope.products = data;
                    });
                });
            };
            var prt1 = new productModule.Product();
            prt1.Id = 1;
            prt1.Description = "A Product";
            prt1.Name = "Product #1";
            prt1.Category = "Category #1";
            prt1.Price = 100;
            var prt2 = new productModule.Product();
            prt2.Id = 2;
            prt2.Description = "A Product";
            prt2.Name = "Product #1";
            prt2.Category = "Category #2";
            prt2.Price = 200;
            var prt3 = new productModule.Product();
            prt3.Id = 3;
            prt3.Description = "A Product";
            prt3.Name = "Product #2";
            prt3.Category = "Category #3";
            prt3.Price = 300;
            var prt4 = new productModule.Product();
            prt3.Id = 4;
            prt3.Description = "A Product";
            prt3.Name = "Product #3";
            prt3.Category = "Category #4";
            prt3.Price = 400;
            $scope.products = [prt1];
        }
        productController.prototype.getAllProducts = function (successCallback) {
            this.productService.get('/api/products').success(function (data, status) {
                successCallback(data);
            });
        };
        productController.prototype.addProduct = function (product, successCallback) {
            this.productService.post('/api/products', product).success(function () {
                successCallback();
            });
        };
        productController.prototype.deleteProduct = function (productId, successCallback) {
            this.productService.delete('/api/products/' + productId).success(function () {
                successCallback();
            });
        };
        productController.prototype.refreshProducts = function (scope) {
            this.getAllProducts(function (data) {
                scope.products = data;
            });
        };
        return productController;
    })();
    exports.productController = productController;
});
//# sourceMappingURL=productController.js.map