import React from 'react';
import './App.css';

export type AppProps = {}
export type AppState = {}

export class App extends React.Component<AppProps, AppState> {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <p>
            React Accurate Calculator
          </p>
        </header>
      </div>
    );
  }
}