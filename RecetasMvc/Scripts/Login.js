var Login = {
    init: function () {
        $("#formularioLogin").on("submit", function (e) {
            e.preventDefault()

            var Correo = $("#correo").val();
            var Contra = $("#contra").val();

            if (Correo.trim() == "") {
                Dialog.show("El campo 'Correo' es obligatorio", Dialog.type.error);
                return;
            }
            if (Contra.trim() == "") {
                Dialog.show("El campo 'Contraseña' es obligatorio", Dialog.type.error);
                return;
            }
            $.ajax({
                url: Root + "Acceso/IniciarSesion",
                type: "POST",
                data: { correo: Correo, contraseña: Contra },
                beforeSend: function () {
                },
                success: function (response) {
                    if (response > 0) {
                        document.location.href = '../Acceso/RedirectRol';
                    }
                    else {
                        Dialog.show("Usuario y/o Contraseña Invalida", Dialog.type.error);
                    }
                }
            });

        });
    },
}