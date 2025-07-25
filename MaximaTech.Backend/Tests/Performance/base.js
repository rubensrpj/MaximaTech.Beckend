import {check} from 'k6';
import http from 'k6/http';

export const options = {
    tags: {
        name: 'Base URL',
    },
    thresholds: {
        http_req_failed: ['rate<0.01'], // http errors should be less than 1%
        http_req_duration: ['p(95)<200'], // 95% of requests should be below 200ms
    },
    vus: 10,
    duration: '30s',
};

export default function () {
    const url = 'https://dev.xdatasolucoes.com.br:9091/';

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    const res = http.get(url, params);

    check(res, {
        'is status 200': (r) => r.status === 200,
    });
}
