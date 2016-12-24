/*
 *
 * GameList
 *
 */

import React from 'react';
import { connect } from 'react-redux';
import selectGameList from './selectors';
import { FormattedMessage } from 'react-intl';
import List from 'components/List';
import ListItem from 'components/ListItem';
import messages from './messages';

export class GameList extends React.PureComponent { // eslint-disable-line react/prefer-stateless-function
  render() {
    const games = ['game1'];
    return (
      <div>
        <FormattedMessage {...messages.header} />
        <List items={games} component={ListItem}></List>
      </div>
    );
  }
}

const mapStateToProps = selectGameList();

function mapDispatchToProps(dispatch) {
  return {
    dispatch,
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(GameList);
