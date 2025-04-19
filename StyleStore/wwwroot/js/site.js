document.addEventListener('DOMContentLoaded', function () {
    // Navbar scroll effect
    window.addEventListener('scroll', function () {
        if (window.scrollY > 50) {
            document.querySelector('.navbar').classList.add('shadow');
        } else {
            document.querySelector('.navbar').classList.remove('shadow');
        }
    });

    // Add to cart animation
    const addToCartButtons = document.querySelectorAll('.add-to-cart');
    addToCartButtons.forEach(button => {
        button.addEventListener('click', function () {
            button.innerHTML = 'Added ✓';
            button.classList.add('btn-success');
            setTimeout(() => {
                button.innerHTML = 'Add to Cart';
                button.classList.remove('btn-success');
            }, 2000);
        });
    });

    // Product image hover effect
    const productCards = document.querySelectorAll('.product-card');
    productCards.forEach(card => {
        card.addEventListener('mouseenter', function () {
            card.querySelector('.product-image').style.transform = 'scale(1.05)';
        });
        card.addEventListener('mouseleave', function () {
            card.querySelector('.product-image').style.transform = 'scale(1)';
        });
    });
});