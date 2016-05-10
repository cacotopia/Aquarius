/// <reference path="typings/angularjs/angular.d.ts" />
/// <reference path="typings/angularjs/angular-route.d.ts" />
/// <reference path="typings/angular-translate/angular-translate.d.ts" />
/// <reference path="typings/angular-ui-router/angular-ui-router.d.ts" />
/// <reference path="typings/angular-ui/angular-ui-sortable.d.ts" />
/// <reference path="typings/angular-translate/angular-translate.d.ts" />
/// <reference path="app/shareApp.ts" />
define(["require", "exports", "./app/shareApp"], function (require, exports, shareAppModule) {
    requirejs.config({
        baseUrl: "Scripts/app",
        paths: {
            "jquery": "../jquery-2.2.3.min",
            "bootstrap": "../bootstrap",
            "angular": "../angular.min",
            "ngSanitize": "../angular-sanitize",
            "ngRoute": "../angular-route.min",
            "ui.router": "../angular-ui-router.min",
            "ui.bootstrap": "../angular-ui/ui-bootstrap-tpls",
            "angular-translate": "../angular-translate.min",
            "applicationController": "./controllers/applicationController",
            "app": "./shareApp",
            "routeConfig": "./configs/configRouter",
            "transplteConfig": "./configs/configTranslate",
            "serviceFactory": "./services/accountService"
        },
        shim: {
            "ui.router": {
                deps: ['angular']
            },
            "ngRoute": ['angular'],
            "ngSanitize": ['angular'],
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
    requirejs(["app", "bootstrap", "angular", "ngRoute", "ui.router", "ngSanitize", "ui.bootstrap", "angular-translate"], function (app) {
        var shareApp = new shareAppModule.shareApp();
        angular.element(document).ready(function () {
            angular.bootstrap(document, ['shareApp']);
        });
    });
});
//# sourceMappingURL=main.js.map