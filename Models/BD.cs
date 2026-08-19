using Microsoft.Data.SqlClient;
using Dapper;

public class BD{
    private string _connectionString = @"Server=.; DataBase=session; Integrated Security = True; TrustServerCertificate=True;";

    public void AgregarUsuario(Usuario usuario){
        string query = "INSERT INTO Usuarios (NombreUsuario, Contraseña, Nombre, Apellido, Tipo, ClaveSeguridad) VALUES (@pNombreUsuario, @pContraseña, @pNombre, @pApellido, @pTipo, @pClaveSeguridad)";
        using(SqlConnection connection = new SqlConnection(_connectionString)){
            connection.Execute(query, new {pNombreUsuario = usuario.NombreUsuario, pContraseña = usuario.Contraseña, pNombre = usuario.Nombre, pApellido = usuario.Apellido, pTipo = usuario.Tipo, pClaveSeguridad = usuario.ClaveSeguridad});
        }
    }

    public Usuario ObtenerUsuario(string nombreUsuario)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT NombreUsuario, Contraseña, Nombre, Apellido, Tipo, ClaveSeguridad FROM Usuarios WHERE NombreUsuario = @pNombreUsuario";

            return connection.QuerySingleOrDefault<Usuario>(query, new 
            {
                pNombreUsuario = nombreUsuario
            });
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

    public bool LoginConClaveCorrecta(string nombreUsuario, string claveSeguridad)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string query = "SELECT COUNT(*) FROM Usuarios WHERE NombreUsuario = @pNombreUsuario AND ClaveSeguridad = @pClaveSeguridad";

            int cantidad = connection.ExecuteScalar<int>(query, new
            {
                pNombreUsuario = nombreUsuario,
                pClaveSeguridad = claveSeguridad
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