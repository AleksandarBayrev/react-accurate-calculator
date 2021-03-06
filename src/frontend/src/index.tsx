import React from 'react';
import ReactDOM from 'react-dom/client';
import './styles/index.css';
import { App } from './components/App';
import _ from 'lodash';
import reportWebVitals from './reportWebVitals';
import { IApplicationConfiguration, ILogger, UpdatedWindow } from './types';
import { Configuration } from './constants/Configuration';
import { Logger } from './utils/Logger';
import { MathWebApi } from './services/MathWebApi';

const updatedWindow: UpdatedWindow = window as any as UpdatedWindow;
const logger: ILogger = new Logger("ReactAccurateCalculator");
const mathApiLogger: ILogger = new Logger("MathWebApi");

updatedWindow.RenderCalculator = (divId: string, configuration: IApplicationConfiguration | undefined) => {
  const finalAppConfiguration: IApplicationConfiguration = _.merge({}, Configuration, configuration);
  logger.Log(`Rendering ReactAccurateCalculator to div ${divId}`);
  logger.Log(`App configuration: ${JSON.stringify(finalAppConfiguration)}`);
  const root = ReactDOM.createRoot(
    document.getElementById(divId) as HTMLElement
  );
  root.render(
    <React.StrictMode>
      <App configuration={finalAppConfiguration} mathWebApi={new MathWebApi(finalAppConfiguration.apiUrl, mathApiLogger)} logger={logger} />
    </React.StrictMode>
  );
}

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
