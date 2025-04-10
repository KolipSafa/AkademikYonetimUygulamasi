// Tooltip'leri etkinleştir
$(function () {
    $('[data-bs-toggle="tooltip"]').tooltip();
});

// Confirm dialogs
function confirmDelete(event, itemName) {
    if (!confirm(`'${itemName}' öğesini silmek istediğinize emin misiniz?`)) {
        event.preventDefault();
    }
}

// Form validasyon mesajlarının Türkçe çevirisi
if ($.validator) {
    $.extend($.validator.messages, {
        required: "Bu alan zorunludur",
        remote: "Lütfen bu alanı düzeltin",
        email: "Lütfen geçerli bir e-posta adresi girin",
        url: "Lütfen geçerli bir web adresi girin",
        date: "Lütfen geçerli bir tarih girin",
        dateISO: "Lütfen geçerli bir tarih girin (ISO)",
        number: "Lütfen geçerli bir sayı girin",
        digits: "Lütfen sadece sayısal karakterler girin",
        creditcard: "Lütfen geçerli bir kredi kartı numarası girin",
        equalTo: "Lütfen aynı değeri tekrar girin",
        extension: "Lütfen geçerli uzantıya sahip bir dosya seçin",
        maxlength: $.validator.format("Lütfen en fazla {0} karakter girin"),
        minlength: $.validator.format("Lütfen en az {0} karakter girin"),
        rangelength: $.validator.format("Lütfen {0} ile {1} arasında karakter girin"),
        range: $.validator.format("Lütfen {0} ile {1} arasında bir değer girin"),
        max: $.validator.format("Lütfen {0} değerine eşit ya da daha küçük bir değer girin"),
        min: $.validator.format("Lütfen {0} değerine eşit ya da daha büyük bir değer girin")
    });
} 