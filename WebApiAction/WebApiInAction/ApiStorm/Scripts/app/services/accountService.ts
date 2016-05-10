"use strict";
import ng = angular;

interface IAccountServiceHandler {

    assign(service: AccountService): void;

    validateUser<T>(userName: string): ng.IHttpPromise<T>;

    registerUser<T>(user: T): ng.IHttpPromise<T>;
}

export class AccountService {
    $http: any;
    constructor($http: ng.IHttpService) {
        this.$http = $http;
        return this;
    }
}

export class AccountServiceHandler implements IAccountServiceHandler {
    service: AccountService;
    constructor() {

    }

    public assign(service: AccountService): void {
        this.service = service;
    }

    public validateUser<T>(userName: string): ng.IHttpPromise<T> {
        return this.service.$http({
            method: 'GET',
            url: '/api/Students?userName=' + userName
        });
    };

    public registerUser<T>(user: T): ng.IHttpPromise<T> {
        return this.service.$http({
            method: 'POST',
            url: '/api/Account',
            data: user
        });
    };
}

