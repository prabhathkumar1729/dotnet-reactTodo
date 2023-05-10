import React from "react";
import { NavLink } from "react-router-dom";
import { FaReact } from "react-icons/fa";
import "../styles/navbar.css";
export default function Navbar() {
  return (
    <>
      <div className="Nav">
        <div className="Home">
          <NavLink to="/">
            <FaReact />
          </NavLink>
        </div>
        <div className="Profile">
          <NavLink to="/profile">
            Profile
          </NavLink>
        </div>
        <div className="TodoList">
          <NavLink to="/todos">
            Todo list
          </NavLink>
        </div>
        <div className="NavBtn">
          <div className="NavBtnLink">
            <NavLink to="/newtodo"> ADD New Todo</NavLink>
          </div>
        </div>
      </div>
    </>
  );
}
