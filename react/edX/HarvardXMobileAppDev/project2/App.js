
import React from 'react';
import {TouchableOpacity, View, ScrollView, Button, Image, Text, TextInput, StyleSheet} from 'react-native'
import {search} from './mockData'
import MovieItem from './MovieItem'
import {Constants} from 'expo'
import {
  createStackNavigator,
} from "react-navigation";

import MovieListScreen from './screens/MovieListScreen'
import MovieDetailScreen from './screens/MovieDetailScreen'
import SetKeyScreen from './screens/SetKeyScreen'

const AppNavigator = createStackNavigator(
  {
    MovieList: MovieListScreen,
    MovieDetail: MovieDetailScreen,
    SetKey: SetKeyScreen
  },
  {
    initialRouteName: "MovieList",
    navigationOptions: {
      headerStyle: {
        backgroundColor: "#fff"
      }
    }
  }
);

const _settings = {apikey: ''};

export default class App extends React.Component {
  state = {
    movies: [...search.Search]
  };

  setApiKey = apikey => {
    console.log(apikey);
    _settings.apikey = apikey;
    this.setState(prevState => ({
      apikey: apikey
    }));
  };

  render() {
    return (
      <AppNavigator
        screenProps={{
          movies: [...this.state.movies],
          setApiKey: this.setApiKey
        }}
      />
    );
  }
}
