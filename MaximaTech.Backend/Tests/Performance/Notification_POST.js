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
    vus: 10,
    duration: '1m',
};

export default function () {
    const url = 'https://dev.xdatasolucoes.com.br:9091/notifications';

    const payload = JSON.stringify({
        title: "lorem ipsum dolor sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua",
        message: "lorem ipsum dolor sit amet consectetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua"
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJJZCI6IjYyIiwiVXNlclVuaXF1ZUlkIjoiZWU5M2ExZTktMmE4Ny00ZDg2LWI2N2YtYzg5MjQyNmMyMmRhIiwiQWNjb3VudElkIjoiNDdmMjg5ZjMtNzM0OC00ZjUxLWE3MmItM2Y4NzljNGRhNDI4Iiwicm9sZSI6ImF1dGhlbnRpY2F0ZWQiLCJzdWIiOiJsZWFuZHJvQHhkYXRhc29sdWNvZXMuY29tLmJyIiwiZW1haWwiOiJsZWFuZHJvQHhkYXRhc29sdWNvZXMuY29tLmJyIiwianRpIjoiMDAyOTc1MjUtZGY5Yi00MzA5LTk4MGYtNjhjMmY3YmNiOTM4IiwidW5pcXVlX25hbWUiOiJUaWFnbyBSb2RyaWd1ZXMiLCJuYmYiOjE3MDIxNTI3ODYsImV4cCI6MTcwMjE1OTk4NiwiaWF0IjoxNzAyMTUyNzg2LCJpc3MiOiJodHRwczovL3NhbW1vYmlsaWRhZGUuY29tLmJyIiwiYXVkIjoiYXV0aGVudGljYXRlZCJ9.ClLgJAMWJQfUWll4cJP_XlMUInrbLL1vcnxAV9XGskE'
        },
    };

    http.post(url, payload, params);

}
