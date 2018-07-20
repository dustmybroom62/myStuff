import React from 'react';
import {View, Button, Text, TextInput, StyleSheet} from 'react-native'

const styles = StyleSheet.create({
  appContainer: {
    flex: 1,
  },
  countContainer: {
    alignItems: 'center',
    justifyContent: 'center',
  },
  count: {
    fontSize: 48,
  },
  textinput: {
    height: 40,
    width: 100,
    borderColor: 'black',
    borderWidth: 1,
    fontSize: 20
  },
  buttonRow: {flexDirection: 'row', justifyContent: 'space-between', padding: 10}
});

class Counter extends React.Component {
  constructor(props) {
    super(props)
    this.interval = null;
    this.state = {
      count: props.count,
    }
  }
  
  componentDidMount() {
    this.start();
  }

  get invalid () {
    if (this.props.count || 0 < this.props.count) {
      return false;
    } else {
      return true;
    }    
  }

  start = () => {
    if (this.invalid) return false;
    if (this.props.count || 0 < this.props.count) {
      this.interval = setInterval(this.decrement, 1000)
    }
    return true;
  }
  
  componentWillUnmount() {
    this.pause();
  }

  reset = () => {
    if (this.invalid) return false;
    this.setState({count: this.props.count});
    return true;
  }

  pause = () => {
    if (this.invalid) return false;
    if (this.interval) {
      clearInterval(this.interval);
      this.interval = null;
    }
    return true;
  }
  
  decrement = () => {
    console.log('decrement!')
    let curCount = this.state.count;
    if (0 >= curCount) {
      curCount = 0;
      this.pause();
      this.props.onDone();
    }
    if (0 < curCount) {
      curCount--;
    }
    this.setState({
      count: curCount,
    })
  }

  render() {
    return (
      <View style={styles.countContainer}>
      <Text style={styles.count}>{this.props.title} </Text>
      <Text style={styles.count}>{this.state.count} </Text>
      </View>
    )
  }
}

export default class App extends React.Component {
  constructor(props) {
    super(props)
    this.state = {
      showCounter: true,
      paused: true,
      workTime: 0,
      restTime: 0
    }
  }
  
  toggleCounter = () => {
    this.setState( prevState => { return {
      showCounter: !prevState.showCounter
      }
    })
  }

  pauseStart = () => {
    let p = this.state.paused;
    let r = false;
    if (p) {
      r = this._child.start();
    } else {
      r = this._child.pause();
    }
    if (!r) return;
    this.setState({
      paused: !p
    })
  }

  reset = () => {
    this._child.reset();
  }

  // this is a more concise version with the same functionality
  render() {
    return (
      <View style={[styles.appContainer ,styles.countContainer]}>
        <View style={{flexDirection: 'row', padding: 10}}>
          <Text style={{fontSize: 20, padding: 10}}>Work Time</Text>
          <TextInput style={styles.textinput}
            keyboardType={'numeric'}
            returnKeyType={'go'} selectTextOnFocus={true}
            value={this.state.workTime + ''}
           onChangeText={(t) => this.setState({workTime: t - 0})} />
        </View>
        <View style={{flexDirection: 'row'}}>
          <Text style={{fontSize: 20, padding: 10}}>Rest Time</Text>
          <TextInput style={styles.textinput}
            keyboardType={'numeric'}
            returnKeyType={'go'} selectTextOnFocus={true}
            value={this.state.restTime + ''}
           onChangeText={(t) => this.setState({restTime: t - 0})} />
        </View>
        <View style={styles.buttonRow}>
          <Button style={{padding: 5}} title={this.state.paused ? "Start" : "Pause"} onPress={this.pauseStart} />
          <Text>  </Text>
          <Button style={{padding: 5}} title="Reset" onPress={this.reset} />
        </View>
        {this.state.showCounter && <Counter count={this.state.workTime} title="Work Timer" onDone={this.toggleCounter} ref={(child) => {this._child = child}} />}
        {!this.state.showCounter && <Counter count={this.state.restTime} title="Rest Timer" onDone={this.toggleCounter} ref={(child) => {this._child = child}} />}
      </View>
    )
  }
}
