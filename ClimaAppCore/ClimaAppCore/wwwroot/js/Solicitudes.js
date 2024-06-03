/*const axios = require('axios');*/

const options = {
    method: 'GET',
    url: 'https://weatherbit-v1-mashape.p.rapidapi.com/current',
    params: {
        lon: '38.5',
        lat: '-78.5'
    },
    headers: {
        'X-RapidAPI-Key': 'aea8e88785msh0ef263db4492f51p1037ccjsn2c8924655f88',
        'X-RapidAPI-Host': 'weatherbit-v1-mashape.p.rapidapi.com'
    }
};

async function EnviarSolicitud(options) {
    const { url, params, headers } = options;

    // Construir URL con parámetros
    const queryParams = new URLSearchParams(params).toString();
    const requestUrl = `${url}?${queryParams}`;

    try {
        const response = await fetch("https://ipinfo.io/json?token=ipinfo.io");

        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }

        const data = await response.json();
        console.log(data);
    } catch (error) {
        console.error(error);
    }
}

//const encodedParams = new URLSearchParams();
//encodedParams.set('q', 'Hello, world!');
//encodedParams.set('target', 'es');
//encodedParams.set('source', 'en');

//const options = {
//    method: 'POST',
//    url: 'https://google-translate1.p.rapidapi.com/language/translate/v2',
//    headers: {
//        'content-type': 'application/x-www-form-urlencoded',
//        'Accept-Encoding': 'application/gzip',
//        'X-RapidAPI-Key': 'aea8e88785msh0ef263db4492f51p1037ccjsn2c8924655f88',
//        'X-RapidAPI-Host': 'google-translate1.p.rapidapi.com'
//    },
//    data: encodedParams,
//};





/*EnviarSolicitud(options);*/


//{
//    "data": {
//        "translations": [{ "translatedText": "Hola" }]
//    }
//}