"use strict";

import ng = angular;
import svc = require("../services/accountService");

export class registerController {
    location: ng.ILocationService;
    user: any;
    serviceFactory: svc.AccountServiceHandler;
    parent: any;

    constructor($scope: ng.IScope, $location: ng.ILocationService, services: svc.AccountServiceHandler) {
        this.serviceFactory = services;
        this.location = $location;
        this.parent = $scope.$parent;
        this.user = {};
    }

    public register(): void {
        var self = this;
        this.serviceFactory.registerUser(this.user).then(function (response) {
            if (response.status === 201) {
                self.parent.ctrl.message = "";
                self.location.path("/");
            }
        }).catch(function (response) {
            self.parent.ctrl.message = response.data.Message + ";" + response.data.ExceptionMessage;
        });
        self.user = {};
    };
}

