const form = document.getElementById("formRegistro");

if (form) {

    form.addEventListener("submit", function (event) {

        let usuario = document.getElementById("NombreUsuario").value.trim();
        let contraseña = document.getElementById("Contrasena").value;
        let nombre = document.getElementById("Nombre").value.trim();
        let apellido = document.getElementById("Apellido").value.trim();

        let errores = [];

        // Usuario obligatorio y mínimo 4 caracteres
        if (usuario === "") {
            errores.push("El usuario es obligatorio.");
        } else if (usuario.length < 4) {
            errores.push("El usuario debe tener al menos 4 caracteres.");
        }

        // Contraseña obligatoria y mínimo 6 caracteres
        if (contraseña === "") {
            errores.push("La contraseña es obligatoria.");
        } else if (contraseña.length < 6) {
            errores.push("La contraseña debe tener al menos 6 caracteres.");
        }

        // Nombre obligatorio y solo letras
        if (nombre === "") {
            errores.push("El nombre es obligatorio.");
        } else if (!/^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/.test(nombre)) {
            errores.push("El nombre solo puede contener letras.");
        }

        // Apellido obligatorio y solo letras
        if (apellido === "") {
            errores.push("El apellido es obligatorio.");
        } else if (!/^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/.test(apellido)) {
            errores.push("El apellido solo puede contener letras.");
        }

        // Si hay errores, NO se manda el formulario
        if (errores.length > 0) {

            event.preventDefault();

            let mensaje = "";

            for (let i = 0; i < errores.length; i++) {
                mensaje += "<p>" + errores[i] + "</p>";
            }

            document.getElementById("register-errors").innerHTML = mensaje;
        }

    });

}

