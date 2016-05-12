define(["require", "exports", "./controllers/mainControllers"], function (require, exports, mainCtrlsModule) {
    "use strict";
    var shareApp = (function () {
        function shareApp() {
            var ngApp = angular.module('shareApp', ["ngRoute", "ngSanitize", "ui.router", "ui.bootstrap", "pascalprecht.translate", "mainControllers"]);
            var mainCtrls = new mainCtrlsModule.mainControllers();
        }
        return shareApp;
    }());
    exports.shareApp = shareApp;
});
//# sourceMappingURL=shareApp.js.map