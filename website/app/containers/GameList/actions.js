/*
 *
 * GameList actions
 *
 */

import {
  SELECT_GAME,
} from './constants';
/**
 * chooses a game for the player to join
 *
 * @param  {gameId} name The ID of the game to join
 *
 * @return {object}    An action object with a type of SElECT_GAME
 */
export function selectGame(gameId) {
  return {
    type: SELECT_GAME,
    gameId,
  };
}
