let conteiner_products = document.getElementById("conteiner_textfields-products");
let conteiner_customers = document.getElementById("conteiner_textfields-customers");
let conteiner_orders = document.getElementById("conteiner_textfields-orders");

let btns_for_prod = document.querySelectorAll(".btn_for_products");

for (let i = 0; i < btns_for_prod.length; i++) {
    btns_for_prod[i].onclick = function () {
        addInConteinProd(btns_for_prod[i].value);
    }
}


function addInConteinProd(value) {
    switch (value) {
        case "create":
            conteiner_products.innerHTML = `
                <form action="/PersonAccount/AddProductinDB" data-ajax="true" data-ajax-method="GET" data-ajax-mode="replace"
                    data-ajax-update="#conteiner_info-inner" data-ajax-url="https://localhost:44319/PersonAccount/AddProductinDB" id="form0" method="post">
                    <div class="conteiner_textfields-products-inner">
                        <p>Name</p>
                        <input type="text" name="name_prod" placeholder="Name" />
                    </div>
                    <div class="conteiner_textfields-products-inner">
                        <p>Quantity</p>
                        <input type="number" name="quantity_prod"/>
                    </div>
                    <div class="conteiner_textfields-products-inner">
                        <p>Image</p>
                        <input type="hidden" id="image_path" name="image_prod" />
                        <input type="file" id="image" placeholder="Image" />
                    </div>
                    <div class="conteiner_textfields-products-inner">
                        <p>Price</p>
                        <input type="text" name="price_prod"/>
                    </div>
                    <button type="send">Add product</button>
                </form>
            `
            document.getElementById("image").onblur = function () {
                document.getElementById("image_path").value = document.getElementById("image").value.slice(12);
            }
            break;
        case "update":
            conteiner_products.innerHTML = `
                <form action="/PersonAccount/UpdateProductinDB" data-ajax="true" data-ajax-method="GET" data-ajax-mode="replace"
                    data-ajax-update="#conteiner_info-inner" data-ajax-url="https://localhost:44319/PersonAccount/UpdateProductinDB" id="form0" method="post">
                    <div class="conteiner_textfields-products-inner">
                        <p>Id product</p>
                        <input type="number" name="id_prod"/>
                    </div>
                    <div class="conteiner_textfields-products-inner">
                        <p>Name</p>
                        <input type="text" name="name_prod" placeholder="Name" />
                    </div>
                    <div class="conteiner_textfields-products-inner">
                        <p>Quantity</p>
                        <input type="text" name="quantity_prod"/>
                    </div>
                    <div class="conteiner_textfields-products-inner">
                        <p>Image</p>
                        <input type="hidden" id="image_path" name="image_prod" />
                        <input type="file" id="image" placeholder="Image" />
                    </div>
                    <div class="conteiner_textfields-products-inner">
                        <p>Price</p>
                        <input type="text" name="price_prod"/>
                    </div>
                    <button type="send">Update product</button>
                </form>
            `
            document.getElementById("image").onblur = function () {
                document.getElementById("image_path").value = document.getElementById("image").value.slice(12);
            }
            break;
        case "delete":
            conteiner_products.innerHTML = `
                <form action="/PersonAccount/DeleteProductinDB" data-ajax="true" data-ajax-method="GET" data-ajax-mode="replace"
                    data-ajax-update="#conteiner_info-inner" data-ajax-url="https://localhost:44319/PersonAccount/DeleteProductinDB" id="form0" method="post">
                    <div class="conteiner_textfields-products-inner">
                        <p>Id product</p>
                        <input type="number" name="id_prod"/>
                    </div>
                    
                    <button type="send">Delete product</button>
                </form>
            `
            break;
    }
}
