@*@model PGMG.Models.LlamadaSolicitadaViewModel *@
@model IEnumerable < PGMG.Models.LlamadaSolicitadaViewModel >


@{
    ViewBag.Title = "Respuestas de llamadas solicitadas ";
}

<script type="text/javascript" src="/functions.js"></script>
    <body onload="alert('Completada la carga de la página')"></body>

    <body class="w3">
        <div class="centrar">
            <hr />
            <h4>@ViewBag.Title</h4>
            <hr />
            <br />
            <table id="alertas" class="table table-striped">
                <thead>
                    <tr>
                        <th style="text-align: center">Fecha y hora</th>
                        <th style="text-align: center">Cliente</th>
                        <th style="text-align: center">Empleado</th>
                        <th style="text-align: center">Teléfono</th>
                        <th style="text-align: center">Observaciones</th>
                        <th style="text-align: center">Estado llamada</th>
                        <th style="text-align: center">Telefonista</th>
                        <th style="text-align: center">Acción</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var item in Model)
                    {
                        <tr>
                            <td>
                                @item.Fecha.ToShortDateString()  @item.Hora.ToShortTimeString()
                            </td>
                            <td>
                                @Html.DisplayFor(modelItem => item.NombreCliente)
                            </td>
                            <td>
                                @Html.DisplayFor(modelItem => item.NombreEmpleado)
                            </td>
                            <td>
                                @Html.DisplayFor(modelItem => item.Telefono)
                            </td>
                            <td>
                                @Html.DisplayFor(modelItem => item.Observaciones)
                            </td>
                            <td id="estado">
                                @Html.DisplayFor(modelItem => item.EstadoLlamada)
                            </td>
                            <td>
                                @Html.DisplayFor(modelItem => item.UsuarioTelef)
                            </td>
                            <td>
                                @if (item.EstadoLlamada == "Rechazada" || item.EstadoLlamada == "Suspendida")
                                {
                                    <a href="@Url.Action(" Edit3", "LlamadasSolicitadas", new {id = item.LlamadaSolicitadaId})" class="btn btn-default"
                                       data-target="#modal-eliminar" data-toggle="modal" title="Borrar alerta">
                                        <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                    </a>
                            }

                                @if (User.IsInRole("Administradora") || User.IsInRole("Consultora"))
                                {
                                <a href="@Url.Action(" Edit2", "Llamadas", new {id = item.LlamadaId})" target="_blank" class="btn btn-default"
                                       data-toggle="tooltip" title="Tomar llamada">
                                        <span class="glyphicon glyphicon-earphone" aria-hidden="true"></span>
                                    </a>
                    }
                    @if (User.IsInRole("Administradora") || User.IsInRole("Telefonista"))
                                {
                        <a href="@Url.Action(" Edit", "LlamadasSolicitadas", new {id = item.LlamadaSolicitadaId})" target="_blank" class="btn btn-default"
                                       data-toggle="tooltip" title="Gestionar la llamada">
                                        <span class="glyphicon glyphicon-edit" aria-hidden="true"></span>
                                    </a>
                }
                            </td>
                        </tr>
        }
                </tbody>
            </table >
        </div >
    </body >

    <div class="modal fade" id="modal-eliminar" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
            </div>
        </div>
    </div>


@section Scripts{
    <script>
            //$(function hayalerta() {
            //    if (existen_registros(alertas)) {
            //        swal("Atención", "Tiene una nueva llamada", "success");

            //        console.log('La primera tabla tiene registros');
            //    }
            //    else {
            //        console.log('La primera tabla no tiene registros');
            //    }
            //    setInterval(hayalerta, 10000)
            //});

            //function existen_registros(tabla) {
            //    let filas = $(tabla).find('tbody tr').length;

            //    if (filas > 0) {
            //        return 1;
            //    }
            //    else {
            //        return 0;
            //    }
            //}
            contar();

        function contar() {
                var nFilas = $("#alertas tr").length;
                var nColumnas = $("#alertas tr:last td").length;
                var msg = nFilas - 1;
                if (msg < 0) {
            msg = '';
        }
                $("#notify").text(msg);
                //export {msg};
            };

                //module.exports = {
                //    "contar": contar
                //}

                //module.exports = contar;

        </script>
    }
