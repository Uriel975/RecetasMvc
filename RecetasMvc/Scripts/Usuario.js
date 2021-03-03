var Usuario = {
    Objects: {
        IDUsuario: 0
    },
    init: function () {
        $("#formulario").on("submit", function (e) {
            e.preventDefault()

            var Nombre = $("#nombre").val();
            var Apellido = $("#apellido").val();
            
            var Correo = $("#correo").val();
            var Contraseña = $("#contraseña").val();

            if (Usuario.Objects.IDUsuario == 0) {
                var Rol = $("#rol").val();
                var Genero = $("#genero").val();
                if (Nombre.trim() == "") {
                    Dialog.show("El campo 'Nombre' es obligatorio", Dialog.type.error);
                    return;
                }
                if (Apellido.trim() == "") {
                    Dialog.show("El campo 'Apellido' es obligatorio", Dialog.type.error);
                    return;
                }
                if (Genero.trim() == "") {
                    Dialog.show("El campo 'Genero' es obligatorio", Dialog.type.error);
                    return;
                }
                if (Correo.trim() == "") {
                    Dialog.show("El campo 'Correo' es obligatorio", Dialog.type.error);
                    return;
                }
                if (Contraseña.trim() == "") {
                    Dialog.show("El campo 'Contraseña' es obligatorio", Dialog.type.error);
                    return;
                }
                if (Rol.trim() == "") {
                    Dialog.show("El campo 'Rol' es obligatorio", Dialog.type.error);
                    return;
                }

                $.ajax({
                    url: Root + "Usuarios/New",
                    type: "POST",
                    data: { nombre: Nombre, apellido: Apellido, genero: Genero, correo: Correo, contraseña: Contraseña, rol: Rol },
                    beforeSend: function () {
                        Dialog.show("Enviando Datos...", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Nuevo Usuario Creado Con Exito", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al guardar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });

            }
            else {
                $.ajax({
                    url: Root + "Usuarios/EditarUsuario",
                    type: "POST",
                    data: { nombre: Nombre, apellido: Apellido, correo: Correo, contraseña: Contraseña, id: Usuario.Objects.IDUsuario },
                    beforeSend: function () {
                        Dialog.show("Actualizando datos...", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Usuarios actualizado correctamente", Dialog.type.success);
                            $(".sem-dialog").on("done", function () {
                                location.reload(true);
                            });
                        }
                        else {
                            Dialog.show("Ocurrió un error al actualizar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            }
        });
        
    },
    evts: {
        getUsuarioData: function (id, Nombre, Apellido, Correo, Contraseña) {
            Usuario.Objects.IDUsuario = id;
            $("#nombre").val(Nombre);
            $("#apellido").val(Apellido);
            $("#correo").val(Correo);
            $("#contraseña").val(Contraseña);

            $("#mdlDetail").modal("show");
            $("#UsuarioStr").text("Actualizar Usuario");
            Dialog.hide();
        },
        DeleteUser: function (id) {
                Dialog.show("¿Estás seguro que quiere Eliminar este Usuario?", Dialog.type.question);
            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "Usuarios/Eliminar",
                    type: "POST",
                    data: { id: id},
                    beforeSend: function () {
                        Dialog.show("Eliminando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            location.reload(true);
                        }
                        else {
                            Dialog.show("Ocurrió un error al eliminar, inténtelo de nuevo", Dialog.type.error);
                        }
                    }
                });
            });
        }
    }
}