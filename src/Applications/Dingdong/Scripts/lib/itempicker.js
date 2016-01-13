/**
 * Item Picker
 */

(function (factory) {

    if (typeof define === 'function' && define.amd) {
        define(["jquery", "delayer"], factory);
    } else {
        factory(window.jQuery, window.Delayer);
    }

})(function ($, Delayer) {

    // Plugin Definition
    $.fn.itempicker = function (options) {

        var $container = $(this),
            threshold = 5, /* 历史数据数组阈值 */
            delayer = new Delayer(800), /* 做延迟加载的延迟器 */
            ipickerHistoryKey = $container.data("ipickerType") + "PickerHistory", /* 历史数据键值 */
            $optionPanel = $container.find(".ipicker-option-panel"),
            $optionList = $container.find(".ipicker-option-list"),
            $selectedList = $container.find(".ipicker-panel"),
            $input = $selectedList.find(".search-field input");

        // 保证调用者设置的优先级最高
        options = $.extend({}, $.fn.itempicker.default, options);

        options.name = $container.data("ipickerName");
        options.mode = $container.data("ipickerMode");
        options.placeholder = $container.data("ipickerPlaceholder");
        options.fetchItemsUrl = $container.data("ipickerFetchItemsUrl");

        // 设置input的placeholder
        $input.attr("placeholder", options.placeholder);

        // 获取历史数据
        function getHistory() {
            var history = localStorage[ipickerHistoryKey];
            if (history) {
                history = JSON.parse(history);
            }

            return history;
        }

        // 添加历史数据
        function setHistory(item) {
            var history = getHistory();
            if ($.isArray(history)) {
                if (history.length > threshold - 1) {
                    history.shift();
                }
            } else {
                history = [];
            }

            var flag = false;
            $.each(history, function (index, _item) {
                if (_item.id == item.id) {
                    flag = true;
                }
            });

            if (flag) {
                return;
            }

            history.push(item);

            // localStorage[ipickerHistoryKey] = JSON.stringify(history);
            // localStorage[ipickerHistoryKey] = JSON.stringify(history);
        }

        // 显示待选Item列表
        function showOptionPanel() {

            // 渲染列表
            var history = localStorage[ipickerHistoryKey];
            if (history) {
                history = JSON.parse(history);
                if (history.length > 0) {

                    // 清空列表
                    $optionList.empty();

                    $.each(history, function (index, item) {
                        var html = "<li><a href='javascript:;'>" + item.name + "</a></li>";
                        $(html).data("item", item).appendTo($optionList[0]);
                    });

                    $optionPanel.show();
                }
            }
        }

        // 隐藏待选Item列表
        function hideOptionPanel() {
            $optionList.empty();
            $optionPanel.hide();
        }

        // 删除已选Item
        function removeItem($item) {
            $item.remove();
            $container.trigger({ type: "ipicker.removed", item: $item.data("item") });
        }

        $input
            // 搜索输入框焦点事件
            .on("focus", function () {
                showOptionPanel();
            })
            // 搜索Item
            .on("keyup", function (e) {
                e.preventDefault();

                // 无内容退格时，删除已选中
                if (!$input.val() && e.keyCode == 8) {
                    removeItem($selectedList.children("li.ipicker-item:last"));
                    delayer.clear();
                    return;
                }

                delayer.call(function () {
                    $.get(options.fetchItemsUrl, { keyword: $input.val() }, function (items) {
                        if ($.isArray(items) && items.length > 0) {
                            $optionList.empty();

                            $.each(items, function (index, item) {
                                var html = "<li><a href='javascript:;'>" + item.name + "</a></li>";
                                $(html).data("item", item).appendTo($optionList[0]);
                            });

                            // 显示选择列表
                            if ($optionPanel.is(":hidden")) {
                                $optionPanel.show();
                            }
                        }
                    });
                });
            });

        // 选择Item
        $optionList.on("click", "li", function (e) {
            var $this = $(this),
                item = $this.data("item");

            // 单选时移除之前选择的
            if (options.mode === "single") {
                $selectedList.children("li.ipicker-item").remove();
            }

            $selectedList.prepend('<li class="ipicker-item label bg-danger">\
                                        <span>' + item.name + '</span>\
                                        <a href="javascript:;">\
                                            <i class="fa fa-close"></i>\
                                        </a>\
                                        <input type="hidden" name="' + options.name + '" value="' + item.id + '" />\
                                    </li>');

            // 添加到历史数据
            setHistory(item);

            // 清空输入框内容
            $input.val("");

            hideOptionPanel();
            
            $container.trigger({ type: "ipicker.picked", item: item });
        });

        // 移除Item
        $selectedList.on("click", ".fa-close", function (e) {
            removeItem($(this).closest("li"));
        });

        // 点击别处，隐藏待选列表
        $(document).on("click", "*", function (e) {
            var $target = $(e.target || e.srcElement);

            if ($target.closest("div.item-picker").length) {
                return;
            }

            hideOptionPanel();
        });

        return $container;
    };

    // Default Options
    $.fn.itempicker.default = {
        name: "",
        mode: "single", // multi多选
        placeholder: "选择...",
        fetchItemsUrl: ""
    };
});