import {check} from 'k6';
import http from 'k6/http';

export const options = {
    tags: {
        name: 'City - Posição Veículo'
    },
    thresholds: {
        http_req_failed: ['rate<0.01'], // http errors should be less than 1%
        http_req_duration: ['p(95)<1000'], // 95% of requests should be below 1s
    },
    vus: 100,
    duration: '1m',
};

export default function () {
    const url = 'https://simapp.rmtcgoiania.com.br/veiculo/recuperarposicao';
    const payload = {
        qryIdVeiculo: "20529",
        qryIdPontoParada: "1286"
    };

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    const res = http.post(url, payload, params);

    check(res, {
        'is status 200': (r) => r.status === 200,
    });
}
