window.addEventListener('scroll', function () {
    const nav = document.querySelector('nav');
    const body = document.body;
    const main = document.querySelector('main');
    
    // Add 'nav-fixed' class when scrolling down
    if (window.scrollY > document.querySelector('header').offsetHeight) {
        body.classList.add('nav-fixed');
        main.style.marginTop = nav.offsetHeight + 'px';
    } else {
        // Remove 'nav-fixed' class when scrolling up
        body.classList.remove('nav-fixed');
        main.style.marginTop = 0;
        nav.style.left = '20px'; // Adjust the value as needed
    }
});