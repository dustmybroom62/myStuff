import React from 'react';
import { Text, ScrollView, View, Image } from 'react-native';
import MovieRating from '../MovieRating'
export default class MovieDetailScreen extends React.Component {
  static navigationOptions = ({ navigation }) => {
    //const movieId = navigation.getParam('imdbID');
    //console.log('movieId: ' + movieId);

    return {
      headerTitle: navigation.getParam('Title')
    };
  };

  render() {
    let movie = this.props.navigation.getParam('detail');
    //console.log('movieDetail.render(): ' + movie);
    return (
      <ScrollView style={{flex: 1}}>
        <View style={{flexDirection: 'column', padding: 4}}>
          <Image style={{width: '100%', height: 350}} source={{uri: this.props.navigation.getParam('Poster')}} />
          <Text style={{padding: 4, fontSize: 24, fontWeight: 'bold'}} >{this.props.navigation.getParam('Title')}</Text>
          <Text style={{padding: 4}} >{movie.Rated}, {movie.Runtime}</Text>
          <Text style={{padding: 4, fontStyle: 'italic'}} >{movie.Plot}</Text>
          <View style={{padding: 4}}>
          {movie.Ratings.map(rating => (
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
