"use strict";
import ng = angular;

interface IServiceHandler {

    assign(service: exportService): void;

    validateUser<T>(userName: string): ng.IHttpPromise<T>;

    registerUser<T>(user: T): ng.IHttpPromise<T>;
}

export class exportService {
    $http: any;
    constructor($http: ng.IHttpService) {
        this.$http = $http;
        return this;
    }
}

export class serviceHandler implements IServiceHandler {
    service: exportService;
    constructor() {
    }

    public assign(service: exportService): void {
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
            url: '/api/Students',
            data: user
        });
    };
}