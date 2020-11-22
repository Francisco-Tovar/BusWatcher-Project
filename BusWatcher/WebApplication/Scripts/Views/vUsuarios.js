
function vUsuarios() {

	this.tblUsuariosId = 'tblUsuarios';
	this.service = 'usuario';
	this.ctrlActions = new ControlActions();
	this.columns = "cedula,nombre,apellido1,apellido2,dob,correoUsuario,contrasena,telefono,estadoUsuario";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblUsuariosId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblUsuariosId, true);
	}

	this.Create = function () {
		var usuarioData = {};
		usuarioData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, usuarioData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var usuarioData = {};
		usuarioData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, usuarioData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Deactivate = function () {

		var usuarioData = {};
		usuarioData = this.ctrlActions.GetDataForm('frmEdition');

        if (usuarioData.estadoUsuario == "Activo") {
			usuarioData.estadoUsuario = "Inactivo";
        } else {
			usuarioData.estadoUsuario = "Activo";
        }
		
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, usuarioData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Delete = function () {

		var usuarioData = {};
		usuarioData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, usuarioData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vusuario = new vUsuarios();
	vusuario.RetrieveAll();

});

