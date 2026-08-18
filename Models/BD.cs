using Microsoft.Data.SqlClient;
using Dapper;

public class BD{
    private string _connectionString = @"Server=.; DataBase=session; Integrated Security = True; TrustServerCertificate=True;";

    public void AgregarUsuario(Usuario usuario){
        string query = "INSERT INTO Usuarios (NombreUsuario, Contraseña, Nombre, Apellido, Tipo) VALUES (@pNombreUsuario, @pContraseña, @pNombre, @pApellido, @pTipo)";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Execute(query, new {pNombreUsuario = usuario.NombreUsuario, pContraseña = usuario.Contraseña, pNombre = usuario.Nombre, pApellido = usuario.Apellido, pTipo = usuario.Tipo});
        }
    }

    public bool LoginCorrecto(string nombreUsuario, string contraseña)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @pNombreUsuario AND Contraseña = @pContraseña";

        int cantidad = connection.ExecuteScalar<int>(query, new
        {
            pNombreUsuario = nombreUsuario,
            pContraseña = contraseña
        });

        return cantidad > 0;
    }
}
public bool ExisteUsuario(string NombreUsu)
{
    using (SqlConnection connection = new SqlConnection(_connectionString))
    {
        string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @pNombreUsu";

        int cantidad = connection.ExecuteScalar<int>(query, new
        {
            pNombreUsu = NombreUsu
        });

        return cantidad > 0;
    }
}
}