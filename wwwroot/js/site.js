// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let addBtn = document.getElementById('addBtn');
let addNum = document.getElementById('addNumber');
let num = document.getElementById('num');
let textNumbers = document.getElementById('textNumbers');
let form = document.getElementById('addForm');
let resetBtn = document.getElementById('resetBtn');
let popModal = document.getElementById('popModal');

if (popModal.innerHTML == 'True') {
    openModal();
    popModal.innerHTML = 'False';
}

resetBtn.addEventListener('click', resetData)

addBtn.addEventListener('click', () => {
    if (isNaN(parseInt(addNum.value))) {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Please Enter a Number'
        })
    } else {
        num.innerHTML += `${addNum.value}, `;
        textNumbers.value += `${addNum.value},`;
        form.reset();
    }
})
addNum.addEventListener('keypress', (keypress) => {
    if (keypress.key == 'Enter') {
        keypress.preventDefault();
        if (isNaN(parseInt(addNum.value))) {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Please Enter a Number'
            })
        } else {
            num.innerHTML += `${addNum.value}, `;
            textNumbers.value += `${addNum.value},`;
            form.reset();
        }
    }
})

function resetData() {
    textNumbers.value = '';
    num.innerHTML = '';
}

function openModal() {
    let modal = new bootstrap.Modal(document.getElementById("exampleModal"), {});
    modal.show();
}