
(function ($) {

    var $window = $(window),
        $document = $(document),

        attachEventListeners = function () {

            /* ======================================================================
             * 同步POST请求方式的超链接
             ************************************************************************
             * 借用form，设置其action为post，然后提交form间接实现link的post提交效果
             * ====================================================================== */
            $document.on("click", "a[data-role='post-link']", function (e) {

                e.preventDefault();

                var self = this,
                    confirmMsg = $(this).data("confirm"),
                    postAction = function () {
                        var tempFormId = "temp_form_" + Date.now();
                        $("body").append("<form id='" + tempFormId + "'></form>");
                        $("#" + tempFormId).attr("method", "post")
                            .attr("action", self.href)
                            .submit();
                    };

                // do post action
                if (confirmMsg) {
                    confirm(confirmMsg) && postAction();
                } else {
                    postAction();
                }
            });

            /* ======================================================================
             * checkbox组的全（不）选
             ************************************************************************
             * form中name相同的checkbox视为一组，切换全（不）选组的checkbox会被单独标
             * 记data-role="switch"和data-group="{name}"属性，
             * 注意：切换全（不）选组的checkbox不需要name属性（以防其value被错误的提交）
             * ====================================================================== */
            $document.on("click", ":checkbox", function () {

                // 忽略没有被form包裹的checkbox
                var $form = $(this).closest("form");
                if (!$form.length) {
                    return;
                }

                var self = this,
                    $self = $(this);

                if ($self.is("[data-role='switch']")) {
                    $form.find(":checkbox[name='" + $self.data("group") + "']")
                        .each(function (index, item) {
                            item.checked = self.checked;
                        });
                } else {

                    // 忽略没有name属性的checkbox
                    if (!self.name) {
                        return;
                    }

                    var $switch = $form.find(":checkbox[data-role='switch'][data-group='" + self.name + "']");
                    $switch.length && ($switch[0].checked = !$form.find(":checkbox[name='" + self.name + "']:not(':checked')").length);
                }
            });

        },

        detachEventListeners = function () {
            $document.off();
        };


    $document.ready(function () {

        attachEventListeners();

    });

    $window.on("unload", function () {
        detachEventListeners();
    });

})(window.jQuery);

