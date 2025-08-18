


document.querySelectorAll('.bt-collapse').forEach(caret => {
    caret.addEventListener('click', function (event) {
        event.preventDefault(); // prevent link click
        event.stopPropagation(); // stop it from bubbling to <a>
        const icon = this.querySelector('i');
        const submenu = this.closest('li').querySelector('.submenu');

        // Toggle submenu visibility
        const isOpen = submenu.style.display === 'block';
        submenu.style.display = isOpen ? 'none' : 'block';
        //icon.classList.toggle('fa-caret-down', isOpen);
        //icon.classList.toggle('fa-caret-up', !isOpen);
        if (isOpen) {
            icon.classList.remove('fa-caret-up');
            icon.classList.add('fa-caret-down');

        } else {
            icon.classList.remove('fa-caret-down');
            icon.classList.add('fa-caret-up');
        }
    });
});