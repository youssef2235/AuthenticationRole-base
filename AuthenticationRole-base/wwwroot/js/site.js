// Navigation toggle functionality
document.addEventListener('DOMContentLoaded', function () {
    const navToggle = document.getElementById('navToggle');
    const navLinks = document.getElementById('navLinks');

    if (navToggle && navLinks) {
        navToggle.addEventListener('click', () => {
            navLinks.classList.toggle('active');
        });
    }

    // Close mobile menu when clicking outside
    document.addEventListener('click', function (event) {
        if (navLinks && navLinks.classList.contains('active') &&
            !navLinks.contains(event.target) &&
            event.target !== navToggle) {
            navLinks.classList.remove('active');
        }
    });
});

// WhatsApp button functionality
document.addEventListener('DOMContentLoaded', function () {
    const whatsappButton = document.querySelector('.whatsapp-button');

    if (whatsappButton) {
        whatsappButton.addEventListener('click', function (e) {
            e.preventDefault();
            window.open('https://wa.me/966123456789', '_blank');
        });
    }
});