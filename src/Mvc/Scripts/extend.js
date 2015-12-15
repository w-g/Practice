/**
 * 对原生js的一些扩展实现
 */

/**
 * JavaScript = ECMAScript + DOM + BOM（window + location + navigator + 同步且模态的弹出窗口 + ...等）
 * window的双重角色：JavaScript访问BOM的接口 + ECMAScript中规定的Global对象
 * 模态类型对话框：就是指除非采取有效的关闭手段，用户鼠标焦点或者输入光标一直停留在其上的对话框
 * override: confirm - 由于其同步且模态（对话框显示时，在用户做出响应前JavaScript会停止执行）的特性无法被实现，所以该重写无法完成
 */

/* helper
 ****************/
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

/* extend
 ****************/
(function () {
    
    // String.prototype.format

})();

/* polyfill
 ****************/
(function () {

    // polyfill: Array.isArray
    if (!Array.isArray) {
        Array.isArray = function (arg) {
            return Object.prototype.toString.call(arg) === '[object Array]';
        };
    }

})();

