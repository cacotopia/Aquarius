define(["require", "exports"], function (require, exports) {
    "use strict";
    var AccountService = (function () {
        function AccountService($http) {
            this.$http = $http;
            return this;
        }
        return AccountService;
    })();
    exports.AccountService = AccountService;
    var AccountServiceHandler = (function () {
        function AccountServiceHandler() {
        }
        AccountServiceHandler.prototype.assign = function (service) {
            this.service = service;
        };
        AccountServiceHandler.prototype.validateUser = function (userName) {
            return this.service.$http({
                method: 'GET',
                url: '/api/Students?userName=' + userName
            });
        };
        ;
        AccountServiceHandler.prototype.registerUser = function (user) {
            return this.service.$http({
                method: 'POST',
                url: '/api/Account',
                data: user
            });
        };
        ;
        return AccountServiceHandler;
    })();
    exports.AccountServiceHandler = AccountServiceHandler;
});
//# sourceMappingURL=accountService.js.map