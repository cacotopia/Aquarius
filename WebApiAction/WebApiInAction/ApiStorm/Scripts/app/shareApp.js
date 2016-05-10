define(["require", "exports", "./controllers/applicationController"], function (require, exports, appCtrls) {
    "use strict";
    var shareApp = (function () {
        function shareApp() {
            var ngApp = angular.module('shareApp', ["ngSanitize", "ui.router", "ngRoute", "ui.bootstrap", "pascalprecht.translate", "ApplicationController"]);
            var mainCtrls = new appCtrls.ApplicationController();
        }
        return shareApp;
    })();
    exports.shareApp = shareApp;
});
//# sourceMappingURL=shareApp.js.map