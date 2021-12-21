import { IMovieBase } from "common/types";
import { SecondaryText } from "common/components";

type Props = {
  movie: IMovieBase;
  onClick: () => void;
};

export const MovieCard = ({ movie, onClick }: Props) => {
  return (
    <div className="col mb-4">
      <div className="card">
        <img
          src={movie.poster}
          className="card-img-top"
          alt={`Poster of ${movie.title} movie`}
        />
        <div className="card-body">
          <h5 className="card-title">{movie.title}</h5>
          <SecondaryText>{movie.year}</SecondaryText>
          <button className="btn btn-primary" onClick={onClick}>
            More Details
          </button>
        </div>
      </div>
    </div>
  );
};
