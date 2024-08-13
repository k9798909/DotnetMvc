// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
jQuery.extend(jQuery.validator.messages, {
    required: "此欄位為必填。",
    remote: "請修正此欄位。",
    email: "請輸入有效的電子郵件地址。",
    url: "請輸入有效的 URL。",
    date: "請輸入有效的日期。",
    dateISO: "請輸入有效的日期 (ISO)。",
    number: "請輸入有效的數字。",
    digits: "請僅輸入數字。",
    creditcard: "請輸入有效的信用卡號碼。",
    equalTo: "請再次輸入相同的值。",
    accept: "請輸入具有有效副檔名的值。",
    maxlength: jQuery.validator.format("請輸入不超過 {0} 個字元。"),
    minlength: jQuery.validator.format("請輸入至少 {0} 個字元。"),
    rangelength: jQuery.validator.format("請輸入介於 {0} 到 {1} 個字元之間的值。"),
    range: jQuery.validator.format("請輸入介於 {0} 到 {1} 之間的值。"),
    max: jQuery.validator.format("請輸入小於或等於 {0} 的值。"),
    min: jQuery.validator.format("請輸入大於或等於 {0} 的值。")
});
