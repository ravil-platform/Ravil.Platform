$(document).ready(function () {
    LoadCkEditor4();
});

function LoadCkEditor4() {
    var script = document.createElement("script");
    script.src = "/lib/ckeditor4/ckeditor/ckeditor.js";

    script.onload = function () {
        for (let i = 0; i <= 12; i++) {
            const editorId = i === 0 ? "ckeditor5" : `ckeditor5-${i}`;
            const element = document.getElementById(editorId);

            // فقط اگر المنت وجود داره، CKEditor رو جایگزین کن
            if (element) {
                try {
                    CKEDITOR.replace(editorId, {
                        customConfig: '/lib/ckeditor4/ckeditor/config.js'
                    });
                } catch (error) {
                    console.warn(`CKEditor initialization failed for: ${editorId}`, error);
                }
            }
        }
    };

    // اضافه کردن اسکریپت به صفحه
    document.body.appendChild(script);
}
