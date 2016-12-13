/*
 *
 * GameBoard
 *
 */

import React from 'react';
import { connect } from 'react-redux';
import Helmet from 'react-helmet';
import selectGameBoard from './selectors';
import { FormattedMessage } from 'react-intl';
import messages from './messages';
import Player from '../../components/Player';

export class GameBoard extends React.Component { // eslint-disable-line react/prefer-stateless-function
  constructor(players){
    
  }
  render() {
    return (
      <div>
        <Helmet
          title="GameBoard"
          meta={[
            { name: 'description', content: 'Description of GameBoard' },
          ]}
        />
        <FormattedMessage {...messages.header} />
        {{ players.map(p => <Player {...p}></Player>) }}
      </div>
    );
  }
}

const mapStateToProps = selectGameBoard();

function mapDispatchToProps(dispatch) {
  return {
    dispatch,
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(GameBoard);
