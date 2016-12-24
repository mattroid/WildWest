import expect from 'expect';
import gameListReducer from '../reducer';
import { fromJS } from 'immutable';
// import {
//   selectGame,
// } from '../actions';

describe('gameListReducer', () => {
  it('returns the initial state', () => {
    expect(gameListReducer(undefined, {})).toEqual(fromJS({}));
  });
});
