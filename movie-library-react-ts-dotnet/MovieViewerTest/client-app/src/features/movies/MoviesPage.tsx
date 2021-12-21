import { useState } from "react";
import Modal from "react-bootstrap/Modal";
import { MovieSearch } from "features/movieSearch";
import { IMovieBase } from "common/types";
import { useToggle } from "common/hooks";
import { Spinner } from "common/components";
import { useSearchResult } from "./useSearchResult";
import { MovieDetailsModal } from "./MovieDetailsModal";
import { MovieList } from "./MovieList";
import styles from "./MoviesPage.module.css";

export const MoviesPage = () => {
  const { foundMoviesModel, searchQuery, isLoading, isIdle, isRejected, isResolved } = useSearchResult();
  const [selectedMovie, setSelectedMovie] = useState<IMovieBase>();
  const {
    value: isMovieDetailsOpen,
    show: openMovieDetails,
    hide: closeMovieDetails,
  } = useToggle();

  const selectMovie = (movie: IMovieBase) => {
    setSelectedMovie(movie);
    openMovieDetails();
  };

  const renderContent = () => {
    if (isIdle) {
      return <h5>Start searching right now. 🔍</h5>;
    }

    if (isLoading) {
      return <Spinner />;
    }

    if (isRejected) {
      return <h5>Ooops! Something went wrong. 😞</h5>;
    }

    if (isResolved && !foundMoviesModel.movies.length) {
      return <h5>{searchQuery} not found. 😳</h5>;
    }

    return <MovieList movies={foundMoviesModel.movies} onClick={(movie: IMovieBase) => selectMovie(movie)} />;
  };

  return (
    <>
      <div className={styles.moviesPage}>
        <MovieSearch initialSearchQuery={searchQuery} />
        <div className="row">
          <div className="col-md-6">
            <h4>Movie</h4>
            {renderContent()}
          </div>
        </div>
      </div>
      <Modal show={isMovieDetailsOpen} onHide={closeMovieDetails}>
        <Modal.Header closeButton>
          <Modal.Title>Movie Details</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <MovieDetailsModal imdbID={selectedMovie?.imdbID} queryId={foundMoviesModel.queryId} />
        </Modal.Body>
      </Modal>
    </>
  );
};
