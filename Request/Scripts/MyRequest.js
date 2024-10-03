document.querySelectorAll('.row-check').forEach(function (checkbox) {
    checkbox.addEventListener('change', function () {
        const row = this.closest('tr'); // Get the closest row to the checkbox
        if (this.checked) {
            row.classList.add('highlight');
        } else {
            row.classList.remove('highlight');
        }
    });
});