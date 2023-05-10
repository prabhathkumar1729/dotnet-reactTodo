import React from "react";
import "../styles/todolist.css";
export default function Hometodo({ todos }) {
  function getRowColor(completed) {
    if (completed) {
      return "green";
    } else {
      return "red";
    }
  }
  return (
    <>
      <table>
        <thead>
          <tr>
            <th>S.No</th>
            <th>Todo</th>
            <th>Completed</th>
          </tr>
        </thead>
        <tbody>
          {todos.todos.length === 0 && (
            <tr>
              <td colSpan={3}>Empty</td>
            </tr>
          )}
          {todos.todos.map((todo, index) => (
            <tr
              key={index}
              style={{ backgroundColor: getRowColor(todo.isCompleted) }}
            >
              <td>{index + 1}</td>
              <td>{todo.task}</td>
              <td>{todo.isCompleted ? "Yes" : "No"}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </>
  );
}
