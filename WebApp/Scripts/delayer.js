/**
 * Delayer Definition
 */

(function (factory) {

    if (typeof define === 'function' && define.amd) {
        define([], factory);
    } else {
        window.Delayer = factory();
    }

})(function () {

    // 延迟器（顺延功能）
    var Delayer = function (timeout) {
        this._stos = []; /* _标识私有变量 */
        this.timeout = timeout;
    };

    Delayer.prototype = {

        call: function (handler, context, args) {

            var sto = setTimeout(function (args) {
                handler.call(context, args);

                // 这一定是队首
                this._stos.shift();

            }, this.timeout, args);

            if (this._stos.length) {
                clearTimeout(this._stos.shift());
            }

            this._stos.push(sto);
        }
    };

    return Delayer;
});
