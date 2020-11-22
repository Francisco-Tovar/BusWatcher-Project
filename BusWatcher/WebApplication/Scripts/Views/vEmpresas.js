
function vEmpresas() {

	this.tblEmpresasId = 'tblEmpresas';
	this.service = 'empresa';
	this.ctrlActions = new ControlActions();
	this.columns = "cedulaJuridica,nombreComercial,nombreLegal,paginaWeb,telefono,estadoEmpresa";

	this.RetrieveAll = function () {
		this.ctrlActions.FillTable(this.service, this.tblEmpresasId, false);
	}

	this.ReloadTable = function () {
		this.ctrlActions.FillTable(this.service, this.tblEmpresasId, true);
	}

	this.Create = function () {
		var empresaData = {};
		empresaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PostToAPI(this.service, empresaData);
		//Refresca la tabla
		this.ReloadTable();
	}

	this.Update = function () {

		var empresaData = {};
		empresaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.PutToAPI(this.service, empresaData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.Delete = function () {

		var empresaData = {};
		empresaData = this.ctrlActions.GetDataForm('frmEdition');
		//Hace el post al create
		this.ctrlActions.DeleteToAPI(this.service, empresaData);
		//Refresca la tabla
		this.ReloadTable();

	}

	this.BindFields = function (data) {
		this.ctrlActions.BindFields('frmEdition', data);
	}
}

//ON DOCUMENT READY
$(document).ready(function () {

	var vempresa = new vEmpresas();
	vempresa.RetrieveAll();

});

