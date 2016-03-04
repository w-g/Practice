
/* =========================================================
 * 实现同步POST请求方式的超链接
 ***********************************************************
 * 借用form，设置其action为post，
 * 然后提交form间接实现link的post提交效果
 * ========================================================= */

$("a[data-trigger='post-link']").on("click", function (e) {
    e.preventDefault();

    var $this = $(this),
        $form = $("<form>");

    if (confirm("confirm message")/* not required */) {

        $form.attr("method", "post")
            .attr("action", $this.attr("href"));

        $form.submit();
    }
});