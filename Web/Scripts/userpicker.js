/**
 * User Picker Script
 */

(function (factory) {

    if (typeof define === 'function' && define.amd) {
        define(["jquery", "delayer"], factory);
    } else {
        factory(window.jQuery, window.Delayer);
    }

})(function ($, Delayer) {

    // Definition
    var UserPicker = function (element, options) {

        var self = this,
            $container = $(element),
            $input = $container.find(".user-selected-panel input");

        this.$optionPanel = $container.find(".user-option-panel");

        this.users = [];
        var history = localStorage["userSelectorHistory"];
        if (history) {
            this.users = history.split(",");
        }

        // temp
        var delayer = new Delayer(500);

        this.fetchUsersUrl = options.fetchUsersUrl;

        // Bind Event Handler
        $input
            .on("focus", function (e) {

                if (self.users.length > 0) {
                    self.$optionPanel.show();
                }

                e.preventDefault();
                e.stopPropagation();
            })
            .on("keyup", function (e) {

                // delay for avoid request server too frequently
                delayer.call(self.fetchUsers);

                e.preventDefault();
                e.stopPropagation();
            });
    };

    UserPicker.prototype = {

        render: function () {

        },

        select: function ($user) {
            var $input = $user.find("input");
            $input[0].checked = true;

            this.addUser($input.val());

            this.$optionPanel.hide();
        },

        addUser: function (userId) {
            this.users.push(userId);
            localStorage["userSelectorHistory"] = this.users.toString();
        },

        fetchUsers: function (keyword) {
            $.get(this.fetchUsersUrl, function (data) {
            });
        }
    };

    // Plugin Definition
    $.fn.userpicker = function (options) {
        new UserPicker(this, $.extend({}, $.fn.userpicker.default, options));
    };

    // Default Options
    $.fn.userpicker.default = {
        fetchUsersUrl: "User/SelectorData"
    };
});