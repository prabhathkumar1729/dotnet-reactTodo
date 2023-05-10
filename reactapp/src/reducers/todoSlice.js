import { createSlice, createAsyncThunk, current } from "@reduxjs/toolkit";
import todoServices from "../services/todosFetch";

export const fetchallTodos = createAsyncThunk(
    'todo/allTodos',
    async (userId) => {
        const todos = await todoServices.getAll(userId);
        return todos;
    }
);

export const addnewTodo = createAsyncThunk(
    'todo/addTodo',
    async (newObject) => {

        const todo = await todoServices.create(newObject);
        return todo;
    }
);

export const removeTodo = createAsyncThunk(
    'todo/removeTodo',
    async (id) => {
        const todo = await todoServices.remove(id);
        return todo;
    }
);

export const changeTodo = createAsyncThunk(
    'todo/editTodo',
    async (newObject) => {
        const todo = await todoServices.update(newObject);
        return todo;
    }
);


const todoSlice = createSlice({
    name: 'todo',
    initialState: [],
    reducers: {
    },
    extraReducers(builder) {
        builder
            .addCase(fetchallTodos.fulfilled, (state, action) => {
                state.length = 0;
                state.push(...action.payload);
            })
            .addCase(addnewTodo.fulfilled, (state, action) => {
                state.push(action.payload);
            })
            .addCase(removeTodo.fulfilled, (state, action) => {
                const indexTorRemove = state.findIndex(todo => todo.todoId === action.payload);
                state.splice(indexTorRemove, 1);
            })
            .addCase(changeTodo.fulfilled, (state, action) => {
                const id = action.payload.todoId;
                const indexToChange = state.findIndex(todo => todo.todoId === id);
                state[indexToChange] = action.payload;
            })
    }
});



export const { allTodos, addTodo, toggleTodo, editTodo } = todoSlice.actions;
export default todoSlice.reducer;