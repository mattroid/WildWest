/**
*
* Player
*
*/

import React from 'react';

import { FormattedMessage } from 'react-intl';
import messages from './messages';


function Player() {
  return (
    <div>
      <FormattedMessage {...messages.header} />
    </div>
  );
}

export default Player;
