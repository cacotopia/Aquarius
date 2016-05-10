define(["require", "exports"], function (require, exports) {
    "use strict";
    var registerController = (function () {
        function registerController($scope, $location, services) {
            this.serviceFactory = services;
            this.location = $location;
            this.parent = $scope.$parent;
            this.user = {};
        }
        registerController.prototype.register = function () {
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
        ;
        return registerController;
    })();
    exports.registerController = registerController;
});
//# sourceMappingURL=registerController.js.map