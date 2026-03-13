
const Grafico = (url) => {
    document.getElementById("grafico").src = url
}
async function actualizarTablaVotos(url) {
    const response = await fetch(url);
    const datos = await response.json();
    const formatoNum = (num) => Number(num).toLocaleString("en-US");

    if (!Array.isArray(datos)) {
        console.error("Error del servidor:", datos.mensaje);
        return;
    }

    const totalEH = datos.reduce((sum, x) => sum + x.eh, 0);
    const totalTV = datos.reduce((sum, x) => sum + x.tv, 0);
    const totalTA = datos.reduce((sum, x) => sum + x.ta, 0);

    document.getElementById("electoresHabiles").textContent = formatoNum(totalEH);

    const tbody = document.getElementById("bodyVotos");
    tbody.innerHTML = `
        <tr>
            <td>Total : <span>${formatoNum(totalTV)}</span></td>
            <td>Total : <span>${formatoNum(totalTA)}</span></td>
        </tr>
        <tr>
            <td>% Total : <span>${datos[0].ptv}</span></td>
            <td>% Total : <span>${datos[0].pta}</span></td>
        </tr>
    `;
}
async function cargarVotos() {
    const response = await fetch("/TotalV/GetTotalVotos");
    const datos = await response.json();
    const formatoNum = (num) => Number(num).toLocaleString("en-US");

    if (!Array.isArray(datos)) {
        console.error("Error del servidor:", datos.mensaje);
        return;
    }

    document.getElementById("electoresHabiles").textContent =
        formatoNum(datos[0].electoresHabiles);

    const tbody = document.getElementById("bodyVotos");
    tbody.innerHTML = `
        <tr>
            <td>Total : <span>${formatoNum(datos[0].totalAsistentes)}</span></td>
            <td>Total : <span>${formatoNum(datos[0].totalAusentes)}</span></td>
        </tr>
        <tr>
            <td>% Total : <span>${datos[0].porcentajeTotalAsistentes}</span></td>
            <td>% Total : <span>${datos[0].porcentajeTotalAusentes}</span></td>
        </tr>
    `;
}
async function cargarVotosPeru() {
    actualizarTablaVotos("/TotalV/GetVotosPeruJson")
    const response = await fetch("/TotalV/GetVotosPeru");
    const html = await response.text();
    document.getElementById("contenedorTabla").innerHTML = html;
}
async function cargarVotosExtrajero() {
    actualizarTablaVotos("/TotalV/GetVotosExtranjeroJson")
    const response = await fetch("/TotalV/GetVotosExtranjero");
    const html = await response.text();
    document.getElementById("contenedorTabla").innerHTML = html;
}

document.addEventListener("DOMContentLoaded", cargarVotos);
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("btnNacional").addEventListener("click", function (e) {
        e.preventDefault();
        cargarVotosPeru();
    });
    document.getElementById("btnExtranjero").addEventListener("click", function (e) {
        e.preventDefault();
        cargarVotosExtrajero();
    });
});