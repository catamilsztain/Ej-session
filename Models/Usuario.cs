public class Usuario{
    public string NombreUsuario {get;set;}
    public string Contraseña {get;set;}
    public string Nombre {get;set;}
    public string Apellido {get;set;}
    public string Tipo {get;set;}

    public Usuario(string usuario, string contra, string nombre, string apellido, string tipo){
        NombreUsuario = usuario;
        Contraseña = contra;
        Nombre = nombre;
        Apellido = apellido;
        Tipo = tipo;
    }
}