function moviesInfo(movies) {
    let movieData = [];

    movies.forEach(row => {
            if (row.includes("addMovie ")) {
                const name = row.split("addMovie ")[1];

                let movie = {
                    name
                };

                movieData.push(movie);
            } else if (row.includes("directedBy")) {
                const [movieName, director] = row.split(" directedBy ");

                for (const currMovie of movieData) {
                    if (currMovie.name === movieName)
                        currMovie["director"] = director;
                }
            } else if (row.includes("onDate")) {
                const [movieName, date] = row.split(" onDate ");

                for (const currMovie of movieData) {
                    if (currMovie.name === movieName)
                        currMovie["date"] = date;
                }
            }

        }
    )

    movieData.forEach(movie => {
        if (movie.name && movie.date && movie.director) {
            console.log(JSON.stringify(movie));
        }
    })
}
