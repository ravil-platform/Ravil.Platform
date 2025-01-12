class MyUploadAdapter {
    constructor(loader) {
        // The file loader instance to use during the upload.
        this.loader = loader;
    }
    // Starts the upload process.
    upload() {
        return this.loader.file
            .then(file => new Promise((resolve, reject) => {
                this._initRequest();
                this._initListeners(resolve, reject, file);
                this._sendRequest(file);
            }));
    }
    // Aborts the upload process.
    abort() {
        if (this.xhr) {
            this.xhr.abort();
        }
    }
    // Initializes the XMLHttpRequest object using the URL passed to the constructor.
    _initRequest() {
        const xhr = this.xhr = new XMLHttpRequest();
        // Note that your request may look different. It is up to you and your editor
        // integration to choose the right communication channel. This example uses
        // a POST request with JSON as a data structure but your configuration
        // could be different.
        xhr.open('POST', '/UploadImage', true);
        xhr.responseType = 'json';
    }
    // Initializes XMLHttpRequest listeners.
    _initListeners(resolve, reject, file) {
        const xhr = this.xhr;
        const loader = this.loader;
        const genericErrorText = `Couldn't upload file: ${file.name}.`;
        xhr.addEventListener('error', () => reject(genericErrorText));
        xhr.addEventListener('abort', () => reject());
        xhr.addEventListener('load', () => {
            const response = xhr.response;
            // This example assumes the XHR server's "response" object will come with
            // an "error" which has its own "message" that can be passed to reject()
            // in the upload promise.
            //
            // Your integration may handle upload errors in a different way so make sure
            // it is done properly. The reject() function must be called when the upload fails.
            if (!response || response.error) {
                return reject(response && response.error ? response.error.message : genericErrorText);
            }
            // If the upload is successful, resolve the upload promise with an object containing
            // at least the "default" URL, pointing to the image on the server.
            // This URL will be used to display the image in the content. Learn more in the
            // UploadAdapter#upload documentation.
            resolve({
                default: response.url
            });
        });
        // Upload progress when it is supported. The file loader has the #uploadTotal and #uploaded
        // properties which are used e.g. to display the upload progress bar in the editor
        // user interface.
        if (xhr.upload) {
            xhr.upload.addEventListener('progress', evt => {
                if (evt.lengthComputable) {
                    loader.uploadTotal = evt.total;
                    loader.uploaded = evt.loaded;
                }
            });
        }
    }
    // Prepares the data and sends the request.
    _sendRequest(file) {
        // Prepare the form data.
        const data = new FormData();
        data.append('upload', file);
        // Important note: This is the right place to implement security mechanisms
        // like authentication and CSRF protection. For instance, you can use
        // XMLHttpRequest.setRequestHeader() to set the request headers containing
        // the CSRF token generated earlier by your application.
        // Send the request.
        this.xhr.send(data);
    }
}
function MyCustomUploadAdapterPlugin(editor) {
    editor.plugins.get('FileRepository').createUploadAdapter = (loader) => {
        // Configure the URL to the upload script in your back-end here!
        return new MyUploadAdapter(loader);
    };
}

ClassicEditor
    .create(document.querySelector('.ckeditor'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

ClassicEditor
    .create(document.querySelector('#ckeditor5'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

ClassicEditor
    .create(document.querySelector('#ckeditor5-1'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

ClassicEditor
    .create(document.querySelector('#ckeditor5-2'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

ClassicEditor
    .create(document.querySelector('#ckeditor5-3'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

ClassicEditor
    .create(document.querySelector('#ckeditor5-4'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

ClassicEditor
    .create(document.querySelector('#ckeditor5-5'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

ClassicEditor
    .create(document.querySelector('#ckeditor5-6'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

ClassicEditor
    .create(document.querySelector('#ckeditor5-7'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

ClassicEditor
    .create(document.querySelector('#ckeditor5-8'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);


ClassicEditor
    .create(document.querySelector('#ckeditor5-9'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

ClassicEditor
    .create(document.querySelector('#ckeditor5-10'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);


ClassicEditor
    .create(document.querySelector('#ckeditor5-11'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

ClassicEditor
    .create(document.querySelector('#ckeditor5-12'), {
        extraPlugins: [MyCustomUploadAdapterPlugin],
        // Editor configuration.
        //پشتیبانی از تگ های HTML
        htmlSupport: {
            allow: [
                {
                    name: /.*/,
                    attributes: true,
                    classes: true,
                    styles: true
                }
            ]
        },
        //edit toolbar
        toolbar: {
            items: [
                'undo', 'redo',
                '|', 'heading',
                '|', 'fontColor', 'fontBackgroundColor',
                '|', 'bold', 'italic', 'code',
                '|', 'uploadImage',/*'imageInsert'*/ 'mediaEmbed',
                '|', 'link', 'blockQuote', 'codeBlock',
                '|', 'alignment',
                '|', 'bulletedList', 'numberedList', 'outdent', 'indent',
                '|', 'htmlEmbed', 'sourceEditing'
            ],
            shouldNotGroupWhenFull: false
        },
        //edit heading
        heading: {
            options: [
                { model: 'paragraph', title: 'Paragraph', class: 'ck-heading_paragraph' },
                { model: 'heading1', view: 'h1', title: 'Heading 1', class: 'ck-heading_heading1' },
                { model: 'heading2', view: 'h2', title: 'Heading 2', class: 'ck-heading_heading2' },
                { model: 'heading3', view: 'h3', title: 'Heading 3', class: 'ck-heading_heading3' },
                { model: 'heading4', view: 'h4', title: 'Heading 4', class: 'ck-heading_heading4' },
                { model: 'heading5', view: 'h5', title: 'Heading 5', class: 'ck-heading_heading5' },
                { model: 'heading6', view: 'h6', title: 'Heading 6', class: 'ck-heading_heading6' },
                //{ model: 'gallery1', view: { name: 'div', classes: 'gallery gallery-1' }, title: 'Gallery1', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery2', view: { name: 'div', classes: 'gallery gallery-2' }, title: 'Gallery2', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery3', view: { name: 'div', classes: 'gallery gallery-3' }, title: 'Gallery3', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery4', view: { name: 'div', classes: 'gallery gallery-4' }, title: 'Gallery4', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery5', view: { name: 'div', classes: 'gallery gallery-5' }, title: 'Gallery5', class: 'ck-Gallery', converterPriority: 'high' },
                //{ model: 'gallery6', view: { name: 'div', classes: 'gallery gallery-6' }, title: 'Gallery6', class: 'ck-Gallery', converterPriority: 'high' },
            ]
        },
        //edit link
        link: {
            addTargetToExternalLinks: true,
            decorators: [
                { mode: 'manual', label: 'قابلیت دانلود', attributes: { download: 'download' }, defaultValue: false, },
            ],
        },
        //edit font color
        fontColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
                { color: '#f7f7f7', label: 'خاکستری' },
            ]
        },
        //edit background color
        fontBackgroundColor: {
            colors: [
                { color: 'red', label: 'قرمز' },
                { color: 'green', label: 'سبز' },
                { color: 'blue', label: 'آبی' },
                { color: 'pink', label: 'صورتی' },
            ]
        },
    })
    .then(editor => {
        window.editor = editor;
    })
    .catch(handleSampleError);

function handleSampleError(error) {
    const issueUrl = 'https://github.com/ckeditor/ckeditor5/issues';
    const message = [
        'Oops, something went wrong!',
        `Please, report the following error on ${issueUrl} with the build id "npwdoukyfz5-3bd6as171pns" and the error stack trace:`
    ].join('\n');
    console.error(message);
    console.error(error);
}