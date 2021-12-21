import { useEffect, useState } from "react";
import { omdbAPI } from "api/omdbAPI";
import { IMovieModel, IRating } from "common/types";
import { Rating, Spinner } from "common/components";
import { MovieDetailsField } from "./MovieDetailsField";
import { fields } from "./fields";

type Props = {
  imdbID?: string | null;
  queryId?: number | null;
};

export const MovieDetailsModal = ({ imdbID, queryId }: Props) => {
  const [movie, setMovie] = useState<IMovieModel | null>(null);
  const [isLoading, setIsLoading] = useState<boolean>(false);

  useEffect(() => {
    if (!imdbID || !queryId) return;

    setIsLoading(true);
    omdbAPI
      .getByImdbID(imdbID, queryId)
      .then((data) => {
        setMovie(data);
        setIsLoading(false);
      })
      .catch((error) => {
        console.log(error);
      });
  }, [imdbID, queryId]);

  if (isLoading) {
    return <Spinner />;
  }

  if (!movie) {
    return <h1>Seems like something went wrong. 😞</h1>;
  }

  return (
    <div className="card">
      <img src={movie.poster} className="card-img-top" alt={`Poster of ${movie.title} movie`} />
      <div className="card-body">
        <h5 className="card-title">{movie.title}</h5>
        <div className="card-content-info mb-3">
          <div>
            {fields.map(({ label, field }) => {
              return <MovieDetailsField label={label} content={movie[field]} />;
            })}
          </div>
          {movie.ratings.map((rating: IRating) => {
            return <Rating rating={rating} />;
          })}
        </div>
      </div>
    </div>
  );
};
