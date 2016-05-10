define(["require", "exports", "../services/accountService", "../configs/configRouter", "../configs/configTranslate", "./account/loginController", "./account/registerController"], function (require, exports, accountServiceModule, routeConfigModule, translateConfigModule, loginCtrlModule, registerCtrlModule) {
    "use strict";
    var ApplicationController = (function () {
        function ApplicationController() {
            var app = angular.module("ApplicationController", []);
            var route = new routeConfigModule.configRouter();
            app.config(route.configure);
            var translate = new translateConfigModule.configTranslate();
            app.config(translate.configure);
            var serviceHandler = new accountServiceModule.AccountServiceHandler();
            var serviceMod = app.factory("accountService", ["$http", accountServiceModule.AccountService]);
            app.controller("ApplicationController", function ($location, services) {
                return new loginCtrlModule.loginController($location, services, serviceHandler);
            });
            app.controller("LoginControle", function ($location, services) {
                return new loginCtrlModule.loginController($location, services, serviceHandler);
            });
            app.controller("RegisterController", function ($scope, $location, services) {
                return new registerCtrlModule.registerController($scope, $location, serviceHandler);
            });
        }
        return ApplicationController;
    })();
    exports.ApplicationController = ApplicationController;
});
//# sourceMappingURL=applicationController.js.map