const SlecAmbito = document.getElementById("cdgoAmbito");
const SlecDepartamento = document.getElementById("cdgoDep");
const SlecProvincia = document.getElementById("cdgoProv");
const SlecDistrito = document.getElementById("cdgoDist");
const Local = document.getElementById("actas_ubigeo");
//conseguir Departamentos
async function cargarDepartamentos() {
    const ambito = SlecAmbito.value;
    const response = await fetch(`/Actas/GetDepartamento?ambito=${ambito}`);
    const departamentos = await response.json();
    SlecDepartamento.innerHTML = '<option value="">-- Seleccione --</option>';
    departamentos.forEach(dep => {
        const opcion = document.createElement("option");
        opcion.value = dep.idDepartamento;
        opcion.textContent = dep.Detalle;
        SlecDepartamento.appendChild(option);
    })
}

SlecAmbito.addEventListener("change", cargarDepartamentos)