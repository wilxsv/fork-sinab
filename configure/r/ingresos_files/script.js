function AlertDialog(btn_yes, message, condition, key) {
    var btns = {};


    if (condition == 1 || condition == 3) {
        btns[btn_yes] = function () {
            __doPostBack(key, true);
            $(this).dialog("close");
        };
    } else {
        btns[btn_yes] = function () {
            $(this).dialog("close");
        };
    }


    $('<div></div>').appendTo('body')
                    .html('<div>' + message + '</div>')
                    .dialog({
                        modal: true,
                        title: key,
                        zIndex: 10000,
                        autoOpen: true,
                        minWidth : '200',
                        resizable: false,
                        buttons: btns
                    });
};

function ConfirmDialog(btn_yes, btn_no, message, condition, key) {
    var btns = {};

    switch (condition) {
        case 1:
            btns[btn_yes] = function () {
                __doPostBack(key, true);
                $(this).dialog("close");
            };

            btns[btn_no] = function () {
                $(this).dialog("close");
            };
            break;
        case 2:
            btns[btn_yes] = function () {
                $(this).dialog("close");
            };

            btns[btn_no] = function () {
                __doPostBack(key, false);
                $(this).dialog("close");
            };
            break;
        case 3:
            btns[btn_yes] = function () {
                __doPostBack(key, true);
                $(this).dialog("close");
            };

            btns[btn_no] = function () {
                __doPostBack(key, false);
                $(this).dialog("close");
            };
            break;
        default:
            btns[btn_yes] = function () {
                $(this).dialog("close");
            };

            btns[btn_no] = function () {
                $(this).dialog("close");
            };
    }

    $('<div></div>').appendTo('body')
                    .html('<div>' + message + '</div>')
                    .dialog({
                        modal: true,
                        title: key,
                        zIndex: 10000,
                        autoOpen: true,
                        minWidth: '200',
                        resizable: false,
                        buttons: btns
                    });
};

var obj = "<div class='AdminItem' style='display:block; height:42px;'><div style='padding: 4px 0px; float:left'><label for='tbNombreAdmin'>Nombre : </label><input type='text' id='tbNombreAdmin' style=width:150px;margin-right:8px;'></input><label for='tbCargoAdmin'>Cargo : </label><input type='text' id='tbCargoAdmin' style=width:100px;margin-right:8px;'></input></div><div class='Grid' style='border:none !important;padding:4px;'><a class='GridAgregar AdminAdd' title='Agregar' style='float:left; padding:0px 4px; '></a> <a class='GridBorrar AdminDel' title='Borrar' style='float:left; padding:0px 4px;'></a></div></div>";
function AgregarElemento(agregar, field) {
    if (agregar) {
        $(".groupAdmin fieldset").append(obj);
    } else {
        field.parent().parent().remove();
    }

    $(".AdminAdd").click(function () {
        AgregarElemento(true, $(this));
    });
    $(".AdminDel").click(function () {
        AgregarElemento(false, $(this));
    });
}
/*
//Script para que no funcione el boton atras del navegador
if (history.forward(1)) { location.replace(history.forward(1)) }

document.onkeydown = function() {
var key = event.keyCode;
var tE = event.srcElement;

//T1 es para los nombres
var t1 = tE.type;

//Ya que los links no tienen la propiedad Type, se utiliza la propiedad tagName
var t2 = tE.tagName;

var texto = (t1 == 'textarea' || t1 == 'text' || t1 == 'password') ? 1 : 0;
var textoEnter = (t1 == 'textarea' || t1 == 'button' || t1 == 'submit' || t2 == 'A') ? 1 : 0;

var calendarPopup = 0;

if (t1 == 'button') {
if (tE.onclick.toString().indexOf('CalendarPopup') > -1) {
calendarPopup = 1;
}
}

var disabled = (texto == 1) ? tE.disabled : false;
var readOnly = (texto == 1) ? tE.readOnly : false;

//tecla "Backspace"
if ((key == 8 && texto == 0) || (key == 8 && (disabled || readOnly))) {
//Se bloquea
event.keyCode = 0;
event.returnValue = false;
}

if (key == 13 && (textoEnter == 0 || calendarPopup == 1)) {
//Se convierte en tab
event.keyCode = 9;
}
}

//Funcion Javascript
function cpS(valor) {
ed = objects[0];
document.getElementById(ed.DivID).focus();
s = document.selection.createRange();
s.pasteHTML(valor);
}

function validarCantidades(val, args) {

var eCantidad1 = document.getElementById('ctl00_PageContent_nbCantidad');
var eCantidad2 = document.getElementById('ctl00_PageContent_nbCantidad1');

if (eCantidad1.value == '' || eCantidad2.value == '') {
args.IsValid = true;
}
else {
var cantidad1 = parseFloat(eCantidad1.value);
var cantidad2 = parseFloat(eCantidad2.value);

if ((cantidad1 + cantidad2) > 0) {
args.IsValid = true;
}
else {
args.IsValid = false;
}
}

}
*/