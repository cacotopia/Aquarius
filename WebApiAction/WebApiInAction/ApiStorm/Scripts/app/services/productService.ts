"use strict";
import ng = angular;

interface IProductServiceHandler {

    assign(service: ProductService): void;

    saveProduct<T>(product: T): ng.IHttpPromise<T>;

    getProduct<T>(productId: number): ng.IHttpPromise<T>;

    getAllProduct<T>(): ng.IHttpPromise<T>;

    deleteProduct<T>(productId: number): ng.IHttpPromise<T>;
}

export class ProductService {
    $http: any;
    constructor($http: ng.IHttpService) {
        this.$http = $http;
        return this;
    }
}

export class ProductServiceHandler implements IProductServiceHandler {
    service: ProductService;
    constructor() {
    }

    public assign(service: ProductService): void {
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

    public saveProduct<T>(product: T): ng.IHttpPromise<T> {
        return this.service.$http({
            method: 'POST',
            url: '/api/Product',
            data: product
        });
    }

    public getProduct<T>(productId: number): ng.IHttpPromise<T> {
        return this.service.$http({
            method: 'GET',
            url: '/api/Product/' + productId
        });
    }

    public getAllProduct<T>(): ng.IHttpPromise<T> {
        return this.service.$http({
            method: 'GET',
            url: '/api/Product'
        });
    }

    public deleteProduct<T>(productId: number): ng.IHttpPromise<T> {
        return this.service.$http({
            method: 'GET',
            url: '/api/Product/Delete/' + productId
        });
    }
}