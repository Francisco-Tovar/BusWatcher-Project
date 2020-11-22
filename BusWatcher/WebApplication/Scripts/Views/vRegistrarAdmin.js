
function vRegistrarAdmin() {
	
	this.service = 'usuario';
	this.ctrlActions = new ControlActions();
	

	this.Create = function () {
		var usuarioData = {};
		usuarioData = this.ctrlActions.GetDataForm('frmRegistro');
		// estado predeterminado del usuario puede cambiarse a pendiente luego para aprobacion
		usuarioData.estadoUsuario = "Activo";
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, usuarioData);
		
	}


}

//ON DOCUMENT READY
$(document).ready(function () {

	var vusuario = new vUsuarios();
	

});

