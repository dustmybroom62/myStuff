import React from 'react';
import { TextInput, Text, Button, View, StyleSheet } from 'react-native';

import FlatListMovies from '../FlatListMovies';

export default class MovieListScreen extends React.Component {
  static navigationOptions = ({ navigation }) => {
    return {
      headerTitle: 'Home',
      headerRight: (
        <Button
          title="Key"
          onPress={() => navigation.push('SetKey')}
          color="#a41034"
        />
      ),
    };
  };

  state = {
    showMovies: true,
  };

  searchChange = (search) => {
    this.setState({search});
  };

  handleSelectMovie = movie => {
    console.log('in handleSelectMovie: ' + movie)
    this.props.navigation.push('MovieDetail', movie);
  };

  render() {
    return (
      <View style={styles.container}>
        <TextInput style={{height: 40, width: '100%'}}
          placeholder="Search"
          onChangeText={this.searchChange}
          value={this.state.search}
        />
        {!this.state.showMovies && <Text style={{padding: 4}}>No results</Text>}
        {this.state.showMovies && (
          <FlatListMovies
            movies={this.props.screenProps.movies}
            onSelectMovie={this.handleSelectMovie}
          />
        )}
      </View>
    );
  }
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
  },
});
