import React from "react";
import { useNavigate } from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";
import { addnewTodo } from "../reducers/todoSlice";
import "../styles/addnewtodo.css";
export default function Newtodo() {
    const navigate = useNavigate();
    const dispatch = useDispatch();
    const profile = useSelector((state) => state.profile.profile);
    const addTodo = (e) => {
        e.preventDefault();
        const todo = e.target.elements.todo.value;
        dispatch(
            addnewTodo({
                task: todo,
                isCompleted: false,
                userId: profile.id
            })
        );
        e.target.elements.todo.value = "";
        navigate("/todos");
    };
    return (
        <div className="addtodo">
            <div className="addtodo_container">
                <form onSubmit={addTodo}>
                    <input type="text" name="todo" placeholder="Enter todo here" required />
                    <button type="submit">Add Todo</button>
                </form>
            </div>
        </div>
    );
}
