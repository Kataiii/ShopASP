let arrayBtnAddCar = document.querySelectorAll(".button_add_cart");
let counter = document.getElementById("counter");
let count;
if (sessionStorage.getItem('count') == null || sessionStorage.getItem('count') == 0) count = 0;
else count = sessionStorage.getItem('count').length;
if (count == 0) counter.style.display = "none";

for (let i = 0; i < arrayBtnAddCar.length; i++) {
    
    arrayBtnAddCar[i].onclick = function () {
        let array = [];
        if (sessionStorage.getItem('count') != null) {
            let array1 = sessionStorage.getItem('count');
            let flag = 0;
            for (let j = 0; j < array1.length; j++) {
                if (arrayBtnAddCar[i].value != array1[j]) flag = 1;
            }
            if (flag != 0) {
                count++;
                array.push(arrayBtnAddCar[i].value);
                for (let k = 0; k < array1.length; k++) {
                    array.push(array1[k]);
                }
                sessionStorage.setItem("count", array);
            }
        } else {
            array = [];
            array.push(arrayBtnAddCar[i]);
            count++;
            sessionStorage.setItem("count", array);
        }
        counter.style.display = "block";
        counter.innerText = count;
    }
}

document.getElementById("account").onclick = function () {
    sessionStorage.setItem('count', count);
}

document.getElementById("cart").onclick = function () {
    sessionStorage.setItem('count', count);
}

document.getElementById("btn_cart").onclick = function () {
    sessionStorage.setItem('count', 0);
}
