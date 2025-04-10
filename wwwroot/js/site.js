// DOM hazır olduğunda çalıştırılacak kodlar
$(document).ready(function() {
    // Tooltipleri etkinleştir
    $('[data-bs-toggle="tooltip"]').tooltip();
    
    // Dropdown menülerin animasyonu
    $('.dropdown').on('show.bs.dropdown', function() {
        $(this).find('.dropdown-menu').first().addClass('fade-in');
    });
    
    // Otomatik kapanan uyarılar
    setTimeout(function() {
        $('.alert-dismissible').fadeOut('slow');
    }, 5000);
    
    // Sayfa yükleme animasyonu
    $('main').addClass('fade-in');
    
    // Tablolarda sıralama işlemleri için gerekli sınıflar
    $('.sortable').click(function() {
        const table = $(this).parents('table').eq(0);
        const rows = table.find('tr:gt(0)').toArray().sort(comparer($(this).index()));
        this.asc = !this.asc;
        if (!this.asc) {
            rows.reverse();
        }
        for (let i = 0; i < rows.length; i++) {
            table.append(rows[i]);
        }
        
        // Sıralama ikonları
        table.find('th').removeClass('sorting-asc sorting-desc');
        $(this).addClass(this.asc ? 'sorting-asc' : 'sorting-desc');
    });
    
    // Mobil cihazlarda dropdown menüyü otomatik kapat
    if (window.innerWidth < 992) {
        $('.navbar-nav .dropdown-item').click(function() {
            $('.navbar-collapse').collapse('hide');
        });
    }
    
    // Aktif menü öğesini vurgula
    highlightActiveMenuItem();
    
    // Responsive tablo işleme
    makeTableResponsive();
    
    // Form validasyonlarını güzelleştir
    enhanceFormValidation();
});

// Tablolar için karşılaştırma fonksiyonu
function comparer(index) {
    return function(a, b) {
        const valA = getCellValue(a, index);
        const valB = getCellValue(b, index);
        return $.isNumeric(valA) && $.isNumeric(valB) ? valA - valB : valA.toString().localeCompare(valB);
    };
}

// Tablo hücresindeki değeri al
function getCellValue(row, index) {
    return $(row).children('td').eq(index).text();
}

// Aktif menü öğesini vurgula
function highlightActiveMenuItem() {
    const currentUrl = window.location.pathname;
    $('.nav-link').each(function() {
        const linkUrl = $(this).attr('href');
        if (linkUrl && currentUrl.includes(linkUrl) && linkUrl !== '/') {
            $(this).addClass('active');
            if ($(this).hasClass('dropdown-toggle')) {
                $(this).parent().addClass('active');
            }
        } else if (currentUrl === '/' && linkUrl === '/') {
            $(this).addClass('active');
        }
    });
}

// Tabloları responsive yap
function makeTableResponsive() {
    $('.table').each(function() {
        if (!$(this).parent().hasClass('table-responsive')) {
            $(this).wrap('<div class="table-responsive"></div>');
        }
    });
}

// Form validasyonlarını güzelleştir
function enhanceFormValidation() {
    if ($.validator) {
        // Form validasyon mesajlarının Türkçe çevirisi
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
        
        // Validasyon hatalarını gösterme stili
        $.validator.setDefaults({
            errorElement: 'span',
            errorClass: 'field-validation-error text-danger',
            highlight: function(element) {
                $(element).addClass('is-invalid');
            },
            unhighlight: function(element) {
                $(element).removeClass('is-invalid');
            }
        });
    }
}

// Silme işlemi onayı
function confirmDelete(event, itemName) {
    event.preventDefault();
    
    if (confirm(`'${itemName}' öğesini silmek istediğinize emin misiniz?`)) {
        // İşleme devam et
        window.location.href = event.target.href;
    }
}

// Sayfalarda geri gitme işlemi
function goBack() {
    window.history.back();
}

// Sayfa kaydırma efekti
$('a[href^="#"]').on('click', function(event) {
    var target = $(this.getAttribute('href'));
    if (target.length) {
        event.preventDefault();
        $('html, body').stop().animate({
            scrollTop: target.offset().top - 70
        }, 500);
    }
});

// Yazdırma işlevi
function printContent(elementId) {
    const printContents = document.getElementById(elementId).innerHTML;
    const originalContents = document.body.innerHTML;
    
    document.body.innerHTML = printContents;
    window.print();
    document.body.innerHTML = originalContents;
    window.location.reload();
}

// Responsive tablo oluştur
function createResponsiveTable(tableSelector) {
    const table = $(tableSelector);
    const headers = [];
    
    // Başlıkları al
    table.find('th').each(function() {
        headers.push($(this).text());
    });
    
    // Mobil görünüm için tabloyu yeniden şekillendir
    if (window.innerWidth < 768) {
        table.find('tbody tr').each(function() {
            let mobileRow = '';
            $(this).find('td').each(function(i) {
                mobileRow += `<div class="mobile-table-row"><span class="mobile-table-heading">${headers[i]}</span><span class="mobile-table-content">${$(this).html()}</span></div>`;
            });
            $(this).html(`<td>${mobileRow}</td>`);
        });
        table.addClass('mobile-table');
    }
} 