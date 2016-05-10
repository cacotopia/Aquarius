"user strict";

export class User {
    UserID: number;
    FirstName: string;
    LastName: string;
    UserName: string;
    UserRoles: UserRole[];
    constructor(userID: number, userName: string, userRoles: UserRole[]) {
        this.UserID = userID;
        this.UserName = userName;
        this.UserRoles = userRoles;
    }
}

export class UserRole {
    RoleID: number;
    RoleName: string;
} 