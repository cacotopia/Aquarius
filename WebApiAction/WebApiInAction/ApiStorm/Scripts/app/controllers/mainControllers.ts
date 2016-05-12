"use strict";

import serviceModule = require("../services/serviceHandler");
import accountServiceModule = require("../services/accountService");
import productServiceModule = require("../services/productService");
import routeConfigModule = require("../configs/configRouter");
import translateConfigModule = require("../configs/configTranslate");
import loginCtrlModule = require("./account/loginController");
import registerCtrlModule = require("./account/registerController");
import ng = angular;

export interface IMainScope  extends ng.IScope {
    name: string;
    lastName: string;    
}

export class mainControllers {

    constructor() {
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

        app.controller("MainController", ($location, services) =>
            new loginCtrlModule.loginController($location, services, serviceHandler));

        app.controller("LoginControle", ($location, services) =>
            new loginCtrlModule.loginController($location, services, serviceHandler));
        app.controller("RegisterController", ($scope, $location, services) =>
            new registerCtrlModule.registerController($scope, $location, serviceHandler));
    }
}