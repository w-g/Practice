

(function (factory) {

    if (typeof define === 'function' && define.amd) {
        define([], factory);
    } else {
        window.Delayer = factory();
    }

})(function () {

    var Uri = function (uri) {

        var matches = /(http[s]?):\/\/(\w|\.+)([:\d{1,6}]?)((\/\w)*)\/?((\?.*)?)/i.exec(uri);

        this.protocal = matches[1];
        this.host = matches[2];
        this.port = matches[3];
        this.path = matches[4];
        this.search = matches[5];

        this.query;
        var queryMatches = this.search.match(/[^\=]+\=[^&]+/g);
        for (var i = 0; i < queryMatches.length; i++) {
            query[queryMatches[i].match(/[^\=]+/)[0]] = queryMatches[i].match(/(\?<=\=)[^&]+/)[0];
        }
    };

    Uri.prototype = {

        toString: function () {
            return this.protocal + "://" + this.host + ":" + this.port + this.path + this.search;
        },

        getSearch: function (key) {

        },

        setSearch: function (key, value) {

        }
    };


    return Uri;
});
