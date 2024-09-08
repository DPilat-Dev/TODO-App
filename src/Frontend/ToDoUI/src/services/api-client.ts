import axios, { AxiosRequestConfig } from "axios";

const axiosInstance = axios.create({
    baseURL: 'https://localhost:5174'
});

class APIClient<T>{
    endpoint: string;

    constructor(endpoint: string){
        this.endpoint = endpoint;
    }

    getAll = (config: AxiosRequestConfig) => {
        return axiosInstance
            .get<T>(this.endpoint, config)
            .then(res => res.data);
    }

    get = (id: number) => {
        return axiosInstance
            .get<T>(this.endpoint + '/' + id)
            .then(res => res.data);
    }

    post = () => {
        return axiosInstance
            .post<T>(this.endpoint + '/')
            .then(res => res.data);
    }

    put = (id: number) => {
        return axiosInstance
            .put<T>(this.endpoint + '/' + id)
            .then(res => res.data);
    }

    delete = (id: number) => {
        return axiosInstance
            .delete(this.endpoint + '/' + id)
            .then(res => res.status);
    }

}

export default APIClient;