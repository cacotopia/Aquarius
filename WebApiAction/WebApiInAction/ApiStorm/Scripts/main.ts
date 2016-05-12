/// <reference path="typings/angularjs/angular.d.ts" />
/// <reference path="typings/angularjs/angular-route.d.ts" />
/// <reference path="typings/angular-translate/angular-translate.d.ts" />
/// <reference path="typings/angular-ui-router/angular-ui-router.d.ts" />
/// <reference path="typings/angular-ui/angular-ui-sortable.d.ts" />
/// <reference path="typings/angular-translate/angular-translate.d.ts" />
requirejs.config({
    baseUrl: "Scripts/app",
    paths: {
        "jquery": "../jquery-2.2.3.min",
        "bootstrap": "../bootstrap.min",
        "angular": "../angular.min",
        "ngSanitize": "../angular-sanitize",
        "ngRoute": "../angular-route.min",
        "ui.router": "../angular-ui-router.min",
        "ui.bootstrap": "../angular-ui/ui-bootstrap-tpls",
        "angular-translate": "../angular-translate.min",
        "app": "./shareApp",
        "mainCtrls": "./controllers/mainControllers",
        "routeConfig": "./configs/configRouter",
        "transplteConfig": "./configs/configTranslate",
        "serviceFactory": "./services/serviceHandler",
        "accountServiceFactory": "./services/accountService",
        "productServiceFactory": "./services/productService"
    },
    shim: {
        "ngRoute": ['angular'],
        "ngSanitize": ['angular'],
        "ui.router": {
            deps: ['angular']
        },
        "ui.bootstrap": {
            deps: ['angular']
        },
        "bootstrap": ['jquery'],
        "angular-translate": {
            deps: ['angular'],
            exports: 'angular-translate'
        }
    }
});
/**
 * Main entry point for RequireJS
 */
requirejs(["app", "bootstrap", "angular", "ngRoute", "ui.router", "ngSanitize", "ui.bootstrap", "angular-translate"], (app) => {
    var shareApp = new app.shareApp();
    angular.element(document).ready(() => {
        angular.bootstrap(document, ['shareApp']);
    });
});





