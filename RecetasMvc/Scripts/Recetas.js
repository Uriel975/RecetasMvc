var Recetas = {
    Objects: {
        ID_Recetas: 0
    },
    init: function () {
        $("#formulario").on("submit", function (e) {
            e.preventDefault()

            var RECETA = $("#receta").val();
            var TIEMPO = $("#tiempo").val();
            var INGREDIENTES = $("#ingredientes").val();
            var PREPARACION = $("#preparacion").val();
          
            if (Recetas.Objects.ID_Recetas == 0) {

                if (RECETA.trim() == "") {
                    Dialog.show("El campo 'Nombre de la receta' es obligatorio", Dialog.type.error);
                    return;
                }
                if (TIEMPO.trim() == "") {
                    Dialog.show("El campo 'Tiempo' es obligatorio", Dialog.type.error);
                    return;
                }
                if (INGREDIENTES.trim() == "") {
                    Dialog.show("El campo 'Ingredientes' es obligatorio", Dialog.type.error);
                    return;
                }
                if (PREPARACION.trim() == "") {
                    Dialog.show("El campo 'Preparacion' es obligatorio", Dialog.type.error);
                    return;
                }
                $.ajax({
                    url: Root + "Receta/AgregarReceta",
                    type: "POST",
                    data: { receta: RECETA, tiempo: TIEMPO, ingredientes: INGREDIENTES, preparacion: PREPARACION },
                    beforeSend: function () {
                        Dialog.show("Enviando Datos...", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Nueva Receta Creada Con Exito", Dialog.type.success);
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
                    url: Root + "Receta/EditaReceta",
                    type: "POST",
                    data: { receta: RECETA, tiempo: TIEMPO, ingredientes: INGREDIENTES, preparacion: PREPARACION, id: Recetas.Objects.ID_Recetas },
                    beforeSend: function () {
                        Dialog.show("Actualizando datos", Dialog.type.progress);
                    },
                    success: function (response) {
                        if (response > 0) {
                            Dialog.show("Receta actualizada correctamente", Dialog.type.success);
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
        getRecetaData: function (id, RECETA, TIEMPO, INGREDIENTES, PREPARACION) {
            Recetas.Objects.ID_Recetas = id;
            $("#receta").val(RECETA);
            $("#tiempo").val(TIEMPO);
            $("#ingredientes").val(INGREDIENTES);
            $("#preparacion").val(PREPARACION);

            $("#mdlDetail").modal("show");
            $("#RecetaStr").text("Actualizar Receta");
            Dialog.hide();
        },
        DeleteRecet: function (id) {
            Dialog.show("Estás seguro que quiere Eliminar esta receta??", Dialog.type.question);

            $(".sem-dialog").on("done", function () {
                $.ajax({
                    url: Root + "Receta/EliminarReceta",
                    type: "POST",
                    data: { id: id },
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