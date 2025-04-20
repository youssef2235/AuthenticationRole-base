document.addEventListener('DOMContentLoaded', function () {
    // تحسين المراقب للعناصر عند الظهور
    if ('IntersectionObserver' in window) {
        const productCards = document.querySelectorAll('.product-card');

        // تهيئة جميع البطاقات بدون حركة في البداية
        productCards.forEach(card => {
            card.style.animation = 'none';
            card.style.opacity = '0';
        });

        const observer = new IntersectionObserver((entries) => {
            entries.forEach((entry, index) => {
                if (entry.isIntersecting) {
                    // تطبيق تأثير الظهور بشكل متدرج
                    setTimeout(() => {
                        entry.target.style.animation = `fadeInUp 0.7s cubic-bezier(0.25, 0.46, 0.45, 0.94) forwards`;
                    }, index * 150); // زيادة التأخير لجعل الحركة أكثر وضوحاً

                    // إزالة المراقبة بعد التنفيذ
                    observer.unobserve(entry.target);
                }
            });
        }, {
            threshold: 0.15,
            rootMargin: '0px 0px -50px 0px'
        });

        productCards.forEach(card => {
            observer.observe(card);
        });
    }

    // تأثير إضافي عند تحريك الماوس على البطاقات
    const cards = document.querySelectorAll('.product-card');
    cards.forEach(card => {
        card.addEventListener('mouseenter', function () {
            this.querySelector('.details-button').classList.add('hover-effect');
        });

        card.addEventListener('mouseleave', function () {
            this.querySelector('.details-button').classList.remove('hover-effect');
        });
    });
});