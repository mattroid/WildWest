import { createSelector } from 'reselect';

/**
 * Direct selector to the gameList state domain
 */
const selectGameListDomain = () => (state) => state.get('gameList');

/**
 * Other specific selectors
 */


/**
 * Default selector used by GameList
 */

const selectGameList = () => createSelector(
  selectGameListDomain(),
  (substate) => substate.toJS()
);

export default selectGameList;
export {
  selectGameListDomain,
};
