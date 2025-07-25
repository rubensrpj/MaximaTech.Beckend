import {check} from 'k6';
import http from 'k6/http';

export const options = {
    tags: {
        name: 'Notifications Mobile App',
    },
    thresholds: {
        http_req_failed: ['rate<0.01'], // http errors should be less than 1%
        http_req_duration: ['p(95)<1000'], // 95% of requests should be below 1s
    },
    vus: 100,
    duration: '3m',
};

export default function () {
    const url = 'https://dev.xdatasolucoes.com.br:9091/notifications';

    const params = {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjYyIiwiVXNlclVuaXF1ZUlkIjoiZWU5M2ExZTktMmE4Ny00ZDg2LWI2N2YtYzg5MjQyNmMyMmRhIiwiQWNjb3VudElkIjoiNDdmMjg5ZjMtNzM0OC00ZjUxLWE3MmItM2Y4NzljNGRhNDI4Iiwicm9sZSI6ImF1dGhlbnRpY2F0ZWQiLCJzdWIiOiJsZWFuZHJvQHhkYXRhc29sdWNvZXMuY29tLmJyIiwiZW1haWwiOiJsZWFuZHJvQHhkYXRhc29sdWNvZXMuY29tLmJyIiwianRpIjoiYmJiMDA0YmMtZjlmZi00MjA4LTg1NzQtNzA3ZmNkMmJiNGJmIiwidW5pcXVlX25hbWUiOiJUaWFnbyBSb2RyaWd1ZXMiLCJuYmYiOjE3MDIxNTg0MzEsImV4cCI6MTcwMjIwMTYzMSwiaWF0IjoxNzAyMTU4NDMxLCJpc3MiOiJodHRwczovL3NhbW1vYmlsaWRhZGUuY29tLmJyIiwiYXVkIjoiYXV0aGVudGljYXRlZCJ9.QfHuTBXZs1-ZOZsFZ33zetKtkHXPkEaszNP0KzJtTwE'
        },
    };

    const res = http.get(url, params);

    check(res, {
        'is status 200': (r) => r.status === 200,
    });
}
