const mapMovie = movie => ({
  Poster: movie.Poster,
  Title: movie.Title,
  Year: movie.Year,
  Type: movie.Type,
  imdbID: movie.imdbID
})

export const apiSettings = {apikey: ''};

const baseUrl = 'https://www.omdbapi.com/';

export const fetchMovies = async (search) => {
  //console.log('apiSettings.apikey: ' + apiSettings.apikey);
  const url = `${baseUrl}?apikey=${apiSettings.apikey}&s=${search}`;
  const response = await fetch(url);
  //console.log(response);
  const {Search} = await response.json();
  //console.log('results: ' + Search)
  if (Search) {
    return Search.map(mapMovie);
  } else {
    return [];
  }
}

export const fetchMovieDetail = async (movieId) => {
  const url = `${baseUrl}?apikey=${apiSettings.apikey}&i=${movieId}`;
  const response = await fetch(url);
  //console.log('fetchMovieDetail response: ' + response);
  const results = await response.json();
  //console.log('fetchMovieDetail results:' + JSON.stringify(results));
  return results;
}
