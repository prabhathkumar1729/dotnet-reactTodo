import React from 'react';
import todoReducer from './reducers/todoSlice'
import profileReducer from './reducers/profileSlice';
import { configureStore } from '@reduxjs/toolkit';

const store = configureStore({
    reducer: {
        todos: todoReducer,
        profile: profileReducer
    }
});

export default store;