import expect from 'expect';
import gameBoardReducer from '../reducer';
import { fromJS } from 'immutable';

describe('gameBoardReducer', () => {
  it('returns the initial state', () => {
    expect(gameBoardReducer(undefined, {})).toEqual(fromJS({}));
  });
});
