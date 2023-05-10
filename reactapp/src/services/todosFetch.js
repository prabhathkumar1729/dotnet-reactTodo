import React from "react";
import axios from "axios";

const baseUrl = "https://localhost:7107/api/TodoService/";

const getAll = async (userId) => {
    const request = await axios.get(baseUrl + `GetTodos/${userId}`);
    return request.data;
};

const create = async (newObject) => {
    const request = await axios.post(baseUrl + "AddTodo", newObject);
    return request.data;
}

const update = async (newObject) => {
    const request = await axios.put(baseUrl + "EditTodo", newObject);
    return request.data;
}

const remove = async (todoId) => {
    await axios.delete(baseUrl + `DeleteTodo/${todoId}`);
    return todoId;
}

const gettodo = async (todoId) => {
    const request = await axios.get(baseUrl + `GetTodo/${todoId}`);
    return request.data;
}

export default { getAll, create, update, remove, gettodo };