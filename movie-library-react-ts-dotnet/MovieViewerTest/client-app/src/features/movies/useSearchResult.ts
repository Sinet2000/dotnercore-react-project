import { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { Routes } from "app/routes";
import { omdbAPI } from "api/omdbAPI";
import { IFoundMovieByTitleModel } from "common/types";
import { useURLSearchQuery } from "common/hooks";

type Status = "idle" | "pending" | "resolved" | "rejected";

type State = {
  status: Status;
  foundMoviesModel: IFoundMovieByTitleModel;
  error?: string | null;
};

export const useSearchResult = () => {
  const history = useHistory();
  const urlSearchQuery = useURLSearchQuery(Routes.Movies);
  const [{ status, foundMoviesModel }, setState] = useState<State>({
    status: "idle",
    foundMoviesModel: <IFoundMovieByTitleModel>{},
    error: null,
  });

  useEffect(() => {
    if (!urlSearchQuery) {
      history.push(Routes.Movies);
      return;
    }

    setState({ status: "pending", foundMoviesModel: <IFoundMovieByTitleModel>{} });
    omdbAPI
      .getByTitle(urlSearchQuery)
      .then((data) => {
        setState({ status: "resolved", foundMoviesModel: data });
      })
      .catch((error) => {
        setState({
          status: "rejected",
          foundMoviesModel: <IFoundMovieByTitleModel>{},
          error: error.message ?? "Something went wrong",
        });
      });
  }, [urlSearchQuery, history]);

  return {
    foundMoviesModel,
    searchQuery: urlSearchQuery,
    isIdle: status === "idle",
    isLoading: status === "pending",
    isResolved: status === "resolved",
    isRejected: status === "rejected",
  };
};
