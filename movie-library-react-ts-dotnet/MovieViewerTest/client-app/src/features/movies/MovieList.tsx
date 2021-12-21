import { IMovieBase } from "common/types";
import { MovieCard } from "./MovieCard";

type Props = {
  movies: Array<IMovieBase>;
  onClick: (movie: IMovieBase) => void;
};

export const MovieList = ({ movies, onClick }: Props) => {
  return (
    <div className="row row-cols-1">
      {movies.map((movie: IMovieBase, index) => {
        return (
          <MovieCard key={index} movie={movie} onClick={() => onClick(movie)} />
        );
      })}
    </div>
  );
};
