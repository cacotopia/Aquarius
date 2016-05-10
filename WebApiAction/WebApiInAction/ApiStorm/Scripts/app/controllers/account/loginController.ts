"user strict";

import ng = angular;
import mod = require("../models/UserModel");
import svc = require("../services/accountService");

export interface Scope {

}

export class loginController {
    location: ng.ILocationService;
    loggedIn: boolean;
    message: string;
    user: any;
    serviceFactory: svc.AccountServiceHandler;
    loggedInUser: any;

    constructor($location: ng.ILocationService, services: any, serviceClass: svc.AccountServiceHandler) {
        this.serviceFactory = serviceClass;
        this.serviceFactory.assign(services);
        this.location = $location;
        this.loggedIn = false;
        this.message = "";
        this.user = {};
    }

    public login(): void {
        var self = this;
        this.serviceFactory.validateUser(this.user.UserName).then(function (response) {
            if (response.status == 200) {
                self.loggedIn = true;
                self.message = "";
                self.loggedInUser = response.data;
            }
        }).catch(function (response) {
            self.loggedIn = false;
            self.message = response.data.Message + ";" + response.data.ExceptionMessage;
        });
        self.user = {};
    }

    public validate(): void {
        if (!this.loggedIn) {
            this.message = "Login before adding buddies or shares.";
            this.location.path("/");
        }
    }
}

