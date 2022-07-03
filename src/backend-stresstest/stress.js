const fetch = require('node-fetch');
const equation = "0.1*0.2*0.3"
const requestOptions = {
    method: "POST",
    body: JSON.stringify({
        equation
    }),
    headers: {
        "Content-Type": "application/json"
    }
};
setInterval(() =>
    fetch("http://localhost:5260/calculate", requestOptions)
    .then(x => x.json())
    .then(x => console.log(`${new Date().toISOString()}: `, x)),
100);