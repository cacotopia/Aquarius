"use strict";

import appCtrls = require("./controllers/applicationController");

export class shareApp {

    constructor() {

        var ngApp = angular.module('shareApp', ["ngSanitize", "ui.router", "ngRoute", "ui.bootstrap", "pascalprecht.translate", "ApplicationController"]);

        var mainCtrls = new appCtrls.ApplicationController();
    }
}
