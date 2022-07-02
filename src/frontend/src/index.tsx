import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { App } from './App';
import reportWebVitals from './reportWebVitals';
import { IApplicationConfiguration, UpdatedWindow } from './types';
import { Configuration } from './Configuration';

const updatedWindow: UpdatedWindow = window as any as UpdatedWindow;

updatedWindow.RenderCalculator = (divId: string, configuration: IApplicationConfiguration) => {
  const root = ReactDOM.createRoot(
    document.getElementById(divId) as HTMLElement
  );
  root.render(
    <React.StrictMode>
      <App configuration={{...configuration, ...Configuration}} />
    </React.StrictMode>
  );
}

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
