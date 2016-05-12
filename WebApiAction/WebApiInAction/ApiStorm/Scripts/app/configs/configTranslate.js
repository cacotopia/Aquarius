define(["require", "exports"], function (require, exports) {
    "use strict";
    var configTranslate = (function () {
        function configTranslate() {
        }
        configTranslate.prototype.configure = function ($translateProvider) {
            $translateProvider.useStaticFilesLoader({
                prefix: 'locale-',
                suffix: '.json'
            });
            $translateProvider.useStaticFilesLoader({
                prefix: '/Scripts/app/locales/',
                suffix: '.json'
            });
            //$translateProvider.useStaticFilesLoader({
            //    prefix: 'another/path/to/locales/',
            //    suffix: '.json'
            //});
            $translateProvider.registerAvailableLanguageKeys(['en', 'zh'], {
                'en_US': 'en',
                'en_UK': 'en',
                'zh_CN': 'zh'
            });
            //set preferred lang
            $translateProvider.preferredLanguage('en');
            //auto determine preferred lang
            $translateProvider.determinePreferredLanguage();
            //when can not determine lang, choose en lang.
            //$translateProvider.fallbackLanguage('en');           
            //$translateProvider.preferredLanguage('en');
            //$translateProvider.preferredLanguage('zh');
        };
        return configTranslate;
    }());
    exports.configTranslate = configTranslate;
});
//# sourceMappingURL=configTranslate.js.map