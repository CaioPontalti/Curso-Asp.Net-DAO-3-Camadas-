//script para limitar o tamanho do campo  em 11 caracteres
function validaCampo() {
    var campo = document.getElementById("inputCPF");  /* Id do campo inputCPF */
    if (campo.value.length > 11)
    {
        campo.value = campo.value.substr(0, 11);
    }
}

//script permite digitar apenas numeros, apagar e enter
function onlynumber(evt) {
    var theEvent = evt || window.event;
    var key = theEvent.keyCode || theEvent.which;
    key = String.fromCharCode(key);
    //var regex = /^[0-9.,]+$/;
    var regex = /^[0-9.]+$/;
    if (!regex.test(key) && theEvent.keyCode !== 13)  {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}
