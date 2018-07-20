import React from 'react';
import SetKeyForm from '../SetKeyForm';

export default class SetKeyScreen extends React.Component {
  static navigationOptions = {
    headerTitle: 'Set API Key',
  };

  handleSubmit = formState => {
    this.props.screenProps.setApiKey(formState.apikey);
    this.props.navigation.pop();
  };

  render() {
    return <SetKeyForm onSubmit={this.handleSubmit} />;
  }
}
