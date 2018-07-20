import React from 'react';
import {
  Button,
  KeyboardAvoidingView,
  StyleSheet,
  TextInput,
  View,
} from 'react-native';

export default class SetKeyForm extends React.Component {
  state = {
    apikey: '',
    isFormValid: false,
  };

  componentDidUpdate(prevProps, prevState) {
    if (
      this.state.apikey !== prevState.apikey
    ) {
      this.validateForm();
    }
  }

  getHandler = key => val => {
    this.setState({ [key]: val });
  };

  validateForm = () => {
    //console.log(this.state);
    if (
      this.state.apikey
    ) {
      this.setState({ isFormValid: true });
    } else {
      this.setState({ isFormValid: false });
    }
  };

  handleSubmit = () => {
    this.props.onSubmit(this.state);
  };

  render() {
    return (
      <KeyboardAvoidingView behavior="padding" style={styles.container}>
        <TextInput
          style={styles.input}
          value={this.state.apikey}
          onChangeText={this.getHandler('apikey')}
          placeholder="API Key"
        />
        <Button
          title="Submit"
          onPress={this.handleSubmit}
          disabled={!this.state.isFormValid}
        />
      </KeyboardAvoidingView>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
  input: {
    borderWidth: 1,
    borderColor: 'black',
    minWidth: 100,
    marginTop: 20,
    marginHorizontal: 20,
    paddingHorizontal: 10,
    paddingVertical: 5,
    borderRadius: 3,
  },
});
