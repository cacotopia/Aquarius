define(["require", "exports"], function (require, exports) {
    "user strict";
    var User = (function () {
        function User(userID, userName, userRoles) {
            this.UserID = userID;
            this.UserName = userName;
            this.UserRoles = userRoles;
        }
        return User;
    })();
    exports.User = User;
    var UserRole = (function () {
        function UserRole() {
        }
        return UserRole;
    })();
    exports.UserRole = UserRole;
});
//# sourceMappingURL=UserModel.js.map