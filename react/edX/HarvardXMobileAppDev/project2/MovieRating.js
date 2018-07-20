import React from 'react';
import { Text, View } from 'react-native';

export default class MovieRating extends React.Component {
  constructor(props) {
    super(props)
    let pct = null;
    let color = null;
    let val = 0;
    if ( 0 > props.value.indexOf('%')) {
      val = Math.floor(eval(props.value) * 100);
    } else {
      val = Math.floor(parseInt(props.value));
    }
    pct = val + '%';

    if (val > 66) {
      color = 'green';
    } else if (val > 33) {
      color = 'yellow';
    } else {
      color = 'red';
    }
    this.state = {
      source: props.source,
      pct: pct,
      color: color
    }
  }

  render() {
    return (
      <View style={{flexDirection: 'column'}}>
        <Text>{this.state.source}    ({this.props.value})</Text>
        <View style={{paddingTop: 10, paddingBottom: 10}}>
          <View style={{width: this.state.pct, height: 20, backgroundColor: this.state.color}} />
        </View>
      </View>
    );
  }
  
}
