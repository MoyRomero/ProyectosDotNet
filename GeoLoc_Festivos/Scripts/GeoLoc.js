const Url = window.location.href;

const ObtenerDatosGeoLoc = () => {
    const UrlEndPoint = `${Url}/ConsumirApi?${MiDireccionIp()}`;

    $.get(`GeoLoc/ConsumirApi/${MiDireccionIp()}`, (data) => {
        const datos = JSON.parse(data);
        AsignarASpans(datos);
    });
}

const AsignarASpans = (datos) => {

    document.getElementById("DireccionIp").textContent = datos.query;
    document.getElementById("PaisSpan").textContent = datos.country;
    document.getElementById("CiudadSpan").textContent = datos.city;
}

const MiDireccionIp = () => {

    fetch("https://api.ipify.org?format=json")
        .then(respuesta => {
            if (!respuesta.ok) {
                throw new Error(`Hubo un error en la solicitud. ${respuesta.status}`);
            }
            return respuesta.json();
        })
        .then(datos => {
            return datos.ip;
        })
        .catch(error => {
            console.log(`Error al obtener los datos: ${error}`);
        });
}
