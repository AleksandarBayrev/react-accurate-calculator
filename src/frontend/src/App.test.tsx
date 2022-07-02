import renderer from 'react-test-renderer';
import { App } from './App';

describe('App UI Tests', () => {
  test('app snapshot', () => {
    const component = renderer.create(<App />).toJSON();
    expect(component).toMatchSnapshot();
  });
});
