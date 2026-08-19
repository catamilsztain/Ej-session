public class Usuario{
    public string NombreUsuario {get;set;}
    public string Contraseña {get;set;}
    public string Nombre {get;set;}
    public string Apellido {get;set;}
    public string Tipo {get;set;}
    public string ClaveSeguridad {get;set;}

    public Usuario(){}

    public Usuario(string nombreUsuario, string contraseña, string nombre, string apellido, string tipo, string claveSeguridad){
        NombreUsuario = nombreUsuario;
        Contraseña = contraseña;
        Nombre = nombre;
        Apellido = apellido;
        Tipo = tipo;
        ClaveSeguridad = claveSeguridad;
    }
}