"use strict";

import mainCtrlsModule = require("./controllers/mainControllers");
export class shareApp {
    constructor() {



        var ngApp = angular.module('shareApp', ["ngRoute", "ngSanitize", "ui.router", "ui.bootstrap", "pascalprecht.translate","mainControllers"]);
        var mainCtrls = new mainCtrlsModule.mainControllers();
    }
}
