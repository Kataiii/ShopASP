let arrayBtnAddCar = document.querySelectorAll(".button_add_cart");
let counter = document.getElementById("counter");
let count = 0;
if (count == 0) counter.style.display = "none";

for (let i = 0; i < arrayBtnAddCar.length; i++) {
    
    arrayBtnAddCar[i].onclick = function () {
        counter.style.display = "block";
        count++;
        counter.innerText = count;
    }
}
