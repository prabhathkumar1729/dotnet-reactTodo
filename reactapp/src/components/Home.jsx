import React, { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { fetchallTodos } from "../reducers/todoSlice";
import { fetchProfile } from "../reducers/profileSlice";
import Hometodo from "./Hometodo";
import "../styles/homepage.css";
export default function Home() {
    const dispatch = useDispatch();
    const userId = 3;
  useEffect(() => {
      dispatch(fetchProfile(userId));
      dispatch(fetchallTodos(userId));
  }, []);

  const name = useSelector((state) => state.profile.profile.name);
  const todos = useSelector((state) => state.todos);
  return (
    <>
      <div className="greeting">
        <h1>
          Hello <span className="username">{name}</span>
        </h1>
        <div>This is your Todo list</div>{" "}
      </div>
      <Hometodo todos={{ todos }} />
      <div className="homepage"></div>
    </>
  );
}
