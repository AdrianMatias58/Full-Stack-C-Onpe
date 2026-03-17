const btnBuscar = document.getElementById("btnBuscar");
const nroMesa = document.getElementById("nroMesa");
const divDetalle = document.getElementById("divDetalle");

btnBuscar.addEventListener("click", async () => {
    const numero = nroMesa.value.trim();

    if (!numero) {
        alert("Ingrese un número de acta");
        return;
    }

    try {
        const response = await fetch(`/Actas/GetDetalleGrupoV?idGrupoVotacion=${numero}`);

        if (!response.ok) {
            divDetalle.innerHTML = "<p>No se encontró el acta ingresada.</p>";
            divDetalle.style.display = "block";
            return;
        }

        const html = await response.text();
        divDetalle.innerHTML = html;
        divDetalle.style.display = "block"; 

    } catch (error) {
        console.error("Error:", error);
    }
});
