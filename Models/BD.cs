using Microsoft.Data.SqlClient;
using Dapper;

public class BD{
    private string _connectionString = @"Server=localhost; DataBase=session; Integrated Security = True; TrustServerCertificate=True;";

    public void AgregarUsuario(Usuario usuario){
        string query = "INSERT INTO Usuarios (NombreUsuario, Contraseña, Nombre, Apellido, Tipo) VALUES (@pNombreUsuario, @pContraseña, @pNombre, @pApellido, @pTipo)";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Execute(query, new {pNombreUsuario = usuario.NombreUsuario, pContraseña = usuario.Contraseña, pNombre = usuario.Nombre, pApellido = usuario.Apellido, pTipo = usuario.Tipo});
        }
    }

    public bool ExisteUsuario(string NombreUsu){
        string usuario;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT NombreUsuario FROM Usuarios WHERE NombreUsuario = @pNombreUsu";
            usuario = connection.QueryFirstOrDefault(query, new {pNombreUsuario = NombreUsu});
        }
        bool existe=false;
        if(usuario == NombreUsu){
            existe = true;
        }
        return existe;
    } 

    public bool MismaContraseña(string Contra){
        string contra;
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            string query = "SELECT Contraseña FROM Usuarios WHERE Contraseña = @pContra";
            contra = connection.QueryFirstOrDefault(query, new {pContraseña = Contra});
        }
        bool existe=false;
        if(contra == Contra){
            existe = true;
        }
        return existe;
    } 
}