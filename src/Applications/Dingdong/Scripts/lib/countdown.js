
(function ($) {

    // Countdown jQuery plugin
    $.fn.countdown = function () {

        var $this = $(this),
            text = $this.text(),
            pattern = /(\d+)天(\d+)小时(\d+)分(\d+)秒/;

        if (!pattern.test(text)) {
            return;
        }

        var matches = pattern.exec(text /* 1天2小时3分4秒 */),
			day = parseInt(matches[1]),
			hour = parseInt(matches[2]),
			minute = parseInt(matches[3]),
			second = parseInt(matches[4]);

        // debug time span
        // var prevTime = new Date().valueOf();

        setTimeout(function () {

            // debug time span
            // console.log(new Date().valueOf() - prevTime);
            // prevTime = new Date().valueOf();

            if (second == 0) {
                if (minute == 0) {
                    if (hour == 0) {
                        if (day == 0) {
                            return;
                        } else {
                            day--;
                        }

                        hour = 23;
                    } else {
                        hour--;
                    }

                    minute = 59;
                } else {
                    minute--;
                }

                second = 59;
            } else {
                second--;
            }

            $this.text(day + "天" + hour + "小时" + minute + "分" + second + "秒");

            setTimeout(arguments.callee, 1000);
        }, 1000);
    }

})(window.jQuery);
