//contar();

function contar() {
	var nFilas = $("#alertas tr").length;
	var nColumnas = $("#alertas tr:last td").length;
	var msg = nFilas - 1;
	if (msg < 0) {
		msg = '';
	}
	$("#notify").text(msg);    
};
