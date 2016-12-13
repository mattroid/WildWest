import { createSelector } from 'reselect';

/**
 * Direct selector to the gameBoard state domain
 */
const selectGameBoardDomain = () => (state) => state.get('gameBoard');

/**
 * Other specific selectors
 */


/**
 * Default selector used by GameBoard
 */

const selectGameBoard = () => createSelector(
  selectGameBoardDomain(),
  (substate) => substate.toJS()
);

export default selectGameBoard;
export {
  selectGameBoardDomain,
};
