
/* =========================================================
 * 实现同步POST请求方式的超链接
 ***********************************************************
 * 借用form，设置其action为post，
 * 然后提交form间接实现link的post提交效果
 * ========================================================= */

$("a[data-plugin='post-link']").on("click", function (e) {
    var $this = $(this),
        $form = $("<form>");

    $form.attr("method", "post")
        .attr("action", $this.attr("href"));

    $form.submit();

    e.preventDefault();
});