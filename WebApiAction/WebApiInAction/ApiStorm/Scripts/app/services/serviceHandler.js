define(["require", "exports"], function (require, exports) {
    "use strict";
    var exportService = (function () {
        function exportService($http) {
            this.$http = $http;
            return this;
        }
        return exportService;
    })();
    exports.exportService = exportService;
    var serviceHandler = (function () {
        function serviceHandler() {
        }
        serviceHandler.prototype.assign = function (service) {
            this.service = service;
        };
        serviceHandler.prototype.validateUser = function (userName) {
            return this.service.$http({
                method: 'GET',
                url: '/api/Students?userName=' + userName
            });
        };
        ;
        serviceHandler.prototype.registerUser = function (user) {
            return this.service.$http({
                method: 'POST',
                url: '/api/Students',
                data: user
            });
        };
        ;
        return serviceHandler;
    })();
    exports.serviceHandler = serviceHandler;
});
//# sourceMappingURL=serviceHandler.js.map