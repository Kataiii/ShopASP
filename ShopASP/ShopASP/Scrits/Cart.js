/*let counter = document.getElementById("counter");
let count = 0;
let arr_products = [];

let buttons_add = document.querySelectorAll(".add_to_cart");

for (let i = 0; i < buttons_add.length; i++) {
    buttons_add[i].onclick = function () {
        
        if (buttons_add[i].type === "button") {
            let value = buttons_add[i].getAttribute("placeholder");
            let product = {
                id: value,
                quantity: 1
            }
            arr_products.push(product);
            count += 1;
            counter.innerText = count;
            buttons_add[i].setAttribute("type", "number");
            buttons_add[i].value = 1;
        } else {
            let value = buttons_add[i].value;
            let product = arr_products.find(item => item.id == buttons_add[i].getAttribute("placeholder"));
            let index = arr_products.indexOf(product);
            product.quantity = value;
            arr_products.splice(index, 1);
            arr_products.push(product);
        }
        console.log(arr_products);
    }
}*/

//let cart = document.getElementById("cart");

/*cart.onclick = function () {
    console.log("AAAAAAAAAAAAA");
    let personId = document.getElementById("id_person").textContent;
    console.log(personId);
    let personWithOrder = {
        id: personId,
        order: arr_products
    };
    console.log(personWithOrder);
    console.log("qqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq");
    setOrder(personWithOrder);
}*/

/*async function setOrder(personWithOrder) {
    let resp = await fetch("/PersonAccount/ProductsinOrder", {
        method: "POST",
        headers: {
            'Content-Type': 'application/json;charset=utf-8'
        },
        body: JSON.stringify(personWithOrder)
    });
    //let result = await resp.json();
    //console.log(result);
}*/

//let div_button_add = document.getElementById("button-inner");

/*div_button_add.innerHTML = `
    <button type="submit" name="action" value="add_to_cart">Add to cart</button>
`*/
let arrayBtnAddCar = document.querySelectorAll(".button_add_cart");
let arratInputQuantity = document.querySelectorAll(".input_value_quantity");
//let arrayDivBtn = 

/*div_button_add.onclick = function () {
    div_button_add.innerHTML = `
    <button type="submit" name="action" value="reduce_quantity">-</button>
    <input type="text" id="value_quantity" value = "1">
    <button type="submit" name="action" value="add_quantity">+</button>
`
}*/
