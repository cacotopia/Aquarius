/// <reference path="typings/angularjs/angular.d.ts" />
/// <reference path="typings/angularjs/angular-route.d.ts" />
requirejs.config({
    baseUrl: "Scripts/appScripts",
    paths: {
        "jquery": "../jquery-2.2.1.min",
        "bootstrap": "../bootstrap",
        "app": "./shareApp",
        "angular": "../angular",
        "ngRoute": "../angular-route",
        "ngSanitize": "../angular-sanitize",
        "mainCtrls": "./mainControllers",
        "ui.bootstrap": "../angular-ui/ui-bootstrap-tpls"
    },
    shim: {
        "ngRoute": ['angular'],
        "ngSanitize": ['angular'],
        "ui.bootstrap": ['angular'],
        "bootstrap": ['jquery']
    }
});
requirejs(["app", "bootstrap", "angular", "ngRoute", "ngSanitize", "ui.bootstrap"], function (app) {
    var shareApp = new app.shareApp();
    angular.element(document).ready(function () {
        angular.bootstrap(document, ['shareApp']);
    });
});
//# sourceMappingURL=main.js.map