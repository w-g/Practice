



(function () {

    // 辅助方法
    window.Helper = {};

    // 处理Url相关的辅助方法
    var UrlHelper = {

        // (http[s]?)://([a-z\.]+)/?([a-z/]*)\??(.*)

        replace: function (href, param, replacement) {
            var regex = new RegExp(param + "=[^&]+");
            return href.replace(param, param + "=" + replacement);
        }

    };

    // 关联到Helper对象
    window.Helper.Url = UrlHelper;

})();