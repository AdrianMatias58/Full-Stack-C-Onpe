const Tabla = document.getElementById("tbodyMesas")
const SetLocal = document.getElementById("actas_ubigeo")

async function getMesas() {
    try {
        const idLocal = SetLocal.value
        const response = await fetch(`/Actas/GetGruposVotacion?idLocalVotacion=${idLocal}`)
        console.log(response)
        if (!response.ok) throw new Error("Error al obtener provincias");
        const mesas = await response.json();
        console.log(mesas)
        Tabla.innerHTML = "";
        let fila = document.createElement("tr");
        mesas.forEach((mesa, index) => {
            const td = document.createElement("td");
            td.bgcolor = "#C1C1C1";
            td.style.cursor = "pointer";
            const a = document.createElement("a");
            a.href = "#";
            a.textContent = mesa.idGrupoVotacion;
            td.appendChild(a);
            td.addEventListener("click", async () => {
                try {
                    const res = await fetch(`/Actas/GetDetalleGrupoV?idGrupoVotacion=${mesa.idGrupoVotacion}`);
                    const html = await res.text();
                    document.getElementById("GrupoVotacion").innerHTML = html;
                    document.getElementById("GrupoVotacion").style.display = "block";
                } catch (error) {
                    console.error("Error detalle:", error); 
                }
            });
            fila.appendChild(td);
            if ((index + 1) % 10 === 0) {
                Tabla.appendChild(fila);
                fila = document.createElement("tr");
            }
        });
        if (fila.children.length > 0) Tabla.appendChild(fila);
    } catch (error) {

    }
}



SetLocal.addEventListener("change", () => {
    getMesas()
})


