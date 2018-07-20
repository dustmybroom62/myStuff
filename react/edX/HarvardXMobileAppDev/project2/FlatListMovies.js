import React from 'react';
import { FlatList } from 'react-native';
import PropTypes from 'prop-types';

import MovieItem from './MovieItem';

const FlatListMovies = props => {
  console.log('props2: ' + props);
  return (
  <FlatList
    keyExtractor={item => item.imdbID}
    renderItem={({ item }) => <MovieItem {...item} onSelectMovie={props.onSelectMovie} />}
    data={props.movies}
    />
  )
};

FlatListMovies.propTypes = {
  movies: PropTypes.array,
};

export default FlatListMovies;
