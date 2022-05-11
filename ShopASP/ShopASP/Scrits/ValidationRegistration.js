console.log("Hello world");
let button = document.getElementById("submit");
let map = new Map();
map.set("Firstname", false);
map.set("Surname", false);
map.set("Patronymic", false);
map.set("Phone", false);
map.set("Email", false);
map.set("Password", false);


//Surname
let user_surname = document.getElementById("surname");

user_surname.onblur = function () {
    if (user_surname === undefined || user_surname.value === "") {
        user_surname.style.border = "2px solid #F30404";
        user_surname.placeholder = "Incorrectly filled in field";
        map.set("Surname", false);
    } else {
        user_surname.style.border = "2px solid #000000";
        map.set("Surname", true);
    }
    check();
}

//Firstname
let user_name = document.getElementById("firstname");

user_name.onblur = function () {
    if (user_name === undefined || user_name.value === "") {
        user_name.style.border = "2px solid #F30404";
        user_name.placeholder = "Incorrectly filled in field";
        map.set("Firstname", false);
    } else {
        user_name.style.border = "2px solid #000000";
        map.set("Firstname", true);
    }
    check();
}

//Patronymic
let user_patronymic = document.getElementById("patronymic");

user_patronymic.onblur = function () {
    if (user_patronymic === undefined) {
        user_patronymic.style.border = "2px solid #F30404";
        user_patronymic.placeholder = "Incorrectly filled in field";
        map.set("Patronymic", false);
    } else {
        user_patronymic.style.border = "2px solid #000000";
        map.set("Patronymic", true);
    }
    check();
}

//Email
let user_email = document.getElementById("email");

user_email.onblur = function () {
    if (user_email === undefined || !validateEmail(user_email)) {
        user_email.style.border = "2px solid #F30404";
        user_email.placeholder = "Incorrectly filled in field";
        map.set("Email", false);
    } else {
        user_email.style.border = "2px solid #000000";
        map.set("Email", true);
    }
    check();
}

const validateEmail = (email) => {
    return email.value.match(
        /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
    );
};


//Phone
let inp = document.getElementById("login");

inp.onblur = function () {
    let regexp = /\+7\([0-9]{3}\)-[0-9]{3}-[0-9]{2}-[0-9]{2}/;
    if (inp === undefined || inp.value === "" || inp.value.match(regexp) == null) {
        inp.style.border = "2px solid #F30404";
        inp.placeholder = "Incorrectly filled in field";
        map.set("Phone", false);
    } else {
        inp.style.border = "2px solid #000000";
        map.set("Phone", true);
    }
    check();
}

inp.onclick = function () {
    if (inp.value == "" || inp === undefined) {
        inp.value = "+";
        old = 0;
    }
}

let old = 0;

inp.addEventListener('keypress', e => {
    if (!/\d/.test(e.key))
        e.preventDefault();
    var curLen = inp.value.length;

    if (curLen < old) {
        old--;
        return;
    }
    if (curLen == 2)
        inp.value = inp.value + "(";
    if (curLen == 6)
        inp.value = inp.value + ")-";
    if (curLen == 11)
        inp.value = inp.value + "-";
    if (curLen == 14)
        inp.value = inp.value + "-";
    if (curLen > 16)
        inp.value = inp.value.substring(0, inp.value.length - 1);

    old++;
});

//Password
let user_password = document.getElementById("password");
let user_password_repeat = document.getElementById("repeat_password");

user_password_repeat.onblur = function () {
    if (user_password === undefined || user_password === "" ||
        user_password_repeat === undefined || user_password_repeat === "" || !check_password(user_password_repeat.value, user_password.value)) {
        user_password.style.border = "2px solid #F30404";
        user_password_repeat.style.border = "2px solid #F30404";
        user_password.placeholder = "Incorrectly filled in field";
        map.set("Password", false);
    } else {
        user_password.style.border = "2px solid #000000";
        user_password_repeat.style.border = "2px solid #000000";
        map.set("Password", true);
    }
    check();
}

function check() {
    let flag = 0;
    for (let value of map.values()) {
        if (value == false) flag = 1;
    }
    if (flag == 0) button.removeAttribute("disabled");
}

function check_password(str1, str2) {
    if (str1.length != str2.length) return false;
    for (let i = 0; i < str1.length; i++) {
        if (str1[i] != str2[i]) return false;
    }
    return true;
}