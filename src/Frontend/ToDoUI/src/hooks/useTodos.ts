import Todo from "../model/todo";
import APIClient from "../services/api-client";

const apiClient = new APIClient<Todo>('/Todo');

const useTodos = () => {
    //get react query
};

export default useTodos;