import React from 'react';
import { TextInput, Text, Button, View, StyleSheet } from 'react-native';
import {fetchMovies, fetchMovieDetail} from '../api'
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
    showMovies: false,
  };

  searchChange = async (search) => {
    let movies = await fetchMovies(search);
    //console.log('movies: ' + movies);
    this.setState({
      search: search,
      movies: movies,
      showMovies: movies && 0 !== movies.length
    });

  };

  handleSelectMovie = async (movie) => {
    //console.log('in handleSelectMovie: ' + movie)
    let detail = await fetchMovieDetail(movie.imdbID);
    this.props.navigation.push('MovieDetail', {...movie, detail: detail});
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
            movies={this.state.movies}
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
