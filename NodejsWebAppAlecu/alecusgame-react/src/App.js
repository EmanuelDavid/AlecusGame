import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import AlecuGrid from "./Components/AlecuGrid";

export default class App extends Component {
    render() {
        return (
            <div className="App">
                <header className="App-header">
                    <img src={logo} className="App-logo" alt="logo" />
                    <h1 className="App-title">Alecu's Game - React UI</h1>
                </header>

                <AlecuGrid />
                <div id="winnerDiv" className="winnerDiv"></div>
            </div>
    );
    }
}

