const Url = window.location.href;


btnConsultarDiasF


const ConsultarDiasFestivos = () => {

    const SelectPaises = document.getElementById("SelectPaises");
    const option_1 = document.getElementById("option_1");
    const divLiDiasFestivos = document.getElementById("divLiDiasFestivos");

    if (SelectPaises.selectedIndex < 1) {
        alert("Antes de consultar, debe seleccionar un código de país.");
        return;
    }

    $.get(`DiasFestivos/ObtenerDiasFestivos/?CodigoPais=${SelectPaises.value}`, (data) => {

        if (data != null || data != "" || data != " ") {
            const datos = JSON.parse(data);
            let Li = "";

            Li += EncabezadoLi();
            
            for (let i = 0; i < datos.length; i++) {                
                Li += CrearLi(datos[i]);                
            }

            Li += "</ul >";

            document.getElementById("divListaDesordenada").innerHTML = Li;           
        }
        else {
            alert("Ocurrió un error en el servidor.");
        }
    });
}

const EncabezadoLi = () => {
    const Encabezado =
        `<ul>
            <li>
                <span>FECHA</span>
                <span>FESTIVO</span>
            </li>`;
    return Encabezado;
}

const CrearLi = (datos) => {
    
    let Li = 
    `<li>
        <span>${datos.date}</span>
        <span>${datos.localName}</span>
    </li>`;
    
    return Li;
}

