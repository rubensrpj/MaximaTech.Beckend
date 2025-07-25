import { check } from 'k6';
import http from 'k6/http';

export const options = {
    tags: {
        name: 'Login Mobile App',
      },    
    thresholds: {
        http_req_failed: ['rate<0.01'], // http errors should be less than 1%
        http_req_duration: ['p(95)<1000'], // 95% of requests should be below 1s
    },
    vus: 50,
    duration: '1m',
};

export default function () {
    const url = 'https://dev.xdatasolucoes.com.br:9091/auth/login';
    const payload = JSON.stringify({
        email: "leandro@xdatasolucoes.com.br",
        password: "123456",
        deviceId: "TP1A.220624.014",
        publicKey: "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAvi6rX9wwibBDiRd5Gz3AUZxO3YODIry96ecF+vL6Bzn/jIrdMtwxAJCkn+Mv6ee8X4wbMGztccNEo66aOSsJjLCKmHgYFe1P6dTA5LSx4WSIRX9RIZMxVlpOBqmAn4hpmm1La3v4wqKlBawiPFlyVvXfRtbUGQLjb1ATndK7WXDC2DWDierLXhzlxf2T9OjcqULIlbCQfyVTZjMn8O1LphK2INCnqXz56T/ZdZS6aifwpYZDq3b01VruU5bvEqkiButW8Y55qyseWEfn5g4h7/QMRH8N5CwZBgf6y5q0EFRZkHrVuB0VZAHzZAWEMjuFpcYaRwyrAd8ZOEWw3cKAfwIDAQAB"
    });

    const params = {
        headers: {
            'Content-Type': 'application/json',
        },
    };

    const res = http.post(url, payload, params);

    check(res, {
        'is status 200': (r) => r.status === 200,
        'success': (r) => r.json("success") === true,
        'has user data': (r) => !!r.json("user.id"),
        'has access token': (r) => !!r.json("accessToken"),
        'has refresh token': (r) => !!r.json("refreshToken"),
        'has session key': (r) => !!r.json("sessionKey"),

    });
}
