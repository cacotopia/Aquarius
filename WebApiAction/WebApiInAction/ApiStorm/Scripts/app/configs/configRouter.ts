"use strict";
import ng = angular;
import ngr = angular.route;
import ngui = angular.ui;

export class configRouter {
    constructor() {
    }
    //ui.route configuration   
    public routeconfigure($stateProvider: ngui.IStateProvider, $urlRouterProvider: ngui.IUrlRouterProvider): void {
        $urlRouterProvider.when("", "/Home");
        // UI States, URL Routing & Mapping. For more info see: https://github.com/angular-ui/ui-router
        // our routers, self explanatory
        $stateProvider
            .state('home', {
                url: '/',
                templateUrl: '/Scripts/app/views/Home.html'
            })
            .state('movies', {
                url: '/movies',
                templateUrl: '/Scripts/app/views/notFound.html',
                controller: 'MoviesController'
            })
            .state('otherwise', {
                url: '*path',
                templateUrl: '/Scripts/app/views/Error.html',
                controller: 'ErrorCtrl'
            });

        /*
        $stateProvider.state('home', {
            url: '/',
            templateUrl: 'PartialViews/Home.html',
            controller:'MainController as vm'
        }).state('notFound', {
            url: '/notFound',
            templateUrl: 'PartialViews/notFound.html',
            controller: 'NotFoundController as vm'
        }).state('Error', {
            url: '/Error',
            templateUrl: 'PartialViews/Error.html',
            controller: 'ErrorController as vm'
        });    
        $stateProvider.state('account', {
            url: '/account',
            template: '<div ui-view></div>',
            abstract: true
        });
        $stateProvider.state('account.login', {
            url: '/login',
            templateUrl: "PartialViews/Login.html",
            controller: "LoginController as vm"
        });
        $stateProvider.state('reader.register', {
            url: '/register',
            templateUrl: "PartialViews/Register.html",
            controller: "RegisterController as vm"
        });
        $stateProvider.state('reader', {
            url: '/reader',
            template: '<div ui-view></div>',
            abstract: true
        });
        $stateProvider.state('reader.create', {
            url: '/create',
            templateUrl: 'controllers/reader/create.html',
            controller: 'ReaderCreateController as vm'
        });
        $stateProvider.state('reader.list', {
            url: '/list',
            templateUrl: 'controllers/reader/list.html',
            controller: 'ReaderListController as vm'
        });
        $stateProvider.state('thread', {
            url: '/thread',
            template: '<div ui-view></div>',
            abstract: true
        });
        $stateProvider.state('thread.list', {
            url: '/list',
            templateUrl: 'controllers/thread/list.html',
            controller: 'ThreadListController as vm'
        });
        $stateProvider.state('thread.tree', {
            url: '/tree',
            templateUrl: 'controllers/thread/tree.html',
            controller: 'ThreadTreeController as vm'
        });
        $stateProvider.state('thread.show', {
            url: '/:id/show?title&poster',
            templateUrl: 'controllers/thread/show.html',
            controller: 'ThreadShowController as vm'
        });
        */
    }
    //ngRouter configuration    
    public configure($routeProvider: ngr.IRouteProvider, $locationProvider: ng.ILocationProvider): void {
        $routeProvider.when("/", {
            templateUrl: "PartialViews/Home.html",
            controller: "MainController as vm"
        }).when("/Login", {
            templateUrl: "PartialViews/Login.html",
            controller: "LoginController as vm"
        }).when("/Register", {
            templateUrl: "PartialViews/Register.html",
            controller: "RegisterController"
        }).when("/Buddies", {
            templateUrl: "PartialViews/Buddies.html",
            controller: "BuddiesController"
        }).when("/Share", {
            templateUrl: "PartialViews/Buddies.html",
            controller: "ShareController"
        }).otherwise({
            redirectTo: "/"
        });
        //$urlRouterProvider.otherwise('NotFound');
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    }
}
