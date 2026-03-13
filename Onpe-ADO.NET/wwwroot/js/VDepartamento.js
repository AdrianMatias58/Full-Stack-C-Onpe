const params = new URLSearchParams(window.location.search);
const departamento = params.get("departamento");
const formatoNum = (num) => Number(num).toLocaleString("en-US");

async function cargarDepartamento() {
    
    const url = `/TotalV/GetTotalVDepartamento?Departamento=${departamento}`;
    const response = await fetch(url);
    const datos = await response.json();
    // Calcular totales
    const totalEH = datos.reduce((sum, x) => sum + x.eh, 0);
    const totalTV = datos.reduce((sum, x) => sum + x.tv, 0);
    const totalTA = datos.reduce((sum, x) => sum + x.ta, 0);
    const pTV = (totalTV * 100.0 / totalEH).toFixed(3);
    const pTA = (totalTA * 100.0 / totalEH).toFixed(3);

    // Electores hábiles
    document.getElementById("electoresHabiles").textContent = formatoNum(totalEH);

    // Tabla participación / ausentismo
    document.getElementById("bodyVotos").innerHTML = `
        <tr>
            <td>Total : <span>${formatoNum(totalTV)}</span></td>
            <td>Total : <span>${formatoNum(totalTA)}</span></td>
        </tr>
        <tr>
            <td>% Total : <span>${pTV} %</span></td>
            <td>% Total : <span>${pTA} %</span></td>
        </tr>`;

    // Tabla detalle provincias
    let filas = "";
    datos.forEach(item => {
        filas += `
            <tr style="cursor:pointer;">
                <td>${item.provincia}</td>
                <td>${formatoNum(item.tv)}</td>
                <td>${item.ptv}</td>
                <td>${formatoNum(item.ta)}</td>
                <td>${item.pta}</td>
                <td>${formatoNum(item.eh)}</td>
            </tr>`;
    });

    document.getElementById("contenedorTabla").innerHTML = `
        <div style="background-color:#b8960c; border-radius:20px;
                    padding:8px 20px; display:inline-block; margin-bottom:15px;">
            <span style="color:white; font-weight:bold;">
                ${departamento} - DETALLE POR PROVINCIA
            </span>
        </div>
        <div class="table-responsive">
            <table class="table table-bordered table-hover" cellspacing="0" style="text-align:center;">
                <thead>
                    <tr style="background-color:#f5f5f5;">
                        <th>PROVINCIA / PAIS</th>
                        <th>TOTAL ASISTENTES</th>
                        <th>% TOTAL ASISTENTES</th>
                        <th>TOTAL AUSENTES</th>
                        <th>% TOTAL AUSENTES</th>
                        <th>ELECTORES HÁBILES</th>
                    </tr>
                </thead>
                <tbody>${filas}</tbody>
            </table>
        </div>`;
}
document.getElementById("contenedorTabla").addEventListener("click", function (e) {
    const fila = e.target.closest("tr");
    if (fila && fila.closest("tbody")) {
        const provincia = fila.cells[0].textContent.trim();
        window.location.href = `/TotalV/VistaProvinciaV?provincia=${provincia}`;
    }
});

document.addEventListener("DOMContentLoaded", cargarDepartamento);