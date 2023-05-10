//import React, { Component } from 'react';

//export default class App extends Component {
//    static displayName = App.name;

//    constructor(props) {
//        super(props);
//        this.state = { forecasts: [], loading: true };
//    }

//    componentDidMount() {
//        this.populateWeatherData();
//    }

//    static renderForecastsTable(forecasts) {
//        return (
//            <table className='table table-striped' aria-labelledby="tabelLabel">
//                <thead>
//                    <tr>
//                        <th>Date</th>
//                        <th>Temp. (C)</th>
//                        <th>Temp. (F)</th>
//                        <th>Summary</th>
//                    </tr>
//                </thead>
//                <tbody>
//                    {forecasts.map(forecast =>
//                        <tr key={forecast.date}>
//                            <td>{forecast.date}</td>
//                            <td>{forecast.temperatureC}</td>
//                            <td>{forecast.temperatureF}</td>
//                            <td>{forecast.summary}</td>
//                        </tr>
//                    )}
//                </tbody>
//            </table>
//        );
//    }

//    render() {
//        let contents = this.state.loading
//            ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
//            : App.renderForecastsTable(this.state.forecasts);

//        return (
//            <div>
//                <h1 id="tabelLabel" >Weather forecast</h1>
//                <p>This component demonstrates fetching data from the server.</p>
//                {contents}
//            </div>
//        );
//    }

//    async populateWeatherData() {
//        const response = await fetch('weatherforecast');
//        const data = await response.json();
//        this.setState({ forecasts: data, loading: false });
//    }
//}


import React from "react";
import { useSelector, useDispatch } from "react-redux";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Home from "./components/Home";
import NotFound from "./components/NotFound";
import Profilecard from "./components/Profilecard";
import Todoslist from "./components/Todoslist";
import Newtodo from "./components/Newtodo";
import Navbar from "./components/Navbar";
import Todo from "./components/Todo";
import Login from "./components/Login";
function App() {
    return (
        <Router>
            <Navbar />
            <Routes>
                
                <Route path="*" element={<NotFound />} />
                <Route path="/" element={<Home />} />
                <Route path="/profile" element={<Profilecard />} />
                <Route path="/todos" element={<Todoslist />} />
                <Route path="/newtodo" element={<Newtodo />} />
                <Route path="/todos/:id" element={<Todo />} />
            </Routes>
        </Router>
    );
}

export default App;