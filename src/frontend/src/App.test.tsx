import renderer from 'react-test-renderer';
import { App } from './App';
import { Configuration } from './Configuration';

describe('App UI Tests', () => {
  test('app snapshot', () => {
    const component = renderer.create(<App configuration={Configuration} />).toJSON();
    expect(component).toMatchSnapshot();
  });
});
