import React from 'react';
import { TouchableOpacity, StyleSheet, Text, View, Image } from 'react-native';
import PropTypes from 'prop-types';

const MovieItem = props => (
  <TouchableOpacity onPress={() => { //console.log(props); 
    props.onSelectMovie(props);}}>
  <View style={{flex: 1, flexDirection: 'row', padding: 10}}>
    <Image style={{width: 50, height: 50}} source={{uri: props.Poster}} />
    <View style={{flex: 1, flexDirection: 'column', paddingLeft: 20}}>
      <Text style={{fontWeight: 'bold'}}>{props.Title}</Text>
      <Text>{props.Year} ({props.Type})</Text>
    </View>
  </View>
  </TouchableOpacity>
);

MovieItem.propTypes = {
  Poster: PropTypes.string,
  Title: PropTypes.string,
  Year: PropTypes.string,
  Type: PropTypes.string,
  imdbID: PropTypes.string,
};

export default MovieItem;
