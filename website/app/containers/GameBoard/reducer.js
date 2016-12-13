/*
 *
 * GameBoard reducer
 *
 */

import { fromJS } from 'immutable';
import {
  DEFAULT_ACTION,
  JOIN_GAME,
} from './constants';

const initialState = fromJS({});

function gameBoardReducer(state = initialState, action) {
  switch (action.type) {
    case JOIN_GAME:
      gameJoined(state);
      return state;
    case DEFAULT_ACTION:
      return state;
    default:
      return state;
  }
}

export default gameBoardReducer;
