define(["require", "exports"], function (require, exports) {
    "use strict";
    var configTranslate = (function () {
        function configTranslate() {
        }
        configTranslate.prototype.configure = function ($translateProvider) {
            $translateProvider.translations('en', {
                'TITLE': 'Hello',
                'FOO': 'This is a paragraph'
            });
            $translateProvider.translations('zh', {
                'TITLE': '你好',
                'FOO': '这是一幅图'
            });
            $translateProvider.preferredLanguage('zh');
        };
        return configTranslate;
    })();
    exports.configTranslate = configTranslate;
});
//# sourceMappingURL=configTranslate.js.map