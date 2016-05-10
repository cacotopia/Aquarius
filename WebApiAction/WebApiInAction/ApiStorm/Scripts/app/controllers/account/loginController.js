define(["require", "exports"], function (require, exports) {
    "user strict";
    var loginController = (function () {
        function loginController($location, services, serviceClass) {
            this.serviceFactory = serviceClass;
            this.serviceFactory.assign(services);
            this.location = $location;
            this.loggedIn = false;
            this.message = "";
            this.user = {};
        }
        loginController.prototype.login = function () {
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
        };
        loginController.prototype.validate = function () {
            if (!this.loggedIn) {
                this.message = "Login before adding buddies or shares.";
                this.location.path("/");
            }
        };
        return loginController;
    })();
    exports.loginController = loginController;
});
//# sourceMappingURL=loginController.js.map