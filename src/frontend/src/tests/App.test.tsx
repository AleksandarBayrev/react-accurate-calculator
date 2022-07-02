import renderer from 'react-test-renderer';
import { App } from '../components/App';
import { Configuration } from '../constants/Configuration';
import { MathWebApi } from '../services/MathWebApi';
import { Logger } from '../utils/Logger';

describe('App UI Tests', () => {
  test('app snapshot', () => {
    const component = renderer.create(<App configuration={Configuration} mathWebApi={new MathWebApi(Configuration.apiUrl, new Logger("MathWebApi"))} logger={new Logger("App")} />).toJSON();
    expect(component).toMatchSnapshot();
  });
});
