$(document).ready(function () {
    $("#agregarCiudad").on("click", function () {
        if ($("#idCiudad").val()) {
            //Recorrer la tabla dinamica para validar si la ciudad ya existe
            for (var j = 1; j <= counterC; j++) {
                if (parseInt($("#idCiudad" + j).val()) === parseInt($("#CodigoMaterial").val())) {
                    var r = confirm("El material ya existe en el listado, Desea agregarlo?");
                    if (r === true) {
                        // console.log("You pressed OK!");
                        sw = 0;
                    } else {
                        //console.log("You pressed Cancel!");
                        sw = 1;
                    }
                }
            }
        }
    })
})