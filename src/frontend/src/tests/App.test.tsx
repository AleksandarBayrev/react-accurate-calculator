import renderer from 'react-test-renderer';
import { App } from '../components/App';
import { Configuration } from '../constants/Configuration';

describe('App UI Tests', () => {
  test('app snapshot', () => {
    const component = renderer.create(<App configuration={Configuration} />).toJSON();
    expect(component).toMatchSnapshot();
  });
});
