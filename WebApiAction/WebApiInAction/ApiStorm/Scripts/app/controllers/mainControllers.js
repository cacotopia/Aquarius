define(["require", "exports", "../services/serviceHandler", "../services/accountService", "../services/productService", "../configs/configRouter", "../configs/configTranslate", "./account/loginController", "./account/registerController"], function (require, exports, serviceModule, accountServiceModule, productServiceModule, routeConfigModule, translateConfigModule, loginCtrlModule, registerCtrlModule) {
    "use strict";
    var mainControllers = (function () {
        function mainControllers() {
            var app = angular.module("mainControllers", []);
            var route = new routeConfigModule.configRouter();
            app.config(route.configure);
            var translate = new translateConfigModule.configTranslate();
            app.config(translate.configure);
            var serviceHandler = new serviceModule.serviceHandler();
            var serviceMod = app.factory("services", ["$http", serviceModule.exportService]);
            var accountService = new accountServiceModule.AccountServiceHandler();
            var accountServiceMod = app.factory("accountServices", ["$http", accountServiceModule.AccountService]);
            var productService = new productServiceModule.ProductServiceHandler();
            var productServiceMod = app.factory("productServices", ["$http", productServiceModule.ProductService]);
            app.controller("MainController", function ($location, services) {
                return new loginCtrlModule.loginController($location, services, serviceHandler);
            });
            app.controller("LoginControle", function ($location, services) {
                return new loginCtrlModule.loginController($location, services, serviceHandler);
            });
            app.controller("RegisterController", function ($scope, $location, services) {
                return new registerCtrlModule.registerController($scope, $location, serviceHandler);
            });
        }
        return mainControllers;
    }());
    exports.mainControllers = mainControllers;
});
//# sourceMappingURL=mainControllers.js.map