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

    // Plugin Definition
    $.fn.userpicker = function (options) {

        var $container = $(this),
            threshold = 5, /* 历史数据数组阈值 */
            delayer = new Delayer(800), /* 做延迟加载的延迟器 */
            upHistoryKey = $container.data("upType") + "PickerHistory", /* 历史数据键值 */
            $optionPanel = $container.find(".user-option-panel"),
            $optionList = $container.find(".user-option-list"),
            $selectedList = $container.find(".user-selected-panel"),
            $input = $selectedList.find(".search-field input");

        options.name = $container.data("upName");
        options.fetchUsersUrl = $container.data("upUrl");

        // 保证用户设置的优先级最高
        options = $.extend({}, $.fn.userpicker.default, options);

        // 设置input的placeholder
        $input.attr("placeholder", options.placeholder);

        // 获取历史数据
        function getHistory() {
            var history = localStorage[upHistoryKey];
            if (history) {
                history = JSON.parse(history);
            }

            return history;
        }

        // 添加历史数据
        function setHistory(user) {
            var history = getHistory();
            if ($.isArray(history)) {
                if (history.length > threshold - 1) {
                    history.shift();
                }
            } else {
                history = [];
            }

            var flag = false;
            $.each(history, function (index, _user) {
                if (_user.id == user.id) {
                    flag = true;
                }
            });

            if (flag) {
                return;
            }

            history.push(user);

            localStorage[upHistoryKey] = JSON.stringify(history);
        }

        // 显示待选用户列表
        function showOptionPanel() {

            // 渲染列表
            var history = localStorage[upHistoryKey];
            if (history) {
                history = JSON.parse(history);
                if (history.length > 0) {

                    // 清空列表
                    $optionList.empty();

                    $.each(history, function (index, user) {
                        var item = "<li><a href='javascript:;'>" + user.name + "</a></li>";
                        $(item).data("user", user).appendTo($optionList[0]);
                    });

                    $optionPanel.show();
                }
            }
        }

        // 隐藏待选用户列表
        function hideOptionPanel() {
            $optionList.empty();
            $optionPanel.hide();
        }

        $input
            // 搜索输入框焦点事件
            .on("focus", function () {
                showOptionPanel();
            })
            // 搜索用户
            .on("keyup", function (e) {
                e.preventDefault();

                // 无内容退格时，删除已选中
                if (!$input.val() && e.keyCode == 8) {
                    $selectedList.children("li.selected-user:last").remove();
                    delayer.clear();
                    return;
                }

                delayer.call(function () {
                    $.get(options.fetchUsersUrl, { keyword: $input.val() }, function (users) {
                        if ($.isArray(users) && users.length > 0) {
                            $optionList.empty();

                            $.each(users, function (index, user) {
                                var item = "<li><a href='javascript:;'>" + user.name + "</a></li>";
                                $(item).data("user", user).appendTo($optionList[0]);
                            });

                            // 显示选择列表
                            if ($optionPanel.is(":hidden")) {
                                $optionPanel.show();
                            }
                        }
                    });
                });
            });

        // 选择用户
        $optionList.on("click", "li", function (e) {
            var $this = $(this),
                user = $this.data("user");

            // 暂时只实现单选
            $selectedList.children("li.selected-user").remove();
            $selectedList.prepend('<li class="selected-user label bg-danger">\
                                        <span>' + user.name + '</span>\
                                        <a href="javascript:;">\
                                            <i class="fa fa-close"></i>\
                                        </a>\
                                        <input type="hidden" name="' + options.name + '" value="' + user.id + '" />\
                                    </li>');

            // 添加到历史数据
            setHistory(user);

            // 清空输入框内容
            $input.val("");

            hideOptionPanel();
        });

        // 移除用户
        $selectedList.on("click", ".fa-close", function (e) {
            $(this).closest("li").remove();
        });

        // 点击别处，隐藏待选列表
        $(document).on("click", "*", function (e) {
            var $target = $(e.target || e.srcElement);

            if ($target.closest("div.user-selector-container").length) {
                return;
            }

            hideOptionPanel();
        });
    };

    // Default Options
    $.fn.userpicker.default = {
        name: undefined,
        placeholder: "选择用户...",
        fetchUsersUrl: "User/UserPickerData",
    };
});