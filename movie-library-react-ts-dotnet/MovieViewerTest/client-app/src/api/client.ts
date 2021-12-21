import axios, { AxiosResponse } from "axios";

const instance = axios.create({
  baseURL: "https://localhost:44388/api",
  headers: {
    "Content-type": "application/json",
  },
});

const responseBody = (response: AxiosResponse) => response.data;

export const requestManager = {
  get: (url: string, params: {}) =>
    instance.get(url, params).then(responseBody),
  post: (url: string, body: {}) => instance.post(url, body).then(responseBody),
  put: (url: string, body: {}) => instance.put(url, body).then(responseBody),
  delete: (url: string) => instance.delete(url).then(responseBody),
};
