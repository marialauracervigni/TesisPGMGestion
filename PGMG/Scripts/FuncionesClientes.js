﻿﻿var EmpleadosItems = new Listas();
var ModulosItems = new Listas();


function MostrarEmpleados(editar) {
    $('#EmpleadosItems').html('');
    if (EmpleadosItems.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped"/>');
        if (editar)
            $table.append('<thead><tr><th>Nombre</th><th>Puesto</th><th>Teléfono</th><th>Correo</th><th>Opción</th></tr></thead>');
        else
            $table.append('<thead><tr><th>Nombre</th><th>Puesto</th><th>Teléfono</th><th>Correo</th></tr></thead>');
        var $tbody = $('<tbody/>');
        for (var i = 0; i < EmpleadosItems.Total(); i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(EmpleadosItems.Item(i).NombreCompleto));
            $row.append($('<td/>').html(EmpleadosItems.Item(i).Puesto));
            $row.append($('<td/>').html(EmpleadosItems.Item(i).Telefono));
            $row.append($('<td/>').html(EmpleadosItems.Item(i).Correo));
            if (editar)
                $row.append($('<td/>').html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarEmpleado(" + i + ");'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#EmpleadosItems').html($table);
    }
}

function MostrarModulos(editar) {
    $('#ModulosItems').html('');
    if (ModulosItems.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped"/>');
        if (editar)
            $table.append('<thead><tr><th>Código</th><th>Módulo</th><th>Opción</th></tr></thead>');
        else
            $table.append('<thead><tr><th>Código</th><th>Módulo</th></tr></thead>');
        var $tbody = $('<tbody/>');
        for (var i = 0; i < ModulosItems.Total(); i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(ModulosItems.Item(i).CodigoModulo));
            $row.append($('<td/>').html(ModulosItems.Item(i).Descripcion));
            if (editar)
                $row.append($('<td/>').html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarModulo(" + i + ");'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#ModulosItems').html($table);
    }
}


function addModulo_Click() {
    ModulosItems.Agregar({
        ModuloId: 0,
        CodigoModulo: $('#CodigoModulo').val().trim(),
        Descripcion: $('#Modulo').val().trim(),
    });

$('#CodigoModulo').val('').focus();
$('#Modulo').val('');

MostrarModulos(true);
}


function addEmpleado_Click() {
    EmpleadosItems.Agregar({
        EmpleadoId: 0,
        NombreCompleto: $('#NombreCompleto').val().trim(),
        Puesto: $('#Puesto').val().trim(),
        Telefono: $('#Telefono').val().trim(),
        Correo: $('#Correo').val().trim(),
        Cliente_ClienteId: $('#Cliente_ClienteId').val().trim()
    });

    $('#NombreCompleto').val('').focus();
    $('#Puesto').val('');
    $('#Telefono').val('');
    $('#Correo').val('');

MostrarEmpleados(true);
}

function EliminarEmpleado(indice) {
    EmpleadosItems.Eliminar(indice);
    MostrarEmpleados(true);
    return false;
}

function EliminarModulo(indice) {
    ModulosItems.Eliminar(indice);
    MostrarModulos(true);
    return false;
}

//function crear_Click() {
//    var data = {
//        ClienteId: 0,
//        Nombre: $('#Nombre').val().trim(),
//        Localidad: $('#Localidad').val().trim(),
//        ProvinciaId: $('#ProvinciaId').val(),
//        Domicilio: $('#Domicilio').val().trim(),
//        Telefono: $('#Telefono').val().trim(),
//        Correo: $('#Correo').val().trim(),
//        FechaAlta: $('#FechaAlta').val().trim(),
//        FechaFundacion: $('#FechaFundacion').val().trim(),
//        Empleados: EmpleadosItems.lista,
//        Modulos: ModulosItems.lista
//    }

//    var token = $('[name=__RequestVerificationToken]').val();
//    //var url = '/Clientes/Edit/' + idCliente;
//    $.ajax({
//        url: '/Clientes/Crear/',
//        type: "POST",
//        data: { __RequestVerificationToken: token, cliente: data },
//        success: function (d) {
//            if (d === true) {
//                window.location.href = "/Clientes/Index2";
//            }
//            else {
//                alert('Ha ocurrido un error al intentar guardar');
//            }
//        },
//        error: function () {
//            alert('Error. Por favor intente de nuevo.');
//        }
//    });
//}

//function modificar_Click() {
//    var isAllValid = true;

//    if (isAllValid) {
//        var data = {
//            ClienteId: $('#ClienteId').val().trim(),
//            Nombre: $('#Nombre').val().trim(),
//            Localidad: $('#Localidad').val().trim(),
//            ProvinciaId: $('#ProvinciaId').val(),
//            Domicilio: $('#Domicilio').val().trim(),
//            Telefono: $('#Telefono').val().trim(),
//            Correo: $('#Correo').val().trim(),
//            FechaAlta: $('#FechaAlta').val().trim(),
//            FechaFundacion: $('#FechaFundacion').val().trim(),
//            Empleados: EmpleadosItems.lista,
//            Modulos: ModulosItems.lista
//        }
//        var idCliente = $('#ClienteId').val().trim();
//        var token = $('[name=__RequestVerificationToken]').val();
//        var url = '/Clientes/Edit2/' + idCliente;
//        $.ajax({
//            //url: '/Clientes/Edit/' + idCliente;
//            url: url,
//            type: "POST",
//            data: { __RequestVerificationToken: token, cliente: data },
//            success: function (d) {
//                if (d === true) {
//                    window.location.href = "/Clientes/Index2";
//                }
//                else {
//                    alert('Ha ocurrido un error al intentar guardar');
//                }
//            },
//            error: function () {
//                alert('Error. Por favor intente de nuevo.');
//            }
//        });
//    }
//}