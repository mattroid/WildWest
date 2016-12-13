/*
 *
 * GameBoard actions
 *
 */

import {
  DEFAULT_ACTION,
} from './constants';
export function joinGame() {
  return {
    type: JOIN_GAME,
  };
}
export function defaultAction() {
  return {
    type: DEFAULT_ACTION,
  };
}
