import { GameList } from '../index';
import { IntlProvider } from 'react-intl';
import expect from 'expect';
import { mount } from 'enzyme';
import React from 'react';

describe('<GameList />', () => {
  it('should show a list of games', () => {
    const renderedComponent = mount(
      <IntlProvider locale="en">
        <GameList />
      </IntlProvider>
    );
    expect(
      renderedComponent
        .text()
        .indexOf('game1')
    ).toBeGreaterThan(-1);
  });
});
