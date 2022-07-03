import React from 'react';
import '../../styles/App.css';
import { IApplicationConfiguration, ILogger, IMathWebApi, LogLevel } from '../../types';

export type AppProps = {
  configuration: IApplicationConfiguration
  mathWebApi: IMathWebApi
  logger: ILogger
}
export type AppState = {
  equation: string
  error: string
  result: string
}

export class App extends React.Component<AppProps, AppState> {
  private readonly configuration: IApplicationConfiguration;
  private readonly mathWebApi: IMathWebApi;
  private readonly logger: ILogger;

  constructor(props: AppProps) {
    super(props);
    this.configuration = props.configuration;
    this.mathWebApi = props.mathWebApi;
    this.logger = props.logger;
    this.state = {
      equation: '',
      error: '',
      result: ''
    };
  }

  private onChangeHandler = (e: any) => {
    this.setState({
      error: '',
      equation: e.target.value,
      result: ''
    });
  }

  private onClickHandler = async (e: any) => {
    if (!this.state.equation) {
      this.setState({
        error: 'Equation empty!'
      });
      return;
    }
    try {
      const result = await this.mathWebApi.calculate(this.state.equation);
      this.setState({
        result: result.resultAsString
      });
    } catch (err) {
      const error = `MathWebAPI: Error calculating equation for ${this.state.equation}`;
      this.setState({
        error
      });
      this.logger.Log(error, LogLevel.Error);
    }
  }

  private clearState = async () => {
    await new Promise((res, rej) => {
      setTimeout(() => {
        this.setState({
          error: '',
          result: '',
          equation: ''
        });
        res(this.state);
      });
    });
  }

  private renderResult() {
    const shouldRenderResult = this.state.equation.length && this.state.result.length;
    return (
      shouldRenderResult ?
      <div id="calculation-result">
        {this.state.equation}={this.state.result}
      </div>
      : <></>
    )
  }

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <p>
            React Accurate Calculator
          </p>
          <p>
            <input type="text" onChange={this.onChangeHandler} placeholder="Input equation" value={this.state.equation} />
          </p>
          <p>
            <button onClick={this.onClickHandler}>Calculate</button>
          </p>
          <p>
            <button onClick={this.clearState}>Clear</button>
          </p>
          <p>
            {this.state.error.length ? this.state.error : this.renderResult()}
          </p>
        </header>
      </div>
    );
  }
}