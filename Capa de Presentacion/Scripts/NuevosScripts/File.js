function Modal() {
    Limpiar();
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#ModalDatosCompra').modal('show');
}

function Limpiar() {
    $('.txtLimpiar').val('');
    $('#sltEstado').val(0);
}