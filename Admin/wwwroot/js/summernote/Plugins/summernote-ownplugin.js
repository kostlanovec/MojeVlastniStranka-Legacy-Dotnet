(function (factory) {
    if (typeof define === "function" && define.amd) {
        define(["jquery"], factory);
    } else if (typeof module === "object" && module.exports) {
        module.exports = factory(require("jquery"));
    } else {
        factory(window.jQuery);
    }
})(function ($) {
    $.extend($.summernote.plugins, {
        structurePlugin: function (context) {
            var ui = $.summernote.ui;
            var structureShown = false;

            // create button
            var structureButton = ui.button({
                contents: '<i class="fa fa-columns"/> Structure',
                tooltip: "Toggle Structure Visibility",
                click: function () {
                    structureShown = !structureShown;
                    var structureDivs = $(".structure-divs");

                    if (structureShown) {
                        structureDivs.show();
                    } else {
                        structureDivs.hide();
                    }
                },
            });

            var changeColorButton = ui.button({
                contents: '<i class="fa fa-paint-brush"/> Change Background Color',
                tooltip: "Change Background Color",
                click: function () {
                    $('.note-editable').addClass('body');
                },
            });

            // create dropdown menu
            var structureDropdown = ui.buttonGroup([
                ui.button({
                    className: 'dropdown-toggle',
                    contents: '<i class="fa fa-tag"/> Tag <span class="caret"></span>',
                    tooltip: 'Tags',
                    data: {
                        toggle: 'dropdown'
                    }
                }),
                ui.dropdown({
                    className: 'dropdown-style',
                    items: ['<li><a data-event="tag" href="#" data-tag="main">Main</a></li>',
                        '<li><a data-event="tag" href="#" data-tag="header">Header</a></li>',
                        '<li><a data-event="tag" href="#" data-tag="section">Section</a></li>',
                        '<li><a data-event="tag" href="#" data-tag="article">Article</a></li>',
                        '<li><a data-event="tag" href="#" data-tag="aside">Aside</a></li>',
                        '<li><a data-event="tag" href="#" data-tag="p">Paragraph</a></li>'].join('')
                })
            ]);

            // add the buttons and the dropdown to the toolbar
            context.memo('button.structurePlugin', function () {
                var buttonContainer = ui.buttonGroup([
                    structureButton,
                    changeColorButton,
                    structureDropdown
                ]);

                return buttonContainer.render();
            });

            // handle tag selection
            $(document).on('click', '[data-event="tag"]', function (e) {
                e.preventDefault();
                var tag = $(this).data('tag');
                if (!context.invoke('editor.hasFocus')) {
                    context.invoke('editor.focus');
                }
                if (tag === 'header' || tag === 'main') {
                    var structureTag = '<' + tag + ' class="structure-divs" style="border: 1px solid black; padding: 5px;"></' + tag + '>';
                    context.invoke('editor.insertNode', $(structureTag)[0]);
                } else {
                    var structureTag = '<main class="structure-divs" style="border: 1px solid black; padding: 5px;"><' + tag + '></' + tag + '></main>';
                    context.invoke('editor.insertNode', $(structureTag)[0]);
                }
            });

            // Add structure lines initially
            $(document).ready(function () {
                $(".structure-divs").css({
                    'border': '1px solid black',
                    'padding': '5px'
                }).hide();
            });
        }
    });
});
