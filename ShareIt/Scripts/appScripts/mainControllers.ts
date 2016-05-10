"use strict";

export class mainControllers {
    constructor() {
        var app = angular.module("mainControllers", []);

        app.controller('MainController', ($scope, $location) => {
            $scope.name = "John";
            $scope.lastName = "Doe";
        });
    }
}