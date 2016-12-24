import expect from 'expect';
import {
  selectGame,
} from '../actions';
import {
  SELECT_GAME,
} from '../constants';

describe('GameList actions', () => {
  describe('Select Game Action', () => {
    it('has a type of SELECT_GAME', () => {
      const expected = {
        gameId: 1,
        type: SELECT_GAME,
      };
      expect(selectGame(1)).toEqual(expected);
    });
  });
});
