import React, { Component } from 'react';

export default class AlecuGrid extends Component {

    tdClick = async () => {

        var alecuMoves = [];

        var inputs = document.getElementsByTagName('input');

        for (var i = 0; i < inputs.length; i++) {
            alecuMoves.push(+inputs[i].value);
        }

        var model = JSON.stringify({ AlecuMoves: alecuMoves });

        const settings = {
            method: 'POST',
            headers: {
                Accept: 'application/json',
                'Content-Type': 'application/json'
            },
            body: model
        };
        
        const api_call = await fetch("https://localhost:44315/Alecu/CheckIfCorrect", settings)
            .then(response => response.json())
            .then(json => {
                return json;
            })
            .catch(e => {
                return e;
            });

        if (api_call) {

            var contor = 0;
            var isWinner = 0;

            alecuMoves.forEach(function (value) {
                if (parseInt(value, 10) !== parseInt(0, 10)) {
                    isWinner++;
                } else {
                    contor++;
                }
                if (contor === 4 && isWinner === 8) {
                    document.getElementById("winnerDiv").innerHTML = "UUooa! We have a winner!";
                }
            });

        } else {
            alert("The inputed char is not correct, please change the number or the neighbors!");
        }
    };


    render() {
        return (

            <table id="containerTable" name="containerTable" className="myTable">
                <tbody>
                    <tr id="row1" name="row1">
                        <td><input type="text" onKeyUp={this.tdClick} /></td>
                        <td id="cell2" name="cell2" className="td"><input type="text" onKeyUp={this.tdClick} /></td>
                        <td id="cell3" name="cell3"><input type="text" onKeyUp={this.tdClick} /></td>
                        <td id="cell4" name="cell4"><input type="text" onKeyUp={this.tdClick} /></td>
                    </tr>
                    <tr id="row2" name="row2">
                        <td id="cell5" name="cell5"><input type="text" onKeyUp={this.tdClick} /></td>
                        <td id="cell6" name="cell6"><input type="text" onKeyUp={this.tdClick} /></td>
                        <td id="cell7" name="cell7"><input type="text" onKeyUp={this.tdClick} /></td>
                        <td id="cell8" name="cell8"><input type="text" onKeyUp={this.tdClick} /></td>
                    </tr>
                    <tr id="row3" name="row3">
                        <td ><input type="text" onKeyUp={this.tdClick} /></td>
                        <td ><input type="text" onKeyUp={this.tdClick} /></td>
                        <td ><input type="text" onKeyUp={this.tdClick} /></td>
                        <td ><input type="text" /></td>
                    </tr>
                </tbody>
            </table>

        );
    }
}