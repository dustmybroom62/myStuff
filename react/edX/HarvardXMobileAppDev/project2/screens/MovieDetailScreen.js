import React from 'react';
import { Text, ScrollView, View, Image } from 'react-native';
import {movie} from '../mockData'
import MovieRating from '../MovieRating'
export default class MovieDetailScreen extends React.Component {
  static navigationOptions = ({ navigation }) => {
    const movieId = navigation.getParam('imdbId');
    console.log('movieId: ' + movieId);

    return {
      headerTitle: navigation.getParam('Title'),
    };
  };

  state = {
    rating: movie.Rated,
    runtime: movie.Runtime,
    plot: movie.Plot,
    ratings: [...movie.Ratings]
  }

  render() {
    return (
      <ScrollView style={{flex: 1}}>
        <View style={{flexDirection: 'column'}}>
          <Image style={{width: '100%', height: 350}} source={{uri: this.props.navigation.getParam('Poster')}} />
          <Text style={{padding: 4, fontSize: 24, fontWeight: 'bold'}} >{this.props.navigation.getParam('Title')}              </Text>
          <Text style={{padding: 4}} >{this.state.rating}, {this.state.runtime}</Text>
          <Text style={{padding: 4, fontStyle: 'italic'}} >{this.state.plot}</Text>
          <View style={{padding: 4}}>
          {this.state.ratings.map(rating => (
            <View style={{padding: 2}}>
              <MovieRating source={rating.Source} value={rating.Value} />
            </View>
          ))}
          </View>
        </View>
      </ScrollView>
    );
  }
}
