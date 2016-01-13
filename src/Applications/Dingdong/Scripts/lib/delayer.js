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

    var Delayer = function (timeout) {
        this._stos = [];
        this.timeout = timeout || 200;
    };

    Delayer.prototype = {

        call: function (handler, context, args) {

            var self = this;
            var sto = setTimeout(function (args) {
                handler.call(context, args);

                self._stos.shift();

            }, self.timeout, args);

            if (self._stos.length) {
                clearTimeout(self._stos.shift());
            }

            self._stos.push(sto);
        },

        clear: function () {
            var self = this;
            if (self._stos.length) {
                $.each(self._stos, function (index, sto) {
                    clearTimeout(sto);
                });
            }
        }
    };

    return Delayer;
});
