import React from 'react';
import './App.css';
import { IApplicationConfiguration } from './types';

export type AppProps = {
  configuration: IApplicationConfiguration
}
export type AppState = {}

export class App extends React.Component<AppProps, AppState> {
  private readonly configuration: IApplicationConfiguration;
  constructor(props: AppProps) {
    super(props);
    this.configuration = props.configuration;
  }
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