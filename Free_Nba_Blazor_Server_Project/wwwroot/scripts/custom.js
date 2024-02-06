window.initializeAccordion = () => {
    // Gerekirse başlangıçta accordion'u hazırla
    var accordions = document.querySelectorAll('.accordion-item');

    accordions.forEach((accordion) => {
        accordion.addEventListener('click', function () {
            // Tıklandığında diğer accordions'ları kapat
            accordions.forEach((otherAccordion) => {
                if (otherAccordion !== accordion) {
                    otherAccordion.classList.remove('active');
                }
            });

            // Tıklandığında seçili accordion'u aç/kapat
            accordion.classList.toggle('active');
        });
    });
};

window.toggleAccordion = (id) => {
    // id parametresini kullanarak belirli accordion'u aç/kapat işlemini gerçekleştir
    var targetAccordion = document.getElementById(`flush-collapse${id}`);

    if (targetAccordion) {
        targetAccordion.classList.toggle('active');
    }
};
