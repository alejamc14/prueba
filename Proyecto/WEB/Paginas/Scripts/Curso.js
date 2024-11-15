jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html")
    
    LlenarComboXServicios("https://localhost:44385/api/CategoriaCursos/LlenarCombo", "#cboCategoriaCurso");
     LlenarTabla();
   
});

function LlenarTabla() {
    LlenarTablaXServicios("https://localhost:44385/api/Cursos/LlenarTabla", "#tblCursos");
}


async function EjecutarComando(Metodo, Funcion) {
    const curso = new Curso($("#txtId").val(), $("#txtNombre").val(), $("#txtDescripcion").val(), $("#txtFechaInicio").val(),
        $("#txtFechaFin").val(), $("#txtPrecio").val(), $("#txtDocProfesor").val(), $("#cboCategoriaCurso").val());

    let URL = "https://localhost:44385/api/Cursos/" + Funcion;
    await EjecutarComandoServicio(Metodo, URL, curso);
    LlenarTabla();

    
}

async function Consultar() {
    let Codigo = $("#txtId").val();
    URL = "https://localhost:44385/api/Cursos/ConsultarXCodigo?codigo=" + Codigo;
    //Invoco el servicio genérico
    const curso = await ConsultarServicio(URL);
    if (curso != null) {
        $("#dvMensaje").html("");
        $("#txtNombre").val(curso.Nombre);
        $("#txtDescripcion").val(curso.Descripcion);
        $("#txtFechaInicio").val(curso.FechaInicio.split('T')[0]);
        $("#txtFechaFin").val(curso.FechaFin.split('T')[0]);
        $("#txtDocProfesor").val(curso.DocumentoProfesor);
        $("#txtPrecio").val(curso.Precio);
        $("#cboCategoriaCurso").val(curso.IdCategoria);

    }
    else {
        //Se presenta el error en un div de Mensaje
        $("#dvMensaje").html("El curso no existe en la base de datos");
        $("#txtNombre").val("");
        $("#txtDescripcion").val("");
        $("#txtFechaInicio").val("");
        $("#txtFechaFin").val("");
        $("#txtDocProfesor").val("");
        $("#txtPrecio").val("");
        $("#cboCategoriaCurso").val("");
    }
}

class Curso {
    constructor(Id, Nombre, Descripcion, FechaInicio, FechaFin, Precio, DocumentoProfesor, IdCategoria) {
        this.Id = Id;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
        this.FechaInicio = FechaInicio;
        this.FechaFin = FechaFin;
        this.Precio = Precio;
        this.DocumentoProfesor = DocumentoProfesor;
        this.IdCategoria = IdCategoria;

    }
}