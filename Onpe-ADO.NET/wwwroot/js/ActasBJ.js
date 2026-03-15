const SlecAmbito = document.getElementById("cdgoAmbito");
const SlecDepartamento = document.getElementById("cdgoDep");
const SlecProvincia = document.getElementById("cdgoProv");
const SlecDistrito = document.getElementById("cdgoDist");
const Local = document.getElementById("actas_ubigeo");
const Detallemesa = document.getElementById("divDetalle")
const ocultarDetalleMesa = () => {Detallemesa.style.display ="none" }
function resetSelect(select) {
    select.innerHTML = '<option value="">--SELECCIONE--</option>';
    select.disabled = true;
}

async function cargarDepartamentos() {
    try {
        const ambito = SlecAmbito.value;
        const response = await fetch(`/Actas/GetDepartamento?ambito=${ambito}`);
        if (!response.ok) throw new Error("Error al obtener departamentos");

        const departamentos = await response.json();

        departamentos.forEach(dep => {
            const option = document.createElement("option"); 
            option.value = dep.idDepartamento;
            option.text = dep.detalle;
            SlecDepartamento.appendChild(option);
        });
        SlecDepartamento.disabled = false;
    } catch (error) {
        console.error("Error:", error);
    }
}

async function cargarProvincia() {
    try {
        const idDepartamento = SlecDepartamento.value;
        const response = await fetch(`/Actas/GetProvincia?idDepartamento=${idDepartamento}`);
        if (!response.ok) throw new Error("Error al obtener provincias");
        const provincia = await response.json();
        provincia.forEach(dep => {
            const option = document.createElement("option");
            option.value = dep.idProvincia;
            option.text = dep.detalle;
            SlecProvincia.appendChild(option);
        });
        SlecProvincia.disabled = false;
    } catch (error) {

    }
}
async function cargarDistrito() {
    try {
        const idProvincia= SlecProvincia.value;
        const response = await fetch(`/Actas/GetDistritos?idProvincia=${idProvincia}`);
        if (!response.ok) throw new Error("Error al obtener provincias");
        const distrito= await response.json();
        distrito.forEach(dep => {
            const option = document.createElement("option");
            option.value = dep.idDistrito;
            option.text = dep.detalle;
            SlecDistrito.appendChild(option);
        });
        SlecDistrito.disabled = false;
    } catch (error) {

    }
}
async function cargarLocales() {
    try {
        const idDistrito = SlecDistrito.value;
        const response = await fetch(`/Actas/GetLocalVotacion?idDistrito=${idDistrito}`);
        if (!response.ok) throw new Error("Error al obtener provincias");
        const Locales = await response.json();
        Locales.forEach(dep => {
            const option = document.createElement("option");
            option.value = dep.idLocalVotacion;
            option.text = dep.razonSocial;
            Local.appendChild(option);
        });
        Local.disabled = false;
    } catch (error) {

    }
}


SlecAmbito.addEventListener("change", () => {
    resetSelect(SlecDepartamento);
    resetSelect(SlecProvincia);
    resetSelect(SlecDistrito);
    cargarDepartamentos()
})
SlecDepartamento.addEventListener("change", () => {
    resetSelect(SlecProvincia);
    resetSelect(SlecDistrito);
    cargarProvincia()
})
SlecProvincia.addEventListener("change", () => {
    resetSelect(SlecDistrito);
    resetSelect(Local);
    cargarDistrito()
})
SlecDistrito.addEventListener("change", () => {
    ocultarDetalleMesa()   
    resetSelect(Local);
    cargarLocales()
})
Local.addEventListener("change", () => {
    const idLocal = Local.value;
    if (!idLocal) {
        ocultarDetalleMesa()
        return;
    }
    Detallemesa.style.display = "block";
})