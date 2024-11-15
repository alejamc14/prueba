jQuery(function () {
    LlenarTabla();
});

async function Ejecutar(Metodo, Funcion) {

    const estudiante = new Estudiante($("#txtDocumento").val(), $("#txtNombre").val(), $("#txtApellido").val(), $("#txtFechaNacimiento").val(),
        $("#txtTelefono").val(), $("#txtDireccion").val(), $("#txtCorreo").val());

    let URL = "https://localhost:44385/api/Estudiantes/" + Funcion;
    EjecutarComandoServicio(Metodo, URL, estudiante);
}

async function Consultar() {
    let Documento = $("#txtDocumento").val();
    let URL = "https://localhost:44385/api/Estudiantes/ConsultarXDocumento?Documento=" + Documento;

    const estudiante = await ConsultarServicio(URL);

    if (estudiante != null) {
        $("#txtNombre").val(estudiante.Nombre);
        $("#txtApellido").val(estudiante.Apellido);
        $("#txtFechaNacimiento").val(estudiante.FechaNacimiento.split('T')[0]);
        $("#txtTelefono").val(estudiante.Telefono);
        $("#txtDireccion").val(estudiante.Direccion);
        $("#txtCorreo").val(estudiante.Correo);
    }
    else {
        $("#dvMensaje").html("No se encontró el estudiante en la base de datos.");
    }
    
}

class Estudiante {
    constructor(Documento, Nombre, Apellido, FechaNacimiento, Telefono, Direccion, Correo) {
        this.Documento = Documento;
        this.Nombre = Nombre;
        this.Apellido = Apellido;
        this.FechaNacimiento = FechaNacimiento;
        this.Telefono = Telefono;
        this.Direccion = Direccion;
        this.Correo = Correo;
    }
}

async function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44385/api/Estudiantes/LlenarTabla", "#tblEstudiantes");
}