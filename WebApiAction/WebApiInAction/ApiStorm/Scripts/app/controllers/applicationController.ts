"use strict";

import accountServiceModule = require("../services/accountService");
import routeConfigModule = require("../configs/configRouter");
import translateConfigModule = require("../configs/configTranslate");
import loginCtrlModule = require("./account/loginController");
import registerCtrlModule = require("./account/registerController");
import ng = angular;

export class ApplicationController {

    constructor() {
        var app = angular.module("ApplicationController", []);
        var route = new routeConfigModule.configRouter();
        app.config(route.configure);
        var translate = new translateConfigModule.configTranslate();
        app.config(translate.configure);
        var serviceHandler = new accountServiceModule.AccountServiceHandler();
        var serviceMod = app.factory("accountService", ["$http", accountServiceModule.AccountService]);
        app.controller("ApplicationController", ($location, services) =>
            new loginCtrlModule.loginController($location, services, serviceHandler));
        app.controller("LoginControle", ($location, services) =>
            new loginCtrlModule.loginController($location, services, serviceHandler));
        app.controller("RegisterController", ($scope, $location, services) =>
            new registerCtrlModule.registerController($scope, $location, serviceHandler));

    }
}

