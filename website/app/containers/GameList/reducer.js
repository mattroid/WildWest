/*
 *
 * GameList reducer
 *
 */

import { fromJS } from 'immutable';
import {
  SELECT_GAME,
} from './constants';

const initialState = fromJS({});

function gameListReducer(state = initialState, action) {
  switch (action.type) {
    case SELECT_GAME:
      return state;
    default:
      return state;
  }
}

export default gameListReducer;
