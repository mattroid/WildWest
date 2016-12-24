import selectGameList from '../selectors';
import { fromJS } from 'immutable';
import expect from 'expect';


describe('selectGame', () => {
  const selector = selectGameList();
  it('select the game state', () => {
    const gameListState = fromJS({
      gameId: 1,
    });
    const mockedState = fromJS({
      gameList: gameListState,
    });
    expect(selector(mockedState).gameId).toEqual(1);
  });
});
