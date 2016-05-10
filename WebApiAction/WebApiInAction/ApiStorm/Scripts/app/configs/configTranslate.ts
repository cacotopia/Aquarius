"use strict";

import ng = angular;
import ng_trans = angular.translate;
export class configTranslate {
    constructor() {
    }
    public configure($translateProvider: ng_trans.ITranslateProvider) {
        $translateProvider.translations('en', {
            'TITLE': 'Hello',
            'FOO': 'This is a paragraph'
        });
        $translateProvider.translations('zh', {
            'TITLE': '你好',
            'FOO': '这是一幅图'
        });
        $translateProvider.preferredLanguage('zh');
    }
}