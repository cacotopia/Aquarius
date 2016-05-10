define(["require", "exports"], function (require, exports) {
    "use strict";
    var mainControllers = (function () {
        function mainControllers() {
            var app = angular.module("mainControllers", []);
            app.controller('MainController', function ($scope, $location) {
                $scope.name = "John";
                $scope.lastName = "Doe";
            });
        }
        return mainControllers;
    })();
    exports.mainControllers = mainControllers;
});
//# sourceMappingURL=mainControllers.js.map