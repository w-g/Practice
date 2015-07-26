/*
 * 一些对jQuery对象的扩展
 */


(function ($) {

	/* 扩展 :file 使其支持图片的本地预览
	 ************************************/

	$.fn.preview = function ($img) {

		var self = this[0],
			img = $img[0];

		if (self.type != "file") {
			throw "只支持input:file";
		}

		try {
			if (self.files && self.files[0]) {
				img.src = URL.createObjectURL(self.files[0]);
			} else {
				// 所谓的滤镜
				img.style.filter = "progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale)";
				img.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = self.value;
			}

			img.width = 100;
		}
		catch (ecp) {
			alert("不支持的文件类型");
			console.log(ecp.message);
		}
	};


})(window.jQuery);
